using System;
using System.Numerics;
using Donut.Geometry.Primitives;

namespace Donut.Geometry
{
    public class Frame
    {
        public Screen Screen { get; set; }
        public Vector3 CameraPosition { get; init; }
        public Vector3 ScreenCenter { get; set; }
        public char[,] Pixels { get; set; }
        private readonly double[,] _depthBuffer;
        public Vector3 Light { get; set; }

        public Frame(Screen screen, Vector3 cameraPosition)
        {
            Screen = screen;
            ScreenCenter = new(screen.Height / 2, screen.Width / 2, 0);
            CameraPosition = cameraPosition;
            Pixels = new char[screen.Width, screen.Height];
            _depthBuffer = new double[screen.Width, screen.Height];
            Light = CameraPosition;

            for (int i = 0; i < screen.Width; ++i)
            {
                for (int j = 0; j < screen.Height; ++j)
                {
                    Pixels[i, j] = ' ';
                    _depthBuffer[i, j] = double.MaxValue;
                }
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Screen.Width; ++i)
            {
                for (int j = 0; j < Screen.Height; ++j)
                {
                    Pixels[i, j] = ' ';
                    _depthBuffer[i, j] = double.MaxValue;
                }
            }
        }

        public void AddPolygons(Polygon[] polygons)
        {
            foreach (Polygon polygon in polygons)
            {
                AddPoints(polygon.Points);
            }
        }

        public void AddPoints(Point[] points)
        {
            foreach (Point point in points)
            {
                int x = (int)Math.Round(point.Position.X * Screen.ZDistanse / point.Position.Z) + (Screen.Width / 2);
                int y = (int)Math.Round(point.Position.Y * Screen.ZDistanse / point.Position.Z) + (Screen.Height / 2);

                double distance = Vector3.Distance(CameraPosition, point.Position);

                if (x >= 0 && x < Screen.Width && y >= 0 && y < Screen.Height && _depthBuffer[x, y] > distance)
                {
                    Pixels[x, y] = GetBrightness(Light, point);
                    _depthBuffer[x, y] = distance;
                }
            }
        }

        public void Render()
        {
            Console.Clear();
            for (int i = 0; i < Screen.Width; ++i)
            {
                for (int j = 0; j < Screen.Height; ++j)
                {
                    Console.Write(Pixels[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static char GetBrightness(Vector3 Light, Point point)
        {
            Vector3 lightToPoint = point.Position - Light;
            double angle = Math.Acos(Vector3.Dot(lightToPoint, point.Normal) / (lightToPoint.Length() * point.Normal.Length()));
            double brightness = 2 * 255 * angle / Math.PI;

            return brightness < 23
                ? '.'
                : brightness < 46
                ? ','
                : brightness < 69
                ? '-'
                : brightness < 92
                ? '~'
                : brightness < 115
                ? ':'
                : brightness < 138
                ? ':'
                : brightness < 161 ? '=' : brightness < 184 ? '!' : brightness < 207 ? '#' : brightness < 230 ? '$' : '@';
        }
    }
}
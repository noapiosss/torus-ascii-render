using System;
using System.Numerics;
using Donut.Geometry.Primitives;

namespace Donut.Geometry
{
    public class Frame
    {
        public int Height { get; init; }
        public int Width { get; init; }
        public int CameraDistance { get; init; }
        public char[,] Pixels { get; set; }
        private readonly double[,] _depthBuffer;
        public Vector3 Light { get; set; }

        public Frame(int height, int width, int cameraDistance)
        {
            Height = height;
            Width = width;
            CameraDistance = cameraDistance;
            Pixels = new char[width, height];
            _depthBuffer = new double[width, height];
            Light = new(0, 0, -CameraDistance);

            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    Pixels[i, j] = ' ';
                    _depthBuffer[i, j] = double.MaxValue;
                }
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
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
                int x = (int)Math.Round(point.Position.X * CameraDistance / (point.Position.Z + CameraDistance));
                int y = (int)Math.Round(point.Position.Y * CameraDistance / (point.Position.Z + CameraDistance));

                Vector3 lightToPoint = point.Position - Light;
                double angle = Math.Acos(Vector3.Dot(lightToPoint, point.Normal) / (lightToPoint.Length() * point.Normal.Length()));
                char color = GetColor(2 * 255 * angle / Math.PI);

                double distance = Math.Sqrt(Math.Pow(point.Position.X, 2) + Math.Pow(point.Position.Y, 2) + Math.Pow(point.Position.Z + CameraDistance, 2));

                if (x >= 0 && x < Width && y >= 0 && y < Height && _depthBuffer[x, y] > distance)
                {
                    Pixels[x, y] = color;
                    _depthBuffer[x, y] = distance;
                }
            }
        }

        public void Render()
        {
            Console.Clear();
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
                {
                    Console.Write(Pixels[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static char GetColor(double brightness)
        {
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
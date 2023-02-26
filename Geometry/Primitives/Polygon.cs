using System;
using System.Collections.Generic;
using System.Numerics;

namespace Donut.Geometry.Primitives
{
    public class Polygon
    {
        public Vector3 A { get; set; }
        public Vector3 B { get; set; }
        public Vector3 C { get; set; }
        public Point[] Points { get; set; }
        public Vector3 Normal { get; set; }
        public char Color { get; set; }

        public Polygon(Vector3 a, Vector3 b, Vector3 c, char color)
        {
            A = a;
            B = b;
            C = c;
            Color = color;

            CalculateNormal();
            GeneratePixels();
        }

        private void GeneratePixels()
        {
            Points = Array.Empty<Point>();
            List<Point> points = new();

            Line AB = new(A, B, Normal, Color);

            foreach (Point C1 in AB.Points)
            {
                Line CC1 = new(C, C1.Position, Normal, Color);
                points.AddRange(CC1.Points);
            }

            Points = points.ToArray();
        }

        private void CalculateNormal()
        {
            Vector3 direction = Vector3.Cross(B - A, C - A);
            Normal = Vector3.Normalize(direction);
        }

        public void RotateX(Vector3 pivot, float angle)
        {
            A = A.RotateX(pivot, angle);
            B = B.RotateX(pivot, angle);
            C = C.RotateX(pivot, angle);

            CalculateNormal();
            GeneratePixels();
        }

        public void RotateY(Vector3 pivot, float angle)
        {
            B = B.RotateY(pivot, angle);
            A = A.RotateY(pivot, angle);
            C = C.RotateY(pivot, angle);

            CalculateNormal();
            GeneratePixels();
        }

        public void RotateZ(Vector3 pivot, float angle)
        {
            A = A.RotateZ(pivot, angle);
            B = B.RotateZ(pivot, angle);
            C = C.RotateZ(pivot, angle);

            CalculateNormal();
            GeneratePixels();
        }
    }
}
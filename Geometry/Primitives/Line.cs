using System;
using System.Collections.Generic;
using System.Numerics;

namespace Donut.Geometry.Primitives
{
    public class Line
    {
        public Vector3 A { get; init; }
        public Vector3 B { get; init; }
        public char Color { get; set; }
        public Point[] Points { get; set; }

        public Line(Vector3 a, Vector3 b, Vector3 normal, char color)
        {
            A = a;
            B = b;
            Color = color;

            List<Point> points = new();
            for (float i = Math.Min(a.X, b.X); i < Math.Max(a.X, b.X); i += 0.5f)
            {
                points.Add(new(
                    i,
                    ((i - A.X) * (B.Y - A.Y) / (B.X - A.X)) + A.Y,
                    ((i - A.X) * (B.Z - A.Z) / (B.X - A.X)) + A.Z,
                    normal
                ));
            }

            for (float i = Math.Min(a.Y, b.Y); i < Math.Max(a.Y, b.Y); i += 0.5f)
            {
                points.Add(new(
                    ((i - A.Y) * (B.X - A.X) / (B.Y - A.Y)) + A.X,
                    i,
                    ((i - A.Y) * (B.Z - A.Z) / (B.Y - A.Y)) + A.Z,
                    normal
                ));
            }

            for (float i = Math.Min(a.Z, b.Z); i < Math.Max(a.Z, b.Z); i += 0.5f)
            {
                points.Add(new(
                    ((i - A.Z) * (B.X - A.X) / (B.Z - A.Z)) + A.X,
                    ((i - A.Z) * (B.Y - A.Y) / (B.Z - A.Z)) + A.Y,
                    i,
                    normal
                ));
            }

            Points = points.ToArray();
        }
    }
}
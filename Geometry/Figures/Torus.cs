using System;
using System.Collections.Generic;
using System.Numerics;
using Donut.Geometry.Primitives;

namespace Donut.Geometry.Figures
{
    public class Torus
    {
        public Vector3 Center { get; set; }
        public float Radius { get; set; }
        public float TubeRadius { get; set; }
        public Point[] Points { get; set; }

        public Torus(Vector3 center, float radius, float tubeRadius)
        {
            Center = center;
            Radius = radius;
            TubeRadius = tubeRadius;

            GeneratePoints();
        }

        private void GeneratePoints()
        {
            Points = Array.Empty<Point>();
            List<Point> points = new();

            for (float u = 0; u < Center.X + Radius; u += 0.05f)
            {
                for (float v = 0; v < Center.Y + Radius; v += 0.05f)
                {
                    points.Add(new(
                        x: (float)((Radius + (TubeRadius * Math.Cos(v))) * Math.Cos(u)) + Center.X,
                        y: (float)((Radius + (TubeRadius * Math.Cos(v))) * Math.Sin(u)) + Center.Y,
                        z: (float)(TubeRadius * Math.Sin(v)) + Center.Z,
                        normal: new((float)(Math.Cos(v) * Math.Cos(u)), (float)(Math.Cos(v) * Math.Sin(u)), (float)Math.Sin(v))));
                }
            }

            Points = points.ToArray();
        }

        public void RotateX(Vector3 pivot, float angle)
        {
            foreach (Point point in Points)
            {
                point.RotatePointX(pivot, angle);
            }
        }

        public void RotateY(Vector3 pivot, float angle)
        {
            foreach (Point point in Points)
            {
                point.RotatePointY(pivot, angle);
            }
        }

        public void RotateZ(Vector3 pivot, float angle)
        {
            foreach (Point point in Points)
            {
                point.RotatePointZ(pivot, angle);
            }
        }

        public void MoveZ(float distance)
        {
            Center = Center.MoveZ(distance);

            foreach (Point point in Points)
            {
                point.MoveZ(distance);
            }
        }
    }
}
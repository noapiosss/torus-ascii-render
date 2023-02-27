using System;
using System.Collections.Generic;
using System.Numerics;
using Donut.Geometry.Primitives;

namespace Donut.Geometry.Figures
{
    public class Cube
    {
        public Vector3 A1 { get; set; }
        public Vector3 B1 { get; set; }
        public Vector3 C1 { get; set; }
        public Vector3 D1 { get; set; }
        public Vector3 A2 { get; set; }
        public Vector3 B2 { get; set; }
        public Vector3 C2 { get; set; }
        public Vector3 D2 { get; set; }

        public Polygon[] Polygons { get; set; }

        public Cube(Vector3 a1, Vector3 c2)
        {
            A1 = new(a1.X, a1.Y, a1.Z);
            B1 = new(a1.X, a1.Y, c2.Z);
            C1 = new(c2.X, a1.Y, c2.Z);
            D1 = new(c2.X, a1.Y, a1.Z);
            A2 = new(a1.X, c2.Y, a1.Z);
            B2 = new(a1.X, c2.Y, c2.Z);
            C2 = new(c2.X, c2.Y, c2.Z);
            D2 = new(c2.X, c2.Y, a1.Z);

            GeneratePolygons();
        }

        private void GeneratePolygons()
        {
            Polygons = Array.Empty<Polygon>();
            List<Polygon> polygons = new()
            {
                new(B1, D1, A1),
                new(D1, B1, C1),

                new(D2, C2, B2),
                new(A2, D2, B2),

                new(B2, C2, B1),
                new(C2, C1, B1),

                new(C2, D1, C1),
                new(C2, D2, D1),

                new(D2, A1, D1),
                new(D2, A2, A1),

                new(B2, B1, A1),
                new(A2, B2, A1)
            };

            Polygons = polygons.ToArray();
        }

        public void RotateX(Vector3 pivot, float angle)
        {
            A1 = A1.RotateX(pivot, angle);
            B1 = B1.RotateX(pivot, angle);
            C1 = C1.RotateX(pivot, angle);
            D1 = D1.RotateX(pivot, angle);
            A2 = A2.RotateX(pivot, angle);
            B2 = B2.RotateX(pivot, angle);
            C2 = C2.RotateX(pivot, angle);
            D2 = D2.RotateX(pivot, angle);

            GeneratePolygons();
        }

        public void RotateY(Vector3 pivot, float angle)
        {
            A1 = A1.RotateY(pivot, angle);
            B1 = B1.RotateY(pivot, angle);
            C1 = C1.RotateY(pivot, angle);
            D1 = D1.RotateY(pivot, angle);
            A2 = A2.RotateY(pivot, angle);
            B2 = B2.RotateY(pivot, angle);
            C2 = C2.RotateY(pivot, angle);
            D2 = D2.RotateY(pivot, angle);

            GeneratePolygons();
        }

        public void RotateZ(Vector3 pivot, float angle)
        {
            A1 = A1.RotateZ(pivot, angle);
            B1 = B1.RotateZ(pivot, angle);
            C1 = C1.RotateZ(pivot, angle);
            D1 = D1.RotateZ(pivot, angle);
            A2 = A2.RotateZ(pivot, angle);
            B2 = B2.RotateZ(pivot, angle);
            C2 = C2.RotateZ(pivot, angle);
            D2 = D2.RotateZ(pivot, angle);

            GeneratePolygons();
        }
    }
}
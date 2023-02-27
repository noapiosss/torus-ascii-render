using System;
using System.Numerics;

namespace Donut.Geometry.Primitives
{
    public static class Vector3Extensions
    {
        public static Vector3 RotateX(this Vector3 vector, Vector3 pivot, float angle)
        {
            Matrix4x4 matrix = new(
                1, 0, 0, 0,
                0, (float)Math.Cos(angle), (float)-Math.Sin(angle), 0,
                0, (float)Math.Sin(angle), (float)Math.Cos(angle), 0,
                0, 0, 0, 0);

            return Vector3.Transform(vector - pivot, matrix) + pivot;
        }

        public static Vector3 RotateY(this Vector3 vector, Vector3 pivot, float angle)
        {
            Matrix4x4 matrix = new(
                (float)Math.Cos(angle), 0, (float)Math.Sin(angle), 0,
                0, 1, 0, 0,
                (float)-Math.Sin(angle), 0, (float)Math.Cos(angle), 0,
                0, 0, 0, 0);

            return Vector3.Transform(vector - pivot, matrix) + pivot;
        }

        public static Vector3 RotateZ(this Vector3 vector, Vector3 pivot, float angle)
        {
            Matrix4x4 matrix = new(
                (float)Math.Cos(angle), (float)-Math.Sin(angle), 0, 0,
                (float)Math.Sin(angle), (float)Math.Cos(angle), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 0);

            return Vector3.Transform(vector - pivot, matrix) + pivot;
        }

        public static Vector3 MoveZ(this Vector3 vector, float distance)
        {
            return new(vector.X, vector.Y, vector.Z + distance);
        }
    }
}
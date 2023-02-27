using System.Numerics;

namespace Donut.Geometry.Primitives
{
    public class Point
    {
        public Point(float x, float y, float z, Vector3 normal, char color = '@')
        {
            Position = new(x, y, z);
            Normal = normal;
            Color = color;
        }
        public Vector3 Position { get; set; }
        public Vector3 Normal { get; set; }
        public char Color { get; set; }
        public byte Brightness { get; set; }

        public void RotatePointX(Vector3 pivot, float angle)
        {
            Position = Position.RotateX(pivot, angle);
            Normal = Normal.RotateX(Vector3.Zero, angle);
        }

        public void RotatePointY(Vector3 pivot, float angle)
        {
            Position = Position.RotateY(pivot, angle);
            Normal = Normal.RotateX(Vector3.Zero, angle);
        }

        public void RotatePointZ(Vector3 pivot, float angle)
        {
            Position = Position.RotateZ(pivot, angle);
            Normal = Normal.RotateX(Vector3.Zero, angle);
        }

        public void MoveZ(float distance)
        {
            Position = Position.MoveZ(distance);
        }
    }
}
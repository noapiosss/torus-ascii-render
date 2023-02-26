namespace Donut.Geometry
{
    public class Screen
    {
        public int Height { get; init; }
        public int Width { get; init; }

        public Screen(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
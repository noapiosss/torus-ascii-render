namespace Donut.Geometry
{
    public class Screen
    {
        public int Height { get; init; }
        public int Width { get; init; }
        public double ZDistanse { get; set; }

        public Screen(int height, int width, double zDistanse)
        {
            Height = height;
            Width = width;
            ZDistanse = zDistanse;
        }
    }
}
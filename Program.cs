using System;
using System.Numerics;
using Donut.Geometry;
using Donut.Geometry.Figures;

Screen screen = new(100, 60);
Frame frame = new(screen.Height, screen.Width, 10000);

Vector3 center = new(30, 30, 20);
Torus torus = new(center, 15, 12);

frame.Light = new(center.X - 500, center.Y - 500, center.Z);

frame.AddPoints(torus.Points);
frame.Render();

while (true)
{
    ConsoleKeyInfo key = Console.ReadKey(true);

    if (key.Key == ConsoleKey.UpArrow)
    {
        torus.RotateY(center, -0.1f);
    }
    if (key.Key == ConsoleKey.DownArrow)
    {
        torus.RotateY(center, 0.1f);
    }
    if (key.Key == ConsoleKey.RightArrow)
    {
        torus.RotateX(center, -0.1f);
    }
    if (key.Key == ConsoleKey.LeftArrow)
    {
        torus.RotateX(center, 0.1f);
    }

    frame.Clear();
    frame.AddPoints(torus.Points);
    frame.Render();
}
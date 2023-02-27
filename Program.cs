using System;
using System.Numerics;
using Donut.Geometry;
using Donut.Geometry.Figures;

Screen screen = new(100, 60, 50);
Frame frame = new(screen, Vector3.Zero);

Vector3 torusCenter = new(0, 0, 100);
Torus torus = new(torusCenter, 25, 20);

frame.Light = new(torusCenter.X - 500, torusCenter.Y - 500, torusCenter.Z);

frame.AddPoints(torus.Points);
frame.Render();

while (true)
{
    ConsoleKeyInfo key = Console.ReadKey(true);

    if (key.Key == ConsoleKey.UpArrow)
    {
        torus.RotateY(torusCenter, -0.1f);
    }
    if (key.Key == ConsoleKey.DownArrow)
    {
        torus.RotateY(torusCenter, 0.1f);
    }
    if (key.Key == ConsoleKey.RightArrow)
    {
        torus.RotateX(torusCenter, -0.1f);
    }
    if (key.Key == ConsoleKey.LeftArrow)
    {
        torus.RotateX(torusCenter, 0.1f);
    }

    frame.Clear();
    frame.AddPoints(torus.Points);
    frame.Render();
}
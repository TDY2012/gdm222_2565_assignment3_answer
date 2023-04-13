using System;

class Program
{
    static void Main(string[] args)
    {
        Vector2 p1 = new Vector2
        (
            double.Parse(Console.ReadLine()),
            double.Parse(Console.ReadLine())
        );
        Vector2 p2 = new Vector2
        (
            double.Parse(Console.ReadLine()),
            double.Parse(Console.ReadLine())
        );
        Vector2 p3 = new Vector2
        (
            double.Parse(Console.ReadLine()),
            double.Parse(Console.ReadLine())
        );

        Vector2 midP1P2 = (p1 + p2)/2.0;
        Vector2 midP2P3 = (p2 + p3)/2.0;

        Console.WriteLine(midP1P2);
        Console.WriteLine(midP2P3);

        Line2 lineP1P2 = new Line2(p1, p2);
        Line2 lineP2P3 = new Line2(p2, p3);

        Console.WriteLine(lineP1P2);
        Console.WriteLine(lineP2P3);

        Line2 perpP1P2 = Line2.Perpendicular(lineP1P2, midP1P2);
        Line2 perpP2P3 = Line2.Perpendicular(lineP2P3, midP2P3);

        Console.WriteLine(perpP1P2);
        Console.WriteLine(perpP2P3);

        Vector2 c = Line2.Intersection(perpP1P2, perpP2P3);

        Console.WriteLine(c);

        double r = (p1 - c).Magnitude();

        Console.WriteLine(c.X);
        Console.WriteLine(c.Y);
        Console.WriteLine(r);
    }
}
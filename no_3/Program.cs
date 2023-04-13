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

        double r1 = double.Parse(Console.ReadLine());
        double r2 = double.Parse(Console.ReadLine());

        Circle2 c1 = new Circle2(p1, r1);
        Circle2 c2 = new Circle2(p2, r2);

        //  Compute the distance between both circle centers.
        Vector2 u = c2.C - c1.C;
        double d = u.Magnitude();

        //  If the distance is exactly equal to the sum of both
        //  circle radii, this is the case which both circle touches
        //  and yield one intersection.
        if(d == c1.R + c2.R)
        {
            Vector2 intersection = (c1.C + c2.C)/2;
            Console.WriteLine(intersection.X);
            Console.WriteLine(intersection.Y);
        }

        //  If the distance is less than the sum of both
        //  circle radii, this is the case which both circle intersects
        //  and yield two intersection.
        else if(d < c1.R + c2.R)
        {
            //  See https://mathworld.wolfram.com/Circle-CircleIntersection.html
            //  for more information.
            double s = ((c1.R * c1.R) - (c2.R * c2.R) + (d*d))/(2*d);

            double intersectionAngle = Math.Acos(s / c1.R);
            double offsetAngle = Math.Atan2(u.Y, u.X);

            Vector2 intersection1 =
                c1.C
                + new Vector2
                (
                    c1.R * Math.Cos(intersectionAngle + offsetAngle) ,
                    c1.R * Math.Sin(intersectionAngle + offsetAngle)
                );

            Vector2 intersection2 =
                c1.C
                + new Vector2
                (
                    c1.R * Math.Cos(-intersectionAngle + offsetAngle),
                    c1.R * Math.Sin(-intersectionAngle + offsetAngle)
                );

            Console.WriteLine(intersection1.X);
            Console.WriteLine(intersection1.Y);
            Console.WriteLine(intersection2.X);
            Console.WriteLine(intersection2.Y);
        }

        //  Otherwise, both circles just do not intersect. Just do nothing.
    }
}
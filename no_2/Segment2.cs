public class Segment2: Ray2
{
    public Segment2(Vector2 u, Vector2 v): base(u, v)
    {
        this.u = u;
        this.v = v;
    }

    //  Check if given line and segment is intersected.
    public static bool IsIntersected(Segment2 s, Line2 t)
    {
        Vector2 intersection = Line2.Intersection(t, s);
        return IsOn(s, intersection);
    }

    //  Check if given ray and segment is intersected.
    public static bool IsIntersected(Segment2 s, Ray2 t)
    {
        Vector2 intersection = Ray2.Intersection(t, s);
        Console.WriteLine("intersection = {0}", intersection);
        bool isOnRay = Ray2.IsOn(t, intersection);
        bool isOnSegment = IsOn(s, intersection);
        Console.WriteLine("isOnRay = {0}", isOnRay);
        Console.WriteLine("isOnSegment = {0}", isOnSegment);
        return Ray2.IsOn(t, intersection) && IsOn(s, intersection);
    }

    //  Check if given point lies on the segment.
    public static bool IsOn(Segment2 s, Vector2 p)
    {
        if(
            p.X >= Math.Min(s.U.X, s.V.X)
            && p.Y >= Math.Min(s.U.Y, s.V.Y)
            && p.X <= Math.Max(s.U.X, s.V.X)
            && p.Y <= Math.Max(s.U.Y, s.V.Y)
        )
        {
            if(double.IsInfinity(s.m))
            {
                return Math.Abs(s.X0 - p.X) < Segment2.EPSILON;
            }
            else
            {
                return Math.Abs((s.M*p.X) + s.Y0 - p.Y) < Segment2.EPSILON;
            }
        }
        else
        {
            return false;
        }
    }

    public override string ToString()
    {
        return string.Format("Segment2(m: {0}, x0: {1}, y0: {2}, u: {3}, v: {4})", this.m, this.x0, this.y0, this.u, this.v);
    }
}
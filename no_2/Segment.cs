public class Segment2: Line2
{
    //  The endpoints of the segment.
    protected Vector2 u;
    public Vector2 U
    {
        get { return this.u; }
    }
    protected Vector2 v;
    public Vector2 V
    {
        get { return this.v; }
    }

    public Segment2(Vector2 u, Vector2 v): base(u, v)
    {
        this.u = u;
        this.v = v;
    }

    //  Check if given line and segment is intersected.
    public static bool IsIntersected(Segment2 s, Line2 t)
    {
        Vector2 intersection = Line2.Intersection(s, t);
        return IsOn(s, intersection);
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
                return s.X0 == p.X;
            }
            else
            {
                return (s.M*p.X) + s.Y0 == p.Y;
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
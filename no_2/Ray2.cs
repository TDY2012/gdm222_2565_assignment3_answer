public class Ray2: Line2
{
    //  The endpoint and direction point of the ray.
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

    public Ray2(Vector2 u, Vector2 v): base(u, v)
    {
        this.u = u;
        this.v = v;
    }

    //  Check if given line and ray is intersected.
    public static bool IsIntersected(Ray2 r, Line2 t)
    {
        Vector2 intersection = Line2.Intersection(t, r);
        bool isOn = IsOn(r, intersection);
        return isOn;
    }

    //  Check if given point lies on the ray.
    public static bool IsOn(Ray2 r, Vector2 p)
    {
        Vector2 s = r.V - r.U;
        Vector2 t = p - r.U;

        return Math.Abs(((t.X*s.X) + (t.Y*s.Y))/(t.Magnitude() * s.Magnitude()) - 1) < Ray2.EPSILON;
    }

    public override string ToString()
    {
        return string.Format("Ray2(m: {0}, x0: {1}, y0: {2}, u: {3}, v: {4})", this.m, this.x0, this.y0, this.u, this.v);
    }
}
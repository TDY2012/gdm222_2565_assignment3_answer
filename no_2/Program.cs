using System;

class Program
{
    static void Main(string[] args)
    {
        List<Vector2> pointList = new List<Vector2>();

        Vector2 p;
        while(true)
        {
            p = new Vector2
            (
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine())
            );

            if(p.X == 0 && p.Y == 0)
            {
                break;
            }
            else
            {
                pointList.Add(p);
            }
        }

        Vector2 k = new Vector2
        (
            double.Parse(Console.ReadLine()),
            double.Parse(Console.ReadLine())
        );

        List<Segment2> segmentList = new List<Segment2>();
        for(int i=0; i<pointList.Count; i++)
        {
            Segment2 s = new Segment2(pointList[i], pointList[(i+1)%pointList.Count]);
            segmentList.Add(s);
        }

        //
        //  Here we use the raycasting algorithm with even-odd rule.
        //  See https://en.wikipedia.org/wiki/Point_in_polygon for more information.
        //

        //  Compute the check line slope so that it is not
        //  parallel with any segment.
        double maxSlope = segmentList[0].M;
        double nextMaxSlope = segmentList[0].M;
        for(int i=1; i<segmentList.Count; i++)
        {
            if(segmentList[i].M > maxSlope)
            {
                nextMaxSlope = maxSlope;
                maxSlope = segmentList[i].M;
            }
        }

        if(double.IsInfinity(maxSlope))
        {
            maxSlope = nextMaxSlope + Math.Sign(maxSlope);
        }

        Ray2 t = new Ray2(k, k + new Vector2(1, (maxSlope + nextMaxSlope)/2));

        int intersectionCount = 0;
        for(int i=0; i<segmentList.Count; i++)
        {
            //  If the given point lies exactly on the end point of current
            //  segment, skip it unless it will be checked twice.
            if(k.X == segmentList[i].V.X && k.Y == segmentList[i].V.Y)
            {
                continue;
            }

            //  Failed safe in case that the check line is parallel
            //  with current segment.
            bool isIntersected = Segment2.IsIntersected(segmentList[i], t);
            bool isOn = Segment2.IsOn(segmentList[i], k);
            
            if(isIntersected || isOn)
            {
                intersectionCount++;
            }
        }

        //  Apply the even-odd rule.
        if(intersectionCount % 2 == 0)
        {
            Console.WriteLine("Outside");
        }
        else
        {
            Console.WriteLine("Inside");
        }
    }
}
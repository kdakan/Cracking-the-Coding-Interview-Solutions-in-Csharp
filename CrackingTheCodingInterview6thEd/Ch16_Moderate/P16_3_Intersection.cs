using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch16_Moderate
{
    public class P16_3_Intersection
    {
        public static Point FindIntersectionPoint(Point start1, Point end1, Point start2, Point end2)
        {
            //6.      o       .
            //5.     o     .   
            //4.    o   .      
            //3.   o .         
            //2.  X->(3,2)            
            //1. o             
            //0.o..............
            // 0123456789012345
            //
            // y=x-1
            // y=(1/2)(x-3)+2
            // x-1 = (1/2)(x-3)+2
            // x - (1/2)x = -(3/2) + 2 + 1
            // x = 3, y = 2
            // this intersection point (x,y) should also be on both line segments
            // min(start1.x, end1.x) <= x <= max(start1.x, end1.x)
            // min(start1.y, end1.y) <= y <= max(start1.y, end1.y)
            // min(start2.x, end2.x) <= x <= max(start2.x, end2.x)
            // min(start2.y, end2.y) <= y <= max(start2.y, end2.y)

            //if both slopes are infinite, no intersection point
            if (end1.X == start1.X && end2.X == start2.X)
                return null;

            //y = ax + b => a: slope, b: y intercept
            double a1 = 0;
            double a2 = 0;
            if (end1.X != start1.X)
                a1 = (end1.Y - start1.Y) / (end1.X - start1.X);

            if (end2.X != start2.X)
                a2 = (end2.Y - start2.Y) / (end2.X - start2.X);

            double b1 = start1.Y - (start1.X * a1);
            double b2 = start2.Y - (start2.X * a2);

            //if only one of the slopes is infinite, intersection point is on x intercept of that line
            if (end1.X == start1.X)
            {
                var xIntercept1 = start1.X;
                //solve for y
                var intersectionY = a2 * xIntercept1 + b2;
                return checkIfIntersectionPointInsideBothSegments(new Point(xIntercept1, intersectionY), start1, end1, start2, end2);
            }

            if (end2.X == start2.X)
            {
                var xIntercept2 = start2.X;
                //solve for y
                var intersectionY = a1 * xIntercept2 + b1;
                return checkIfIntersectionPointInsideBothSegments(new Point(xIntercept2, intersectionY), start1, end1, start2, end2);
            }

            //same slope means either lines are parallel or they overlap, so no intersection point
            if (a1 == a2)
                return null;

            //y = a1x + b1
            //and
            //y = a2x + b2
            //solve for (x,y)
            //a1x + b1 = a2x + b2
            //(a1-a2)x = b2-b1
            //x = (b2-b1)/(a1-a2)
            double x = (b2 - b1) / (a1 - a2);
            double y = a1 * x + b1;

            // this intersection point (x,y) should also be on both segments
            return checkIfIntersectionPointInsideBothSegments(new Point(x, y), start1, end1, start2, end2);
        }

        private static Point checkIfIntersectionPointInsideBothSegments(Point intersectionPoint, Point start1, Point end1, Point start2, Point end2)
        {
            if (!intersectionPoint.IsInRectangle(start1, end1))
                return null;
            if (!intersectionPoint.IsInRectangle(start2, end2))
                return null;

            return intersectionPoint;
        }
    }

    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool IsInRectangle(Point start, Point end)
        {
            if (X < Math.Min(start.X, end.X))
                return false;
            if (X > Math.Max(start.X, end.X))
                return false;
            if (Y < Math.Min(start.Y, end.Y))
                return false;
            if (Y > Math.Max(start.Y, end.Y))
                return false;

            return true;
        }
    }
}

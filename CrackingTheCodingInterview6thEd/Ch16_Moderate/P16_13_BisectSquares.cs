using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CrackingTheCodingInterview6thEd.Ch16_Moderate
{
    public class P16_13_BisectSquares
    {
        public static LineSegment FindBisectorSegment(Square square1x, Square square2x)
        {
            //find line segment that passes through both squares and divides both in half
            //assume squares are parallel to the x axis
            //in order to do this it should pass through centers of both squares
            //8
            //7   o o o o o
            //6   x _     o
            //5   o   c _ o
            //4   o       x _       
            //3   o o o o o   x _ o o
            //2                 o c o
            //1                 o o o
            //0 1 2 3 4 5 6 7 8 9 0 1 2
            //
            // sidelength1: 5
            // sidelength2: 3
            // center1: (4,5)
            // center2: (10,2)
            // bisector slope: -0.5
            // bisector line: y=ax+b, a:slope, b:y-axis intercept
            // from (4,5) solve for b: 5 = -0.5 * 4 + b => b = 7
            // bisector segment can either start on topmost side or leftmost side
            // we can find out by solving for x,y on both sides
            // if it were on topmost, y=ax+b => 7 = -0.5 * x + 7 => x = 0, but x is not inside square
            // so it should be on leftmost, y=ax+b => y = -0.5 * 2 + 7 = 6
            // and the other end of segment is, y=ax+b => y = -0.5 * 11 + 7 = 1.5

            var topSquare = square1x;
            var bottomSquare = square2x;
            if (square2x.TopLeftCorner.Y > square1x.TopLeftCorner.Y)
            {
                topSquare = square2x;
                bottomSquare = square1x;
            }

            var center1 = topSquare.FindCenter();
            var center2 = bottomSquare.FindCenter();
            //bidector slope
            var a = (center2.Y - center1.Y) / (center2.X - center1.X);
            //bisector y-axis intercept
            var b = center1.Y - a * center1.X;
            //try topmost, y=ax+b, x=(y-b)/a
            double startingY = topSquare.TopLeftCorner.Y;
            double startingX = (startingY - b) / a;
            double endingY = 0;
            double endingX = 0;
            if (startingX >= topSquare.TopLeftCorner.X && startingX <= topSquare.TopLeftCorner.X + topSquare.SideLength)
            {
                endingY = bottomSquare.TopLeftCorner.Y - bottomSquare.SideLength;
                endingX = (endingY - b) / a;
            }
            else
            {
                startingX = topSquare.TopLeftCorner.X;
                startingY = a * startingX + b;
                endingX = bottomSquare.TopLeftCorner.X + bottomSquare.SideLength;
                endingY = a * endingX + b;
            }

            return new LineSegment(new Point(startingX, startingY), new Point(endingX, endingY));
        }

    }

    public class Square
    {
        public Point TopLeftCorner { get; set; }
        public double SideLength { get; set; }

        public Square(Point topLeftCorner, double sideLength)
        {
            TopLeftCorner = topLeftCorner;
            SideLength = sideLength;
        }

        public Point FindCenter()
        {
            return new Point(TopLeftCorner.X + SideLength/2, TopLeftCorner.Y - SideLength/2);
        }
    }

    public class LineSegment
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public LineSegment(Point start, Point end)
        {
            Start = start;
            End = end;
        }
    }

}

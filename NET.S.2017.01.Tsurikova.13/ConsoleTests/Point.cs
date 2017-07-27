using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class Point : IEquatable<Point>
    {
        public double X { get; set; }
        public double Y { get; set; }
        public const double EPSILONE = 0.001;

        public Point()
        {
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            if (ReferenceEquals(other, null)) return false;

            if (ReferenceEquals(other, this)) return true;

            return (Math.Abs(other.X - X) < EPSILONE && Math.Abs(other.Y - Y) < EPSILONE);
        }

        public override string ToString() => $"({X}, {Y})";

        public bool Equals(Point x, Point y)
        {
            Console.WriteLine(x);
            return true;
        }

    }
}

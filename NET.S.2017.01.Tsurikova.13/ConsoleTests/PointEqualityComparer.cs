using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTests
{
    public class PointEqualityComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point x, Point y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;

            return (Math.Abs(x.X - y.X) < 0.0001 && Math.Abs(x.Y - y.Y) < 0.0001);
        }

        public int GetHashCode(Point obj)
        {
            return base.GetHashCode();
        }
    }
}

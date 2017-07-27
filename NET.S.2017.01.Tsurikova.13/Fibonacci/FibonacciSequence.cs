using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class FibonacciSequence
    {
        public static IEnumerable<int> Generate(int number)
        {
            if (number < 0) throw new ArgumentException($"{nameof(number)} can't be negative");
            int a = 0;
            int b = 1;

            yield return a;
            if (number == 0) yield break;
            yield return b;

            while (a + b <= number)
            {
                int sum = a + b;
                a = b;
                b = sum;
                yield return sum;
            }
        }
    }
}

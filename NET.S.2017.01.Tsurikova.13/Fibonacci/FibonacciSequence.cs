using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    /// <summary>
    /// class for working with fibonacci numbers
    /// </summary>
    public class FibonacciSequence
    {
        /// <summary>
        /// generate sequence of fibonacci numbers
        /// </summary>
        /// <param name="number">number to which sequence to be generated</param>
        /// <returns>sequence of numbers</returns>
        /// <exception cref="ArgumentException">throws when number is negative</exception>
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

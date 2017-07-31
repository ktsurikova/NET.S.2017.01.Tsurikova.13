using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        /// <param name="number">number of elements in sequence to be generated</param>
        /// <returns>sequence of numbers</returns>
        /// <exception cref="ArgumentException">throws when number is negative</exception>
        public static IEnumerable<BigInteger> Generate(int number)
        {
            if (number < 0) throw new ArgumentException($"{nameof(number)} can't be negative");
            BigInteger a = -1;
            BigInteger b = 1;

            for (int i = 0; i < number; i++)
            {
                BigInteger sum = a + b;
                a = b;
                b = sum;
                yield return sum;
            }
        }
    }
}

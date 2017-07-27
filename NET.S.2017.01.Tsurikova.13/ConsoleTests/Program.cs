using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fibonacci;
using Queue;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //Queue<string> queue= new Queue<string>(new []{"cat Ginger", "cat Vasya", "dog Rex"});
            //Console.WriteLine($"3 {queue.Count}");
            //queue.Enqueue("crocodile Gena");
            //Console.WriteLine($"Ginger {queue.Peek()}");
            //Console.WriteLine($"Ginger {queue.Dequeue()}");
            //Console.WriteLine();
            //foreach (var item in queue)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine($"true {queue.Contains("cat Vasya")}");
            //Console.WriteLine();
            //string[] animals = queue.ToArray();
            //Array.ForEach(animals, Console.WriteLine);
            //Console.WriteLine();
            //animals[0] = null;
            //queue.СоруТо(animals, 1);
            //Array.ForEach(animals, Console.WriteLine);
            //queue.Clear();
            //Console.WriteLine(queue.Count);

            foreach (var VARIABLE in FibonacciSequence.Generate(0))
            {
                Console.WriteLine(VARIABLE);
            }
            Console.WriteLine();
            foreach (var VARIABLE in FibonacciSequence.Generate(1))
            {
                Console.WriteLine(VARIABLE);
            }
            Console.WriteLine();
            foreach (var VARIABLE in FibonacciSequence.Generate(10))
            {
                Console.WriteLine(VARIABLE);
            }
            Console.WriteLine();
            foreach (var VARIABLE in FibonacciSequence.Generate(200))
            {
                Console.WriteLine(VARIABLE);
            }

            Console.ReadLine();
        }
    }
}

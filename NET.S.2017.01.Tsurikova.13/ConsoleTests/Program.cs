using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fibonacci;
using System.Numerics;
using Set;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue.Queue<string> queue= new Queue.Queue<string>(new []{"cat Ginger", "cat Vasya", "dog Rex"});
            //IEnumerator<string> en = queue.GetEnumerator();
            //while (en.MoveNext())
            //{
            //    Console.WriteLine(en.Current);
            //}
            //en.Reset();
            //Console.WriteLine();
            //while (en.MoveNext())
            //{
            //    Console.WriteLine(en.Current);
            //}
            //en.Reset();
            //Console.WriteLine();
            Console.WriteLine($"3 {queue.Count}");
            //queue.Enqueue("crocodile Gena");
            //while (en.MoveNext())
            //{
            //    Console.WriteLine(en.Current);
            //}
            Console.WriteLine($"Ginger {queue.Peek()}");
            Console.WriteLine($"Ginger {queue.Dequeue()}");
            queue.Enqueue("crocodile Gena");
            Console.WriteLine();
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"true {queue.Contains("cat Vasya")}");
            Console.WriteLine();
            string[] animals = queue.ToArray();
            Array.ForEach(animals, Console.WriteLine);
            Console.WriteLine();
            animals[0] = null;
            queue.СоруТо(animals, 1);
            Array.ForEach(animals, Console.WriteLine);
            queue.Clear();
            Console.WriteLine(queue.Count);


            //Console.WriteLine();
            //foreach (BigInteger VARIABLE in FibonacciSequence.Generate(1000))
            //{
            //    Console.WriteLine(VARIABLE);
            //}

            //Set<Point> set = new Set<Point>(new[]{new Point(1,1), new Point(2,2),
            //    new Point(3,3), new Point(3,3) }, new PointEqualityComparer());

            ////Console.WriteLine(set.IsEqualElements(new Point(1, 2), new Point(1, 2)));

            ////Set<Point> set = new Set<Point>();
            ////Set<Point> set = new Set<Point>(3);
            //Console.WriteLine(set);
            //Console.WriteLine("3+" + set.Count);
            //Console.WriteLine("false+" + set.Contains(null));
            //Console.WriteLine("true+" + set.Contains(new Point(1, 1)));
            //Console.WriteLine("false+" + set.Contains(new Point(4, 4)));
            //try
            //{
            //    Console.WriteLine(set.Add(null));
            //}
            //catch (ArgumentNullException e)
            //{
            //    Console.WriteLine("Exception " + e.Message);
            //}
            //Console.WriteLine("true+" + set.Add(new Point(4, 4)));
            //Console.WriteLine("true+" + set.Add(new Point(5, 5)));
            //Console.WriteLine("true+" + set.Add(new Point(6, 6)));
            //Console.WriteLine("true+" + set.Add(new Point(7, 7)));
            //Console.WriteLine("true+" + set.Add(new Point(8, 8)));
            //Console.WriteLine("false+" + set.Add(new Point(3, 3)));
            //Console.WriteLine("8 points: " + set);
            //Console.WriteLine("false+" + set.Remove(null));
            //Console.WriteLine("true+" + set.Remove(new Point(4, 4)));
            //Console.WriteLine("7 points: " + set);
            //Console.WriteLine("false+" + set.Remove(new Point(9, 9)));
            //Console.WriteLine("7 points: " + set);
            //Console.WriteLine("7+" + set.Count);
            //Console.WriteLine("true+" + set.SetEquals(set));
            //Console.WriteLine("true+" + set.SetEquals(new[]
            //{
            //    new Point(1,1),
            //    new Point(2,2),
            //    new Point(3,3),
            //    new Point(5,5),
            //    new Point(6,6),
            //    new Point(7,7),
            //    new Point(8,8),
            //}));
            //Console.WriteLine("false+" + set.SetEquals(new[]
            //{
            //    new Point(1,1),
            //    new Point(3,3),
            //    new Point(5,5),
            //    new Point(6,6),
            //    new Point(7,7),
            //    new Point(8,8),
            //}));
            //Console.WriteLine("false+" + set.SetEquals(new[]
            //{
            //    new Point(1,1),
            //    new Point(2,2),
            //    new Point(3,3),
            //    new Point(5,5),
            //    new Point(6,6),
            //    new Point(7,7),
            //    new Point(8,8),
            //    new Point(9,9),
            //}));
            //set.IntersectWith(new[]
            //{
            //    new Point(1,1),
            //    new Point(2,2),
            //    new Point(3,3),
            //    new Point(6,6),
            //    new Point(7,7),
            //    new Point(9,9),
            //    new Point(10,10),
            //});
            //Console.WriteLine("5 points: " + set);
            //set.IntersectWith(new[]
            //{
            //    new Point(1,1),
            //    new Point(2,2),
            //    new Point(3,3),
            //});
            //Console.WriteLine("3 points: " + set);
            //set.UnionWith(new[]
            //{
            //    new Point(4,4),
            //    new Point(4,4),
            //    new Point(4,4),
            //});
            //Console.WriteLine("4 points: " + set);
            //set.UnionWith(new[]
            //{
            //    new Point(4,4),
            //    new Point(5,5),
            //    new Point(6,6),
            //    new Point(1,1),
            //    new Point(7,7),
            //});
            //Console.WriteLine("7 points: " + set);
            //set.ExceptWith(new[]
            //{
            //    new Point(10,10),
            //    new Point(6,6),
            //    new Point(-8,-9),
            //    new Point(7,7),
            //});
            //Console.WriteLine("5 points: " + set);
            //set.SymmetricExceptWith(new[]
            //{
            //    new Point(5,5),
            //    new Point(6,6),
            //    new Point(4,4),
            //    new Point(7,7),
            //});
            //Console.WriteLine("5 points: " + set);
            //Console.WriteLine("true+" + set.Overlaps(new[]
            //{
            //    new Point(5,5),
            //    new Point(6,6),
            //    new Point(4,4),
            //    new Point(7,7),
            //}));
            //Console.WriteLine("false+" + set.Overlaps(new[]
            //{
            //    new Point(50,50),
            //    new Point(60,60),
            //    new Point(-4,-4),
            //    new Point(79,72),
            //}));
            //Console.WriteLine("true+" + set.Overlaps(new[]
            //{
            //    null,
            //    new Point(50,50),
            //    null,
            //    new Point(3,3),
            //}));
            //Console.WriteLine("false+" + set.IsSubsetOf(new[]
            //{
            //    new Point(3,3),
            //    new Point(6,6),
            //    new Point(-4,-4),
            //    new Point(79,72),
            //}));
            //Console.WriteLine("true+" + set.IsSubsetOf(new[]
            //{
            //    new Point(3,3),
            //    new Point(6,6),
            //    new Point(1,1),
            //    new Point(2,2),
            //    new Point(7,7),
            //}));
            //Console.WriteLine("true+" + set.IsSubsetOf(new[]
            //{
            //    new Point(3,3),
            //    new Point(6,6),
            //    new Point(1,1),
            //    new Point(2,2),
            //    new Point(7,7),
            //    new Point(8,8),
            //}));
            //Set<Point> emptySet = new Set<Point>();
            //Console.WriteLine("true+" + emptySet.IsProperSubsetOf(new[]
            //{
            //    new Point(3,3),
            //    new Point(6,6),
            //    new Point(1,1),
            //    new Point(2,2),
            //    new Point(7,7),
            //    new Point(8,8),
            //}));
            //Console.WriteLine("true+" + set.IsProperSubsetOf(new[]
            //{
            //    new Point(3,3),
            //    new Point(6,6),
            //    new Point(1,1),
            //    new Point(2,2),
            //    new Point(7,7),
            //    new Point(8,8),
            //}));
            //Console.WriteLine("false+" + set.IsProperSubsetOf(new[]
            //{
            //    new Point(3,3),
            //    new Point(6,6),
            //    new Point(1,1),
            //    new Point(2,2),
            //    new Point(7,7),
            //}));
            //Console.WriteLine("false+" + set.IsProperSubsetOf(new[]
            //{
            //    new Point(3,3),
            //    new Point(6,6),
            //}));
            //Console.WriteLine("true+" + set.IsSupersetOf(emptySet));
            //Console.WriteLine("true+" + set.IsSupersetOf(new[]
            //{
            //    new Point(3,3),
            //    new Point(6,6),
            //}));
            //Console.WriteLine("false+" + set.IsSupersetOf(new[]
            //{
            //    new Point(3,3),
            //    new Point(6,6),
            //    new Point(1,1),
            //    new Point(2,2),
            //    new Point(7,7),
            //    new Point(8,8),
            //}));
            //Console.WriteLine("true+" + set.IsSupersetOf(new[]
            //{
            //    new Point(3,3),
            //    new Point(6,6),
            //    new Point(1,1),
            //    new Point(2,2),
            //    new Point(7,7),
            //}));
            //Console.WriteLine("true+" + set.IsProperSupersetOf(emptySet));
            //Console.WriteLine("false+" + set.IsProperSupersetOf(new[]
            //{
            //    new Point(3,3),
            //    new Point(6,6),
            //    new Point(1,1),
            //    new Point(2,2),
            //    new Point(7,7),
            //}));
            //Console.WriteLine("true+" + set.IsProperSupersetOf(new[]
            //{
            //    new Point(3,3),
            //    new Point(6,6),
            //    new Point(1,1),
            //    new Point(2,2),
            //}));
            //Console.WriteLine("Enumerator");
            //foreach (var item in set)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("end enumerator");
            //Point[] points = new Point[6];
            //set.CopyTo(points, 3);
            //Console.WriteLine("after copying 3 empty 3 point");
            //foreach (var VARIABLE in points)
            //{
            //    Console.WriteLine(VARIABLE);
            //}
            //Console.WriteLine("end copying");
            ////Set<Point> cloneSet = (Set<Point>)set.Clone();
            ////Console.WriteLine("Clone " + cloneSet);
            ////cloneSet.Add(new Point(9, 9));
            ////Console.WriteLine("set " + set);
            ////Console.WriteLine("clone have 1 more " + cloneSet);
            //set.Clear();
            //Console.WriteLine("0 points: " + set);
            //Console.WriteLine("0+" + set.Count);

            Console.ReadLine();
        }
    }
}

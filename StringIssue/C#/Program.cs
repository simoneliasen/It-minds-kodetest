using System;
using System.Linq;

namespace StringIssue
{
    class Program
    {
        static void Main(string[] args)
        {

            // Original approach
            Console.WriteLine("Filling array: ");

            var strs = Enumerable.Range(0, 40000).Select(s => s.ToString());

            Console.WriteLine("Executing inefficient String-Helper method: ");

            var before = DateTime.Now;

            var output = StringHelpers.MergeStrings(strs);

            var after = DateTime.Now;

            Console.WriteLine($"Length: {output.Length}");
            Console.WriteLine("Elapsed time: " + (after - before));

            Console.ReadLine();




            // Optimized approach
            Console.WriteLine("Filling new array: ");

            var strs2 = Enumerable.Range(0, 40000).Select(s => s.ToString());

            Console.WriteLine("Executing efficient String-Helper w. stringbuilder method: ");

            var before2 = DateTime.Now;

            var output2 = StringHelpers.MergeStringsOptimized(strs2);


            var after2 = DateTime.Now;

            Console.WriteLine($"Length: {output2.Length}");
            Console.WriteLine("Elapsed time: " + (after2 - before2));

            Console.ReadLine();

        }
    }
}

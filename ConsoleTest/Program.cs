using Algorithms.DynamicProgramming;
using Algorithms.Tree;
using Algorithms.TwoPointers;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var dp = new Algorithms.DynamicProgramming.DynamicProgramming();
            int result = dp.NumDecodings("12");

            Console.WriteLine("goodbye");
        }
    }
}

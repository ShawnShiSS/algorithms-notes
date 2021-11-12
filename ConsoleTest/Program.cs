using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Algorithms.Stack.Parenthesis p= new Algorithms.Stack.Parenthesis();

            var output = p.MinRemoveToMakeValid("lee(t(c)o)de)");

            Console.WriteLine(output);
        }
    }
}

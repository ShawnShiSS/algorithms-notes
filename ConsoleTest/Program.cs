using Algorithms.Tree;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TreeNode root = new TreeNode(3, null, null);
            TreeNode node9 = new TreeNode(9, null, null);
            TreeNode node20 = new TreeNode(20, null, null);
            TreeNode node15 = new TreeNode(15, null, null);
            TreeNode node7 = new TreeNode(7, null, null);

            node20.LeftChild = node15;
            node20.RightChild = node7;
            root.LeftChild = node9;
            root.RightChild = node20;

            var bfs = new Algorithms.BreadthFirstSearch.BreadthFirstSearch();
            var result = bfs.ZigzagLevelOrder(root);

            Console.WriteLine("goodbye");
        }
    }
}

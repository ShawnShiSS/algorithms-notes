using Algorithms.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DepthFirstSearch
{
    public partial class DepthFirstSearch
    {
        /// <summary>
        ///     Template to traverse a Binary Search Tree without recursion
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<int> BstInOrderTraversalTemplate(TreeNode root)
        {
            List<int> result = new List<int>();
            
            // edge case
            if (root == null)
            {
                return result;
            }    

            //Stack that holds all tree nodes whose right subtree has not been visited yet.
            Stack<TreeNode> stack = new Stack<TreeNode>();
            // Initialize stack with root and left nodes
            FillTowardsMostLeftChild(stack, root);

            while(stack.Count > 0)
            {
                TreeNode current = stack.Pop();
                // business logic: add to result
                result.Add(current.Value);

                if (current.RightChild != null)
                {
                    FillTowardsMostLeftChild(stack, current.RightChild);
                }
            }

            return result;
        }

        /// <summary>
        ///     Add node and all left children to the stack
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="root"></param>
        private void FillTowardsMostLeftChild(Stack<TreeNode> stack, TreeNode root)
        {
            // NOTE 1: add node and all left children to the stack
            while (root != null)
            {
                stack.Push(root);
                root = root.LeftChild;
            }
        }

        /// <summary>
        ///     230. Kth Smallest Element in a BST
        ///     Given the root of a binary search tree, and an integer k, return the kth (1-indexed) smallest element in the tree.
        ///     https://leetcode.com/problems/kth-smallest-element-in-a-bst/
        ///     Solution: use DFS In-Order traverse template above
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallestElementInBST(TreeNode root, int k)
        {
            int result = -1;

            // edge case
            if (root == null)
            {
                return result;
            }

            //Stack that holds all tree nodes whose right subtree has not been visited yet.
            Stack<TreeNode> stack = new Stack<TreeNode>();
            // Initialize stack with root and left nodes
            FillTowardsMostLeftChild(stack, root);

            int count = 0;
            while (stack.Count > 0)
            {
                TreeNode current = stack.Pop();
                // business logic: add to result
                count++;
                if (count == k)
                {
                    return current.Value;
                }

                if (current.RightChild != null)
                {
                    FillTowardsMostLeftChild(stack, current.RightChild);
                }
            }

            return result;
        }
    }
}

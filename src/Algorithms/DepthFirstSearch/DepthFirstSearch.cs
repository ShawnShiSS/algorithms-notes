using Algorithms.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DepthFirstSearch
{
    public partial class DepthFirstSearch
    {
        // TODO: DFS template using enumeration with recursion

        // TODO: DFS template using Divide and Conquer with recursion

        // TODO: Backtracking example

        // TODO: Binary Tree Divide and Conquer Template

        // TODO: DFS without recursion template

        /// <summary>
        ///     257. Binary Tree Paths
        ///     Given a binary tree, return all root-to-leaf paths.
        ///     https://leetcode.com/problems/binary-tree-paths/
        ///     This solution uses enumeration with recursion.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePathsByEnumeration(TreeNode root)
        {
            IList<string> result = new List<string>();

            if (root == null)
            {
                return result;
            }

            // DFS using enumeration with recursion
            BinaryTreePathsByEnumerationHelper(root, root.Value.ToString(), result);

            return result;
        }

        /// <summary>
        ///     Helper method to enumerate tree and add paths to result
        ///     PROBLEM with this helper: everytime the helper method is called, new paths are initialized in the call stack. 
        ///     See improved version with backtracking.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="path"></param>
        /// <param name="result"></param>
        private void BinaryTreePathsByEnumerationHelper(TreeNode node, string path, IList<string> result)
        {
            if (node == null)
            {
                return;
            }
            
            // leaf
            if (node.LeftChild == null && node.RightChild == null)
            {
                result.Add(path);
            }

            if (node.LeftChild != null)
            {
                BinaryTreePathsByEnumerationHelper(node.LeftChild, path + "->" + node.LeftChild.Value.ToString(), result);
            }

            if (node.RightChild != null)
            {
                BinaryTreePathsByEnumerationHelper(node.RightChild, path + "->" + node.RightChild.Value.ToString(), result);
            }
        }

        /// <summary>
        ///     Helper method to enumerate tree and add paths to result, with backtracking to improve call stack.
        ///     Note: path is no longer a string but a List, so that we can use path as a shared variable for backtracking
        /// </summary>
        /// <param name="node"></param>
        /// <param name="path"></param>
        /// <param name="result"></param>
        private void BinaryTreePathsByEnumerationHelperImproved(TreeNode node, List<int> path, IList<IList<int>> result)
        {
            if (node == null)
            {
                return;
            }

            // leaf
            if (node.LeftChild == null && node.RightChild == null)
            {
                result.Add(path);
            }

            if (node.LeftChild != null)
            {
                path.Add(node.LeftChild.Value); // backtracking, add to the end of list
                BinaryTreePathsByEnumerationHelperImproved(node.LeftChild, path, result);
                path.RemoveAt(path.Count - 1); // backtracking, remove the last element in list
            }

            if (node.RightChild != null)
            {
                path.Add(node.RightChild.Value); // backtracking, add to the end of list
                BinaryTreePathsByEnumerationHelperImproved(node.RightChild, path, result);
                path.RemoveAt(path.Count - 1); // backtracking, remove the last element in list
            }
        }
    }
}

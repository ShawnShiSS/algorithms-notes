﻿using Algorithms.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DepthFirstSearch
{
    /// <summary>
    ///     DFS search templates for binary trees
    ///         - Traversal on Binary Tree
    ///         - Divide and Conquer on Binary Tree
    /// </summary>
    public partial class DepthFirstSearch
    {
        /// <summary>
        ///     257. Binary Tree Paths
        ///     Given a binary tree, return all root-to-leaf paths.
        ///     https://leetcode.com/problems/binary-tree-paths/
        ///     This solution uses traversal with recursion.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePathsByTraversal(TreeNode root)
        {
            IList<string> result = new List<string>();

            if (root == null)
            {
                return result;
            }

            // DFS using traversal with recursion
            BinaryTreePathsByTraversalHelper(root, root.Value.ToString(), result);

            return result;
        }

        /// <summary>
        ///     Helper method to traverse a tree and add paths to result
        ///     PROBLEM with this helper: everytime the helper method is called, new paths are initialized in the call stack. 
        ///     See improved version with backtracking.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="path"></param>
        /// <param name="result"></param>
        private void BinaryTreePathsByTraversalHelper(TreeNode node, string path, IList<string> result)
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
                BinaryTreePathsByTraversalHelper(node.LeftChild, path + "->" + node.LeftChild.Value.ToString(), result);
            }

            if (node.RightChild != null)
            {
                BinaryTreePathsByTraversalHelper(node.RightChild, path + "->" + node.RightChild.Value.ToString(), result);
            }
        }

        /// <summary>
        ///     Helper method to traverse a tree and add paths to result, with backtracking to improve call stack.
        ///     Note: path is no longer a string but a List, so that we can use path as a shared variable for backtracking
        /// </summary>
        /// <param name="node"></param>
        /// <param name="path"></param>
        /// <param name="result"></param>
        private void BinaryTreePathsByTraversalHelperImproved(TreeNode node, List<int> path, IList<IList<int>> result)
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
                BinaryTreePathsByTraversalHelperImproved(node.LeftChild, path, result);
                path.RemoveAt(path.Count - 1); // backtracking, remove the last element in list
            }

            if (node.RightChild != null)
            {
                path.Add(node.RightChild.Value); // backtracking, add to the end of list
                BinaryTreePathsByTraversalHelperImproved(node.RightChild, path, result);
                path.RemoveAt(path.Count - 1); // backtracking, remove the last element in list
            }
        }

        /// <summary>
        ///     257. Binary Tree Paths
        ///     Given a binary tree, return all root-to-leaf paths.
        ///     https://leetcode.com/problems/binary-tree-paths/
        ///     This solution uses Divide and Conquer with recursion.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePathsByDivideAndConquer(TreeNode root)
        {
            IList<string> result = new List<string>();

            // edge case
            if (root == null)
            {
                return result;
            }

            // edge case: leaf node
            // If the result for a leaf node can be retrieved from two null nodes below, we do not have to process it here. 99% of the time, special care on leaf node is not required, e.g., max height of a tree. This solution requires it.
            if (root.LeftChild == null && root.RightChild == null)
            {
                result.Add(root.Value.ToString());
                return result;
            }

            // DFS using Divide and Conquer with recursion
            IList<string> leftSubtree = BinaryTreePathsByDivideAndConquer(root.LeftChild);
            IList<string> rightSubtree = BinaryTreePathsByDivideAndConquer(root.RightChild);
            // Combine result
            foreach (string leftPath in leftSubtree)
            {
                result.Add(root.Value + "->" + leftPath);
            }
            foreach (string rightPath in rightSubtree)
            {
                result.Add(root.Value + "->" + rightPath);
            }

            return result;
        }

        /// <summary>
        ///     900. Closest Binary Search Tree Value.
        ///     Given a non-empty binary search tree and a target value, find the value in the BST that is closest to the target.
        ///     https://www.lintcode.com/problem/closest-binary-search-tree-value/
        ///     Solution: Divide and Conquer. 
        ///         - Find the largest value that is smaller than target, 
        ///         - and find the smallest value that is larger than the target, 
        ///         - then return the one closer to target.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ClosestBinarySearchTreeValue(TreeNode root, decimal target)
        {
            if (root == null)
            {
                return 0;
            }

            // Search
            TreeNode lowerMax = FindLowerMax(root, target);
            TreeNode upperMin = FindUpperMin(root, target);

            // Process search result
            // One of the two nodes must exist
            if (lowerMax == null)
            {
                return upperMin.Value;
            }
            if (upperMin == null)
            {
                return lowerMax.Value;
            }

            if (target - lowerMax.Value > upperMin.Value - target)
            {
                return upperMin.Value;
            }

            return lowerMax.Value;
        }

        /// <summary>
        ///     Find the largest value that is smaller than target
        ///     DFS on binary search tree using recursion.
        ///     O(h), where h = height.
        ///     Note this is not in-order traversal, which is O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private TreeNode FindLowerMax(TreeNode root, decimal target)
        {
            if (root == null)
            {
                return null;
            }

            // Keep searching left subtree
            // Left subtree is smaller than root value
            if (root.Value >= target)
            {
                return FindLowerMax(root.LeftChild, target);
            }

            // root.Value < target
            // The first node that is smaller than target
            TreeNode lowerMax = FindLowerMax(root.RightChild, target);
            if (lowerMax != null)
            {
                return lowerMax;
            }

            return root;
        }

        /// <summary>
        ///     DFS on binary search tree using recursion.
        ///     O(h), where h = height
        ///     Note this is not in-order traversal, which is O(n)
        ///     </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        private TreeNode FindUpperMin(TreeNode root, decimal target)
        {
            throw new NotImplementedException();
        }
    }
}

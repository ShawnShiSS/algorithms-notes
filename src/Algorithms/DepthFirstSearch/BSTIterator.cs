using Algorithms.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DepthFirstSearch
{
    /// <summary>
    ///     173. Binary Search Tree Iterator
    ///     Implement the BSTIterator class that represents an iterator over the in-order traversal of a binary search tree (BST)
    ///     https://leetcode.com/problems/binary-search-tree-iterator/
    /// </summary>
    public class BSTIterator
    {
        /// <summary>
        ///     Stack that holds all tree nodes whose right subtree has not been iterated yet.
        /// </summary>
        private Stack<TreeNode> _stack;

        public BSTIterator(TreeNode root)
        {
            this._stack = new Stack<TreeNode>();
            FillTowardsMostLeftChild(root);
        }

        public int Next()
        {
            TreeNode current = _stack.Pop();
            if (current.RightChild != null)
            {
                FillTowardsMostLeftChild(current.RightChild);
            }

            return current.Value;
        }

        /// <summary>
        ///     Whether the BST has next node to iterate 
        /// </summary>
        /// <returns></returns>
        public bool HasNext()
        {
            return _stack.Count > 0;
        }

        private void FillTowardsMostLeftChild(TreeNode root)
        {
            // NOTE 1: add node and all left children to the stack
            while (root != null)
            {
                _stack.Push(root);
                root = root.LeftChild;
            }
        }
    }
}

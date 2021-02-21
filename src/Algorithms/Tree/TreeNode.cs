using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Tree
{
    /// <summary>
    ///     Tree Node
    /// </summary>
    public class TreeNode
    {
        public TreeNode(int value, TreeNode left, TreeNode right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        /// <summary>
        ///     Node value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        ///     Left Child
        /// </summary>
        public TreeNode LeftChild { get; set; }

        /// <summary>
        ///     Right child
        /// </summary>
        public TreeNode RightChild { get; set; }
    }
}

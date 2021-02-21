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
        /// <summary>
        ///     Node value
        /// </summary>
        public int Value { get; set; }

        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
    }
}

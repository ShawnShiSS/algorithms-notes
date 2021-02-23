using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Graph
{
    /// <summary>
    ///     Definition for Directed Graph Node
    /// </summary>
    public class DirectedGraphNode
    {
        public DirectedGraphNode(int label)
        {
            this.Label = label;
            this.Neighbours = new List<DirectedGraphNode>();
        }
        public int Label { get; set; }
        public List<DirectedGraphNode> Neighbours { get; set; }

    }
}

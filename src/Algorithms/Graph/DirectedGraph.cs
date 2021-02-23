using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Graph
{
    /// <summary>
    ///     Definition for Directed Graph
    /// </summary>
    public class DirectedGraph
    {
        public DirectedGraph(int label)
        {
            this.Label = label;
            this.Neighbours = new List<DirectedGraph>();
        }
        public int Label { get; set; }
        public List<DirectedGraph> Neighbours { get; set; }
    }
}

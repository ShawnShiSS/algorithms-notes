using Algorithms.Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.BreadthFirstSearch
{
    public partial class BreadthFirstSearch
    {
        /// <summary>
        ///     127. Topological Sorting
        ///     Given an directed graph, a topological order of the graph nodes is defined as follow:
        ///     - For each directed edge A -> B in graph, A must before B in the order list.
        ///     - The first node in the order can be any node in the graph with no nodes direct to it.
        ///     Find any topological order for the given graph.
        ///     https://www.lintcode.com/problem/topological-sorting/
        /// </summary>
        public List<DirectedGraphNode> TopologicalSortWithBFS(List<DirectedGraphNode> graph)
        {
            List<DirectedGraphNode> result = new List<DirectedGraphNode>();
            // Dictionary to track node to indegree, which is the number of neighbours that can point to a node
            Dictionary<DirectedGraphNode, int> nodeToIndegree = new Dictionary<DirectedGraphNode, int>();

            // Step 1: interate to calculate indegrees for all nodes
            foreach (DirectedGraphNode node in graph)
            {
                foreach(DirectedGraphNode neighbour in node.Neighbours)
                {
                    if (nodeToIndegree.ContainsKey(neighbour))
                    {
                        int indegree = nodeToIndegree[neighbour] + 1;
                        nodeToIndegree.Add(neighbour, indegree);
                    }
                    else
                    {
                        nodeToIndegree.Add(neighbour, 1);
                    }
                }
            }

            // Step 2: BFS template
            // Note: no need to use another dictionary to track visited nodes, nodeToIndegree does it already
            Queue<DirectedGraphNode> queue = new Queue<DirectedGraphNode>();
            
            // add nodes with 0 indegree to a queue
            foreach(var node in graph)
            {
                if (!nodeToIndegree.ContainsKey(node))
                {
                    queue.Enqueue(node);
                }
            }

            while (queue.Count > 0)
            {
                DirectedGraphNode current = queue.Dequeue();
                // add to result
                result.Add(current);

                // process neighbours by removing the edges between current and neighbours
                foreach (DirectedGraphNode neighbour in current.Neighbours)
                {
                    // remove edge
                    nodeToIndegree[neighbour] = nodeToIndegree[neighbour] - 1;

                    if (nodeToIndegree[neighbour] == 0)
                    {
                        // new node with indegree being 0
                        queue.Enqueue(neighbour);
                    }
                    
                }
            }

            return result;

        }
    }
}

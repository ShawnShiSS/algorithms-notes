using Algorithms.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.BreadthFirstSearch
{
    public partial class BreadthFirstSearch
    {
        /// <summary>
        ///     BFS template code that can be used to enumerate 
        ///         - tree
        ///         - graph
        /// </summary>
        /// <param name="node"></param>
        /// <returns>A list of node values</returns>
        public List<int> BfsTemplateForBothTreeAndGraph(TreeNode root)
        {
            List<int> result = new List<int>();

            // edge case
            if (root == null)
            {
                return result;
            }

            // Note 1: initialization
            // Queue for all nodes not processed yet
            // Dictionary for key = nodes and values = node depth, aka, distance to root node
            Queue<TreeNode> queue = new Queue<TreeNode>(); 
            Dictionary<TreeNode, int> nodeToDepth = new Dictionary<TreeNode, int>(); 

            queue.Enqueue(root);
            nodeToDepth.Add(root, 0);

            // Note 2: enumerate
            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();
                result.Add(current.Value);

                // Note 3: process children nodes for trees, or neighbours for graphs, use GetNeighbourNodes()
                foreach (TreeNode childNode in GetChildNodes(current))
                {
                    if (nodeToDepth.ContainsKey(childNode))
                    {
                        // already visited
                        // this does not apply to trees, but only to graphs
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(childNode);
                        int layerCount = nodeToDepth[current] + 1;
                        nodeToDepth.Add(childNode, layerCount);
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///     Get the child nodes for a given tree node
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private List<TreeNode> GetChildNodes(TreeNode root)
        {
            List<TreeNode> childNodes = new List<TreeNode>();

            if (root == null)
            {
                return childNodes;
            }

            if (root.LeftChild != null)
            {
                childNodes.Add(root.LeftChild);
            }

            if (root.RightChild != null)
            {
                childNodes.Add(root.RightChild);
            }

            return childNodes;
        }

        /// <summary>
        ///     BFS template to enumerate a tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<List<int>> BfsTemplate(TreeNode root)
        {
            List<List<int>> result = new List<List<int>>();
            
            // edge case
            if (root == null)
            {
                return result;
            }

            // Single Queue implementation
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            // enumerate
            while(queue.Count > 0)
            {
                // reset current layer
                List<int> currentLayer = new List<int>();
                
                // must know the layer size 
                int layerSize = queue.Count;
                for(int i = 0; i< layerSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    currentLayer.Add(currentNode.Value);

                    // Add children to queue
                    if (currentNode.LeftChild != null)
                    {
                        queue.Enqueue(currentNode.LeftChild);
                    }
                    if (currentNode.RightChild != null)
                    {
                        queue.Enqueue(currentNode.RightChild);
                    }
                }

                // add the current layer
                result.Add(currentLayer);
            }

            return result;
        }
    }
}

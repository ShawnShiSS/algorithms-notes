using Algorithms.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.BreadthFirstSearch
{
    public class BreadthFirstSearch
    {
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

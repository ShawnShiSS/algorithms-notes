using Algorithms.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.BreadthFirstSearch
{
    public partial class BreadthFirstSearch
    {
        /// <summary>
        ///     103. Binary Tree Zigzag Level Order Traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            // Approach
            // BFS level order traversal, plus a flag to track direction.

            IList<IList<int>> result = new List<IList<int>>();

            // Corner cases
            if (root == null)
            {
                return result;
            }

            // BFS search using a queue
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool goRight = false;

            while (queue.Count > 0)
            {
                // Hold on to the current layer size
                int layerSize = queue.Count;

                // Search this layer
                IList<int> currentLayer = new List<int>();
                for (int i = 0; i < layerSize; i++)
                {
                    TreeNode currentNode = queue.Dequeue();
                    currentLayer.Add(currentNode.Value);

                    // Push child nodes to the queue
                    if (currentNode.LeftChild != null)
                    {
                        queue.Enqueue(currentNode.LeftChild);
                    }
                    if (currentNode.RightChild != null)
                    {
                        queue.Enqueue(currentNode.RightChild);
                    }
                }

                // Honor the direction flag
                if (!goRight)
                {
                    ReverseList(currentLayer);
                }

                // Deep copy current layer into the result
                result.Add(new List<int>(currentLayer));

                // Reset direction flag
                goRight = !goRight;
            }

            return result;
        }

        private void ReverseList(IList<int> list)
        {
            List<int> concreteList = (List<int>)list;
            concreteList.Reverse();
        }
    }
}

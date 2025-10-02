using System.Collections.Generic;

namespace Algorithms.DepthFirstSearch
{
    public class DFS
    {
        public class CombinationIterator
        {
            private Queue<string> _combinations;

            public CombinationIterator(string characters, int combinationLength)
            {
                BuildCombinations(characters, combinationLength);
            }

            public string Next()
            {
                if (!HasNext())
                {
                    return null;
                }

                return _combinations.Dequeue();
            }

            public bool HasNext()
            {
                return _combinations.Count > 0;
            }

            private void BuildCombinations(string characters, int combinationLength)
            {
                // Corner cases

                // Build
                _combinations = new Queue<string>();
                List<char> current = new List<char>();

                DfsSearchHelper(characters, 0, current, combinationLength);
            }

            // Search all combinations of length that start with current
            private void DfsSearchHelper(string characters, int start, List<char> current, int combinationLength)
            {
                // Exit when we have reached the length requirement
                if (current.Count == combinationLength)
                {
                    _combinations.Enqueue(string.Join("", current));
                    return;
                }

                for (int i = start; i < characters.Length; i++)
                {

                    current.Add(characters[i]);

                    // IMPORTANT: use i+1 instead of start + 1, in order to skip visited chars
                    DfsSearchHelper(characters, i + 1, current, combinationLength);

                    current.RemoveAt(current.Count - 1);

                }
            }
        }


    }
}

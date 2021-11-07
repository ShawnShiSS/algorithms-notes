using System.Collections.Generic;

namespace Algorithms.DepthFirstSearch
{
    public class DFS
    {
        public readonly int[] rowDirections = new int[] { 0, 1, 0, -1 };
        public readonly int[] colDirections = new int[] { 1, 0, -1, 0 };

        public IList<int> SpiralOrder(int[][] matrix)
        {
            // Goal: for each element, search whether we can travel in the spiral order, and stop after we have visited all elements.

            // Corner cases
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return new List<int>();
            }

            // Search in spiral fashion
            List<int> result = new List<int>();
            HashSet<string> visited = new HashSet<string>();

            SpiralSearch(matrix, 0, 0, result, visited);

            return result;
        }

        // DFS search 
        private void SpiralSearch(int[][] matrix, int row, int col, List<int> result, HashSet<string> visited)
        {
            // Add to result
            result.Add(matrix[row][col]);
            visited.Add($"{row}{col}");

            // Exit when all neighbours either have been visited or are out of bound
            // if (HasReacheTheSprialEnd(matrix, row, col, visited))
            // {
            //     return;
            // }
            // Or, return when result has collected all elements
            if (result.Count == matrix.Length * matrix[0].Length)
            {
                return;
            }

            // Search in four directions: right, down, left, up        
            for (int i = 0; i < rowDirections[i]; i++)
            {
                int newRow = row + rowDirections[i];
                int newCol = col + colDirections[i];

                if (!IsOutOfBound(matrix, newRow, newCol))
                {
                    SpiralSearch(matrix, newRow, newCol, result, visited);

                    // We can only move in one direction, 
                    // so we break after we move
                    break;
                }
            }
        }

        private bool IsOutOfBound(int[][] matrix, int row, int col)
        {
            return !(row >= 0 && row < matrix.Length &&
                     col >= 0 && col < matrix[0].Length);
        }

        // A spiral end is an element whose four neighbours are either out of bound or have been visited
        private bool HasReacheTheSprialEnd(int[][] matrix, int row, int col, HashSet<string> visited)
        {
            for (int i = 0; i < rowDirections[i]; i++)
            {
                int newRow = row + rowDirections[i];
                int newCol = col + colDirections[i];

                if (!IsOutOfBound(matrix, newRow, newCol) &&
                    !visited.Contains($"{newRow}{newCol}"))
                {
                    // Has something inbound to visit next
                    return false;
                }
            }

            return true;
        }
    }
}

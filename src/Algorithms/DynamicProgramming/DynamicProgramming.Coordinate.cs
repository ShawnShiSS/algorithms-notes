using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DynamicProgramming
{
    public partial class DynamicProgramming
    {
        /// <summary>
        ///     NOTE: Number triangle is not a binary tree.
        ///     120. Triangle
        ///     Given a triangle array, return the minimum path sum from top to bottom.
        ///     For each step, you may move to an adjacent number of the row below. 
        ///     More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.
        ///     Constraints:
        ///         * 1 <= triangle.length <= 200
        ///         * triangle[0].length == 1
        ///         * triangle[i].length == triangle[i - 1].length + 1
        ///         * -104 <= triangle[i][j] <= 104
        ///     https://leetcode.com/problems/triangle/description/
        ///     Solution 1: DFS, O(2^n), as there are 2^n paths in total
        ///     Solution 2: DFS + memorized search, O(n^2), as each [x,y] will only be visited at once
        ///     Solution 3: Dynamic Programming (this one)
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int TriangleMinimumTotal(IList<IList<int>> triangle)
        {
            // DP state: define the path sum from top to current coordinates
            // DP function: break the problem into smaller sub problems
            // DP initialization: exit or boundary cases
            // DP answer: caller

            // edge cases : empty input is/should ruled out by contstrains
            if (triangle == null || triangle.Count == 0)
            {
                return -1;
            }
            if (triangle[0] == null || triangle[0].Count== 0)
            {
                return -1;
            }

            // DP state: dp[x][y] = minimum path value from top 0,0 to x,y
            int rowCount = triangle.Count;
            // A jagged array, array of arrays, with rowCount elements
            int[][] minPathSums = new int[rowCount][]; 
            for(int i=0; i< rowCount; i++)
            {
                minPathSums[i] = new int[i+1];
            }

            // DP initialization
            // starting point
            minPathSums[0][0] = triangle[0][0];
            // triangle border lines
            for (int i = 1; i < rowCount; i++)
            {
                // Left side of triangle
                minPathSums[i][0] = minPathSums[i - 1][0] + triangle[i][0];
                // Right side of triangle
                minPathSums[i][i] = minPathSums[i - 1][i - 1] + triangle[i][i];
            }

            // DP function: break down the problem 
            // starting from 1,1
            for(int row = 1; row < rowCount; row++)
            {
                // Only need to calculate the triangle, thus col < row
                for (int col = 1; col < row; col++)
                {
                    minPathSums[row][col] = Math.Min(minPathSums[row - 1][col], minPathSums[row -1][col - 1]) + triangle[row][col];
                }
            }

            // DP answer: minimum of the values on the bottom side of the triangle
            int minTotal = minPathSums[rowCount - 1][0];
            for(int i = 1; i < rowCount; i++)
            {
                minTotal = Math.Min(minTotal, minPathSums[rowCount - 1][i]);
            }

            return minTotal;

        }

        /// <summary>
        ///     62. Unique Paths
        ///     A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        ///     The robot can only move either down or right at any point in time.The robot is trying to reach the bottom-right corner of the grid(marked 'Finish' in the diagram below).
        ///     How many possible unique paths are there?
        ///     https://leetcode.com/problems/unique-paths/
        ///     Solution: dynamic programming
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        /// <returns></returns>
        public int UniquePaths(int rowCount, int colCount)
        {
            // DP state: jagged array dp[i][j] = unique paths from start to i,j
            int[][] uniquePaths = new int[rowCount][];
            for(int i = 0; i < rowCount; i++)
            {
                uniquePaths[i] = new int[colCount];
            }

            // DP initialization: starting point and boundary lines
            for (int row = 0; row < rowCount; row++)
            {
                uniquePaths[row][0] = 1;
            }
            for (int col = 0; col < colCount; col++)
            {
                uniquePaths[0][col] = 1;
            }

            // DP function: break down problem
            for (int row = 1; row < rowCount; row++)
            {
                for (int col = 1; col < colCount; col++)
                {
                    uniquePaths[row][col] = uniquePaths[row - 1][col] + uniquePaths[row][col - 1];
                }
            }

            // DP answer: finishing point
            return uniquePaths[rowCount - 1][colCount - 1];
        }

        /// <summary>
        ///     63. Unique Paths II
        ///     A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
        ///     The robot can only move either down or right at any point in time.The robot is trying to reach the bottom-right corner of the grid(marked 'Finish' in the diagram below).
        ///     Now consider if some obstacles are added to the grids.How many unique paths would there be?
        ///     An obstacle and space is marked as 1 and 0 respectively in the grid.
        ///     https://leetcode.com/problems/unique-paths/
        ///     Solution: dynamic programming
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            // edge case
            if (obstacleGrid == null || 
                obstacleGrid.Length == 0 || 
                obstacleGrid[0].Length == 0)
            {
                return -1;
            }

            int rowCount = obstacleGrid.Length;
            int colCount = obstacleGrid[0].Length;

            // DP state: jagged array dp[i][j] = unique paths from start to i,j
            int[][] uniquePaths = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                uniquePaths[i] = new int[colCount];
            }

            // DP initialization: starting point and boundary lines
            for (int row = 0; row < rowCount; row++)
            {
                // Stop when running into an obstacle
                if (obstacleGrid[row][0] == 1)
                {
                    break;
                }
                uniquePaths[row][0] = 1;
            }
            for (int col = 0; col < colCount; col++)
            {
                // Stop when running into an obstacle
                if (obstacleGrid[0][col] == 1)
                {
                    break;
                }
                uniquePaths[0][col] = 1;
            }

            // DP function: break down problem
            for (int row = 1; row < rowCount; row++)
            {
                for (int col = 1; col < colCount; col++)
                {
                    // Obstacle's unique paths should be 0
                    if (obstacleGrid[row][col] == 1)
                    {
                        continue;
                    }    

                    uniquePaths[row][col] = uniquePaths[row - 1][col] + uniquePaths[row][col - 1];
                }
            }

            // DP answer: finishing point
            return uniquePaths[rowCount - 1][colCount - 1];
        }

    }
}

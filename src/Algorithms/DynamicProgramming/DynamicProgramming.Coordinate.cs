using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DynamicProgramming
{
    public partial class DynamicProgramming
    {


        /// <summary>
        ///     91. Decode Ways
        ///     https://leetcode.com/problems/decode-ways/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0')
            {
                return 0;
            }

            int n = s.Length;

            // DP definition
            // dp[i]: number of decodings in the first i chars, including 0 chars
            int[] dp = new int[n + 1];

            // DP initialization
            dp[0] = 1;
            dp[1] = 1;

            // DP breakdown
            for (int i = 2; i <= n; i++)
            {
                // Single last digit
                int endingWithSingleDigit = dp[i - 1] * CanDecode(s.Substring(i - 1, 1));

                // Two last digits
                int endingWithDoubleDigits = dp[i - 2] * CanDecode(s.Substring(i - 2, 2));

                dp[i] = endingWithSingleDigit + endingWithDoubleDigits;
            }

            return dp[n];
        }

        private int CanDecode(string s)
        {
            int parsedValue;
            if (!int.TryParse(s, out parsedValue))
            {
                return 0;
            }

            if (s.Length == 1 && parsedValue >= 1 && parsedValue <= 9)
            {
                return 1;
            }
            if (s.Length == 2 && parsedValue >= 10 && parsedValue <= 26)
            {
                return 1;
            }

            return 0;
        }


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

        /// <summary>
        ///     630. Knight Shortest Path II
        ///     Given a knight in a chessboard n * m (a binary matrix with 0 as empty and 1 as barrier). the knight initialze position is (0, 0) and he wants to reach position (n - 1, m - 1), Knight can only be from left to right. Find the shortest path to the destination position, return the length of the route. Return -1 if knight can not reached.
        ///     If the knight is at (x, y), he can get to the following positions in one step:
        ///     (x + 1, y + 2)
        ///     (x - 1, y + 2)
        ///     (x + 2, y + 1)
        ///     (x - 2, y + 1)
        ///     https://www.lintcode.com/problem/630/
        ///     Solution: Dynamic Programming with coordinates
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int KnightShortestPathII(bool[][] grid)
        {
            // edge case
            if (grid == null || 
                grid.Length == 0 || 
                grid[0].Length == 0)
            {
                return -1;
            }

            int rowCount = grid.Length;
            int colCount = grid.Length;

            // DP state: shortest path from 0,0 to i,j
            int[][] shortestPaths = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                shortestPaths[i] = new int[colCount];
            }

            // default values: max value of int
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    shortestPaths[row][col] = int.MaxValue;
                }
            }

            // DP initialization: starting point
            shortestPaths[0][0] = 0;

            // DP function: break down the problem
            int[] deltaX = new int[] { -1, 1, -2, 2 };
            int[] deltaY = new int[] { -2, -2, -1, -1 };

            // Note: because the knight moves left to right, we must loop col first
            for (int col = 0; col < colCount; col++)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    // Check for obstacle
                    if (grid[row][col] == true)
                    {
                        continue;
                    }

                    // Check four direction
                    for (int delta = 0; delta < deltaX.Length; delta++)
                    {
                        int x = row + deltaX[delta];
                        int y = col + deltaY[delta];

                        // Check for out of bound
                        // (0 <= x < rowCount && 0 <= y < colCount)
                        if (x < 0 ||
                            x >= rowCount || 
                            y < 0 ||
                            y >= colCount)
                        {
                            continue;
                        }

                        // Check whether x,y is an obstacle
                        if (shortestPaths[x][y] == int.MaxValue)
                        {
                            continue;
                        }

                        shortestPaths[row][col] = Math.Min(shortestPaths[x][y] + 1, shortestPaths[row][col]);
                    }
                }
            }

            if (shortestPaths[rowCount - 1][colCount - 1] == int.MaxValue)
            {
                return -1;
            }

            return shortestPaths[rowCount - 1][colCount - 1];
        }

        /// <summary>
        ///     300. Longest Increasing Subsequence
        ///     Given an integer array nums, return the length of the longest strictly increasing subsequence.
        ///     A subsequence is a sequence that can be derived from an array by deleting some or no elements without changing the order of the remaining elements.
        ///     https://leetcode.com/problems/longest-increasing-subsequence/
        ///     Solution: dynamic programming, O(n^2) time
        /// </summary>
        /// <example>
        ///     Input: nums = [10,9,2,5,3,7,101,18]
        ///     Output: 4
        ///     Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.</example>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            // edge case
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            // DP state dp[i] : the LIS at the i-th element
            int[] lisTracker = new int[nums.Length];
            
            // DP initialization: all LIS should be 1 as there can be at least one element
            for (int i = 0; i < lisTracker.Length; i++)
            {
                lisTracker[i] = 1;
            }

            // DP function: for each element, the LIS is 1 plus the max of all previous elements
            for (int curr = 0; curr < lisTracker.Length; curr++)
            {
                for (int prev = 0; prev < curr; prev++)
                {
                    // BL: check if the current element value is larger than the previous element
                    if (nums[curr] > nums[prev])
                    {
                        lisTracker[curr] = Math.Max(lisTracker[prev] + 1, lisTracker[curr]);
                    }
                }
            }

            // DP result: the maximum value in the LIS tracker
            int result = lisTracker[0];
            for (int i = 1; i < lisTracker.Length; i++)
            {
                result = Math.Max(result, lisTracker[i]);
            }

            return result;
        }
    }
}

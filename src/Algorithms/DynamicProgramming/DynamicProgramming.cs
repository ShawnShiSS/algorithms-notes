﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DynamicProgramming
{
    public class DynamicProgramming
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
    }
}
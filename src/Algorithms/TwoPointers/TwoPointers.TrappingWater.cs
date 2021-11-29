using System;

namespace Algorithms.TwoPointers
{
    public partial class TwoPointers
    {
        /// <summary>
        ///     42. Trapping Rain Water
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int Trap(int[] heights)
        {
            // Corner cases
            if (heights == null || heights.Length == 0)
            {
                return 0;
            }

            // Scan left to right to fill in leftMaxHeight
            int[] leftMaxHeight = GetLeftMaxHeight(heights);

            // Scan right to left to fill in leftMaxHeight
            int[] rightMaxHeight = GetRightMaxHeight(heights);

            // Scan cells again and add up the total amount of water
            int totalWater = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                int cellWater = Math.Max(0, Math.Min(leftMaxHeight[i], rightMaxHeight[i]) - heights[i]);
                totalWater += cellWater;
            }

            return totalWater;
        }

        private int[] GetLeftMaxHeight(int[] heights)
        {
            int[] result = new int[heights.Length];

            int currentLeftMax = 0;
            for (int i = 1; i < heights.Length; i++)
            {
                currentLeftMax = Math.Max(currentLeftMax, heights[i - 1]);
                result[i] = currentLeftMax;
            }

            return result;
        }

        private int[] GetRightMaxHeight(int[] heights)
        {
            int[] result = new int[heights.Length];

            int currentRightMax = 0;
            for (int i = heights.Length - 2; i >= 0; i--)
            {
                currentRightMax = Math.Max(currentRightMax, heights[i + 1]);
                result[i] = currentRightMax;
            }

            return result;
        }

        // [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]
        //                       |
        //           |           |  |     |    
        //     |     |  |     |  |  |  |  |  |
        // [0, 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3] leftMaxHeight
        // [3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 1, 0] rightMaxHeight
        // [0, 0, 1, 0, 1, ] water: Math.Min(leftMaxHeight[i], rightMaxHeight[i]) - h > 0 ? x : 0;

        // Barrel effect
    }
}

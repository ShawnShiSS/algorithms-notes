using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DynamicProgramming
{
    /// <summary>
    ///     Dynamic programming for backpack-type problems
    /// </summary>
    public partial class DynamicProgramming
    {


        /// <summary>
        ///     ///     92. Backpack
        ///     Given n items, each item has size items[i], an integer m denotes the size of a backpack. How full you can fill this backpack?
        ///     https://www.lintcode.com/problem/backpack/
        ///     Solution: Dynamic programming for backpack
        /// </summary>
        /// <param name="backpackSize"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public int Backpack(int backpackSize, int[] items)
        {
            int itemCount = items.Length;

            // DP state: dp[i][j] whether the first i items can fill up to sum = j
            // Need to track 0 item, thus itemCount + 1
            // Need to track size = 0, thus backpackSize + 1
            bool[][] dp = new bool[itemCount + 1][];
            for (int i = 0; i < dp.Length; i++)
            {
                // Need to also track sum = 0, thus backpackSize + 1
                dp[i] = new bool[backpackSize + 1];
            }

            // DP initialization: first 0 items to create a sum = 0
            dp[0][0] = true;

            // DP function
            // first x items can make a sum
            // , or first i items can make a sum = backpackSize - A[j]
            // start from i = 1, as 0 item can not make a sum > 0
            for(int itemIndex = 1; itemIndex < itemCount + 1; itemIndex++)
            {
                // first x item of course can make a sum = 0, just do not pick it.
                dp[itemIndex][0] = true;
                for (int sum = 1; sum <= backpackSize; sum++)
                {
                    
                    if (sum >= items[itemIndex - 1])
                    {
                        // May pick the current item
                        dp[itemIndex][sum] = dp[itemIndex - 1][sum] || 
                                             dp[itemIndex - 1][sum - items[itemIndex - 1]];
                    }
                    else
                    {
                        // Can not pick the current item
                        dp[itemIndex][sum] = dp[itemIndex - 1][sum];
                    }
                }
            }

            // DP Answer
            for (int sum = backpackSize; sum >=0; sum--)
            {
                if (dp[itemCount][sum])
                {
                    return sum;
                }
            }

            return -1;
        }
    }
}

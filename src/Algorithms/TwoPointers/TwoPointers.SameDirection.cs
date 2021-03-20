using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.TwoPointers
{
    /// <summary>
    ///     Partial class for Two Pointers with the same direction 
    /// </summary>
    public partial class TwoPointers
    {
        /// <summary>
        ///     610. Two Sum - Difference equals to target
        ///     Given an sorted array of integers, find two numbers that their difference equals to a target value.
        ///     Return a list with two number like[num1, num2] that the difference of num1 and num2 equals to target value, and num1 is less than num2.
        ///     https://www.lintcode.com/problem/two-sum-difference-equals-to-target/
        ///     Solution: two pointers with same direction, O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSubstraction(int[] nums, int target)
        {
            int[] result = new int[] { -1, -1 };

            // corner case
            if (nums == null || nums.Length <= 1)
            {
                return result;
            }

            // Target can be negative value, but 2-5 = -3, 5-2=3, we can use abs(-3)
            target = Math.Abs(target);

            // Two pointers with same direction
            int faster = 1;
            for (int slower = 0; slower < nums.Length; slower++)
            {
                // Faster pointer must be at least 1 larger than slower
                faster = Math.Max(faster, slower + 1);

                // Find the first pair where faster - slower >= target
                while (faster < nums.Length && nums[faster] - nums[slower] < target)
                {
                    faster++;
                }

                // Check out of bound
                if (faster >= nums.Length)
                {
                    break;
                }

                if (nums[faster] - nums[slower] == target)
                {
                    result[0] = nums[slower];
                    result[1] = nums[faster];
                }
            }

            return result;
        }

        
    }
}

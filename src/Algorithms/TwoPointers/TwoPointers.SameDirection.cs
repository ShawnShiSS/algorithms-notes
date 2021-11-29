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

        /// <summary>
        ///     1513. Number of Substrings with Only 1s
        ///     Given a binary string s (a string consisting only of '0' and '1's).
        ///     Return the number of substrings with all characters 1's.
        ///     Since the answer may be too large, return it modulo 10^9 + 7.
        ///     https://leetcode.com/problems/number-of-substrings-with-only-1s/
        ///     Solution: two pointers
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int NumberOfSubstrings(string input)
        {
            int result = 0;

            if (input == null || input.Length == 0)
            {
                return result;
            }

            // Two pointers with same direction
            // to calculate the length of substring starting from index slower.
            // The length matches the count. E.g., for 111, 3+2+1=6, which is three "1", two "11", one "111".
            int faster = 1;
            for (int slower = 0; slower < input.Length; slower++)
            {
                // Skip 0 zeros
                if (input[slower] == '0')
                {
                    continue;
                }

                // Faster pointer must be at least 1 larger than slower
                faster = Math.Max(faster, slower + 1);

                // Check boundary,
                // and find the first faster pointer that does not meet the criteria, aka, value = 0
                while (faster < input.Length && input[faster] == '1')
                {
                    faster++;
                }

                result = result + (faster - slower);
            }

            return result;
            // input : 0 1 1 0 1 1 1
            //               ^^
            //               ij
            // answer: 2 + 1 
        }

        /// <summary>
        ///     604. Window Sum
        ///     Given an array of n integers, and a moving window(size k), move the window at each iteration from the start of the array, find the sum of the element inside the window at each moving.
        ///     https://www.lintcode.com/problem/window-sum/
        ///     Solution: two pointers same direction.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] WindowSum(int[] nums, int k)
        {
            // corner cases
            if (nums == null || 
                nums.Length == 0 ||
                k <= 0)
            {
                return new int[] { };
            }

            int[] result = new int[nums.Length - k + 1];


            // Two pointers same direction
            // slow - beginning of window, inclusive
            // fast - end of window, exclusive
            int fast = 1;
            // window sum for range [slow, fast)
            int windowSum = nums[0];

            for (int slow = 0; slow < nums.Length; slow++)
            {
                while (fast < nums.Length && fast - slow < k)
                {
                    windowSum += nums[fast];
                    fast++;
                }

                // Two possible exit paths: out of bound || window size == k
                if (fast - slow == k)
                {
                    result[slow] = windowSum;
                }

                // Important: substract value before incrementing slow pointer
                windowSum -= nums[slow];
            }

            return result;
        }
    }
}

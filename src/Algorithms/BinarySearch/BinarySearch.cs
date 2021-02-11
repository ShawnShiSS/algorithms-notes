using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.BinarySearch
{
    public class BinarySearch
    {
        /// <summary>
        ///     457. Classical Binary Search
        ///     Find any position of a target number in a sorted array. Return -1 if target does not exist.
        ///     O(logn) time
        ///     https://www.lintcode.com/problem/classical-binary-search
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindIndexRecursion(int[] nums, int target)
        {
            return FindIndexRecursionHelper(nums, 0, nums.Length - 1, target); 
        }

        /// <summary>
        ///     Recursion helper to find the index of target in a sorted array.
        ///     Return -1 if not found.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int FindIndexRecursionHelper(int[] nums, int start, int end, int target)
        {
            // exit criteria
            if (start > end)
            {
                return -1;
            }

            int mid = start + (end - start) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }

            // target in the left half
            if (nums[mid] > target)
            {
                return FindIndexRecursionHelper(nums, start, mid - 1, target);
            }

            // target in the right half or not found
            return FindIndexRecursionHelper(nums, mid + 1, end, target);
            
        }
    }
}

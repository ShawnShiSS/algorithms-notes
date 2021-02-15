using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.TwoPointers
{

    /// <summary>
    ///     A collection of partition type questions
    /// </summary>
    public partial class TwoPointers
    {
        /// <summary>
        ///     31. Partition Array
        ///     Given an array nums of integers and an int k, partition the array (i.e move the elements in "nums") such that:
        ///     All elements smaller than k are moved to the left
        ///     All elements equal to or larger than k are moved to the right
        ///     https://www.lintcode.com/problem/partition-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns>Return the partitioning index, i.e the first index i nums[i] >= k.</returns>
        public int PartitionArray(int[] nums, int target)
        {
            // edge cases
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int left = 0;
            int right = nums.Length - 1;
            //int mid = left + (right - left) / 2;
            int pivot = target;
            while (left <= right) // note <= not <, so exit when left>right
            {
                while (left <= right && nums[left] < target)
                {
                    // find the first value >= target
                    left++;
                }
                while (left <= right && nums[right] >= target)
                {
                    // find the first value < target
                    right--;
                }

                if (left <= right)
                {
                    SwapNumbers(nums, left, right);
                    left++;
                    right--;
                }
            }

            // exit when left > right
            return left;
        }

        private void SwapNumbers(int[] nums, int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }

    }
}

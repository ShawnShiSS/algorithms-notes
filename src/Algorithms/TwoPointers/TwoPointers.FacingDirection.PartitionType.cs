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
                    SwapValues(nums, left, right);
                    left++;
                    right--;
                }
            }

            // exit when left > right
            return left;
        }

        /// <summary>
        ///     75. Sort Colors
        ///     Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.
        ///     We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.
        ///     https://leetcode.com/problems/sort-colors/
        /// </summary>
        /// <param name="nums"></param>
        public void SortThreeColors(int[] nums)
        {
            // edge cases
            if (nums == null || nums.Length <= 1)
            {
                return;
            }

            // two pointers
            // left pointer tracking 0s, exclusive
            // right pointer tracking 2s, exclusive
            int left = 0;
            int right = nums.Length - 1;
            int current = 0;
            while (current <= right) // NOTE: i<=right, not length
            {
                if (nums[current] == 0)
                {
                    // swap 0s to left pointer
                    SwapValues(nums, left, current);
                    left++;
                    current++;
                }
                else if (nums[current] == 2)
                {
                    // swap 2s to right pointer
                    // BUT DO NOT increment current, as it may be 0 and has to be evaluated again
                    SwapValues(nums, right, current);
                    right--;
                }
                else
                {
                    // skip 1s
                    current++;
                }
            }

        }

        /// <summary>
        ///     143. Sort Colors II
        ///     Given an array of n objects with k different colors (numbered from 1 to k), sort them so that objects of the same color are adjacent, with the colors in the order 1, 2, ... k.
        ///     Solution:
        ///     - Two Pointers for partitioning
        ///     - Divide and Conquer to break down the K colors problem
        ///     https://www.lintcode.com/problem/143/
        /// </summary>
        /// <param name="nums"></param>
        public void SortKColors(int[] nums, int k)
        {
            // edge case
            if (nums == null || nums.Length <= 1)
            {
                return;
            }

            // Rainbow sort: O(nlogk)
            RainbowSortPartitionHelper(nums, 0, nums.Length - 1, 0, k);

        }

        /// <summary>
        ///     Partition the array given index range (left and right) so that 
        ///     - left half of the array is <= mid color, aka, (fromColor+toColor)/2;
        ///     - right half of the array is > mid color, aka, (fromColor+toColor)/2;
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="fromColor"></param>
        /// <param name="toColor"></param>
        private void RainbowSortPartitionHelper(int[] nums, int leftIndex, int rightIndex, int fromColor, int toColor)
        { 
            // single color, no sort
            if (fromColor == toColor)
            {
                return;
            }

            // recursion exit
            if (leftIndex >= rightIndex)
            {
                return;
            }

            // two pointers template
            int midColor = fromColor + (toColor - fromColor) / 2;
            // need to hold on to left and right values for recusive calls
            int leftPointer = leftIndex; 
            int rightPointer = rightIndex;
            while (leftPointer <= rightPointer)
            {
                while(leftPointer <= rightPointer && nums[leftPointer] <= midColor) // int division for midColor, hence nums[leftPointer] <= midColor
                {
                    leftPointer++;
                }
                while (leftPointer <= rightPointer && nums[rightPointer] > midColor)
                {
                    rightPointer--;
                }

                if (leftPointer <= rightPointer)
                {
                    SwapValues(nums, leftPointer, rightPointer);
                    leftPointer++;
                    rightPointer--;
                }
            } // exit when leftPointer>rightPointer

            RainbowSortPartitionHelper(nums, leftIndex, rightPointer, fromColor, midColor);

            RainbowSortPartitionHelper(nums, leftPointer, rightIndex, midColor + 1, toColor);
        }

        /// <summary>
        ///     Swap two values in an array by index.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        private void SwapValues(int[] nums, int index1, int index2)
        {
            if (index1 < 0 ||
                index2 < 0 ||
                index1 >= nums.Length ||
                index2 >= nums.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }

    }
}

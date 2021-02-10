using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sort
{
    public class QuickSelect
    {
        /// <summary>
        ///     215. Kth Largest Element in an Array
        ///     Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.
        /// </summary>
        /// <param name="k"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int KthLargestElement(int k, int[] nums)
        {
            if (nums == null)
            {
                return -1;
            }

            return QuickSelectHelper(nums, 0, nums.Length - 1, k);
        }

        private int QuickSelectHelper(int[] nums, int start, int end, int k)
        {
            if (start >= end)
            {
                return nums[start];
            }

            // partitioning
            int left = start;
            int right = end;
            int mid = left + (right - left) / 2;
            int pivot = nums[mid];

            while (left <= right)
            {
                // find the first value that is <= pivot (descending purpose)
                while (left <= right && nums[left] > pivot)
                {
                    left++;
                }
                // find the first value that is >= pivot (descending purpose)
                while (left <= right && nums[right] < pivot)
                {
                    right--;
                }
                // swap
                if (left <= right)
                {
                    int temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;

                    // increment in order to reduce to search size
                    left++;
                    right--;
                }
            }

            // exit while loop when left>right: left|right, left|x|right
            // [...... p ......]
            //        ^ ^ 
            //        R L
            if (start + k - 1 <= right)
            {
                return QuickSelectHelper(nums, start, right, k);
            }
            if (start + k - 1 >= left)
            {
                return QuickSelectHelper(nums, left, end, k - (left - start)); // Note not k 
            }

            // there is an element in between left and right
            return nums[right + 1];
        }
    }
}

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

        /// <summary>
        ///     457. Classical Binary Search
        ///     Find any position of a target number in a sorted array. Return -1 if target does not exist.
        ///     O(logn) time
        ///     https://www.lintcode.com/problem/classical-binary-search
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindIndexTwoPointers(int[] nums, int target)
        {
            // edge case
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            int start = 0;
            int end = nums.Length - 1;
            int mid = 0;
            // NOTE 1: exit when start and end are adjacent
            while (start + 1 < end)
            {
                mid = start + (end - start) / 2; // NOTE 2: avoid overflow
                if (nums[mid] == target)
                {
                    return mid;
                }
                
                if (nums[mid] < target)
                {
                    // remove left half.
                    // NOTE : mid + 1 also works, BUT for other use cases like searching last position of a target, mid + 1 will NOT work. Using start = mid as template code!
                    start = mid;
                }

                if (nums[mid] > target)
                {
                    end = mid;
                }
            }

            // NOTE : must check both start and end
            if (nums[start] == target)
            {
                return start;
            }

            if (nums[end] == target)
            {
                return end;
            }

            return -1;
        }

        /// <summary>
        ///     458. Last Position of Target
        ///     Find the last position of a target number in a sorted array. Return -1 if target does not exist.
        ///     O(logn) time
        ///     https://www.lintcode.com/problem/last-position-of-target/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindLastPosition(int[] nums, int target)
        {
            // edge case
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            int start = 0;
            int end = nums.Length - 1;
            int mid = 0;
            // NOTE 1: exit when start and end are adjacent
            while (start + 1 < end)
            {
                mid = start + (end - start) / 2; // NOTE 2: avoid overflow
                if (nums[mid] == target)
                {
                    // last position, move start
                    start = mid;
                }

                if (nums[mid] < target)
                {
                    // remove left half.
                    // NOTE : mid + 1 also works, BUT for other use cases like searching last position of a target, mid + 1 will NOT work. Using start = mid as template code!
                    start = mid;
                }

                if (nums[mid] > target)
                {
                    end = mid;
                }
            }

            // NOTE : must check both start and end
            if (nums[end] == target)
            {
                return end;
            }
            if (nums[start] == target)
            {
                return start;
            }

            return -1;
        }

        /// <summary>
        ///     14. First Position of Target
        ///     For a given sorted array (ascending order) and a target number, find the first index of this number in O(log n) time complexity.
        ///     If the target number does not exist in the array, return -1.
        ///     O(logn) time
        ///     https://www.lintcode.com/problem/first-position-of-target/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindFirstPosition(int[] nums, int target)
        {
            // edge case
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            int start = 0;
            int end = nums.Length - 1;
            int mid = 0;
            // NOTE 1: exit when start and end are adjacent
            while (start + 1 < end)
            {
                mid = start + (end - start) / 2; // NOTE 2: avoid overflow
                if (nums[mid] == target)
                {
                    // first position, move end
                    end = mid;
                }

                if (nums[mid] < target)
                {
                    // remove left half.
                    // NOTE : mid + 1 also works, BUT for other use cases like searching last position of a target, mid + 1 will NOT work. Using start = mid as template code!
                    start = mid;
                }

                if (nums[mid] > target)
                {
                    end = mid;
                }
            }

            // NOTE : must check both start and end
            if (nums[start] == target)
            {
                return start;
            }
            if (nums[end] == target)
            {
                return end;
            }

            return -1;
        }
    }
}

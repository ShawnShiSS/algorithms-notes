using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.TwoPointers
{
    public partial class TwoPointers
    {
        /*
        // Two Sum Category
        //  - Two Sum
        //  - Three Sum : reduce O(n^3) to O(n^2) solution using Two Sum template
        //  - Triangle Count: reduce O(n^3) to O(n^2) solution using Two Sum template
        */

        /// <summary>
        ///     15. 3Sum
        ///     Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
        ///     Notice that the solution set must not contain duplicate triplets.
        ///     https://leetcode.com/problems/3sum/
        ///     Solution:
        ///     1. Sort
        ///     2. Reduce dimension from 3 sum to 2 sum, one while loop
        ///     3. Two Sum, O(N)
        ///     4. Remember to skip duplicated triplets
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            
            // edge case
            if (nums == null || nums.Length < 3)
            {
                return result;
            }

            // Sort array
            Array.Sort(nums);

            // dimension reduction
            for (int indexA = 0; indexA < nums.Length - 2; indexA++) // Note length - 2
            {
                if (indexA > 0 && nums[indexA] == nums[indexA - 1])
                {
                    // avoid duplicated triplets
                    continue;
                }

                // Two Sum and duplication check
                int left = indexA + 1;
                int right = nums.Length - 1;

                TwoSumToTargetWithoutDuplicates(nums, left, right, -nums[indexA], result);
            }

            return result;
        }

        /// <summary>
        ///     Two Sum helper to find target and skip duplicated pairs
        /// </summary>
        public void TwoSumToTargetWithoutDuplicates(int[] nums, int left, int right, int target, IList<IList<int>> result)
        {
            while(left < right)
            {
                if (nums[left] + nums[right] > target)
                {
                    right--;
                }
                else if (nums[left] + nums[right] < target)
                {
                    left++;
                }
                else
                {
                    // target found
                    result.Add(new List<int>() { -target, nums[left], nums[right] }); // IMPORTANT: -target is nums[i]
                    left++; // VERY IMPORTANT to increment after adding result.
                    right--;

                    // skip possible duplicates
                    while (left < right && nums[left] == nums[left - 1])
                    {
                        left++;
                    }

                    while(left < right && nums[right] == nums[right + 1])
                    {
                        right--;
                    }
                }
            } 

        }

    }
}

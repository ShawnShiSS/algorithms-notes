using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DepthFirstSearch
{
    /// <summary>
    ///     Using DFS to solve combination type questions, e.g. subsets
    /// </summary>
    public partial class DepthFirstSearch
    {
        /// <summary>
        ///     78. Subsets
        ///     Given an integer array nums of unique elements, return all possible subsets (the power set).
        ///     The solution set must not contain duplicate subsets.Return the solution in any order.
        ///     https://leetcode.com/problems/subsets/
        ///     Solution: DFS template without duplicates
        ///     90. Subsets II
        ///     Given an integer array nums that may contain duplicates, return all possible subsets (the power set).
        ///     The solution set must not contain duplicate subsets.Return the solution in any order.
        ///     https://leetcode.com/problems/subsets-ii/
        ///     Solution: DFS template with duplicates
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            // edge case
            // note: empty array should return one subset
            if (nums == null)
            {
                return result;
            }

            // Must sort in order to have numbers in a subset ascending
            Array.Sort(nums);

            // DFS with recursion
            DfsCombinationWithoutDuplicatesTemplateHelper(nums, 0, new List<int>(), result);

            return result;
        }

        /// <summary>
        ///     Traverse an array to find all the subsets that start with subset,
        ///     and add the subsets to result in place
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="startIndex"></param>
        /// <param name="subset"></param>
        /// <param name="result"></param>
        private void DfsCombinationWithoutDuplicatesTemplateHelper(int[] nums,
                                                  int startIndex,
                                                  IList<int> subset,
                                                  IList<IList<int>> result)
        {
            // Recursion exit
            // Deep copy the subset into result
            result.Add(new List<int>(subset));

            // Recursion 
            for(int i = startIndex; i < nums.Length; i++)
            {
                // add the current element to the subset
                subset.Add(nums[i]);
                // search all the subsets that start with the subset
                DfsCombinationWithoutDuplicatesTemplateHelper(nums, i + 1, subset, result);

                // backtracking, must remove the current element 
                subset.RemoveAt(subset.Count - 1);
            }
        }

        /// <summary>
        ///     Traverse an array to find all the subsets that start with subset,
        ///     and add the subsets to result in place.
        ///     Note the array, nums, may have duplicated elements.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="startIndex"></param>
        /// <param name="subset"></param>
        /// <param name="result"></param>
        private void DfsCombinationWithDuplicatesTemplateHelper(int[] nums,
                                                  int startIndex,
                                                  IList<int> subset,
                                                  IList<IList<int>> result)
        {
            // Recursion exit
            // Deep copy the subset into result
            result.Add(new List<int>(subset));

            // Recursion 
            for (int i = startIndex; i < nums.Length; i++)
            {
                // Must remove duplicates
                // Another way to avoid duplicates is to use a Hashset to track all subsets already in result.
                if (i > 0 && // Out of bound check
                    nums[i] == nums[i-1] && // same number already added for the current recursion
                    i > startIndex // not the first time seeing this element
                    )
                {
                    continue;
                }

                // add the current element to the subset
                subset.Add(nums[i]);
                // search all the subsets that start with the subset
                DfsCombinationWithDuplicatesTemplateHelper(nums, i + 1, subset, result);

                // backtracking, must remove the current element 
                subset.RemoveAt(subset.Count - 1);
            }
        }

        /// <summary>
        ///     90. Subsets II
        ///     Given an integer array nums that may contain duplicates, return all possible subsets (the power set).
        ///     The solution set must not contain duplicate subsets.Return the solution in any order.
        ///     https://leetcode.com/problems/subsets-ii/
        ///     Solution: use subsets template with Hashset to avoid duplicates
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsII(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            HashSet<string> existingSubsets = new HashSet<string>();

            // edge case
            // note: empty array should return one subset
            if (nums == null)
            {
                return result;
            }

            // Must sort in order to have numbers in a subset ascending
            Array.Sort(nums);

            // DFS with recursion
            DfsCombinationWithoutDuplicatesTemplateHelperII(nums, 0, new List<int>(), result, existingSubsets);

            return result;
        }

        /// <summary>
        ///     Traverse an array to find all the subsets that start with subset,
        ///     and add the subsets to result in place.
        ///     Note the array, nums, may have duplicated elements.
        ///     Use HashSet to handle possible duplicates
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="startIdex"></param>
        /// <param name="subset"></param>
        /// <param name="result"></param>
        /// <param name="existingSubsets"></param>
        private void DfsCombinationWithoutDuplicatesTemplateHelperII(int[] nums,
                                                                     int startIdex,
                                                                     IList<int> subset,
                                                                     IList<IList<int>> result,
                                                                     HashSet<string> existingSubsets)
        {
            // avoid duplicates
            if (existingSubsets.Contains(string.Join("_", subset)))
            {
                return;
            }

            // exit
            existingSubsets.Add(string.Join("_", subset));
            result.Add(new List<int>(subset));

            // break down recursion
            for (int i = startIdex; i < nums.Length; i++)
            {
                subset.Add(nums[i]);
                // Search all the combinations starting with subset with a starting index of i + 1
                DfsCombinationWithoutDuplicatesTemplateHelperII(nums, i + 1, subset, result, existingSubsets);

                // backtracking
                subset.RemoveAt(subset.Count - 1);
            }

        }
    }
}

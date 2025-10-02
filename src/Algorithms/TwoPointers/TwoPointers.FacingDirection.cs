using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.TwoPointers
{
    public partial class TwoPointers
    {
        /// <summary>
        ///     LeetCoce 125. Valid Palindrome
        ///     Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        ///     https://leetcode.com/problems/valid-palindrome/
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Boolean value indicating whether input is valid palindrome</returns>
        public bool IsValidPalindrome(string input)
        {
            // edge case
            if (String.IsNullOrEmpty(input))
            {
                return true;
            }

            // Two Pointers - facing direction
            int left = 0;
            int right = input.Length - 1;

            while(left < right)
            {
                // skip chars that are not letters or digits
                while (left < right && !Char.IsLetterOrDigit(input[left]))
                {
                    left++;
                }
                while (left < right && !Char.IsLetterOrDigit(input[right]))
                {
                    right--;
                }

                // comparison ignoring case
                if (!CharsMeetParlindromeRequirement(input[left], input[right]))
                {
                    return false;
                }
                left++;
                right--;
                
            }

            // exit when left >= right, indicating string is valid palindrome
            return true;
        }

        /// <summary>
        ///     Whehter char a and b match for the purpose of palindrome check,
        ///     E.g., ignoring case
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool CharsMeetParlindromeRequirement(char a, char b)
        {
            return Char.ToLower(a) == Char.ToLower(b);
        }

        /// <summary>
        ///     680. Valid Palindrome II
        ///     Given a non-empty string s, you may delete at most one character. Judge whether you can make it a palindrome.
        ///     The string will only contain lowercase characters a-z. The maximum length of the string is 50000.
        ///     https://leetcode.com/problems/valid-palindrome-ii/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValidPalindromeII(string input)
        {
            // Edge case
            if (String.IsNullOrEmpty(input))
            {
                return true;
            }

            // whether input is already a palindrome
            int left = 0;
            int right = input.Length - 1;
            while (left < right)
            {
                if (!CharsMeetParlindromeRequirement(input[left], input[right]))
                {
                    // unmatched chars found, leave while loop in order to check whether we can remove one char to make it a palindrome
                    break;
                }
                left++;
                right--;
            }
            if (left >= right)
            {
                // exit when left >= right, indicating valid palindrome
                return true;
            }

            return IsPalindrome(input, left + 1, right) || IsPalindrome(input, left, right - 1);

        }

        /// <summary>
        ///     Whether a substring is palindrome.
        ///     The string will only contain lowercase characters a-z.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public bool IsPalindrome(string input, int left, int right)
        {
            while (left < right)
            {
                if (!CharsMeetParlindromeRequirement(input[left], input[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
            // exit when left >= right, indicating valid palindrome
            return true;
        }

        /// <summary>
        ///     1. Two Sum
        ///     Given an array of integers nums and an integer target, 
        ///     return INDICES of the two numbers such that they add up to target.
        ///     You may assume that each input would have exactly one solution, 
        ///     and you may not use the same element twice.
        ///     You can return the answer in any order.
        ///     https://leetcode.com/problems/two-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSumUsingDictionary(int[] nums, int target)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            int[] result = new int[2] { -1, -1};

            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (dictionary.ContainsKey(diff))
                {
                    // Match found
                    result[0] = dictionary[diff];
                    result[1] = i;
                    return result;
                }

                // add to dictionary, key = num, value = index of current number
                dictionary.Add(nums[i], i);
            }

            return result;
        }

        /// <summary>
        ///     1. Two Sum (variation)
        ///     Given an array of integers nums and an integer target, 
        ///     return THE TWO NUMBERS such that they add up to target.
        ///     You may assume that each input would have exactly one solution, 
        ///     and you may not use the same element twice.
        ///     You can return the answer in any order.
        ///     https://leetcode.com/problems/two-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSumUsingTwoPointers(int[] nums, int target)
        {
            int[] result = new int[2] { -1, -1 };
            
            // Step 1 - sort. O(NLogN) time
            Array.Sort(nums);
            var sortedNums = nums.OrderBy(n => n); // Lazy execution

            // Step 2 - two pointers O(N) time
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
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
                    result[0] = nums[left];
                    result[1] = nums[right];
                    return result;
                }
            }
            // exit when left >= right, no match found
            return result;
        }

        /// <summary>
        ///     Sort an array using Quick Sort
        /// </summary>
        /// <param name="nums"></param>
        public void QuickSort(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return;
            }

            QuickSortHelper(nums, 0, nums.Length - 1);
        }

        /// <summary>
        ///     Sort an array in place given indexes using Quick Sort
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void QuickSortHelper(int[] nums, int start, int end)
        {
            // single char or bad request
            if (start >= end)
            {
                return;
            }

            int left = start;
            int right = end;
            // partitioning using pivot and two pointers
            int mid = left + (right - left) / 2;
            int pivot = nums[mid]; // NOTE pivot is an array element, not index

            // NOTE left <= right, NOT left < right, to ensure sorting range gets smaller
            while (left <= right)
            {
                // Find first value on the left half that is >= pivot
                while (left <= right && nums[left] < pivot)
                {
                    left++;
                }
                // Find first value on the right half that is <= pivot
                while (left <= right && nums[right] > pivot)
                {
                    right--;
                }
                if (left <= right) // required
                {
                    // swap
                    int temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;

                    left++;
                    right--;
                }
            }

            // exit while when left > right, ensuring the two halves are not overlapping
            QuickSortHelper(nums, start, right);
            QuickSortHelper(nums, left, end);
        }


        
    }
}

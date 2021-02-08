using System;

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
        public bool IsPalindrome(string input)
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
        

    }
}

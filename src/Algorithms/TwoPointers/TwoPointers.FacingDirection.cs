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

    }
}

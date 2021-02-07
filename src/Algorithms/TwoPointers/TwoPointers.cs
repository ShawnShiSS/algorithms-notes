using System;

namespace Algorithms.TwoPointers
{
    public class TwoPointers
    {
        /// <summary>
        ///     LeetCoce 125. Valid Palindrome
        ///     Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
                if (Char.ToLower(input[left]) != Char.ToLower(input[right]))
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }

        

    }
}

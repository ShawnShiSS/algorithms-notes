using System.Collections.Generic;
using System.Text;

namespace Algorithms.Stack
{
    public class Parenthesis
    {
        /// <summary>
        ///     1249. Minimum Remove to Make Valid Parentheses
        ///     https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MinRemoveToMakeValid(string s)
        {
            // Approach
            // Scan the string from right to left and record the closing brackets in a stack
            // Everytime a opening bracket is found, remove one closing bracket.
            // Rebuild a new string with the necessary brackets removed
            // Return the new string

            // corner cases
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            // A stack to track all the closing brackets (NOT used by a opening bracket yet) to the right side of an element.
            Stack<int> stack = new Stack<int>();
            HashSet<int> indexesToRemove = new HashSet<int>();

            // Because of "right side" and stack is FIFO, we have to start from the right end
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ')')
                {
                    stack.Push(i);
                    continue;
                }
                else if (s[i] == '(')
                {
                    // If there is any closing bracket to the right side of it, i.e., in the stack,
                    // remove the closing bracket from the stack and continue.
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                        continue;
                    }

                    // Otherwise, this opening bracket can not be properly closed and needs to be removed from the string.
                    indexesToRemove.Add(i);
                }
                else
                {
                    // letters, do nothing.
                    continue;
                }
            }

            // If there are any remaining closing brackets in the stack, remove them from string too.
            while (stack.Count > 0)
            {
                int charIndex = stack.Pop();
                indexesToRemove.Add(charIndex);
            }

            return RebuildStringWithCharsRemoved(s, indexesToRemove);
        }

        private string RebuildStringWithCharsRemoved(string s, HashSet<int> indexesToRemove)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (indexesToRemove.Contains(i))
                {
                    continue;
                }

                sb.Append(s[i]);
            }

            return sb.ToString();
        }
    }
}

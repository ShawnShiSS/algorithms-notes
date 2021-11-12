using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Stack
{

    public class Decode
    {
        public string DecodeString(string s)
        {
            // Goal
            // - Scan the string char by char
            // - put everything into a stack to track them
            // - when a ] is found, we need to decode everything in the bracket and put them back into the stack
            // Note: input is guaranteed to be valid.

            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            // Scan all chars
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ']')
                {
                    stack.Push(s[i]);
                    continue;
                }

                // When a ] is found, 
                // we need to decode everything in the bracket and put them back into the stack
                char current = stack.Pop(); // Start with letter
                List<char> charsToBeDecoded = new List<char>();

                while (current != '[')
                {
                    charsToBeDecoded.Add(current);
                    current = stack.Pop();
                }

                // Exit when current == '['
                // Get the multiplier k, and push the decoded chars back to the stack
                int k = (int)stack.Pop();
                PushListToStackMultipleTimes(charsToBeDecoded, stack, k);
            }

            // Now the stack should represent all the decoded chars
            return BuildStringFromStack(stack);
        }

        private void PushListToStackMultipleTimes(List<char> charsToBeDecoded, Stack<char> stack, int k)
        {
            // Push the whole list into the stack for k times
            for (int i = 0; i < k; i++)
            {
                for (int j = charsToBeDecoded.Count - 1; j >= 0; j--)
                {
                    stack.Push(charsToBeDecoded[j]);
                }
            }
        }

        private string BuildStringFromStack(Stack<char> stack)
        {
            StringBuilder sb = new StringBuilder();

            while (stack.Count > 0)
            {
                char currentChar = stack.Pop();
                sb.Insert(0, currentChar);
            }

            return sb.ToString();
        }
    }
}

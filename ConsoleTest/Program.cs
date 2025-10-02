using Algorithms.DepthFirstSearch;
using Algorithms.DynamicProgramming;
using Algorithms.Queue;
using Algorithms.Tree;
using Algorithms.Trie;
using Algorithms.TwoPointers;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            int n = solution.CharacterReplacement("AABABBA", 1);

            Console.WriteLine("goodbye");
        }


        
    }
}


public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        // Edge cases
        if (String.IsNullOrEmpty(s))
        {
            return 0;
        }

        Dictionary<char, int> freq = new Dictionary<char, int>();
        int max = 0;

        // Two pointers
        int left = 0;
        int right = 0;
        while (right < s.Length)
        {
            Console.WriteLine($"checking substring: {s.Substring(left, right - left + 1)}");
            // Increment freq in order to lookup the most frequent char in substring
            if (!freq.ContainsKey(s[right]))
            {
                freq.Add(s[right], 0);
            }
            freq[s[right]]++;

            // If we can replace chars and make a repeating substring
            int length = right - left + 1;
            if (IsValid(freq, length, k))
            {
                Console.WriteLine($"Valid substring {s.Substring(left, right - left + 1)}: {left} to {right}");
                // length - most freq <= k
                max = Math.Max(max, length);
                right++;
            }
            else
            {
                // Remove the char that is now not part of our substring
                freq[s[left]]--;
                left++;

            }
        }

        return max;
    }

    // Whether length - most freq <= k
    private bool IsValid(Dictionary<char, int> freq, int length, int k)
    {
        int mostFreq = GetMostFreq(freq);
        return length - mostFreq <= k;
    }

    private int GetMostFreq(Dictionary<char, int> freq)
    {
        int max = 0;
        foreach (int f in freq.Values)
        {
            max = Math.Max(f, max);
        }
        return max;
    }
}

// AABABBA, k = 1
//     L
//       R
// lookup:  A:1, B:2
// current: (R-L)+1 if substring is valid: length - most freq <= k
// current: 4
// max: Math.Max(max, current)
// max: 4
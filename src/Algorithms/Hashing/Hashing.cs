using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Hashing
{
    public static class Hashing
    {
        /// <summary>
        ///     128. Hash Function
        ///     Given a string as a key and the size of hash table, return the hash value of this key.
        ///     https://www.lintcode.com/problem/hash-function/
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hashSize"></param>
        /// <returns></returns>
        public static int HashCode(string input, int hashSize)
        {
            long answer = 0;

            for (int i = 0; i < input.Length; i++)
            {
                answer = (answer * 33 + (int)input[i]) % hashSize;
            }

            return (int) answer;
        }
    }
}

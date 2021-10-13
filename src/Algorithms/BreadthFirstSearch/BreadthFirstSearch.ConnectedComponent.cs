using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.BreadthFirstSearch
{
    public partial class BreadthFirstSearch
    {
        /// <summary>
        ///     127. Word Ladder.
        ///     https://leetcode.com/problems/word-ladder/
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            // Goal
            //  - Build a search graph that connects begin to end
            //  - Each word is a node on the search graph

            // Build actual dictionary for lookup from the list
            HashSet<string> dictionary = BuildDictionaryFromList(wordList);
            // Add begin word to the dictionary
            dictionary.Add(beginWord);

            // Search from beginWord to endWord by changing one letter at a time
            int shortestSequence = SearchHelper(beginWord, endWord, dictionary);

            return shortestSequence;
        }
        
        private int SearchHelper(string beginWord, string endWord, HashSet<string> dictionary)
        {
            // Breadth First Search for shortest path from begin to end
            // Edge cases
            if (String.Equals(beginWord, endWord))
            {
                // Two words
                return 2;
            }

            // Initialize 
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            int layer = 0;

            while (queue.Count > 0)
            {
                layer++;
                int layerSize = queue.Count;

                for (int i = 0; i < layerSize; i++)
                {
                    string currentWord = queue.Dequeue();
                    // Get all possible words that can derive from current word, including itself
                    List<string> possibleWords = GetPossibleWords(currentWord, dictionary);

                    foreach (var word in possibleWords)
                    {
                        if (String.Equals(word, endWord))
                        {
                            // return layer;
                            // Since we are counting the number of words, need to add 1 for endWord.
                            return layer + 1;
                        }

                        queue.Enqueue(word);
                    }
                }

            }

            // Not found
            return 0;

        }

        private List<string> GetPossibleWords(string word, HashSet<string> dictionary)
        {
            // Criteria: 
            // Transform by one letter, and exist in the dictionary
            // Include the word itself
            // Remove words that are returned

            List<string> result = new List<string>();

            if (word == null || word.Length == 0)
            {
                return result;
            }

            // Include the word itself first
            if (dictionary.Contains(word))
            {
                result.Add(word);
                dictionary.Remove(word);
            }

            // For each letter in the word, we will swap it with one of the 26 letters and see if it makes a actual new word
            for (int i = 0; i < word.Length; i++)
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    string transformedWord = SwapLetter(word, i, c);
                    if (dictionary.Contains(transformedWord))
                    {
                        result.Add(transformedWord);
                        dictionary.Remove(transformedWord);
                    }
                }
            }

            return result;
        }

        private string SwapLetter(string word, int i, char c)
        {
            char[] chars = word.ToCharArray();
            chars[i] = c;

            return new string(chars);
        }


        private HashSet<string> BuildDictionaryFromList(IList<string> wordList)
        {
            HashSet<string> result = new HashSet<string>();

            foreach (var word in wordList)
            {
                result.Add(word);
            }

            return result;
        }
    }
}

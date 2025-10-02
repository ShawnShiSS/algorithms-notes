using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Trie
{
    // Trie tree
    //                  ""
    //          h                   t
    //      e       i*                   i
    //  r*      m*      s*                  m*

    public class TrieTreeMachine
    {
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            // corner case
            // corner cases
            if (searchWord == null || searchWord.Length == 0)
            {
                return new List<IList<string>>();
            }

            // build a search Trie tree
            TrieTree tree = new TrieTree(products);

            // search all prefixes in the trie tree
            return tree.SearchByWord(searchWord);
        }

    }


    public class TrieTree
    {
        private Node _root;

        public TrieTree(string[] words)
        {
            this._root = new Node(null, false);
            // Iterate each word and insert word into the trie tree
            foreach (string word in words)
            {
                Insert(word);
            }
        }

        private void Insert(string word)
        {
            Node current = _root;

            // Add each char to the tree, if needed
            for (int i = 0; i < word.Length; i++)
            {
                int charIndex = word[i] - 'a';
                bool isWordEnd = i == word.Length - 1;
                if (current.Children[charIndex] == null)
                {
                    current.Children[charIndex] = new Node(word[i], isWordEnd);
                }
                else
                {
                    // Word end for a previous word or current word
                    current.Children[charIndex].IsWordEnd = current.Children[charIndex].IsWordEnd || isWordEnd;
                }

                // Move current pointer to the newly iterated char
                current = current.Children[charIndex];
            }

        }

        // Search all prefixes of a word
        public IList<IList<string>> SearchByWord(string word)
        {
            IList<IList<string>> result = new List<IList<string>>();

            string prefix = "";
            foreach (char c in word)
            {
                prefix += c; // e.g. mouse
                var prefixResult = SearchByPrefix(prefix);
                result.Add(new List<string>(prefixResult));
            }

            return result;
        }

        // Search all words on the trie tree that start with <prefix>. E.g. hi
        public IList<string> SearchByPrefix(string prefix)
        {
            IList<string> result = new List<string>();

            // Traverse to the prefix branch 
            Node current = _root;
            for (int i = 0; i < prefix.Length; i++)
            {
                int charIndex = prefix[i] - 'a';
                if (current.Children[charIndex] == null)
                {
                    return result;
                }

                // Move current pointer till it points to the last char of the prefix, 
                // e.g. i for hi, e for mouse
                current = current.Children[charIndex];
            }

            // Search all words that start with prefix
            DfsSearchHelper(current, prefix, result);

            return result;
        }

        private void DfsSearchHelper(Node start, string prefix, IList<string> result)
        {
            // Exit when we have found 3 
            if (result.Count == 3)
            {
                return;
            }

            // Add to result, if needed
            if (start.IsWordEnd)
            {
                result.Add(prefix);
            }

            // Search further down the trie tree
            for (int i = 0; i < start.Children.Length; i++)
            {
                if (start.Children[i] == null)
                {
                    continue;
                }

                string newPrefixToSearch = prefix + start.Children[i].Value;
                DfsSearchHelper(start.Children[i], newPrefixToSearch, result);
            }
        }

    }

    public class Node
    {
        public Node(char? value, bool isWordEnd)
        {
            Value = value;
            IsWordEnd = isWordEnd;
            Children = new Node[26]; // a-z, 26 letters
        }

        public char? Value { get; set; }
        public bool IsWordEnd { get; set; }
        public Node[] Children { get; set; }

    }

}


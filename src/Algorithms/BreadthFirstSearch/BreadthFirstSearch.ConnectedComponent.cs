using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.BreadthFirstSearch
{
    public partial class BreadthFirstSearch
    {
        #region Word Ladder
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
        #endregion

        #region Number of Islands
        /// <summary>
        ///     200. Number of Islands
        ///     https://leetcode.com/problems/number-of-islands/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            // Goal
            // - Iterate all pixels / elements in the grid
            // - For every island found, we record it and remove it
            // - return the number of islands removed

            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }

            int islandCount = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row][col] == '0')
                    {
                        continue;
                    }

                    islandCount++;
                    RemoveIslandFromGrid(grid, row, col);
                }
            }

            return islandCount;
        }

        private void RemoveIslandFromGrid(char[][] grid, int row, int col)
        {
            // Need to remove all adjascent '1's that are part of the island
            // BFS search approach

            Queue<Coordinate> queue = new Queue<Coordinate>();
            // HashSet<string> visitedCoordinates = new HashSet<string>();

            queue.Enqueue(new Coordinate(row, col));
            grid[row][col] = '0';

            while (queue.Count > 0)
            {
                Coordinate current = queue.Dequeue();
                // visitedCoordinates.Add(current.Row+":"+current.Col);

                var adjacentCoordinates = GetAdjacentIslandCoordinates(grid, current.Row, current.Col);

                foreach (var coordinate in adjacentCoordinates)
                {
                    if (grid[coordinate.Row][coordinate.Col] == '0')
                    // || visitedCoordinates.Contains(coordinate.Row + ":" + coordinate.Col))
                    {
                        // Not island, or was island and has been removed
                        continue;
                    }

                    queue.Enqueue(coordinate);
                    grid[coordinate.Row][coordinate.Col] = '0';
                }
            }

        }

        private List<Coordinate> GetAdjacentIslandCoordinates(char[][] grid, int row, int col)
        {
            List<Coordinate> result = new List<Coordinate>();
            // Get adjacent 1s
            // Validate boundary
            int[] xDirections = new int[] { -1, 0, 1, 0 };
            int[] yDirections = new int[] { 0, -1, 0, 1 };

            for (int i = 0; i < xDirections.Length; i++)
            {
                Coordinate coordinate = new Coordinate(row + xDirections[i], col + yDirections[i]);
                if (IsValidCoordinate(grid, coordinate) && grid[coordinate.Row][coordinate.Col] == '1')
                {
                    result.Add(coordinate);
                }
            }

            return result;
        }

        private bool IsValidCoordinate(char[][] grid, Coordinate coordinate)
        {
            return coordinate.Row >= 0 && coordinate.Row < grid.Length &&
                   coordinate.Col >= 0 && coordinate.Col < grid[0].Length;
        }

        // Grid coordinate
        public class Coordinate
        {
            public Coordinate(int row, int col)
            {
                Row = row;
                Col = col;
            }

            public int Row { get; set; }
            public int Col { get; set; }
        }
        #endregion

        #region Knight shortest path
        public class Point
        {
            public int x { get; set; }
            public int y { get; set; }
            public Point() { x = 0; y = 0; }
            public Point(int a, int b) { x = a; y = b; }
        }
        public int shortestPath(bool[][] grid, Point source, Point destination)
        {
            // Goal
            // Search the possbile positions after each move until
            //  - either we get to the destination
            //  - or, we have no more possible moves

            // Edge cases
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return -1;
            }

            if (AreEqual(source, destination))
            {
                return 0;
            }

            // Breadth First Search         
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(source);
            // Mark the position as visited by marking it as barrier (we could also track the visited positions instead)
            MarkAsBarrier(grid, source);

            int numberOfMoves = 0;
            while (queue.Count > 0)
            {
                int queueSize = queue.Count;

                for (int i = 0; i < queueSize; i++)
                {
                    Point current = queue.Dequeue();
                    if (AreEqual(current, destination))
                    {
                        return numberOfMoves;
                    }

                    var nextPoints = GetNextPoints(grid, current);
                    foreach (var next in nextPoints)
                    {
                        queue.Enqueue(next);
                        MarkAsBarrier(grid, next);
                    }
                }

                numberOfMoves++;

            }

            return numberOfMoves;
        }

        private List<Point> GetNextPoints(bool[][] grid, Point current)
        {
            List<Point> result = new List<Point>();
            int[] xDirections = new int[] { 1, 1, -1, -1, 2, 2, -2, -2 };
            int[] yDirections = new int[] { 2, -2, 2, -2, 1, -1, 1, -1 };

            for (int i = 0; i < xDirections.Length; i++)
            {
                Point position = new Point(current.x + xDirections[i], current.y + yDirections[i]);
                if (IsValidPoint(grid, position))
                {
                    result.Add(position);
                }
            }

            return result;
        }

        private bool IsValidPoint(bool[][] grid, Point position)
        {
            // 1. Must be empty
            // 2. Must be in bound
            return grid[position.x][position.y] == false &&
                   position.x >= 0 && position.x < grid.Length &&
                   position.y >= 0 && position.y < grid[0].Length;
        }

        private bool AreEqual(Point source, Point destination)
        {
            return source.x == destination.x && source.y == destination.y;
        }

        private void MarkAsBarrier(bool[][] grid, Point point)
        {
            grid[point.x][point.y] = true;
        }
        #endregion
    }
}

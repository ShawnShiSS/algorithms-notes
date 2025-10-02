using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Queue
{
    public class Element
    {
        public Element(int row, int col, int value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }
        public int Row { get; set; }
        public int Col { get; set; }
        public int Value { get; set; }
    }

    public interface IIterator
    {
        bool HasNext();
        Element Next();
        void Reset();
    }
    
    public class JaggedArrayIterator : IIterator
    {
        private Queue<Element> _queue;
        private readonly int[][] _input;

        public JaggedArrayIterator(int[][] input)
        {
            _queue = InitializeQueueWithFirstElements(input);
            _input = input;
        }

        public bool HasNext()
        {
            return _queue.Count > 0;
        }

        public Element Next()
        {
            if (!HasNext())
            {
                return null;
            }

            // Dequeue the next element
            Element current = _queue.Dequeue();

            // If next has its next, enqueue the next.next element
            if (current.Col + 1 < _input[current.Row].Length)
            {
                _queue.Enqueue(new Element(current.Row, current.Col + 1, _input[current.Row][current.Col + 1]));
            }

            return current;
        }

        public void Reset()
        {
            this._queue = InitializeQueueWithFirstElements(_input);
        }

        private Queue<Element> InitializeQueueWithFirstElements(int[][] input)
        {
            Queue<Element> queue = new Queue<Element>();
            for (int row = 0; row < input.Length; row++)
            {
                if (input[row] != null &&
                    input[row].Length > 0)
                {
                    queue.Enqueue(new Element(row, 0, input[row][0]));
                }
            }

            return queue;
        }
    }
}

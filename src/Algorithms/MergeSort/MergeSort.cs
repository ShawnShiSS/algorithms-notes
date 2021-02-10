using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.MergeSort
{
    public class MergeSort
    {
        /// <summary>
        ///     6. Merge Two Sorted Arrays
        ///     Merge two given sorted ascending integer array A and B into a new sorted integer array.
        ///     https://www.lintcode.com/problem/merge-two-sorted-arrays/
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public int[] MergeSortArray(int[] arrayA, int[] arrayB)
        {
            // edge cases
            if (arrayA == null && arrayB == null)
            {
                return null;
            }
            
            if (arrayA == null)
            {
                return arrayB;
            }

            if (arrayB == null)
            {
                return arrayA;
            }

            int[] result = new int[arrayA.Length + arrayB.Length];
            int pointerA = 0;
            int pointerB = 0;
            int currentIndex = 0;

            while (pointerA < arrayA.Length && pointerB < arrayB.Length)
            {
                if (arrayA[pointerA] <= arrayB[pointerB])
                {
                    result[currentIndex] = arrayA[pointerA];
                    currentIndex++;
                    pointerA++;
                }
                else
                {
                    result[pointerB] = arrayA[pointerB];
                    currentIndex++;
                    pointerB++;
                }
            }

            // exit when one of the pointers get to the end of the arrays
            // ONLY one of the following while loops get executed
            while (pointerA < arrayA.Length)
            {
                result[currentIndex] = arrayA[pointerA];
                currentIndex++;
                pointerA++;
            }
            while (pointerB < arrayB.Length)
            {
                result[currentIndex] = arrayB[pointerB];
                currentIndex++;
                pointerB++;
            }

            return result;
        }
    }
}

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
        public int[] MergeTwoSortedArrays(int[] arrayA, int[] arrayB)
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

        /// <summary>
        ///     Sort an array using Merge Sort
        /// </summary>
        /// <param name="nums"></param>
        public void MergeSortArray(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return;
            }

            int[] temp = new int[nums.Length];
            MergeSortHelper(nums, 0, nums.Length - 1, temp);
        }

        /// <summary>
        ///     Sort an array between two indexes using Merge Sort
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="temp"></param>
        private void MergeSortHelper(int[] nums, int start, int end, int[] temp)
        {
            if (start >= end)
            {
                return;
            }

            int mid = start + (end - start) / 2;
            // Sort left half
            MergeSortHelper(nums, start, mid, temp);
            // Sort right half
            MergeSortHelper(nums, mid + 1, end, temp);

            // Merge the two sorted halves
            Merge(nums, start, end, temp);
        }

        /// <summary>
        ///     Merge two sorted arrays array given two indexes and a temp array for merging
        /// </summary>
        /// <param name="nums">Original array</param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="temp"></param>
        private void Merge(int[] nums, int start, int end, int[] temp)
        {
            // Find the two halves of the array that are already sorted
            int mid = start + (end - start) / 2;
            int left = start; 
            int right= (start + end) / 2 + 1;
            int tempIndex = start;

            // Merge the two sorted halves
            while (left <= mid && right <= end)
            {
                if (nums[left] <= nums[right])
                {
                    temp[tempIndex] = nums[left];
                    tempIndex++;
                    left++;
                }
                else
                {
                    temp[tempIndex] = nums[right];
                    tempIndex++;
                    right++;
                }
            }

            // exit when one of the two pointers reach the end of its half
            // ONLY one of the while loop gets executed
            while (left <= mid)
            {
                temp[tempIndex] = nums[left];
                tempIndex++;
                left++;
            }
            while (right <= end)
            {
                temp[tempIndex] = nums[right];
                tempIndex++;
                right++;
            }

            // Numbers in temp are sorted between start and end
            // copy values to nums
            for(int i = left; i <= right; i++)
            {
                nums[i] = temp[i];
            }
        }
    }
}

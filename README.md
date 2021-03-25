# Algorithms Notes in C#
Summary notes on how to apply template code for algorithms on top interview questions on data structures and algorithms in C# for study purpose.

## Goal
Organize the C# solutions to the most-frequently-asked data structure and algorithms questions by category, with heavy comments on
- time complexity and space complexity
- edge cases handling
- key points to avoid bugs
- bug free templates

## Algorithms and Typical Interview Questions
- **Two Pointers**
  - Same Direction
    - [LeetCode: Number of Substrings With Only 1s](https://leetcode.com/problems/number-of-substrings-with-only-1s/), see notes in [TwoPointers.SameDirection.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/TwoPointers/TwoPointers.SameDirection.cs)
    - [LintCode: Two Sum - Difference equals to target](https://www.lintcode.com/problem/two-sum-difference-equals-to-target/), see notes in [TwoPointers.SameDirection.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/TwoPointers/TwoPointers.SameDirection.cs)
  - Facing Direction
    - [LeetCode: Valid Palindrome](https://leetcode.com/problems/valid-palindrome/), see notes in [TwoPointers.FacingDirection.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/TwoPointers/TwoPointers.FacingDirection.cs)
    - [Valid Palindrome II](https://leetcode.com/problems/valid-palindrome-ii/), see notes in [TwoPointers.FacingDirection.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/TwoPointers/TwoPointers.FacingDirection.cs)
    - [LeetCode: Two Sum](https://leetcode.com/problems/two-sum/), see notes in [TwoPointers.FacingDirection.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/TwoPointers/TwoPointers.FacingDirection.cs)
    - [Leetcode: Three Sum](https://leetcode.com/problems/3sum/), see notes in [TwoPointers.FacingDirection.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/TwoPointers/TwoPointers.FacingDirection.cs)
    - [Leetcode: Sort Colors](https://leetcode.com/problems/sort-colors/), see notes in [TwoPointers.FacingDirection.PartitionType.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/TwoPointers/TwoPointers.FacingDirection.PartitionType.cs)
    - [Lintcode: Rainbow Sort, AKA, Sort K Colors](https://www.lintcode.com/problem/143/), see notes in [TwoPointers.FacingDirection.PartitionType.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/TwoPointers/TwoPointers.FacingDirection.PartitionType.cs)
    - [Lintcode: Partition Array](https://www.lintcode.com/problem/partition-array/), see notes in [TwoPointers.FacingDirection.PartitionType.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/TwoPointers/TwoPointers.FacingDirection.PartitionType.cs)
    - [Leetcode: Move Zeros](https://leetcode.com/problems/move-zeroes/), see notes in [TwoPointers.FacingDirection.PartitionType.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/TwoPointers/TwoPointers.FacingDirection.PartitionType.cs)
  - Opposite Direction
- **Sorting**
  - Quick Sort
  - Merge Sort
    - Merge Two Sorted Arrays
  - Quick Select
    - Kth Largest Element
- **Binary Search**
  - Recursion 
  - Non-recursion template
    - Classic binary search 
    - First position of target
    - Last position of target
    - Peak Index in a Mountain Array
- **Breadth First Search**
  - BFS template to traverse a Tree using a single Queue
  - BFS template to traverse a Graph using a single Queue and a single Dictionary
    - [Topological Sorting](https://www.lintcode.com/problem/topological-sorting/)
  - BFS template variation
    -  - [Leetcode: Subsets](https://leetcode.com/problems/subsets/), see BreadthFirstSearch.cs
- **Depth First Search** 
  - DFS without recursion (using stack)
    - Binary Search Tree In-Order Traversal Template Code using Stack
    - [Leetcode: Binary Search Tree Iterator](https://leetcode.com/problems/binary-search-tree-iterator/)
    - [Leetcode: Kth Smallest Element in a BST](https://leetcode.com/problems/kth-smallest-element-in-a-bst/)
  - DFS template for binary trees with recursion plus backtracking
    - [Leetcode: Binary Tree Paths](https://leetcode.com/problems/binary-tree-paths/)  
    - [Leetcode: Triangle](https://leetcode.com/problems/triangle/)
  - DFS template for N-ary search trees with recursion plus backtracking
    - Template code for combination type questions on non-tree structures. E.g. searching for all possible combinations
    - [Leetcode: Subsets](https://leetcode.com/problems/subsets/)
    - [Leetcode: Subsets ii](https://leetcode.com/problems/subsets-ii/)
    - Template code for permutation type questions. E.g., search all permutations
    - [LeetCode: Permutations](https://leetcode.com/problems/permutations/)
  - DFS with Memorization Search
    - [Leetcode: Triangle](https://leetcode.com/problems/triangle/), see notes in [DepthFirstSearch.BinaryTreeRecursionTemplate.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/DepthFirstSearch/DepthFirstSearch.BinaryTreeRecursionTemplate.cs)   
    - [LeetCode: Word Pattern](https://leetcode.com/problems/word-pattern/), see notes in [DepthFirstSearch.NarySearchTreeTemplate.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/DepthFirstSearch/DepthFirstSearch.NarySearchTreeTemplate.cs)
    - [LeetCode: Word Break](https://leetcode.com/problems/word-break/), see notes in [DepthFirstSearch.NarySearchTreeTemplate.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/DepthFirstSearch/DepthFirstSearch.NarySearchTreeTemplate.cs)
- **Graph**
  - Clone Graph (TODO) 
- **Dynamic Programming**
  - Coordinates Type 
    - [Leetcode: Triangle](https://leetcode.com/problems/triangle/), see notes in [DynamicProgramming.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/DynamicProgramming/DynamicProgramming.Coordinate.cs)
    - [LeetCode: Unique Paths](https://leetcode.com/problems/unique-paths/submissions/), see notes in [DynamicProgramming.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/DynamicProgramming/DynamicProgramming.Coordinate.cs)
    - [LeetCode: Unique Paths II with Obstacles](https://leetcode.com/problems/unique-paths-ii/submissions/), see notes in [DynamicProgramming.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/DynamicProgramming/DynamicProgramming.Coordinate.cs)
    - [LintCode: Knight Shortest Path II](https://www.lintcode.com/problem/630/), see notes in [DynamicProgramming.Coordinate.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/DynamicProgramming/DynamicProgramming.Coordinate.cs)
    - [LeetCode: Jump Game](https://leetcode.com/problems/jump-game/), see notes in [DynamicProgramming.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/DynamicProgramming/DynamicProgramming.Coordinate.cs)
    - [LeetCode: Longest Increasing Subsequence](https://leetcode.com/problems/longest-increasing-subsequence/), see notes in [DynamicProgramming.Coordinate.cs](https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/DynamicProgramming/DynamicProgramming.Coordinate.cs)

## Articles
- [Algorithms — Two Pointers Template That Solves Many Problems](https://shawn-shi.medium.com/summary-notes-on-algorithms-two-pointers-c81735def5b2)
- [Algorithms — Binary Search Template That Can Solve Lots of Problems](https://shawn-shi.medium.com/summary-notes-on-algorithms-binary-search-template-using-two-pointers-347fbb6263a9)
- TODO : Algorithms - Master Breadth First Search Template Code with 5 Problems 

## Sample images
<img src="https://github.com/ShawnShiSS/algorithms-notes/blob/main/src/Algorithms/Uploads/Heap%20vs%20Stack%20storage.jpg" width="520" height="200">

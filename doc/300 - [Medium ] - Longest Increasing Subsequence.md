# 300. Longest Increasing Subsequence [Medium]

The original [**link**](https://leetcode.com/problems/longest-increasing-subsequence/) of problem.

## Description

Given an integer array `nums`, return *the length of the longest **strictly increasing*** 
subsequence[^1]

**Example 1:**

```
Input: nums = [10,9,2,5,3,7,101,18]
Output: 4
Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.
```

**Example 2:**

```
Input: nums = [0,1,0,3,2,3]
Output: 4
```

**Example 3:**

```
Input: nums = [7,7,7,7,7,7,7]
Output: 1
```

**Constraints:**

+ `1 <= nums.length <= 2500`
+ `-10^4 <= nums[i] <= 10^4`

Follow up: Can you come up with an algorithm that runs in `O(n log(n))` time complexity?

## Analysis

常规动态规划解答该题目。
定义长度为`nums.length`的动态规划数组`dp`，其中的每个元素`dp[n]`表示以`nums[n]`(含)为结束的最长严格递增序列的长度。
`dp[n]`的取值比较简单，从`nums[n]`向前找一个位置，该位置的`nums[x]`必定小于`nums[n]`且`dp[x]`最大，令`dp[n] = dp[x] + 1`。状态转移公示为`dp[n] = (for x in 0..n: ensure nums[x] < nums[n] find max(dp[x])) + 1`
状态初始化：每个位置都可以自身作为起始和结束形成长度为`1`的序列，因此全部初始化为`1`

TODO: 时间复杂度优化到`O(NlogN)`

## Remark

关于优化时间复杂度，考虑将查找小于`nums[n]`的`nums[x]`且`dp[x]`最大的操作使用二分查找来优化？


[^1]: **Subsequence**: A **subsequence** is an array that can be derived from another array by deleting some or no elements without changing the order of the remaining elements.
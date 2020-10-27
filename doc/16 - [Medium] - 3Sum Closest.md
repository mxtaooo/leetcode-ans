# 16. 3Sum Closest [Medium]

The [link](https://leetcode.com/problems/3sum-closest/) of question.

## Description

Given an array `nums` of *n* integers and an integer `target`, find three integers in `nums` such that the sum is closest to `target`. Return the sum of the three integers. You may assume that each input would have exactly one solution.


Example 1:
```
Input: nums = [-1,2,1,-4], target = 1
Output: 2
Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
```

Constraints:
```
3 <= nums.length <= 10^3
-10^3 <= nums[i] <= 10^3
-10^4 <= target <= 10^4
```

## 题目分析

暴力算法的时间复杂度是$O(N^3)$，进行三重循环，找出所有数字组，然后从中找出距离目标数字最近的结果。

依然运用上一题目的双指针解法进行优化，优化结果是时间复杂度$O(N^2)$
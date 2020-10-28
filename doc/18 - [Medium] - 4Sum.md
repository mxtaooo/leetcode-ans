# 18. 4Sum [Medium]

The [link](https://leetcode.com/problems/4sum/) of question.

## Description

Given an array `nums` of *n* integers and an integer `target`, are there elements *a*, *b*, *c*, and *d* in `nums` such that `a + b + c + d = target`? Find all **unique** quadruplets in the array which gives the sum of `target`.

**Notice** that the solution set must not contain duplicate quadruplets.

Example 1:
```
Input: nums = [1,0,-1,0,-2,2], target = 0
Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
```

Example 2:
```
Input: nums = [], target = 0
Output: []
```

Constraints:
```
0 <= nums.length <= 200
-109 <= nums[i] <= 109
-109 <= target <= 109
```

## 题目分析

对于这类K-SUM类型的题目，除了K-2重循环+双指针的较为高效的方法，还有一个递归版本的解法。递归解法认为，任意K-SUM问题，都可以理解成基于K-1-SUM问题的解求得。
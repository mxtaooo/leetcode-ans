# 33. Search in Rotated Sorted Array [Medium]

The [link](https://leetcode.com/problems/search-in-rotated-sorted-array/) of question.

## Description

You are given an integer array `nums` sorted in ascending order, and an integer `target`.

Suppose that `nums` is rotated at some pivot unknown to you beforehand (i.e., `[0,1,2,4,5,6,7]` might become `[4,5,6,7,0,1,2]`).

*If `target` is found in the array return its index, otherwise, return `-1`.*

Example 1:
```
Input: nums = [4,5,6,7,0,1,2], target = 0
Output: 4
```

Example 2:
```
Input: nums = [4,5,6,7,0,1,2], target = 3
Output: -1
```

Example 3:
```
Input: nums = [1], target = 0
Output: -1
```

Constraints:
```
1 <= nums.length <= 5000
-10^4 <= nums[i] <= 10^4
-10^4 <= target <= 10^4
```
All values of `nums` are **unique**.
`nums` is guranteed to be rotated at some pivot.

## 题目分析

这道题直接看好像直接从头向后找也可以？这样的时间复杂度为`O(N)`

先二分查找定位到反转点、然后再二分查找定位目标值？定位反转点是否能通过二分查找进行？能保证时间复杂度`O(logN)`？

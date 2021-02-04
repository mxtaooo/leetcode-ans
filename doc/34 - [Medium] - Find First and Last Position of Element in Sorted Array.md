# 34. Find First and Last Position of Element in Sorted Array [Medium]

The [link](https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/) of question.

## Description

Given an array of integers `nums` sorted in ascending order, find the starting and ending position of a given `target` value.

If `target` is not found in the array, return `[-1, -1]`.

**Follow up**: Could you write an algorithm with `O(log n)` runtime complexity?

Example 1:
```
Input: nums = [5,7,7,8,8,10], target = 8
Output: [3,4]
```

Example 2:
```
Input: nums = [5,7,7,8,8,10], target = 6
Output: [-1,-1]
```

Example 3:
```
Input: nums = [], target = 0
Output: [-1,-1]
```

Constraints:
```
0 <= nums.length <= 105
-109 <= nums[i] <= 109
-109 <= target <= 109
```
`nums` is a non-decreasing array.

## 题目分析

最直接的方式当然是遍历方式、时间复杂度为`O(N)`

题目要求保持时间复杂度为`O(logN)`，现实现为先二分查找定位到任一目标数字、然后以二分查找向前向后定位边界。假定二分查找定位到的目标数字坐标为`p`，所谓定位边界，便是找到`[0, p]`最前方的目标数字、`[p, ^1]`中最后方的目标数字。该解法整体运行没有问题，但整体性能没有体现出太大优势，可能还不如遍历法运行得快，此外代码整体显得冗长罗嗦

题解中的遍历是双向的。首先从前向后尝试找到目标数字、找到则停止并记下此时位置，若找到说明数组中必定存在目标数字，然后再从后向前遍历找到结束端；否则直接返回未找到。最坏时间复杂度为`O(N)`

题解优化版的二分查找：二分查找直接定位前端和后端、查找前后端的过程中直接就进行了存在性验证

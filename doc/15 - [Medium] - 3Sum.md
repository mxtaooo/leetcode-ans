# 15. 3Sum [Medium]

The [link](https://leetcode.com/problems/3sum/) of question.

## Description

Given an array `nums` of *n* integers, are there elements *a*, *b*, *c* in `nums` such that `a + b + c = 0`? Find **all** unique triplets in the array which gives the sum of zero.

Notice that the solution set must not contain duplicate triplets.

Example 1:
```
Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
```

Example 2:
```
Input: nums = []
Output: []
```

Example 3:
```
Input: nums = [0]
Output: []
```

Constraints:
```
0 <= nums.length <= 3000
-10^5 <= nums[i] <= 10^5
```

## 题目分析

一个实现思路，暂时没时间去实现。

把数字排序，从开头和结尾初始化两游标，两游标是往中间移动的。由于数据已有序，因此可以用二分查找尝试找出两游标所期望的目标数字，若能找到，则出现一组目标值，若不能则推进游标
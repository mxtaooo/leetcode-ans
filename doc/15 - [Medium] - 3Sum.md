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

最直接的办法当然是暴力搜索，简单改进一下可以将$O(N^3)$的复杂度降低到$O(N^2 \log N)$

当前已实现的思路如下所述，先将数组排序（预计时间复杂度$O(N \log N)$，用以支持接下来时间复杂度$O(\log N)$的二分查找）。然后从头开始，找出所有数字对，然后从其余数字中尝试找到目标数字。过程中注意保证跳过的重复的数字组。

此外，有一个不太成熟的思路，但未能成功实现。把数字排序，从开头和结尾初始化两游标，两游标是往中间移动的。由于数据已有序，因此可以用二分查找尝试找出两游标所期望的目标数字，若能找到，则出现一组目标值，若不能则推进游标。思路的问题在于两侧游标的推进时机不好确定

---

<!-- todo -->

中文版Solution好像提供了优化后的双指针解法
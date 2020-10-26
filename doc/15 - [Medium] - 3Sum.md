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

以上思路的主要问题是，看见了有序数组，就想用上的二分查找，因此被限制住了思路。这是一个典型的双指针问题，两指针指向的数据是有关系的，一个在增大一个在缩小。数组排序后，从头开始，对于**每个数字**以指针`i`指出，尝试在后方找出所有**数字对**，使这三者之和为0。在后方的子数组首位各初始化一个指针`j`和`k`，三指针的目标求和：若大于0说明尾巴太大`k`要前移；若小于0说明头部太小`j`要后移；若等于`0`，那么这三者是一个合格的结果，加入结果集之后`j`与`k`都要移动。该思路已实现。

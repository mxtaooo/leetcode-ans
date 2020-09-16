# 4. Median of Two Sorted Arrays [Hard]

The [link](https://leetcode.com/problems/median-of-two-sorted-arrays/) of question.

## Description

Given two sorted arrays `nums1` and `nums2` of size `m` and `n` respectively, return **the median** of the two sorted arrays.

Follow up: The overall run time complexity should be `O(log(m+n))`.

Example 1:
```
Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.
```

Example 2:
```
Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
```

Example 3:
```
Input: nums1 = [0,0], nums2 = [0,0]
Output: 0.00000
```

Example 4:
```
Input: nums1 = [], nums2 = [1]
Output: 1.00000
```

Example 5:
```
Input: nums1 = [2], nums2 = []
Output: 2.00000
```

Constraints:
```
nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-106 <= nums1[i], nums2[i] <= 106
```

## 题目分析

题目对于时间复杂度的要求提升了难度，简要思路如下：先找到两个数组的中位数，比较大小。然后递归取较大中位数的左半部分，较小中位数的右半部分，只是一直没有想好其结束递归的条件。看了题解，发现忽略了中位数两侧元素个数相等的条件。

考虑其数学意义，有序数组中，中位数两侧数字个数相等。为两有序数组`A`和`B`定义两游标`i`和`j`，于是数组共计划分成4部分，左侧两部分作为中位数左侧，右侧两部分作为中位数右侧，由于必须保证两侧数字个数相等，因此游标`j`可由`i`计算出来，这边满足了两侧数字个数相等的条件。此外需要保证有序条件，由于两数组各自是有序的，因此只需要保证两游标两侧交叉比较依旧有序即可，找到这样的一对游标，也就找到了中位数。在此过程中需要注意游标可能是边界位置，某侧可能无值；也要注意中位数可能单个数字，也可能是某两数字的平均值，所以要注意某侧会多一个数字。

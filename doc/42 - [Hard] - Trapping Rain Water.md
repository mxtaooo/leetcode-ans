# 42. Trapping Rain Water [Hard]

The [link](https://leetcode.com/problems/trapping-rain-water/) of question.

## Description

Given `n` non-negative integers representing an elevation map where the width of each bar is `1`, compute how much water it can trap after raining.

**Example 1**:

![](./img/42.png)

```
Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6
Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.
```

**Example 2**:
```
Input: height = [4,2,0,3,2,5]
Output: 9
```

**Constraints**:

+ `n == height.length`
+ `0 <= n <= 3 * 10^4`
+ `0 <= height[i] <= 10^5`

## 题目分析

基本思路如下：
首先遍历数组，找出最“高”的元素，记录其位置，然后从左右两侧逼近该位置。从最左侧开始，记高度为`left`，向右滑动游标，对于所有小于`left`的元素，都可以“保留雨水”，因此执行`sum += (left - current)`；当遇见一个元素“高于”`left`，那么再右侧可以“保留更多雨水”，因此以这个新高度作为`left`，继续向右滑动计算，直到滑动到TOP元素。因为已知的前提是：TOP在右侧，右侧必定能保证雨水不会泄露。同理，从最右侧逼近TOP的流程与此类似。
找出TOP元素时遍历了一次数组，逼近阶段只是进行划分计算，并未重复遍历，该阶段也只遍历了一次数组。该思路的时间复杂度为`O(n)`、常量空间复杂度。

# 11. Container With Most Water [Medium]

The [link](https://leetcode.com/problems/container-with-most-water/) of question.

## Description

Given `n` non-negative integers `a1`, `a2`, ..., `an` , where each represents a point at coordinate `(i, ai)`. `n` vertical lines are drawn such that the two endpoints of the line `i` is at `(i, ai)` and `(i, 0)`. Find two lines, which, together with the x-axis forms a container, such that the container contains the most water.

**Notice** that you may not slant the container.

Example 1:

![](./img/11.jpg)
```
Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
```

Example 2:
```
Input: height = [1,1]
Output: 1
```

Example 3:
```
Input: height = [4,3,2,1,4]
Output: 16
```

Example 4:
```
Input: height = [1,2,1]
Output: 2
```

Constraints:
```
2 <= height.length <= 3 * 10^4
0 <= height[i] <= 3 * 10^4
```

# 题目分析

第一直觉便是暴力计算，尝试所有可能的数据对，然后找出最大的。时间复杂度$O(n^2)$该方法在某些测试样例上运行超时了，需要改进。

看了Solution，官方给出了两点法。考虑题目，必然是较小的一边限制了容量。于是设立两游标从最左侧和最右侧开始，每次都将较小一侧的游标内移（因为比较矮的边已经没救了，只能向内找更高的尝试抢救下），直到左右两游标重合。时间复杂度$O(n)$

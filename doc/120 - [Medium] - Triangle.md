# 120. Triangle [Medium]

The original [**link**](https://leetcode.com/problems/triangle//) of problem.

## Description

Given a `triangle` array, return *the minimum path sum from top to bottom*.

For each step, you may move to an adjacent number of the row below. More formally, if you are on index i on the current row, you may move to either index `i` or index `i + 1` on the next row.

**Example 1**:

```
Input: triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
Output: 11
Explanation: The triangle looks like:
   2
  3 4
 6 5 7
4 1 8 3
The minimum path sum from top to bottom is 2 + 3 + 5 + 1 = 11 (underlined above).
```

Example 2:

```
Input: triangle = [[-10]]
Output: -10
```

Constraints:

```
1 <= triangle.length <= 200
triangle[0].length == 1
triangle[i].length == triangle[i - 1].length + 1
-10^4 <= triangle[i][j] <= 10^4
```

Follow up: Could you do this using only `O(n)` extra space, where `n` is the total number of rows in the triangle?

## Analysis

动态规划思路解答该问题。

为了使展示更直观，将给定三角形换一种更“程序”的形状展示如下：
```
2
3 4
6 5 7
4 1 8 3
```
其中任意一点出发，只能向正下或者右下前进。

定义与三角形尺寸一致的动态规划数组dp，其中`dp[i,j]`表示到达当前位置的最短路径和。要到达位置`[i,j]`，只能从左上或者正上到达，因此状态转移公式大致为`dp[i,j] = min(dp[i-1,j-1], dp[i-1,j]) + triangle[i,j]`，注意边界条件，例如最左侧不存在“左上”，最右侧不存在“正上”。
起始状态为`dp[0,0] = triangle[0,0]`。

## Remark

注意迭代条件，迭代到每行数字时，只需要上下两行，因此可以考虑缩减dp规模，只保留当前行和上一行。
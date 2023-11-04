# 64. Minimum Path Sum [Medium]

The original [**link**](https://leetcode.com/problems/minimum-path-sum/) of problem.

## Description

Given a `m x n` grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.

**Note**: You can only move either down or right at any point in time.

**Example 1**:

![](./img/64.jpg)

```
Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
Output: 7
Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.
```

**Example 2**:

```
Input: grid = [[1,2,3],[4,5,6]]
Output: 12
```

Constraints:

```
m == grid.length
n == grid[i].length
1 <= m, n <= 200
0 <= grid[i][j] <= 200
```

## Analysis

以动态规划思路解答该问题。
定义尺寸与给图形一致的数组dp，定义`dp[i,j]`是到达位置`[i,j]`的最小的路径，那么对于`dp[i,j]`的取值，便是`dp[i,j-1]`与`dp[i-1,j]`中的较小值与`graph[i,j]`的和，即状态转移公式为:`dp[i,j] = min(dp[i,j-1], dp[i-1,j]) + graph[i,j]`，注意左侧或上侧无值的边界条件。
注意初始条件，第一行和第一列中的所有元素都只有从左侧和从上侧出发并到达的路径，因此可以直接初始化。

## Remark

对于给定数组中的元素`graph[i,j]`，只会在到达`[i,j]`时读取一次，且之后再不需要该值，因此可以直接以`graph`作为动态规划数组


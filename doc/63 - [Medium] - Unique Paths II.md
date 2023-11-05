# 63. Unique Paths II [Medium]

The original [**link**](https://leetcode.com/problems/unique-paths-ii/) of problem.

## Description

You are given an `m x n` integer array `grid`. There is a robot initially located at the **top-left corner** (i.e., `grid[0][0]`). The robot tries to move to the **bottom-right corner** (i.e., `grid[m - 1][n - 1]`). The robot can only move either down or right at any point in time.

An obstacle and space are marked as `1` or `0` respectively in `grid`. A path that the robot takes cannot include *any* square that is an obstacle.

*Return the number of possible unique paths that the robot can take to reach the bottom-right corner.*

The testcases are generated so that the answer will be less than or equal to `2 * 10^9`.

**Example 1**:

![](./img/63-1.jpg)

```
Input: obstacleGrid = [[0,0,0],[0,1,0],[0,0,0]]
Output: 2
Explanation: There is one obstacle in the middle of the 3x3 grid above.
There are two ways to reach the bottom-right corner:
1. Right -> Right -> Down -> Down
2. Down -> Down -> Right -> Right
```

**Example 2**:

![](./img/63-2.jpg)

```
Input: obstacleGrid = [[0,1],[0,0]]
Output: 1
```

**Constraints**:

```
m == obstacleGrid.length
n == obstacleGrid[i].length
1 <= m, n <= 100
obstacleGrid[i][j] is 0 or 1.
```

## Analysis

以动态规划思路解答该问题。
定义规模与给定数组规模一致的动态规划数组dp，定义其中的元素`dp[i,j]`为到达位置`[i,j]`的路径个数。
通常情况到达`[i,j]`有两种途径：从左侧到达和从上方到达。但要注意`[i,j]`位于最上行和最左列的边界情况，以及`graph[i,j] = 1`时表示的位置`[i,j]`不可到达。状态转移公式大致为`dp[i,j] = if graph[i,j] == 1 then 0 else (dp[i-1,j] + dp[i, j-1]) (ensure i>1 j>1)`
初始化时，`dp[i,j]`可以直接依据`graph[0,0]`的情况初始化，此外第一行、第一列中可以直接依赖左侧、上侧的元素情况直接初始化。

## Remark

若左上角的位置“不可达”，则整张图“不可达”。
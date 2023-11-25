# 221. Maximal Square [Medium]

The original [**link**](https://leetcode.com/problems/maximal-square/) of problem.

## Description

Given an `m x n` binary `matrix` filled with `0`'s and `1`'s, *find the largest square containing only `1`'s and return its area*.

**Example 1**:

![](./img/221-1.jpg)

```
Input: matrix = [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
Output: 4
```

**Example 2**:

![](./img/221-2.jpg)

```
Input: matrix = [["0","1"],["1","0"]]
Output: 1
```

**Example 3**:

```
Input: matrix = [["0"]]
Output: 0
```

**Constraints**:

```
m == matrix.length
n == matrix[i].length
1 <= m, n <= 300
matrix[i][j] is '0' or '1'.
```

## Analysis

定义与给定`matrix`大小一致的动态规划数组`dp`，其中的元素`dp[i,j]`表示以`matrix[i,j]`为右下角的最大正方形的边长。
其取值将首先查看`matrix[i,j]`是否为1，若为0无需判断直接赋值0即可；若为1，再参考左上的`dp[i-1,j-1]`取值，若左上为0，则`dp[i,j]`只能取1，若左上为`n`，那么可以确定左上方已经有`n*n`的范围是个合法正方形，此时确保其下方及右侧的行和列全1则`dp[i,j]`可赋值为`n+1`，特别的，下方及右侧可能有部分0，此时应注意取最大正方形的边长。
关于初始状态，关注`matrix[0,0]`是否为1，并赋值即可。当然也可对最上行和最左列进行进行逐个验证，因为其最大边长不会超过1.

## Remark

Other valuable things in solving problem.

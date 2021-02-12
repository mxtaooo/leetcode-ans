# 37. Sudoku Solver [Hard]

The [link](https://leetcode.com/problems/sudoku-solver/) of question.

## Description

Write a program to solve a Sudoku puzzle by filling the empty cells.

A sudoku solution must satisfy **all of the following rules**:

1. Each of the digits `1-9` must occur exactly once in each row.
2. Each of the digits `1-9` must occur exactly once in each column.
3. Each of the digits `1-9` must occur exactly once in each of the 9 `3x3` sub-boxes of the grid.

The `'.'` character indicates empty cells.

**Example 1**:

```
Input: board = 
[["5","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]

Output: 
[["5","3","4","6","7","8","9","1","2"]
,["6","7","2","1","9","5","3","4","8"]
,["1","9","8","3","4","2","5","6","7"]
,["8","5","9","7","6","1","4","2","3"]
,["4","2","6","8","5","3","7","9","1"]
,["7","1","3","9","2","4","8","5","6"]
,["9","6","1","5","3","7","2","8","4"]
,["2","8","7","4","1","9","6","3","5"]
,["3","4","5","2","8","6","1","7","9"]]
```

Explanation: The input board is shown left and the only valid solution is shown right:

![](./img/37-1.png)   ![](./img/37-2.png)

**Constraints**:

+ `board.length == 9`
+ `board[i].length == 9`
+ `board[i][j]` is a digit or `'.'`.
+ It is **guaranteed** that the input board has only one solution.

## 题目分析

当前解决方案直接参考了[题解](https://leetcode-cn.com/problems/sudoku-solver/solution/jie-shu-du-by-leetcode-solution/)的思路

当前实现的简要思路如下

1. 实现一个工具方法、该方法能找出某空白位置的全部候选值（依据该空白位置的行、列、九宫格确定）
2. 首先尝试填充所有“单候选”空白位置（某些位置确定后会进一步影响其它位置、因此会需要循环处理）
3. DFS填充所有多候选的空白、只是这一过程会需要回溯、


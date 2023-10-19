# 44. Climbing Stairs [Easy]

The [link](https://leetcode.com/problems/climbing-stairs) of question.

## Description

You are climbing a staircase. It takes `n` steps to reach the top.

Each time you can either climb `1` or `2` steps. In how many distinct ways can you climb to the top?

Example 1:
```
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps
```

Example 2:
```
Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
``` 

Constraints:

1 <= `n` <= 45

## 题目分析

一维动态规划经典思路。
定义数组`dp`，其中`dp[n]`表示跳到第`n`级台阶的途径数，要到达第`n`级台阶，只有两种途径：从第`n-1`级跳1级到达和从第`n-2`级跳2级到达。状态转移公式为`dp[n] = dp[n-1] + dp[n-2]`。
初始状态：到达第`0`级有`0`种途径，到达第`1`级有`1`种途径(从地面跳1级到达)，到达第`2`级有`2`种途径(从地面跳到1级再跳到2级和从地面直接跳2级)。
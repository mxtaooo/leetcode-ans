# 322. Coin Change [Medium]

The original [**link**](https://leetcode.com/problems/coin-change/) of problem.

## Description

You are given an integer array coins representing coins of different denominations and an integer `amount` representing a total amount of money.

Return the *fewest number* of coins that you need to make up that `amount`. If that `amount` of money cannot be made up by any combination of the coins, return `-1`.

You may assume that you have an infinite number of each kind of coin.

**Example 1:**

```
Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1
```

**Example 2:**

```
Input: coins = [2], amount = 3
Output: -1
```

**Example 3:**

```
Input: coins = [1], amount = 0
Output: 0
```

**Constraints:**

+ `1 <= coins.length <= 12`
+ `1 <= coins[i] <= 2^31 - 1`
+ `0 <= amount <= 10^4`

## Analysis

动态规划方式解答该问题。
定义长度为`[amount+1]`的数组`dp`，其中的元素`dp[n]`表示构成面额`n`所需的最小硬币个数。
对于`dp[n]`的取值，存在以下两种情况：恰好有一个硬币面值为`n`，则直接令`dp[n]=1`；已知面额`x`(`x < n`)可行(即`dp[x] != -1`)，且存在面额为`n - x`的硬币，那么`dp[n] = dp[x] + 1`(注意可能存在多个不同的符合条件的`dp[x]`，要找出其中的最小值)。状态转移公式(示意)为：`dp[n] = 1 when contains(n) || dp[n] = min(dp[x] + 1) when dp[x] != -1 && contains(n-x)`。
初始状态：`dp[0]=0`表示面额`0`需`0`个硬币构成；其余元素先初始化为`-1`表示无法构成

## Remark

题目约束条件中，硬币数目不多于`12`，因此在寻找符合条件的`dp[x]`时可以直接遍历硬币数组。

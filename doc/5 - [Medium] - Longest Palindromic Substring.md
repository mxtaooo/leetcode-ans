# 5. Longest Palindromic Substring [Medium]

The [link](https://leetcode.com/problems/longest-palindromic-substring/solution/) of question.

## Description

Given a string `s`, find the longest palindromic substring in `s`. You may assume that the maximum length of `s` is 1000.

Example 1:
```
Input: "babad"
Output: "bab"
Note: "aba" is also a valid answer.
```

Example 2:
```
Input: "cbbd"
Output: "bb"
```

## 题目分析

这个最长回文子串问题的第一反应是暴力解决，遍历每个字符，对于每个字符，尝试向前后进行扩展，最终找到最长回文串。要注意子串字符个数的奇偶，可以考虑同时进行扩展

## 备注

这个问题官方给出了5种解法，有必要实现一遍来体会思路

1. 最长相同字串

  将字符串`S`反转成为`S'`，然后找出`S`与`S'`的最长相同子串，要注意该子串必须是回文串才行。

2. 动态规划

  对于一个长度大于2的回文串，去掉首尾之后仍是一个回文串。若已知某字串是一个回文串，那么若该串前后又有一对相同字符，那么扩展之后的也是一个回文串。

  定义`P(i, j)`为从第`i`到第`j`个字符是否是回文串，若是则为`true`，若不是或字串不存在(如`i > j`)则为`false`。于是其状态转移方程为`P(i-1, j+1) = P(i, j) && s[i-1]==s[j+1]`，其起始边界条件为`P(i, i) = true`和`P(i, i+1) = true`。由此可以求解

3. 中心扩展

  以上实现即为中心扩展算法

4. 动态规划 - 2023-11-09

  定义大小为`s.length * s.length`的二维动态规划数组`dp`，其中的元素`dp[i,j]`表示子串`s[i..j]`是否为回文串。
  注意`dp[i,j]`若要取到`true`需要保证`s[i] = s[j]`且`dp[i+1, j-1] = true`(即两端字符一致，且内部子串已知是回文串)，注意边界情况，当`i+1 > j-1`时说明字串`s[i..j]`可能仅有一个字符或者两个字符(因此不会有内部子串的概念)，状态转移公式为`dp[i,j] = s[i]==s[j] && (i+1 > j-1 || dp[i+1, j-1])`。
  注意，状态转移过程中`dp[i,j]`的状态取决于`dp[i+1,j-1]`的状态，因此常规的逐行或逐列遍历是无效的，考虑按照“子串长度”进行遍历，这样状态转移矩阵是先填充对角线，然后向右上方逐斜行填充，最终填充完右上侧矩阵。
  找到最长子串时，只需要遍历右上侧矩阵，找到“行列差”最大的即为最长子串。
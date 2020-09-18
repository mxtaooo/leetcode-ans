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

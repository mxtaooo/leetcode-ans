# 32. Longest Valid Parentheses [Hard]

The [link](https://leetcode.com/problems/longest-valid-parentheses/) of question.

## Description

Given a string containing just the characters `'('` and `')'`, find the length of the longest valid (well-formed) parentheses substring.

Example 1:
```
Input: s = "(()"
Output: 2
Explanation: The longest valid parentheses substring is "()".
```

Example 2:
```
Input: s = ")()())"
Output: 4
Explanation: The longest valid parentheses substring is "()()".
```

Example 3:
```
Input: s = ""
Output: 0
```

Constraints:
```
0 <= s.length <= 3 * 10^4
```
`s[i]` is `'('` or `')'`

## 题目分析

首先想到并实现如下：

使用简单堆栈进行处理、首先找到

<!-- --- -->

做个结构、成对消除括号？

这个方案可能会导致内存使用暴涨

<!--  -->

建立映射列表、`(start, len)`、从某处开始的最长封闭括号、然后尝试连接并消除

<!-- --- -->

动态规划做法？是否可以从子问题开始求解？

<!--  -->


--- 

整理题解中的算法：

1. 暴力求解

    以`SubString`的方式取出所有偶数长度的子串，逐一判断是否合法，最终可以找到最长子串。该算法时间复杂度为`O(N^3)`

2. 动态规划

    定义整数数组`dp`，其中`dp[i]`的含义为止于`s[i]`的最长合法子串、从、

3. 堆栈

4. **双向扫描**


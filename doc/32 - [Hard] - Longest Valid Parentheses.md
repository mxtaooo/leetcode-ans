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

建立映射列表、`(start, len)`、从某处开始的最长封闭括号、然后尝试连接并消除

---

just commit file now

...


error ?

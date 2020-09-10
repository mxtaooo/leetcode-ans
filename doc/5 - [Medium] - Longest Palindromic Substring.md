# 5. Longest Palindromic Substring [Medium]

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

这个官方给了N多解法、有必要尝试一遍
# 14. Longest Common Prefix [Easy]

The [link](https://leetcode.com/problems/longest-common-prefix/) of question.

## Description

Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string `""`.

Example 1:
```
Input: strs = ["flower","flow","flight"]
Output: "fl"
```

Example 2:
```
Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
```

Constraints:
```
0 <= strs.length <= 200
0 <= strs[i].length <= 200
strs[i] consists of only lower-case English letters.
```

## 题目分析

该题目比较简单，实现起来不难，可能多个方法想全比较难。整理题解，共总结到以下几个思路

1. 横向扫描

  基于结论`LCP(S1, S2, ..., Sn) = LCP(LCP(LCP(S1, S2), S3), ...)`，依次找出每对字符串的最长相同子序列，然后找最长相同子序列的最长相同子序列，最终找出所有字符串的最长相同子序列。

2. 纵向扫描

  从头开始，比较每个字符串相同位置的字符是否相同，每次字符比较遍历的是所有字符串。当找到某个位置，不是所有的字符都一致，那么其之前的便是最长的公共子序列。

3. 分治法

  基于结论`LCP(S1, S2, ..., Sn) = LCP(LCP(S1, Sx), LCP(Sx+1， Sn)) = ...`

4. 二分查找

  <!-- todo -->
  显然，最长相同子串长度不可能超过最短字符串，将其长度记为`minLength`，从`[0, minLength]`范围内通过二分查找找出最长相同子串长度 
# 7. Reverse Integer [Easy]

The [link](https://leetcode.com/problems/reverse-integer/) of question.

## Description

Given a 32-bit signed integer, reverse digits of an integer.

Example 1:
```
Input: 123
Output: 321
```

Example 2:
```
Input: -123
Output: -321
```

Example 3:
```
Input: 120
Output: 21
```

**Note**:
Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: $[−2^{31}, 2^{31} − 1]$. For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.

## 题目分析

题目本身不麻烦，感觉主要麻烦在于溢出的处理。

仔细思考好像是无法写出一个够好的程序，例如转成字符串->倒序->转成数字，这样必然存在效率问题；如果是 `%10` `/10`一通操作，好像需要对符号进行特殊处理？

我去，完全不需要对符号进行任何特殊处理……

## 备注

需要对于数字的性质进行深入理解和学习了
# 6. ZigZag Conversion [Medium]

The [link](https://leetcode.com/problems/zigzag-conversion/) of question.

## Description

The string `"PAYPALISHIRING"` is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)
```
P   A   H   N
A P L S I I G
Y   I   R
```
And then read line by line: `"PAHNAPLSIIGYIR"`

Write the code that will take a string and make this conversion given a number of rows:
```
string convert(string s, int numRows);
```

Example 1:
```
Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
```

Example 2:
```
Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:

P     I    N
A   L S  I G
Y A   H R
P     I
```

## 题目分析

该题目有两个处理思路。一是顺序遍历字符串的每个字符，遍历过程中确定该字符属于哪一行；另一种是直接计算，第0行是哪几个，第1行是哪几个…… 后者的实现更具技术含量，此外后者只需分配1个Builder，更省空间。

个人题解仅想到了第一种方式，因此实现第二种思路。

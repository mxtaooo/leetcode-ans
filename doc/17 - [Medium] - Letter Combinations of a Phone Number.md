# 17. Letter Combinations of a Phone Number [Medium]

The [link](https://leetcode.com/problems/letter-combinations-of-a-phone-number/) of question.

## Description

Given a string containing digits from `2-9` inclusive, return all possible letter combinations that the number could represent. Return the answer in **any order**.

A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

![](./img/17.png)

Example 1:
```
Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
```

Example 2:
```
Input: digits = ""
Output: []
```

Example 3:
```
Input: digits = "2"
Output: ["a","b","c"]
```

Constraints:
```
0 <= digits.length <= 4
digits[i] is a digit in the range ['2', '9'].
```

## 题目分析

这道题比较简单，感觉最多算是个EASY难度。构造一个MAP，遍历每个字符然后倍增追加即可…
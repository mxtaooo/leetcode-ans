# 12. Integer to Roman [Medium]

The [link](https://leetcode.com/problems/integer-to-roman/) of question.

## Description

Roman numerals are represented by seven different symbols: `I`, `V`, `X`, `L`, `C`, `D` and `M`.

```
Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000
```

For example, `2` is written as `II` in Roman numeral, just two one's added together. `12` is written as `XII`, which is simply `X + II`. The number `27` is written as `XXVII`, which is `XX + V + II`.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not `IIII`. Instead, the number four is written as `IV`. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as `IX`. There are six instances where subtraction is used:

+ `I` can be placed before `V` (5) and `X` (10) to make 4 and 9. 
+ `X` can be placed before `L` (50) and `C` (100) to make 40 and 90. 
+ `C` can be placed before `D` (500) and `M` (1000) to make 400 and 900.

Given an integer, convert it to a roman numeral.

Example 1:
```
Input: num = 3
Output: "III"
```

Example 2:
```
Input: num = 4
Output: "IV"
```

Example 3:
```
Input: num = 9
Output: "IX"
```

Example 4:
```
Input: num = 58
Output: "LVIII"
Explanation: L = 50, V = 5, III = 3.
```

Example 5:
```
Input: num = 1994
Output: "MCMXCIV"
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
```

Constraints:
```
1 <= num <= 3999
```

## 题目分析

感觉这个问题比较考验语言功能、若是语言有个好用的模式匹配、那么这道题目写起来就比较容易

需要从上到下按序匹配即可，注意`1000`、`100`、`10`、`1`可能出现多个符号，其余组合出的数字可能且仅可能出现一次
```
M               1000
CM              900
D               500
CD              400
C               100
XC              90
L               50
XL              40
X               10
IX              9
V               5
IV              4
I               1
```

感觉可以顺便思考一下其它语言的模式匹配怎么写了。

> 看了一下对这个题目的讨论，居然有几乎0ms执行的思路……

就是初始化一个二维数组，第1维表示个、十、百、千，第二维表示0-9十个数字，然后直接将对应罗马数字表示初始化进去。对于一个整数，其千位、百位、十位、个位直接从数组中取到，连接即为罗马数字表示
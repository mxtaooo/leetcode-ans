# 9. Palindrome Number [Easy]

The [link](https://leetcode.com/problems/palindrome-number/) of question.

## Description

Determine whether an integer is a palindrome. An integer is a palindrome when it reads the same backward as forward.

Example 1:
```
Input: 121
Output: true
```

Example 2:
```
Input: -121
Output: false
Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
```

Example 3:
```
Input: 10
Output: false
Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
```

**Follow up**: Coud you solve it without converting the integer to a string?

## 题目分析

看这道题目第一反应是将数字变成字符串，然后将字符串反转，然后直接比较字符串。题目指出尽量不要这样做，所以思路就变成手动将数字拆成单个字符，然后将从两端到中间来逐个比较对应位置的数字是一致的。

题解中给出了只比较数字的一半的做法，其实现比现有实现更好。

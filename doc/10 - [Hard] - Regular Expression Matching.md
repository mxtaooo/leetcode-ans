# 10. Regular Expression Matching [Hard]

The [link](https://leetcode.com/problems/regular-expression-matching/) of question.

## Description

Given an input string (`s`) and a pattern (`p`), implement regular expression matching with support for `'.'` and `'*'`.

```
`'.'` Matches any single character.
`'*'` Matches zero or more of the preceding element.
```

The matching should cover the **entire** input string (not partial).

**Note**:

`s` could be empty and contains only lowercase letters `a-z`.
`p` could be empty and contains only lowercase letters `a-z`, and characters like `.` or `*`.

Example 1:
```
Input:
s = "aa"
p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
```

Example 2:
```
Input:
s = "aa"
p = "a*"
Output: true
Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
```

Example 3:
```
Input:
s = "ab"
p = ".*"
Output: true
Explanation: ".*" means "zero or more (*) of any character (.)".
```

Example 4:
```
Input:
s = "aab"
p = "c*a*b"
Output: true
Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore, it matches "aab".
```

Example 5:
```
Input:
s = "mississippi"
p = "mis*is*p*."
Output: false
```

## 题目分析

思考这个问题比较久了，最正统的可能编译成自动机然后用自动机过一遍字符串，但是觉得这样实现可能不合适（也许根本实现不出来）。思考是否可以考虑用正则中的常规字符作为锚点，然后尝试匹配其前后的`*`和`.`，这样好像无法实现无锚点的。

官方Solution给出了递归式和动态规划式两种解法。在动态规划解法上花了较多时间………………
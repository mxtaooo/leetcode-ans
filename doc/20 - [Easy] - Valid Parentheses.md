# 20. Valid Parentheses [Easy]

The [link](https://leetcode.com/problems/valid-parentheses/) of question.

## Description

Given a string `s` containing just the characters `'('`, `')'`, `'{'`, `'}'`, `'['` and `']'`, determine if the input string is valid.

An input string is valid if:

1. Open brackets must be closed by the same type of brackets.
2. Open brackets must be closed in the correct order.

Example 1:
```
Input: s = "()"
Output: true
```

Example 2:
```
Input: s = "()[]{}"
Output: true
```

Example 3:
```
Input: s = "(]"
Output: false
```

Example 4:
```
Input: s = "([)]"
Output: false
```

Example 5:
```
Input: s = "{[]}"
Output: true
```

Constraints:
```
1 <= s.length <= 104
s consists of parentheses only '()[]{}'
```

## 题目分析

这类题目第一反应是用用栈解决问题。但要注意细节部分，例如可能是在尝试从空栈中弹出元素导致失败、需要确保最终是一个空栈。

题解提供了多个解答思路

<!-- todo -->
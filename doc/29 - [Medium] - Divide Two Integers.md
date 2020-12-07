# 29. Divide Two Integers [Medium]

The [link](https://leetcode.com/problems/divide-two-integers/) of question.

## Description

Given two integers `dividend` and `divisor`, divide two integers without using multiplication, division, and mod operator.

Return the quotient after dividing `dividend` by `divisor`.

The integer division should truncate toward zero, which means losing its fractional part. For example, `truncate(8.345) = 8` and `truncate(-2.7335) = -2`.

**Note**:

Assume we are dealing with an environment that could only store integers within the 32-bit signed integer range: [−2^31, 2^31 − 1]. For this problem, assume that your function **returns 2^31 − 1 when the division result overflows**.

Example 1:
```
Input: dividend = 10, divisor = 3
Output: 3
Explanation: 10/3 = truncate(3.33333..) = 3.
```

Example 2:
```
Input: dividend = 7, divisor = -3
Output: -2
Explanation: 7/-3 = truncate(-2.33333..) = -2.
```

Example 3:
```
Input: dividend = 0, divisor = 1
Output: 0
```

Example 4:
```
Input: dividend = 1, divisor = 1
Output: 1
```

Constraints:
```
-231 <= dividend, divisor <= 231 - 1
divisor != 0
```

## 题目分析

自行实现的累加式除法，运行测试总是在超时。看了题解的解释，是要转变思路、活用二分查找，将时间复杂度从`O(N)`优化到`O(log(N))`

<!-- todo -->

看到了更直观的思路，可以递归调用自身、居然给忽略掉了……
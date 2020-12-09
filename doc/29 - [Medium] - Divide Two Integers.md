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

最初版本是累加式实现。定义一个变量，循环过程中将之加上除数并记录次数，直到该变量“大于”被除数结束循环，那么累加次数减一即为商。该实现时间复杂度`O(N)`，提交测试提示运行超时，说明效率过低，需要进行优化。

优化过程相当坎坷，看到讨论中提到的实现思路是倍增式实现，即每次都是将变量自加，快速放大。

一开始对这个思路的理解是跑到了活用二分查找上，因此将倍增过程的每个阶段都放到查找表，直到变量放大到“大于”被除数，然后以二分查找的方式从`(0, boundary)`中找到被除数对应的商。这一实现的问题在于`(0, boundary)`是不连续的，是一次次倍增放大的`(1, 2, 4, 8, 16, ...)`，例如某个阶段定位到商位于`(4, 16)`之间，其“中间”是`10`，这个“候选商”需要构造，因此还需实现基于现有查找表进行构造的方法。

重新仔细理解讨论后，发现问题本身其实很简单。快速放大到被除数之下的“最大值”之后，将该“最大值”与被除数的差再次调用除法，然后两“商”相加，即为结果商。还可将其是实现成尾递归提升性能。

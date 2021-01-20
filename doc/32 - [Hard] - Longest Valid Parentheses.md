# 32. Longest Valid Parentheses [Hard]

The [link](https://leetcode.com/problems/longest-valid-parentheses/) of question.

## Description

Given a string containing just the characters `'('` and `')'`, find the length of the longest valid (well-formed) parentheses substring.

Example 1:
```
Input: s = "(()"
Output: 2
Explanation: The longest valid parentheses substring is "()".
```

Example 2:
```
Input: s = ")()())"
Output: 4
Explanation: The longest valid parentheses substring is "()()".
```

Example 3:
```
Input: s = ""
Output: 0
```

Constraints:
```
0 <= s.length <= 3 * 10^4
```
`s[i]` is `'('` or `')'`

## 题目分析

首先想到的解法是用于用堆栈判断合法字符串的简单改进、解法的问题在于未能准确判断“当前”合法字符串是否紧跟一个合法字符串。

现整理题解给出的解题方法

1. 暴力求解

    以`SubString`的方式取出所有偶数长度的子串，逐一判断是否合法，最终可以找到最长子串。该算法时间复杂度为`O(N^3)`

2. 动态规划

    定义数组`dp`，其`dp[i]`的含义为止于`s[i]`的最长合法子串。对于字符`s[i]`，为`(`则跳过，为`)`时观测其前方字符，若`s[i-1]`是`(`，那么`s[i]`必定与`s[i-1]`匹配，终止与`s[i]`的最长串长度为止于`s[i-2]`的字串长度加`2`，即为`dp[i]=dp[i-2]+2`；若`s[i-1]`是`)`、那么需要观察以确保位于“前方合法字串之前”（即`s[i-dp[i-1]-1]`）的字符为`(`，这说明止于`s[i-1]`长度为`dp[i-1]`的合法串被一对括号包裹起来，此外还需连接上“更前方”的合法子串，此时`dp[i] = dp[i-dp[i-1]-2] + dp[i-1] + 2`。最终找出`dp`中的最大值即可

    该解法时间复杂度为`O(N)`、空间复杂度为`O(N)`

3. 堆栈

    该解法在堆栈中放置的是位置。位置分两类，一类是`(`字符的`index`，会在遇见`)`字符时被弹出；另一类是`stack.Peek()`的目标，它是无效字符串的结束位置、或者说其“身后”是合法字串的起始位置
    
    基本思路如下：从前向后遍历字符串、遇见`(`则将`index`推入堆栈；遇见`)`则从堆栈中弹出一个元素，然后观察堆栈是否为空、若已空则将当前`index`推入堆栈、若不为空则用当前`index - stack.Peek()`，这便是合法字符串的长度。遍历过程中关注长度大小并找出最大值即可。

    堆栈初始化时、需先推入`-1`用以保证若合法字符串从头开始、弹出所有`(`之后仍可通过`index - stack.Peek()`算出正确长度。

4. **双向扫描**


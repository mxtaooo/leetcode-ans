# 97. Interleaving String [Medium]

The original [**link**](https://leetcode.com/problems/interleaving-string/) of problem.

## Description

Given strings `s1`, `s2`, and `s3`, find whether `s3` is formed by an **interleaving** of `s1` and `s2`.

An **interleaving** of two strings `s` and `t` is a configuration where `s` and `t` are divided into `n` and `m` substrings respectively, such that:

+ `s = s1 + s2 + ... + sn`
+ `t = t1 + t2 + ... + tm`
+ `|n - m| <= 1`

The **interleaving** is `s1 + t1 + s2 + t2 + s3 + t3 + ...` or `t1 + s1 + t2 + s2 + t3 + s3 + ...`

**Note**: `a + b` is the concatenation of strings `a` and `b`.

**Example 1**:

![](./img/97.jpg)

```
Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
Output: true
Explanation: One way to obtain s3 is:
Split s1 into s1 = "aa" + "bc" + "c", and s2 into s2 = "dbbc" + "a".
Interleaving the two splits, we get "aa" + "dbbc" + "bc" + "a" + "c" = "aadbbcbcac".
Since s3 can be obtained by interleaving s1 and s2, we return true.
```

**Example 2**:

```
Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
Output: false
Explanation: Notice how it is impossible to interleave s2 with any other string to obtain s3.
```

Example 3:

```
Input: s1 = "", s2 = "", s3 = ""
Output: true
```

Constraints:

```
0 <= s1.length, s2.length <= 100
0 <= s3.length <= 200
s1, s2, and s3 consist of lowercase English letters.
```

Follow up: Could you solve it using only `O(s2.length)` additional memory space?

## Analysis

使用动态规划思路解答该问题。
定义大小为`(s1.length + 1) * (s2.length + 1)`的状态数组`dp`，定义其中的元素`dp[i,j]`表示长度为`i`的`s1`子串和长度为`j`的`s2`子串是否能构成长度为`i+j`的`s3`子串。`dp[i,j]`取到`true`有以下两种情况：长度为`i-1`的`s1`子串和长度为`j`的`s2`子串可以构成长度为`i+j-1`的`s3`子串且`s1`的第`i`个字符与`s3`的第`i+j`个字符一致；长度为`i`的`s1`子串和长度为`j-1`的`s2`子串可以构成长度为`i+j-1`的`s3`子串且`s2`的第`j`个字符与`s3`的第`i+j`个字符一致。其状态转移方程为：`dp[i,j] = (dp[i-1,j] && s1[i-1] == s[i+j]) || (dp[i,j-1] && s2[j-1] == s[i+j])`，注意`i`、`j`处于矩阵边缘的场景。
关于初始化，`dp[0,0] = true`，其含义为：长度为`0`的`s1`/`s2`子串必定可以构成长度为`0`的`s3`子串（空串互相连接还是空串）

## Remark

存在一些快速失败的场景，例如两子串长度之和与目标串长度不一致、目标串第一个元素与两子串的首元素都不一样。

TODO: 降低空间复杂度，可能是要考虑贪心算法？
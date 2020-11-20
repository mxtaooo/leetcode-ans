# 28. Implement strStr() [Easy]

The [link](https://leetcode.com/problems/implement-strstr/) of question.

## Description

Implement `strStr()`.

Return the index of the first occurrence of needle in haystack, or `-1` if `needle` is not part of `haystack`.

**Clarification**:

What should we return when `needle` is an empty string? This is a great question to ask during an interview.

For the purpose of this problem, we will return `0` when `needle` is an empty string. This is consistent to C's [strstr()](http://www.cplusplus.com/reference/cstring/strstr/) and Java's [indexOf()](https://docs.oracle.com/javase/7/docs/api/java/lang/String.html#indexOf(java.lang.String)).

Example 1:
```
Input: haystack = "hello", needle = "ll"
Output: 2
```

Example 2:
```
Input: haystack = "aaaaa", needle = "bba"
Output: -1
```

Example 3:
```
Input: haystack = "", needle = ""
Output: 0
```

Constraints:

`0 <= haystack.length`, `needle.length <= 5 * 104`

`haystack` and `needle` consist of only lower-case English characters.

## 题目分析

这道题目相对容易，最简单直观的便是滑动窗口的思想。

子串逐一比较法最简单，该思路时间复杂度为`O((N-L)L)`；在此基础上进行优化，例如失败匹配立即停止，避免频繁生成字符串对象，这样可以优化到最好`O((N-L)L)`最坏`O(N)`的时间复杂度。

[Rabin Karp](https://leetcode-cn.com/problems/implement-strstr/solution/shi-xian-strstr-by-leetcode/)-常数复杂度思路如下：生成窗口内子串的哈希码，然后再跟`needle`字符串的哈希码做比较。该算法的问题在于如何在常数时间生成字串的哈希码，这里就很有技术含量了
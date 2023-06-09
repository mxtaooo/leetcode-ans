# 44. Wildcard Matching [Medium]

The [link](https://leetcode.com/problems/wildcard-matching/) of question.

## Description

Given an input string (`s`) and a pattern (`p`), implement wildcard pattern matching with support for '`?`' and '`*`' where:

'`?`' Matches any single character.
'`*`' Matches any sequence of characters (including the empty sequence).
The matching should cover the entire input string (not partial).


Example 1:
```
Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
```

Example 2:
```
Input: s = "aa", p = "*"
Output: true
Explanation: '*' matches any sequence.
```

Example 3:
```
Input: s = "cb", p = "?a"
Output: false
Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.
```

Constraints:

+ `0` <= `s.length`, `p.length` <= `2000`
+ `s` contains only lowercase English letters.
+ `p` contains only lowercase English letters, '`?`' or '`*`'.

## 题目分析

### 思路一

采用双指针/递归法进行判断。
设定两指针`i`/`j`，分别表示当前在处理的`s`/`p`的位置。对于`p[j]`，若其为`?`，那么推动两指针右移，匹配情况取决于右侧；若为任意字母，比对当前字符，若匹配那么推动指针右移，匹配情况取决于右侧，若比对不匹配，那么直接停止，返回不匹配；若为`*`，情况有些复杂，要匹配0个或任意个字符，在此处进入循环，判断`[i, i+1, i+2, ..., i+n, ..., s.length]`为起始的字串是否匹配`j+1`起始的模式子串。

思路一的问题在于当匹配一串`*`时，会落入最坏的时间复杂度`O(mn)`，无法在规定时间内结束。

### 思路二

基于`*`先将`p`切分，然后按顺序进行`index of`操作

// 似乎只是思路一的改进，并没有本质的效率提升？

### 思路三

参考[leetcode Question 123: Wildcard Matching](http://yucoding.blogspot.com/2013/02/leetcode-question-123-wildcard-matching.html)和[Linear runtime and constant space solution](https://leetcode.com/problems/wildcard-matching/solutions/17810/linear-runtime-and-constant-space-solution/)


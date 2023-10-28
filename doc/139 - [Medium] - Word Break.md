# 139. Word Break [Medium]

The original [**link**](https://leetcode.com/problems/word-break/) of problem.

## Description

Given a string `s` and a dictionary of strings `wordDict`, return `true` if `s` can be segmented into a space-separated sequence of one or more dictionary words.

**Note** that the same word in the dictionary may be reused multiple times in the segmentation.

**Example 1:**

```
Input: s = "leetcode", wordDict = ["leet","code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".
```

**Example 2:**

```
Input: s = "applepenapple", wordDict = ["apple","pen"]
Output: true
Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
Note that you are allowed to reuse a dictionary word.
```

**Example 3:**

```
Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
Output: false
```

**Constraints:**

+ `1 <= s.length <= 300`
+ `1 <= wordDict.length <= 1000`
+ `1 <= wordDict[i].length <= 20`
+ `s` and `wordDict[i]` consist of only lowercase English letters.
+ All the strings of `wordDict` are **unique**.

## Analysis

动态规划思路解答该问题。
定义布尔数组`dp`，长度为`s.length`，其中的元素`dp[n]`表示子串`s[0..n]`(含字符`s[n]`)是否可以由`dict`中的元素构造成功。
`dp[n]`取到`true`时存在两种可能：给定`dict`中直接存在子串`s[0..n]`；`dp[x]`(`x < n`)取到`true`，且子串`s[(x+1)..n]`存在于给定`dict`中。否则子串`s[0..n]`无法由给定词库构成，`dp[n]`取`false`。状态转移公式(示意)`dp[n] = contains(s[0..n]) || (dp[x] && contains(s[(x+1)..n]))`。
无初始状态，从第一个字符开始逐个判断即可。
`dp[-1]`即为整个字符串是否可由给定词库构造。

## Remark

1. 布尔数组可以由`BitSet/BitArray`等更省空间的结构来表示；
2. 尝试向前回溯时，可能通过对比`n`的位置与`dict`中词语的个数，在以下两种方案中择优执行：直接遍历`dict`中的词，然后直接查看指定位置的`dp[x]`是否为`true`；遍历`dp[0..n]`并验证`s[(x+1)..n]`是否在`dict`
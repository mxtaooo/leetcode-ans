# 30. Substring with Concatenation of All Words [Hard]

The [link](https://leetcode.com/problems/substring-with-concatenation-of-all-words/) of question.

## Description

You are given a string `s` and an array of strings `words` of **the same length**. Return all starting indices of substring(s) in `s` that is a concatenation of each word in `words` **exactly once**, **in any order**, and **without any intervening characters**.

You can return the answer in **any order**.

Example 1:
```
Input: s = "barfoothefoobarman", words = ["foo","bar"]
Output: [0,9]
Explanation: Substrings starting at index 0 and 9 are "barfoo" and "foobar" respectively.
The output order does not matter, returning [9,0] is fine too.
```

Example 2:
```
Input: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]
Output: []
```

Example 3:
```
Input: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]
Output: [6,9,12]
```

Constraints:
```
1 <= s.length <= 104
s consists of lower-case English letters.
1 <= words.length <= 5000
1 <= words[i].length <= 30
```
`words[i]` consists of lower-case English letters.

## 题目分析

最初考虑题目的时候忽视了一个条件，给出的单词**长度都是一致的**，不可能出现类似`["abc", "abcd"]`这种需要回溯的情况

这道题目基于最朴素的暴力求解进行改进即可。暴力求解思路如下：对于某个位置`i`，若能匹配单词`words[x]`，那么再从位置`i + len(words[x])`尝试其他单词，最终将所有目标单词“吃掉”，此时确定`i`是结果之一；在这一过程中若某个位置无法匹配任何目标单词，那么确定`i`不符合要求。应当注意、可能会有某个单词被要求重复。

当前在此基础上的改进主要有两处。一是将频繁的匹配转换成查表、二是将持续的匹配过程修改为尾递归

<!-- todo -->
<!-- 双指针维护一个滑动窗口的解法 -->

> 以下是拐到沟里的思路、整个直接想歪了额

存在这样的解法：对所有单词进行全排列、共有`N!`种排列，尝试定位每一种排列。看题目约束，`N`可能是一个相当大的数字，这种做法没有可行性

现解法是基于递归思路，程序主要部分是回答“字符串某点后是否紧跟部分单词的连接”这一问题。例如某起始点存在一个单词，跳过这个单词后、应当紧跟其余单词中的任一个、再跳过后还应存在一个，直到所有单词连接成功，此时确定起始点是个合法位置。这一过程是递归且可以优化成尾递归的。递归部分的实现过程中、依赖“不可变集合”及其相关性质。由于不可变集合的程序集未直接集成、因此C#版本题解未提交成功。待解决。

注意到平台支持混合范式编程语言Scala、有内置的不可变相关集合、以Scala实现该解法然后提交测试、

https://leetcode-cn.com/problems/substring-with-concatenation-of-all-words/solution/

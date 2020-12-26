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

存在这样的解法：对所有单词进行全排列、共有`N!`种排列，尝试定位每一种排列。但是看题目约束，`N`可能是一个相当大的数字，这种做法没有可行性

现解法是基于递归思路，程序主要部分是回答“字符串某点后是否紧跟部分单词的连接”这一问题。例如某起始点存在一个单词，跳过这个单词后、应当紧跟其余单词中的任一个、再跳过后还应存在一个，直到所有单词连接成功，此时确定起始点是个合法位置。这一过程是递归且可以优化成尾递归的。递归部分的实现过程中、依赖“不可变集合”及其相关性质。由于不可变集合的程序集未直接集成、因此C#版本题解未提交成功。待解决。

<!-- todo -->
<!-- 由于依赖库问题、尚未成功提交题解 -->

注意到平台支持混合范式编程语言Scala、有内置的不可变相关集合、以Scala实现该解法然后提交测试、

https://leetcode-cn.com/problems/substring-with-concatenation-of-all-words/solution/

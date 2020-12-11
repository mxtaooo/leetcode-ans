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

<!-- todo：完成题目分析 -->

想到了一个简单做法、对所有单词进行全排列、共有`N!`种排列，尝试定位每一种排列。看了下题目约束，`N`可能是一个相当大的数字，因此这种做法肯定不行。
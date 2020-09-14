# 3. Longest Substring Without Repeating Characters [Medium]

The [link](https://leetcode.com/problems/longest-substring-without-repeating-characters/) of question.

## Description

Given a string `s`, find the length of the **longest substring** without repeating characters.

Example 1:
```
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
```

Example 2:
```
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
```

Example 3:
```
Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
```

Example 4:
```
Input: s = ""
Output: 0
```

Constraints:
```
0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
```

## 题目分析

再次看到这道题目，第一反应是用Set来快速判断是否已有了当前字符，按序遍历所有字符，对于每个字符去集合中判断是否已存在，直接丢弃整个已缓存的Set并重新开始缓存。由于Set无法得知重复的元素位于已缓存字串的位置，这种实现无法处理`abac`这样的字串。

因此还是要采用滑动窗口的思路来解决问题，在字符串上维护一个滑动的窗口，按序遍历所有字符，对于每个字符，在窗口确认是否有重复，若无重复则延长窗口，否则便从左侧缩短窗口。在此过程中关注长度的变化情况。对于该思路的实现，最初版本是用StringBuilder持续进行字符的追加和重复序列的去除，将其进行优化，不在分配对象，仅记录窗口最左侧的下标，找到重复字符时，推动左侧右移。

Java版本是最初实现，仅用一个变量记录窗口最左侧位置，每当窗口右侧尝试延长时，都要从窗口最左侧开始验证每个字符不在窗口中，这种实现在窗口较长的时候效率低下，可以考虑引入映射用空间换时间（C#版本题解）

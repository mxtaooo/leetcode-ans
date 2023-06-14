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

> 根据思路三重新思考了一下，可能实现时的尾递归没能生效，导致运行效率低。

### 思路二

基于`*`先将`p`切分，然后按顺序进行`index of`操作

// 似乎只是思路一的改进，并没有本质的效率提升？

### 思路三

参考[leetcode Question 123: Wildcard Matching](http://yucoding.blogspot.com/2013/02/leetcode-question-123-wildcard-matching.html)和[Linear runtime and constant space solution](https://leetcode.com/problems/wildcard-matching/solutions/17810/linear-runtime-and-constant-space-solution/)

该方法使用双指针进行判断。
设定两指针`i`/`j`，分别表示当前在处理的`s`/`p`的位置；定义变量`star`，表示从`p`中发现的上一个`*`的位置；定义变量`sub`，表示从`p`中发现的`*`后，该`*`吃掉任意个字符后子串的起始位置。程序启动时，`i`/`j`为`0`，`star`/`sub`为`-1`。

匹配过程中，对于`p[j]`，若其为`?`或普通字符，若验证匹配`s[i]`则推动指针；若为`*`则由`star`记录其位置，并由`sub`记录此时`s`的位置(此时`sub`表示`*`吃掉了0个字符)；若不匹配，查看是否遇见过`*`，未遇见过说明匹配失败，若是遇见过，则让`sub`右移然后重新赋值给`i`(此时表示`*`多吃掉1个字符)，再开始新一轮匹配进程。

模式`p`可能是以一串`*`结束，因此匹配完`s`后应当验证一步。

该思路是相对最高效的实现，时间复杂度最坏为`O(mn)`，空间复杂度`O(1)`

### 思路四

动态规划方法

参考了[https://leetcode.com/problems/wildcard-matching/solutions/17812/my-java-dp-solution-using-2d-table/comments/17699](https://leetcode.com/problems/wildcard-matching/solutions/17812/my-java-dp-solution-using-2d-table/comments/17699)

定义二维布尔数组`dp`，数组中的任意元素`dp[i][j]`表示模式`p`的前`i`个字符是否能匹配字符串`s`的前`j`个字符。（注意数组中的位置与字符串位置的对应关系）
状态转移规则如下：对`dp[i][j]`，查看其对应位置的`p`，即`p[i-1]`，若为`?`或普通字符，则其状态应参考当前位置匹配状态及`dp[i-1][j-1]`（即左上方）；若为`*`，则状态应参考`dp[i][j-1]`（即左侧，表示`*`在左侧状态基础上再多吃掉了一个字符）或`dp[i-1][j]`（即上侧，表示`*`在上方状态基础上没有吃掉任何字符）
初始状态：`dp[0][0]`表示空模式匹配空字符串，因此必定为`true`；若模式`p`第一个字符是`*`，则数组第一行其余元素为`true`；遍历模式`p`，设定数组第一列，若遇见`*`，则对应位置的`dp[i][0]`取决于`dp[i-1][0]`
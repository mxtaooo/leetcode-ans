# 72. Edit Distance [Medium]

The original [**link**](https://leetcode.com/problems/edit-distance/) of problem.

## Description

Given two strings `word1` and `word2`, return the *minimum number of operations required to convert `word1` to `word2`*.

You have the following three operations permitted on a word:

+ Insert a character
+ Delete a character
+ Replace a character

**Example 1**:

```
Input: word1 = "horse", word2 = "ros"
Output: 3
Explanation: 
horse -> rorse (replace 'h' with 'r')
rorse -> rose (remove 'r')
rose -> ros (remove 'e')
```

**Example 2**:

```
Input: word1 = "intention", word2 = "execution"
Output: 5
Explanation: 
intention -> inention (remove 't')
inention -> enention (replace 'i' with 'e')
enention -> exention (replace 'n' with 'x')
exention -> exection (replace 'n' with 'c')
exection -> execution (insert 'u')
```

**Constraints**:

+ `0 <= word1.length, word2.length <= 500``
+ `word1` and `word2` consist of lowercase English letters.

## Analysis

动态规划思路解答该问题。

> 实际上到目前为止尚未真正理解该思路，但还是先将思路记录下来。

首先，字符串变换的方式有插入/删除/替换，但观察前两者操作结果，对字符串A的插入与对字符串B的删除“结果一致”，因此整体上操作分三种，对字符串A插入，对字符串B插入，字符串替换字符。
基于此，定义二维数组尺寸为`(A.length+1) * (B.length+1)`，其中的元素`dp[i,j]`表示A的长为`i`字串`A[0..i]`变换成B的长为`j`的字串`B[0..j]`所需的操作次数。关于`dp[i,j]`的取值，先观察字符`A[i]`与`B[j]`是否一致，若一致无需变换，直接取`dp[i-1,j-1]`的值即可(A的字串`A[0..i-1]`变换成B的字串`B[0..j-1]`后两子串直接延长即可)，若不一致，则需要从`dp[i-1,j]`、`dp[i,j-1]`、`dp[i-1,j-1]`三者中取最小值并加一，这表示`dp[i,j]`是在最短的变换路径上变换而来。
关于初始化，`dp[0,0]`表示两空串变换次数，直接赋值0，对“第一行”、“第一列”中的元素`dp[0,x]` `dp[x,0]`，都是由“空串”变换为长度为`x`的串的操作次数，其次数必定为`x`。

> 这是个经典问题，关键词“编辑距离”。

## Remark

Other valuable things in solving problem.

# 39. Combination Sum [Medium]

The [link](https://leetcode.com/problems/combination-sum/) of question.

## Description

Given an array of **distinct** integers `candidates` and a target integer `target`, return *a list of **all unique combinations** of `candidates` where the chosen numbers sum to `target`*. You may return the combinations in **any order**.

The **same** number may be chosen from `candidates` an **unlimited number of times**. Two combinations are unique if the frequency of at least one of the chosen numbers is different.

It is **guaranteed** that the number of unique combinations that sum up to `target` is less than `150` combinations for the given input.

**Example 1**:
```
Input: candidates = [2,3,6,7], target = 7
Output: [[2,2,3],[7]]
Explanation:
2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
7 is a candidate, and 7 = 7.
These are the only two combinations.
```

**Example 2**:
```
Input: candidates = [2,3,5], target = 8
Output: [[2,2,2,2],[2,3,3],[3,5]]
```
**Example 3**:
```
Input: candidates = [2], target = 1
Output: []
```

**Example 4**:
```
Input: candidates = [1], target = 1
Output: [[1]]
```

**Example 5**:
```
Input: candidates = [1], target = 2
Output: [[1,1]]
```

**Constraints**:
+ `1 <= candidates.length <= 30`
+ `1 <= candidates[i] <= 200`
+ All elements of `candidates` are **distinct**.
+ `1 <= target <= 500`

## 题目分析

当前实现采用渐进式解法、从`1`逐渐逼近`target`。因为任意数字都是“单子”或“和”，任意“和”都是“两元素”之和，其中的“元素”可能是多个“更小元素”的和。

当前优化点在于改进、使之能更快速判断两`list`相同。

<!--  -->

将同样的思路用F#描述出来、相对更简洁高效、因为F#内置不可变List结构、有序情况下能直接进行等值比较

当前实现的一大瓶颈还是在于两List相等判断上

https://leetcode-cn.com/problems/combination-sum/solution/zu-he-zong-he-by-leetcode-solution/
# 40. Combination Sum II [Medium]

The [link](https://leetcode.com/problems/combination-sum-ii/) of question.

## Description

Given a collection of candidate numbers (`candidates`) and a target number (`target`), find all unique combinations in `candidates` where the candidate numbers sum to `target`.

Each number in `candidates` may only be used **once** in the combination.

Note: The solution set must not contain duplicate combinations.

**Example 1**:
```
Input: candidates = [10,1,2,7,6,1,5], target = 8
Output: 
[
[1,1,6],
[1,2,5],
[1,7],
[2,6]
]
```

**Example 2**:
```
Input: candidates = [2,5,2,1,2], target = 5
Output: 
[
[1,2,2],
[5]
]
```

**Constraints**:

+ `1 <= candidates.length <= 100`
+ `1 <= candidates[i] <= 50`
+ `1 <= target <= 30`

## 题目分析

基于39题的递归解法进行简单修改、此外加入判断两集合是否一致的操作、即为正确解法

但以上去重解法过于粗暴、需要有更优雅的方式进行去重

https://leetcode-cn.com/problems/combination-sum-ii/solution/zu-he-zong-he-ii-by-leetcode-solution/


update：实现方式已更改、现无需主动判断两集合是否一致
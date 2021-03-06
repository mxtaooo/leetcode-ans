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

当前解法是个渐进式思路、从`1`逐渐逼近`target`。对任意数字`a`，可能有`a`或`a = b + c`，而`b`与`c`各自可能是“单元素”或“元素之和”。因此、从`1`的所有组合 -> 构建`2`的所有组合 -> ... -> 构建`target`的所有组合是符合直觉的。这一解法依赖对`list`去重，也因此当前解法的优化点在于改进比较算法、快速判断两`list`的元素一致性。这一思路天然适合函数式编程语言、因为其内置不可变集合结构、而两不可变集合的比较是进行结构与内容的比较、因此排序后能直接进行等值比较

中文力扣给出的[参考思路](https://leetcode-cn.com/problems/combination-sum/solution/zu-he-zong-he-by-leetcode-solution/)是搜索回溯+剪枝。仔细看了下是DFS的应用、算是正向的构建。尝试得到`target`过程中，减去已选择的元素，再尝试构建出其余元素。

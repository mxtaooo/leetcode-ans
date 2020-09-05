# 1. Two Sum [Easy]

The [**link**](https://leetcode.com/problems/two-sum/) of question.

## Description

Given an array of integers `nums` and and integer `target`, return *the indices of the two numbers such that they add up to `target`*.

You may assume that each input would have **exactly one solution**, and you may not use the *same* element twice.

You can return the answer in any order.

Example 1:
```
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Output: Because nums[0] + nums[1] == 9, we return [0, 1]
```

Example 2:
```
Input: nums = [3,2,4], target = 6
Output: [1,2]
```

Example 3:
```
Input: nums = [3,3], target = 6
Output: [0,1]
```

Constraints:
```
1 <= nums.length <= 10^5
-10^9 <= nums[i] <= 10^9
-10^9 <= target <= 10^9
```
**Only one valid answer exists**.

## 题目分析

限于个人功底，思考解决这个问题的时候只能想到最笨的方法。即遍历每个元素，从每个元素发起新的遍历，尝试找到满足条件的一对数字。该实现时间复杂度O(n^2)，空间复杂度O(1)

从题目讨论中学到了另一种思路，用哈希表来优化查找速度。遍历每个元素，首先尝试在哈希表中查找是否存在满足条件的目标数字，若存在直接返回结果，若不存在将自身及下标放到哈希表中，继续处理下个元素。该实现时间复杂度O(n)，空间复杂度O(n)

## 备注

.Net中`Dictionary<Key, Value>`类提供了`Add`和`TryAdd`方法，其中前者会在尝试添加重复键时抛出异常

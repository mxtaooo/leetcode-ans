# 41. First Missing Positive [Hard]

The [link](https://leetcode.com/problems/first-missing-positive/) of question.

## Description

Given an unsorted integer array `nums`, find the smallest missing positive integer.

**Example 1**:
```
Input: nums = [1,2,0]
Output: 3
```

**Example 2**:
```
Input: nums = [3,4,-1,1]
Output: 2
```

**Example 3**:
```
Input: nums = [7,8,9,11,12]
Output: 1
```

**Constraints**:

+ `0 <= nums.length <= 300`
+ `-2^31 <= nums[i] <= 2^31 - 1`

**Follow up**: Could you implement an algorithm that runs in `O(n)` time and uses constant extra space?

## 题目分析

题目要求了`O(n)`复杂度和常量规模空间占用，因此猜测了几个思路：
1. 两个变量，记录当前最小值左侧和最大值右侧，滑动游标过程中一路找到最后。这个思路问题在于找不到`[1,2,4,5]`中间的`3`
2. 两个变量，记录当前找到的“最小区间”。这个思路问题在于无法连接区间，例如`[1,2,5,6,3,4]`

学习到的解决思路，部分重排。
按照题目表述，方法返回值取值范围是`[1, nums.length + 1]`。对于数组内的元素`x`，若是处于区间`[1, nums.length]`，那就把它放到正确的位置`x-1`（注意要正确放置原有位置的元素）。在数组遍历过程中，逐个把接受的元素放到正确的位置。遍历完成后，所有位置与值不对应的都是范围内的缺失元素，将最小一个返回即可。若都对应，说明给定参数数组是“完美”的，返回`nums.length+1`即可。
注：“位置正确”的元素不再交换；每次交换保证至少多一个“位置正确”的元素。因此能保证重复元素不会重复交换，总交换次数不会超出`array.length`。因此总时间复杂度为`O(n)`。

几个其他思路（声称完美通过测试，但其实存在问题）：
1. 数组排序，然后遍历（时间复杂度`O(nlogn)`）
2. 数据存入哈希表，然后快速判断存在性（空间复杂度`O(n)`）

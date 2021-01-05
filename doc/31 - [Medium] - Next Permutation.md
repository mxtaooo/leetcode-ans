# 31. Next Permutation [Medium]

The [link](https://leetcode.com/problems/next-permutation/) of question.

## Description

Implement **next permutation**, which rearranges numbers into the lexicographically next greater permutation of numbers.

If such an arrangement is not possible, it must rearrange it as the lowest possible order (i.e., sorted in ascending order).

The replacement must be **in place** and use only constant extra memory.

Example 1:
```
Input: nums = [1,2,3]
Output: [1,3,2]
```

Example 2:
```
Input: nums = [3,2,1]
Output: [1,2,3]
```

Example 3:
```
Input: nums = [1,1,5]
Output: [1,5,1]
```

Example 4:
```
Input: nums = [1]
Output: [1]
```

Constraints:
```
1 <= nums.length <= 100
0 <= nums[i] <= 100
```

## 题目分析

这道题目主要是理解上存在问题、现将题意进行简单整理

对于给出的几个数字`[1, 2, 3]`，存在`[123, 132,213, 231, ...]`等排列，排列是可比较大小的。现要求找出给定排列紧跟的下一个排列，若给定排列已经最大，那么返回其最小排列。

> 引用力扣的大神[评论](https://leetcode-cn.com/problems/next-permutation/comments/25378)

---

要仅比当前数字“大一点点”的数字，是要找到一个合适的位置，对该位置的数字进行调换能确保数字是在变大。从最低位向最高位尝试找这样的目标位置，该位置`i`应当具备这样的性质：`digit[i] < digit[i+1]`即较小数字在前，遍历过的其他位（即`digit[i+1...n]`）都满足`digit[j] > digit[j+1]`即较大数字在前面。现在要做的就是将这一较小数字换到后面去，那么能确保数字在放大，然后将`digit[i+1...n]`再进行重排确保这一段相对最小。这样就能保证“恰好”生成“大一点点”的数字。

看了一下题解、主要优化点在于“重排”，由于可以确保后半段是从大到小的、那么只需要将后半段翻转即可
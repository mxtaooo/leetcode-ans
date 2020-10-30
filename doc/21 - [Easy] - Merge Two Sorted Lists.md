# 21. Merge Two Sorted Lists [Easy]

The [link](https://leetcode.com/problems/merge-two-sorted-lists/) of question.

## Description

Merge two sorted linked lists and return it as a new **sorted** list. The new list should be made by splicing together the nodes of the first two lists.

Example 1:

![](./img/21.jpg)

```
Input: l1 = [1,2,4], l2 = [1,3,4]
Output: [1,1,2,3,4,4]
```

Example 2:
```
Input: l1 = [], l2 = []
Output: []
```

Example 3:
```
Input: l1 = [], l2 = [0]
Output: [0]
```

Constraints:

The number of nodes in both lists is in the range `[0, 50]`.
`-100` <= Node.val <= `100`
Both `l1` and `l2` are sorted in **non-decreasing** order.

## 题目分析

当前实现是迭代法。首先给出一个哑节点用于标识出结果链表的头、然后依次比较两个链表的头节点，找到较小的一个将之接到结果链表上，最终到达一个链表已空的状态，然后将另一可能不为空的链表尾接入到结果链表。

题解还提供了递归法，每次调用都将结果链表延长一下，但是函数调用相对循环还是较为低效、当然可以实现成尾递归…
# 24.Swap Nodes in Pairs [Medium]

The [link](https://leetcode.com/problems/swap-nodes-in-pairs/) of question.

## Description

Given a linked list, swap every two adjacent nodes and return its head.

You may **not** modify the values in the list's nodes. Only nodes itself may be changed.

Example 1:

![](./img/24.jpg)
```
Input: head = [1,2,3,4]
Output: [2,1,4,3]
```

Example 2:
```
Input: head = []
Output: []
```

Example 3:
```
Input: head = [1]
Output: [1]
```

Constraints:

The number of nodes in the list is in the range `[0, 100]`.

`0 <= Node.val <= 100`

## 题目分析

反转链表节点对问题还是比较常规的，推动一个指针并关注其后面是否有节点构成对，若可以便反转。构造一个“哑”的头结点是处理单链表问题的常规操作，这样首节点也变成一个常规节点。
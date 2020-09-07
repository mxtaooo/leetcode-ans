# 2. Add Two Numbers [Medium]

The [link](https://leetcode.com/problems/add-two-numbers/) of question.

## Description

You are given two `non-empty` linked lists representing two non-negative integers. The digits are stored in `reverse order` and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example:
```
Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8
Explanation: 342 + 465 = 807.
```

## 题目分析

看题目能想到两种解法，一是先将链表转换成整数，然后调用整数加法，这种做法存在数字超出内置`int`/`long`表示范围的问题；第二中做法便是按位加的实现。

## 备注

F#中，`null`不是`ListNode`的合法值，必须用`None`及`ListNode option`来进行是否为空的判断和操作等。

`None`是用`null`进行内部表示，参考[Why None change to null automatically in F#](https://stackoverflow.com/questions/52827260/why-none-change-to-null-automatically-in-f)

此外，C#提供了一系列的语法糖用于简化可空类型的操作
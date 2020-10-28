# 19.Remove Nth Node From End of List [Medium]

## Description

Given the `head` of a linked list, remove the **nth** node from the end of the list and return its head.

**Follow up**: Could you do this in one pass?

Example 1:

![](./img/19.jpg)
```
Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]
```

Example 2:
```
Input: head = [1], n = 1
Output: []
```

Example 3:
```
Input: head = [1,2], n = 1
Output: [1]
```

Constraints:

The number of nodes in the list is `sz`.
```
1 <= sz <= 30
0 <= Node.val <= 100
1 <= n <= sz
```

## 题目分析

若要在一次遍历中就找到目标节点，用一个`index`标明当前元素是在已遍历链表中的位置。当找到目标位置时，随着游标移动，这一目标元素也跟随后移，始终保证对目标元素的引用。

为解决头节点删除问题，将传入链表延长一下；链表是单向，因此遍历中查找的目标节点是要删除节点的前一个，即第`n+1`个节点。
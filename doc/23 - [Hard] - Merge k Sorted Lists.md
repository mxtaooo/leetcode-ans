# 23. Merge k Sorted Lists [Hard]

The [link](https://leetcode.com/problems/merge-k-sorted-lists/) of question.

## Description

You are given an array of `k` linked-lists `lists`, each linked-list is sorted in ascending order.

*Merge all the linked-lists into one sorted linked-list and return it*.

Example 1:
```
Input: lists = [[1,4,5],[1,3,4],[2,6]]
Output: [1,1,2,3,4,4,5,6]
Explanation: The linked-lists are:
[
  1->4->5,
  1->3->4,
  2->6
]
merging them into one sorted list:
1->1->2->3->4->4->5->6
```

Example 2:
```
Input: lists = []
Output: []
```

Example 3:
```
Input: lists = [[]]
Output: []
```

Constraints:
```
k == lists.length
0 <= k <= 10^4
0 <= lists[i].length <= 500
-10^4 <= lists[i][j] <= 10^4
```
`lists[i]` is sorted in **ascending order**.
The sum of `lists[i].length` won't exceed `10^4`.

## 题目分析

现有实现是依赖二路合并实现的，但具体实现思路也是有些小区别。可以将所有链表向结果链表合并；也可以用分治法逐步归并，以尽可能保证数据规模不会差距太大。

---

题解还提出了其他思路，例如把所有数据放到一个大数组中然后进行统一排序；维护N个头节点的多路归并等
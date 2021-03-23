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


https://leetcode-cn.com/problems/combination-sum-ii/solution/zu-he-zong-he-ii-by-leetcode-solution/

考虑将相同的数放在一起进行处理，也就是说，如果数 $\textit{x}$ 出现了 yy 次，那么在递归时一次性地处理它们，即分别调用选择 0, 1, $\cdots$, y0,1,⋯,y 次 xx 的递归函数。这样我们就不会得到重复的组合。具体地：

我们使用一个哈希映射（HashMap）统计数组 \textit{candidates}candidates 中每个数出现的次数。在统计完成之后，我们将结果放入一个列表 \textit{freq}freq 中，方便后续的递归使用。

列表 \textit{freq}freq 的长度即为数组 \textit{candidates}candidates 中不同数的个数。其中的每一项对应着哈希映射中的一个键值对，即某个数以及它出现的次数。
在递归时，对于当前的第 \textit{pos}pos 个数，它的值为 \textit{freq}[\textit{pos}][0]freq[pos][0]，出现的次数为 \textit{freq}[\textit{pos}][1]freq[pos][1]，那么我们可以调用

\text{dfs}(\textit{pos}+1, \textit{rest} - i \times \textit{freq}[\textit{pos}][0])
dfs(pos+1,rest−i×freq[pos][0])

即我们选择了这个数 ii 次。这里 ii 不能大于这个数出现的次数，并且 i \times \textit{freq}[\textit{pos}][0]i×freq[pos][0] 也不能大于 \textit{rest}rest。同时，我们需要将 ii 个 \textit{freq}[\textit{pos}][0]freq[pos][0] 放入列表中。

这样一来，我们就可以不重复地枚举所有的组合了。

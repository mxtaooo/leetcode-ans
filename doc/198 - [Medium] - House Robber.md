## 198. House Robber [Medium]

The [link](https://leetcode.com/problems/house-robber/) of question.

## Description

You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and **it will automatically contact the police if two adjacent houses were broken into on the same night**.

Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight **without alerting the police**.

Example 1:
```
Input: nums = [1,2,3,1]
Output: 4
```

Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
Total amount you can rob = 1 + 3 = 4.

Example 2:
```
Input: nums = [2,7,9,3,1]
Output: 12
```

Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
Total amount you can rob = 2 + 9 + 1 = 12.


Constraints:
```
1 <= nums.length <= 100
0 <= nums[i] <= 400
```

## 题目分析

经典动态规划思路即可。
初始化一个长度为N的数组`dp`，定义`dp[n]`为到达第N处时的最大收益，此处收益有两种可能：第N-2位的最大收益及第N位的收益`dp[n-2]+arr[n]`；第N-1位的最大收益`dp[n-1]`，因此状态转移公式基本为：`dp[n] = max(dp[n-2]+arr[n], dp[n-1])`。初始状态明确，第一位的最大收益就是自身，第二位的最大收益是前两者最大值。


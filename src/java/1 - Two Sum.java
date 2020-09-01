package leetcode;

import java.util.HashMap;

public class Solution {

    public int[] twoSum(int[] nums, int target) {
        return v2(nums, target);
    }

    private int[] v1(int[] nums, int target) {
        for (int i = 0; i < nums.length; i++) {
            for (int j = i + 1; j < nums.length; j++) {
                if (nums[i] + nums[j] == target) {
                    return new int[]{i, j};
                }
            }
        }
        throw new IllegalArgumentException("no solution...");
    }

    private int[] v2(int[] nums, int target) {
        HashMap<Integer, Integer> map = new HashMap<>();
        for (int i = 0; i < nums.length; i++) {
            if (map.containsKey(target - nums[i])) {
                return new int[]{map.get(target - nums[i]), i};
            }
            map.put(nums[i], i);
        }
        throw new IllegalArgumentException("no solution...");
    }

    private static void print(int[] nums, int target) {
        int[] res = new Solution().twoSum(nums, target);
        System.out.println("[" + res[0] + ", " + res[1] + "]");
    }

    public static void main(String[] args) {
        print(new int[]{2, 7, 11, 15}, 9);
        print(new int[]{3, 2, 4}, 6);
        print(new int[]{3, 3}, 6);
    }
}

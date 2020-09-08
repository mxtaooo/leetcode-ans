
class Solution {

    public int lengthOfLongestSubstring(String s) {
        int max = 0;    // 记录已找到的最大长度
        int p = 0;      // 记录窗口左侧
        for (int i = 0; i < s.length(); i++) {
            var c = s.charAt(i);
            for (int j = p; j < i; j++) {
                if (s.charAt(j) == c) {
                    max = max > (i-p) ? max : (i-p);
                    p = j + 1;
                    break;
                }
            }
        }
        return max >= (s.length()-p) ? max : (s.length()-p);
    }

    public static void main(String[] args) {
        var s = new Solution();

        System.out.println("abcabcbb: " + s.lengthOfLongestSubstring("abcabcbb"));
        System.out.println("bbbbb: " + s.lengthOfLongestSubstring("bbbbb"));
        System.out.println("pwwkew: " + s.lengthOfLongestSubstring("pwwkew"));
        System.out.println(": " + s.lengthOfLongestSubstring(""));
        System.out.println("dvdf: " + s.lengthOfLongestSubstring("dvdf"));
        System.out.println("abcde: " + s.lengthOfLongestSubstring("abcde"));
        System.out.println("cdd: " + s.lengthOfLongestSubstring("cdd"));
    }
}
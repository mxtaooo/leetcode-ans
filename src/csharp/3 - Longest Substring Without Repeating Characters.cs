using System;
using System.Collections.Generic;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        var dict = new Dictionary<char, int>();
        var (left, max) = (0, 0);
        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (dict.ContainsKey(c) && dict[c] >= left)
            {
                max = Math.Max(max, i - left);
                left = dict[c] + 1;
            }
            dict[c] = i;
        }
        return Math.Max(max, s.Length-left);
    }
}
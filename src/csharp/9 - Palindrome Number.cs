using System.Collections.Generic;

public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;

        var digits = new List<int>();
        for (; x != 0; x /= 10)
        {
            digits.Add(x % 10);
        }
        for (var i = 0; i < digits.Count/2; i++)
        {
            if (digits[i] != digits[digits.Count-1-i]) return false;
        }
        return true;
    }
}
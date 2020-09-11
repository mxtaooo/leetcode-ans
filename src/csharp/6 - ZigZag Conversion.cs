using System.Text;

public class Solution
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1) return s;
        
        var buffers = new StringBuilder[numRows];
        for (int i = 0; i < numRows; i++)
        {
            buffers[i] = new StringBuilder();
        }
        
        for (var (i, j, inc) = (0, 0, true); i < s.Length; i++)
        {
            buffers[j].Append(s[i]);
            if (inc)
            {
                if (j+1 < numRows) {j++;}
                else {j--; inc = false;}
            }
            else
            {
                if (j > 0) {j--;}
                else {j++; inc = true;}
            }
        }
        
        var res = new StringBuilder();
        foreach (var sb in buffers)
        {
            res.Append(sb);
        }
        return res.ToString();
    }
}
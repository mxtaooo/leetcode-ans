using System.Collections;

namespace ConsoleApp;

class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{MaximalSquare([['0', '0', '0', '1'], ['1', '1', '0', '1'], ['1', '1', '1', '1'], ['0', '1', '1', '1'], ['0', '1', '1', '1']])}");
        Console.WriteLine($"{MaximalSquare([['1', '0', '1', '0', '0'], ['1', '0', '1', '1', '1'], ['1', '1', '1', '1', '1'], ['1', '0', '0', '1', '0']])}");
        Console.WriteLine($"{MaximalSquare([['0', '1'], ['1', '0']])}");
        Console.WriteLine($"{MaximalSquare([['0']])}");
    }

    private static int MaximalSquare(char[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var dp = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            if (matrix[i][0] == '1')
            {
                dp[i, 0] = 1;
            }
        }
        for (int j = 0; j < n; j++)
        {
            if (matrix[0][j] == '1')
            {
                dp[0, j] = 1;
            }
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (matrix[i][j] == '1')
                {
                    var l = 1;
                    while (l <= dp[i - 1, j - 1] && matrix[i - l][j] == '1' && matrix[i][j - l] == '1')
                    {
                        l++;
                    }
                    dp[i, j] = l;
                }
            }
        }
        var max = dp.Cast<int>().Max();
        return max * max;
    }

}


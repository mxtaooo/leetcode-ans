public class Solution 
{
    public int MinPathSum(int[][] grid)
    {

    }

    public int Impl1(int[][] grid) 
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var dp = new int[m, n];
        dp[0, 0] = grid[0][0];

        for (int i = 1; i < n; i++)
        {
            dp[0, i] = dp[0, i - 1] + grid[0][i];
        }
        for (int i = 1; i < m; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + grid[i][0];
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
            }
        }

        return dp[m - 1, n - 1];
    }

   public int Impl2(int[][] grid) 
   {
        var m = grid.Length;
        var n = grid[0].Length;

        for (int i = 1; i < n; i++)
        {
            grid[0][i] = grid[0][i - 1] + grid[0][i];
        }
        for (int i = 1; i < m; i++)
        {
            grid[i][0] = grid[i - 1][0] + grid[i][0];
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                grid[i][j] = Math.Min(grid[i - 1][j], grid[i][j - 1]) + grid[i][j];
            }
        }

        return grid[^1][^1];
    }

}
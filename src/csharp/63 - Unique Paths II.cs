public class Solution
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        var m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;

        var dp = new int[m, n];

        dp[0, 0] = obstacleGrid[0][0] == 0 ? 1 : 0;

        for (int i = 1; i < m; i++)
        {
            dp[i, 0] = obstacleGrid[i][0] == 1 ? 0 : dp[i - 1, 0];
        }

        for (int j = 1; j < n; j++)
        {
            dp[0, j] = obstacleGrid[0][j] == 1 ? 0 : dp[0, j - 1];
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (obstacleGrid[i][j] == 1)
                {
                    dp[i, j] = 0;
                }
                else
                {
                    dp[i, j] = (i > 0 ? dp[i - 1, j] : 0) + (j > 0 ? dp[i, j - 1] : 0);
                }
            }
        }
        return dp[m - 1, n - 1];
    }
}
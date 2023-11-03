class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {

    }

    private int Impl1(IList<IList<int>> triangle)
    {
        var dp = new List<List<int>>(triangle.Count)
        {
            new List<int> { triangle[0][0] }
        };

        for (int N = 2; N <= triangle.Count; N++)
        {
            var line = triangle[N - 1];
            var preDP = dp[N - 2];
            var curDP = new List<int>(N) { preDP[0] + line[0] };

            for (int j = 1; j < N - 1; j++)
            {
                curDP.Add(Math.Min(preDP[j - 1], preDP[j]) + line[j]);
            }
            curDP.Add(preDP[^1] + line[^1]);
            dp.Add(curDP);
        }

        return dp[^1].Min();
    }

    private int Impl2(IList<IList<int>> triangle)
    {
        var dp = new int[triangle.Count];
        dp[0] = triangle[0][0];
        var tmp = new int[triangle.Count];

        for (int N = 2; N <= triangle.Count; N++)
        {
            var line = triangle[N-1];
            tmp[0] = dp[0] + line[0];
            for (int j = 1; j < N-1 ; j++)
            {
                tmp[j] = Math.Min(dp[j - 1], dp[j]) + line[j];
            }
            tmp[N - 1] = dp[N - 2] + line[N - 1];

            (dp, tmp) = (tmp, dp);
        }

        return dp.Min();
    }
}
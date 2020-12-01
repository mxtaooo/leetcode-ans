class Solution
{
    // Time Limit Exceeded
    static int Divide(int dividend, int divisor)
    {
        switch (divisor)
        {
            case 1:
                return dividend;
            case -1 when dividend == int.MinValue:
                return int.MaxValue;
            case -1:
                return -dividend;
            default:
                break;
        }
        var result = 0;
        switch (dividend, divisor) 
        {
            case var _ when dividend > 0 && divisor < 0: 
                while (dividend >= 0)
                {
                    dividend += divisor;
                    result --;
                }
                result ++;
                break;
            case var _ when dividend < 0 && divisor > 0: 
                while (dividend <= 0)
                {
                    dividend += divisor;
                    result --;
                }
                result ++;
                break;
            case var _ when dividend < 0 && divisor < 0: 
                while (dividend <= divisor)
                {
                    dividend -= divisor;
                    result ++;
                }
                break;
            default:    // dividend >= 0 && divisor > 0
                while (dividend >= divisor)
                {
                    dividend -= divisor;
                    result ++;
                }
                break;
        }

        return result;
    }

    // ============================================

    // 判断两数字是否同号
    static bool IsSameFlag(int x, int y) => (x > 0 && y > 0) || (x < 0 && y < 0);

    // 被除数一路自加、尽快“放大”自身到除数的“另一侧”
    // TODO: 需要确认数字“放大”过程中的溢出情况
    static int HitBoundary(Dictionary<int, int> dict, int dividend, int divisor, int cur)
    {
        if ((dividend >= 0 && dict[cur] >= dividend) || (dividend < 0 && dict[cur] <= dividend))
        {
            return cur;
        }
        else
        {
            var next = cur + cur;
            var value = dict[cur] + dict[cur];
            dict[next] = value;
            return HitBoundary(dict, dividend, divisor, next);
        }
    }

    static int BinarySearch(Dictionary<int, int> dict, int dividend, int divisor, (int, int) range)
    {
        var (bottom, top) = range;
        if (top - bottom == 1)
        {
            return IsSameFlag(dividend, divisor) ? bottom : top;
        }
        else
        {
            var sep = IsSameFlag(dividend, divisor) ? (top - bottom) : (bottom - top);
            var half = default(int);
            foreach (var key in dict.Keys)
            {
                if (key + key == sep)
                {
                    half = key;
                }
            }
            var middle = (IsSameFlag(dividend, divisor) ? bottom : top) + half;
            var value = (IsSameFlag(dividend, divisor) ? dict[bottom] : dict[top]) + dict[half];
            dict[middle] = value;
            if (value > dividend)
            {
                return BinarySearch(dict, dividend, divisor, (bottom, middle));
            }
            else
            {
                return BinarySearch(dict, dividend, divisor, (middle, top));
            }
        }
    }

    static int Divide(int dividend, int divisor)
    {
        if (dividend == 0) return 0;
        switch (divisor)
        {
            case 1:
                return dividend;
            case -1 when dividend == int.MinValue:
                return int.MaxValue;
            case -1:
                return -dividend;
            default:
                break;
        }

        var dict = new Dictionary<int, int>
        {
            {-1, -divisor},
            {0, 0},
            {1, divisor}
        };

        var boundary = HitBoundary(dict, dividend, divisor, IsSameFlag(dividend, divisor) ? 1 : -1);

        foreach (var (key, value) in dict)
        {
            if (value == dividend)
            {
                return key;
            }
        }

        return BinarySearch(dict, dividend, divisor, boundary > 0 ? (0, boundary): (boundary, 0));
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Divide(10, 3));
        Console.WriteLine(Divide(7, -3));
        Console.WriteLine(Divide(0, 1));
        Console.WriteLine(Divide(1, 1));
        Console.WriteLine(Divide(-10, -3));
        Console.WriteLine(Divide(int.MinValue, -1));
        Console.WriteLine(Divide(1, -1));
        Console.WriteLine(Divide(12, 3));
        Console.WriteLine(Divide(-12, 3));
        Console.WriteLine(Divide(12, -3));
        Console.WriteLine(Divide(-12, -3));
        Console.WriteLine(Divide(int.MinValue, 1));
    }
}
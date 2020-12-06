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

    static bool IsSameFlag(int x, int y) => (x > 0 && y > 0) || (x < 0 && y < 0);

    static bool IsFarFromZero(int x, int y)
    {
        if (!IsSameFlag(x, y)) throw new ArgumentException();
        if (x > 0)
        {
            return x > y;
        }
        else
        {
            return x < y;
        }
    }

    static bool IsSumOverFlow(int x, int y)
    {
        try
        {
            var z = checked(x + y);
            return false;
        }
        catch (OverflowException)
        {
            return true;
        }
    }

    static int HitBoundary(Dictionary<int, int> dict, int dividend, int divisor, int cur)
    {
        if (dict[cur] == dividend || IsFarFromZero(dict[cur], dividend))
        {
            return cur;
        }
        else
        {
            if (dict[cur] > (int.MaxValue >> 1) || dict[cur] < (int.MinValue >> 1))
            {
                if (IsSumOverFlow(dict[cur], IsSameFlag(dividend, divisor) ? dict[1] : dict[-1]))
                {
                    return cur;
                }
                else
                {
                    var next = default(int); 
                    var enumration = dict[cur] > 0 ? dict.OrderByDescending(p => p.Value) : dict.OrderBy(p => p.Value);
                    foreach (var (key, value) in enumration)
                    {
                        if (!IsSumOverFlow(dict[cur], dict[key]))
                        {
                            dict[cur + key] = dict[cur] + dict[key];
                            next = cur + key;
                            break;
                        }
                    }
                    return HitBoundary(dict, dividend, divisor, next);
                }
            }
            else
            {
                dict[cur + cur] = dict[cur] + dict[cur];
                return HitBoundary(dict, dividend, divisor, cur+cur);
            }
        }
    }

    static int BinarySearch(Dictionary<int, int> dict, int dividend, int divisor, (int, int) range)
    {
        var (bottom, top) = range;
        if (Math.Abs(top - bottom) == 1)
        {
            return bottom;
        }
        else
        {
            var half = (top - bottom) >> 1;
            var middle = bottom + half;
            var value = dict[bottom] + dict[half];
            dict[middle] = value;
            if (IsFarFromZero(value, dividend))
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
        var x = dividend > 0 ? -dividend : dividend;
        var y = divisor > 0 ? -divisor : divisor;
        if (x > y) return 0;
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

        if (dividend == dict[boundary] || IsFarFromZero(dividend, dict[boundary]))
        {
            return boundary;
        }

        return BinarySearch(dict, dividend, divisor, (0, boundary));
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Divide(int.MaxValue, 2));
        Console.WriteLine(Divide(1100540749, -1090366779));
        Console.WriteLine(Divide(int.MaxValue / 2, int.MinValue));
        Console.WriteLine(Divide(int.MinValue, -3));
        Console.WriteLine(Divide(int.MaxValue, 3));
        Console.WriteLine(Divide(int.MinValue, 2));
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
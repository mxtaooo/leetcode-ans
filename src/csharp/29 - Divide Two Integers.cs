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

    // proper solution
    static int Divide(int dividend, int divisor)
    {
        static int InnerFunc(in int val, in int dividend, in int divisor)
        {
            if ((dividend > 0 ? -dividend : dividend) > (divisor > 0 ? -divisor : divisor))
            {
                return val;
            }
            var (k, v) = ((dividend > 0 && divisor > 0) || (dividend < 0 && divisor < 0)) ? (1, divisor) : (-1, -divisor);
            var pre = (k, v);
            while ((v > 0 && dividend > v && v <= (int.MaxValue >> 1)) || (v < 0 && dividend < v && v >= (int.MinValue >> 1)))
            {
                pre = (k, v);
                (k, v) = (k << 1, v << 1);
            }
            return InnerFunc(val + pre.k, dividend - pre.v, divisor);
        }

        // 结果溢出
        if (dividend == int.MinValue && divisor == -1)
        {
            return int.MaxValue;
        }
        else
        {
            return InnerFunc(0, dividend, divisor);
        }
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
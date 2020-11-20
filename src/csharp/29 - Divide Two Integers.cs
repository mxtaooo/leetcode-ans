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
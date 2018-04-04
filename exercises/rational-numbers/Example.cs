using System;

public static class RationalNumbers
{
    public static int[] Add(int[] firstAddendum, int[] secondAddendum)
    {
        var commonDenominator = nok(Math.Abs(firstAddendum[1]), Math.Abs(secondAddendum[1]));
        var numerator1 = firstAddendum[0] * commonDenominator / firstAddendum[1];
        var numerator2 = secondAddendum[0] * commonDenominator / secondAddendum[1];
        return Reduce(new int[]
            {
                numerator1 + numerator2, commonDenominator
            });
    }
    public static int[] Sub(int[] decrementable, int[] subtractor)
    {
        var commonDenominator = nok(Math.Abs(decrementable[1]), Math.Abs(subtractor[1]));
        var numerator1 = decrementable[0] * commonDenominator / decrementable[1];
        var numerator2 = subtractor[0] * commonDenominator / subtractor[1];
        return Reduce(new int[]
            {
                numerator1 - numerator2, commonDenominator
            });
    }
    public static int[] Mul(int[] multiplicand, int[] multiplier)
    {
        if (multiplier[0] == 0) return new int[] { 0, 1};
        var sign = Math.Sign(multiplicand[0]) / Math.Sign(multiplicand[1]) /
                   Math.Sign(multiplier[0]) / Math.Sign(multiplier[1]);

        return Reduce(new int[]
            {
                sign * Math.Abs( multiplicand[0]*multiplier[0]), Math.Abs(multiplicand[1]*multiplier[1])
            });
    }
    public static int[] Div(int[] divisible, int[] divider)
    {
        var sign = Math.Sign(divisible[0]) / Math.Sign(divisible[1]) /
                   Math.Sign(divider[0]) / Math.Sign(divider[1]);

        return Reduce(new int[]
            {
                sign * Math.Abs( divisible[0]*divider[1]), Math.Abs(divisible[1]*divider[0])
            });
    }
    public static int[] Abs(int[] value)
    {
        return new[] { Math.Abs(value[0]), Math.Abs(value[1])};
    }

    public static int[] Reduce(int[] properFraction)
    {
        if (properFraction[1] == 0) return properFraction;
        else if (properFraction[0] == 0) return new int[] { 0, 1};

        var a = Math.Abs(properFraction[0]);
        var b = Math.Abs(properFraction[1]);

        var sign = Math.Sign(properFraction[0]) * Math.Sign(properFraction[1]);

        return new int[] { sign * a / nod(a, b), b / nod(a,b) };
    }

    public static int[] Exprational(int[] baseNumber, int power)
    {
        if (power == 0) return new int[] { 1, 1 };

        var sign = Math.Sign(baseNumber[0]) / Math.Sign(baseNumber[1]);
        return Reduce(new int[]
            {
                sign *
                Math.Abs(myPow(baseNumber[0], power)),
                Math.Abs(myPow(baseNumber[1], power))
            });
    }

    public static double Expreal(int baseNumber, int[] power)
    {
        if (power[0] == 0) return 1;
        else
            return myPow2(baseNumber, power);
    }

    private static int myPow(int baseNumber, int power)
    {
        var result = 1;
        for (int i = 1; i <= power; i++)
        {
            result *= baseNumber;
        }
        return result;
    }

    private static int nod(int a, int b)
    {
        var x = Math.Abs(a);
        var y = Math.Abs(b);

        while (a != b)
            if (a > b) a -= b; else b -= a;
        return a;
    }

    private static int nok(int a, int b)
    {
        return a * (b / nod(a, b));
    }

    private static double myPow2(int baseNumber, int[] power)
    {
        if (power[0] > 0 && power[1] > 0)
        {
            var tempResult = myPow(baseNumber, power[0]);
            return Math.Pow((double)tempResult, 1 / (double)power[1]);
        }
        else return Math.Pow((double)baseNumber, (double)power[0] / (double)power[1]);
    }
}
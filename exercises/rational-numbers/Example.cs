using System;

public static class RationalNumbers
{
    public static int[] Add(int[] firstAddendum, int[] secondAddendum)
    {
        var commonDenominator = nok(absValue(firstAddendum[1]), absValue(secondAddendum[1]));
        var numerator1 = firstAddendum[0] * commonDenominator / firstAddendum[1];
        var numerator2 = secondAddendum[0] * commonDenominator / secondAddendum[1];
        return Reduce(new int[]
            {
                numerator1 + numerator2, commonDenominator
            });
    }
    public static int[] Sub(int[] decrementable, int[] subtractor)
    {
        var commonDenominator = nok(absValue(decrementable[1]), absValue(subtractor[1]));
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
        var sign = getSign(multiplicand[0]) / getSign(multiplicand[1]) /
                   getSign(multiplier[0]) / getSign(multiplier[1]);

        return Reduce(new int[]
            {
                sign * absValue( multiplicand[0]*multiplier[0]), absValue(multiplicand[1]*multiplier[1])
            });
    }
    public static int[] Div(int[] divisible, int[] divider)
    {
        var sign = getSign(divisible[0]) / getSign(divisible[1]) /
                   getSign(divider[0]) / getSign(divider[1]);

        return Reduce(new int[]
            {
                sign * absValue( divisible[0]*divider[1]), absValue(divisible[1]*divider[0])
            });
    }
    public static int[] Abs(int[] value)
    {
        return new[] { absValue(value[0]), absValue(value[1])};
    }

    public static int[] Reduce(int[] properFraction)
    {
        if (properFraction[1] == 0) return properFraction;
        else if (properFraction[0] == 0) return new int[] { 0, 1};

        var a = absValue(properFraction[0]);
        var b = absValue(properFraction[1]);

        var sign = getSign(properFraction[0]) * getSign(properFraction[1]);

        return new int[] { sign * a / nod(a, b), b / nod(a,b) };
    }

    public static int[] Exprational(int[] baseNumber, int power)
    {
        if (power == 0) return new int[] { 1, 1 };

        var sign = getSign(baseNumber[0]) / getSign(baseNumber[1]);
        return Reduce(new int[]
            {
                sign *
                absValue(pow(baseNumber[0], power)),
                absValue(pow(baseNumber[1], power))
            });
    }

    public static double Expreal(int baseNumber, int[] power)
    {
        if (power[0] == 0) return 1;
        else
            return pow2(baseNumber, power);
    }

    private static int nod(int a, int b)
    {
        var x = absValue(a);
        var y = absValue(b);

        while (a != b)
            if (a > b) a -= b; else b -= a;
        return a;
    }

    private static int nok(int a, int b)
    {
        return a * (b / nod(a, b));
    }

    private static int absValue(int value)
    {
        return (value > 0) ? value : -value;
    }

    private static int getSign(int value)
    {
        return (value > 0) ? 1 : -1;
    }

    private static int pow(int baseNumber, int power)
    {
        var result = 1;
        for (int i = 1; i <= power; i++)
        {
            result *= baseNumber;
        }
        return result;
    }

    private static double pow2(int baseNumber, int[] power)
    {
        if (power[0] > 0 && power[1] > 0)
        {
            var tempResult = pow(baseNumber, power[0]);
            return Math.Pow((double)tempResult, 1 / (double)power[1]);
        }
        else return Math.Pow((double)baseNumber, (double)power[0] / (double)power[1]);
    }
}
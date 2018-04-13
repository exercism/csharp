using System;

public static class RationalNumbers
{
    private const int NUMERATOR_INDEX = 0;
    private const int DENOMINATOR_INDEX = 1;

    #region Main code: Add, Sub, Mul, Div, Abs, Reduce, Exprational, Expreal
    public static int[] Add(int[] r1, int[] r2)
    {
        return Reduce(new int[] { r1[NUMERATOR_INDEX] * r2[DENOMINATOR_INDEX] + r1[DENOMINATOR_INDEX] * r2[NUMERATOR_INDEX], r1[DENOMINATOR_INDEX] * r2[DENOMINATOR_INDEX] });
    }

    public static int[] Sub(int[] r1, int[] r2)
    {
        return Reduce(new int[] { r1[NUMERATOR_INDEX] * r2[DENOMINATOR_INDEX] - r1[DENOMINATOR_INDEX] * r2[NUMERATOR_INDEX], r1[DENOMINATOR_INDEX] * r2[DENOMINATOR_INDEX] });
    }

    public static int[] Mul(int[] r1, int[] r2)
    {
        if (r1[NUMERATOR_INDEX] == 0) return new int[] { 0, 1 };
        return Reduce(new int[] { r1[NUMERATOR_INDEX] * r2[NUMERATOR_INDEX], r1[DENOMINATOR_INDEX] * r2[DENOMINATOR_INDEX] });
    }

    public static int[] Div(int[] r1, int[] r2)
    {
        return Reduce(new int[] { r1[NUMERATOR_INDEX] * r2[DENOMINATOR_INDEX], r1[DENOMINATOR_INDEX] * r2[NUMERATOR_INDEX] });
    }

    public static int[] Abs(int[] value)
    {
        return new[] { getAbsValue(value[NUMERATOR_INDEX]), getAbsValue(value[DENOMINATOR_INDEX]) };
    }

    public static int[] Reduce(int[] properFraction)
    {
        if (properFraction[DENOMINATOR_INDEX] == 0) return properFraction;
        else if (properFraction[NUMERATOR_INDEX] == 0) return new int[] { 0, 1 };

        var a = getAbsValue(properFraction[NUMERATOR_INDEX]);
        var b = getAbsValue(properFraction[DENOMINATOR_INDEX]);

        var sign = getSign(properFraction[NUMERATOR_INDEX]) * getSign(properFraction[DENOMINATOR_INDEX]);

        return new int[] { sign * a / greatestCommonDivisor(a, b), b / greatestCommonDivisor(a, b) };
    }

    public static int[] Exprational(int[] baseNumber, int power)
    {
        if (power == 0) return new int[] { 1, 1 };

        var sign = getSign(baseNumber[NUMERATOR_INDEX]) / getSign(baseNumber[DENOMINATOR_INDEX]);
        return Reduce(new int[]
            {
                sign *
                getAbsValue((int)pow(baseNumber[NUMERATOR_INDEX], power)),
                getAbsValue((int)pow(baseNumber[DENOMINATOR_INDEX], power))
            });
    }

    public static double Expreal(int baseNumber, int[] power)
    {
        if (power[NUMERATOR_INDEX] == 0) return 1;
        else
            return pow(baseNumber, power);
    }
    #endregion

    #region Utilities
    private static double pow(int baseNumber, int[] power)
    {
        return nthRoot((getSign(power[NUMERATOR_INDEX]) == getSign(power[DENOMINATOR_INDEX]) ?
                        pow(baseNumber, getAbsValue(power[NUMERATOR_INDEX])) :
                        1d / pow(baseNumber, getAbsValue(power[NUMERATOR_INDEX]))),
                        getAbsValue(power[DENOMINATOR_INDEX]));
    }

    private static int getAbsValue(int value)
    {
        return (value > 0) ? value : -value;
    }

    private static double getAbsValue(double value)
    {
        return (value > 0) ? value : -value;
    }

    private static int getSign(int value)
    {
        return (value > 0) ? 1 : -1;
    }

    private static int greatestCommonDivisor(int a, int b)
    {
        var x = getAbsValue(a);
        var y = getAbsValue(b);

        while (a != b)
            if (a > b) a -= b; else b -= a;
        return a;
    }

    private static double pow(double baseValue, int exp)
    {
        double result = 1.0;
        while (exp != 0)
        {
            if ((exp & 1) != 0) result *= baseValue;
            baseValue *= baseValue;
            exp >>= 1;
        }
        return result;
    }

    private static double nthRoot(double baseValue, int n)
    {
        if (n == 1) return baseValue;
        double deltaX;
        double x = 0.1;
        do
        {
            deltaX = ((double)baseValue / pow(x, (n - 1)) - x) / n;
            x = x + deltaX;
        }
        while (getAbsValue(deltaX) > 0);
        return x;
    }
    #endregion

}
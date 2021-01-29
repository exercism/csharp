using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    // exponentiate real number to the rational number power
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return r.Expreal(realNumber);
    }
}

[DebuggerDisplay("{Numerator} / {Denominator}")]
public struct RationalNumber
{
    public RationalNumber(int numerator, int denominator)
    {
        this.Numerator = numerator;
        this.Denominator = denominator;
    }

    public int Numerator { get; }
    public int Denominator { get; }

    public static RationalNumber operator+ (RationalNumber r1, RationalNumber r2)
    {
        return ReducedRationalNumber(r1.Numerator * r2.Denominator + r1.Denominator * r2.Numerator, r1.Denominator * r2.Denominator);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return ReducedRationalNumber(r1.Numerator * r2.Denominator - r1.Denominator * r2.Numerator, r1.Denominator * r2.Denominator);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        if (r1.Numerator == 0) return new RationalNumber(0, 1);
        return ReducedRationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return ReducedRationalNumber(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Abs(this.Numerator), Abs(this.Denominator));
    }

    public RationalNumber Reduce()
    {
        if (this.Denominator == 0) return new RationalNumber(this.Numerator, this.Denominator);
        else if (this.Numerator == 0) return new RationalNumber(0, 1);

        var a = Abs(this.Numerator);
        var b = Abs(this.Denominator);

        var sign = Sign(this.Numerator) * Sign(this.Denominator);

        return new RationalNumber(sign * a / GreatestCommonDenominator(a, b), b / GreatestCommonDenominator(a, b));
    }

    public RationalNumber Exprational(int power)
    {
        if (power == 0) return new RationalNumber(1, 1);

        return ReducedRationalNumber
            (
                (Sign(this.Numerator) / Sign(this.Denominator)) *
                Abs((int)Pow(this.Numerator, power)),
                Abs((int)Pow(this.Denominator, power))
            );
    }

    public double Expreal(int baseNumber)
    {
        if (this.Numerator == 0)
            return 1;
        else
            return Pow(baseNumber);
    }

    private static RationalNumber ReducedRationalNumber(int numerator, int denominator)
    {
        return new RationalNumber(numerator, denominator).Reduce();
    }

    private double Pow(int baseNumber)
    {
        return NthRoot((Sign(this.Numerator) == Sign(this.Denominator) ?
                        Pow(baseNumber, Abs(this.Numerator)) :
                        1d / Pow(baseNumber, Abs(this.Numerator))),
                        Abs(this.Denominator));
    }

    private int Abs(int value)
    {
        return (value > 0) ? value : -value;
    }

    private double Abs(double value)
    {
        return (value > 0) ? value : -value;
    }

    private int Sign(int value)
    {
        return (value > 0) ? 1 : -1;
    }

    private int GreatestCommonDenominator(int a, int b)
    {
        var x = Abs(a);
        var y = Abs(b);

        while (x != 0 && y != 0)
            if (x > y) x %= y; else y %= x;
        return x == 0 ? y : x;
    }

    private double Pow(double baseValue, int exp)
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

    private double NthRoot(double baseValue, int n)
    {
        if (n == 1) return baseValue;
        double deltaX;
        double x = 0.1;
        do
        {
            deltaX = ((double)baseValue / Pow(x, (n - 1)) - x) / n;
            x = x + deltaX;
        }
        while (Abs(deltaX) > 0);
        return x;
    }
}
public record RationalNumber(int Numerator, int Denominator)
{
    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator).Reduce();

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator).Reduce();

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator).Reduce();

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(r1.Numerator * r2.Denominator, r2.Numerator * r1.Denominator).Reduce();

    public RationalNumber Abs() => new RationalNumber(System.Math.Abs(Numerator), System.Math.Abs(Denominator)).Reduce();

    public RationalNumber Reduce()
    {
        var divisor = Math.Gcd(System.Math.Abs(Numerator), System.Math.Abs(Denominator));
        return Denominator >= 0
            ? new RationalNumber(Numerator / divisor, Denominator / divisor)
            : new RationalNumber(Numerator * -1 / divisor, Denominator * -1 / divisor);
    }
    public RationalNumber Exprational(int power) =>
        power >= 0
            ? new RationalNumber((int)System.Math.Pow(Numerator, power), (int)System.Math.Pow(Denominator, power)).Reduce()
            : new RationalNumber((int)System.Math.Pow(Denominator, System.Math.Abs(power)), (int)System.Math.Pow(Numerator, System.Math.Abs(power))).Reduce();

    public double Expreal(int baseNumber) => Math.NthRoot(System.Math.Pow(baseNumber, Numerator), Denominator, 1e-9);
}

public static class IntExtensions
{
    public static double Expreal(this int realNumber, RationalNumber r) => r.Expreal(realNumber);
}

public static class Math
{
    public static int Gcd(int x, int y) => y == 0 ? x : Gcd(y, x % y);

    public static double NthRoot(double A, double n, double p)
    {
        var x = new double[2];
        x[0] = A;
        x[1] = A / n;
        while (System.Math.Abs(x[0] - x[1]) > p)
        {
            x[1] = x[0];
            x[0] = (1 / n) * (((n - 1) * x[1]) + (A / System.Math.Pow(x[1], n - 1)));
        }
        return x[0];
    }
}

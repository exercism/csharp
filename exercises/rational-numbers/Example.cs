using System;


public static class RationalNumbers
{
    public static int[] Add(int[] r1, int[] r2)
    {
        return Reduce(new int[] {r1[0]*r2[1] + r1[1]*r2[0], r1[1]*r2[1]});
    }
    public static int[] Sub(int[] r1, int[] r2)
    {
        return Reduce(new int[] { r1[0] * r2[1] - r1[1] * r2[0], r1[1] * r2[1] });

    }
    public static int[] Mul(int[] r1, int[] r2)
    {
        if (r1[0] == 0) return new int[] { 0, 1};
        return Reduce(new int[] { r1[0] * r2[0] , r1[1] * r2[1] });
    }
    public static int[] Div(int[] r1, int[] r2)
    {
        return Reduce(new int[] { r1[0] * r2[1], r1[1] * r2[0] });
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

    //private static int nok(int a, int b)
    //{
    //    return a * (b / nod(a, b));
    //}

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

    private static double pow(double baseNumber, int power)
    {
        double result = 1;
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
            //return Math.Pow((double)tempResult, 1 / (double)power[1]);
            return SqrtN(power[1],(double)tempResult);
        }
        else return Math.Pow((double)baseNumber, (double)power[0] / (double)power[1]);

    }

    static double SqrtN(double n, double A, double eps = 0.0001)
    {
        var x0 = A / n;
        var x1 = (1 / n) * ((n - 1) * x0 + A / pow(x0, (int)n - 1));

        while (Math.Abs(x1 - x0) > eps)
        {
            x0 = x1;
            x1 = (1 / n) * ((n - 1) * x0 + A / pow(x0, (int)n - 1));
        }

        return x1;
    }

    // Алгоритм нахождения корня n-ной степени
    // https://ru.wikipedia.org/wiki/%D0%90%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC_%D0%BD%D0%B0%D1%85%D0%BE%D0%B6%D0%B4%D0%B5%D0%BD%D0%B8%D1%8F_%D0%BA%D0%BE%D1%80%D0%BD%D1%8F_n-%D0%BD%D0%BE%D0%B9_%D1%81%D1%82%D0%B5%D0%BF%D0%B5%D0%BD%D0%B8


    //static double NthRoot(double A, int N)
    //{
    //    return Math.Pow(A, 1.0 / N);
    //}

    // https://github.com/exercism/fsharp/blob/master/exercises/rational-numbers/Example.fs

    // Calculate the root of a number without useing the root function or decimal numbers
    // https://math.stackexchange.com/questions/34913/calculate-the-root-of-a-number-without-useing-the-root-function-or-decimal-numbe

    //let rec private gcd x y =
    //if y = 0 then x
    //else gcd y(x % y)

    //let private nthroot n a =
    //    let rec f x =
    //        let m = n - 1.
    //        let x' = (m * x + a / x ** m) / n
    //        match abs(x' - x) with
    //        | t when t<abs(x* 1e-9) -> x'
    //        | _ -> f x'
    //    f(a / float n)

}
using System;

public struct ComplexNumber
{
    public int Real { get; set; }

    public int Imaginary { get; set; }
}

public static class ComplexNumbers
{
    public static ComplexNumber Mul(ComplexNumber z1, ComplexNumber z2)
    {
        return new ComplexNumber
        {
            Real = z1.Real * z2.Real - z1.Imaginary * z2.Imaginary,
            Imaginary = z1.Imaginary * z2.Real + z1.Real * z2.Imaginary
        };
    }

    public static ComplexNumber Add(ComplexNumber z1, ComplexNumber z2)
    {
        return new ComplexNumber
        {
            Real = z1.Real + z2.Real,
            Imaginary = z1.Imaginary + z2.Imaginary
        };
    }

    public static ComplexNumber Sub(ComplexNumber z1, ComplexNumber z2)
    {
        return new ComplexNumber
        {
            Real = z1.Real - z2.Real,
            Imaginary = z1.Imaginary - z2.Imaginary
        };
    }

    public static ComplexNumber Div(ComplexNumber z1, ComplexNumber z2)
    {
        var denominator = z2.Real * z2.Real + z2.Imaginary * z2.Imaginary;
        var real = (z1.Real * z2.Real + z1.Imaginary * z2.Imaginary) / denominator;
        var imaginary = (z1.Imaginary * z2.Real - z1.Real * z1.Real * z2.Imaginary) / denominator;

        return new ComplexNumber
        {
            Real = real,
            Imaginary = imaginary
        };
    }

    public static int Abs(ComplexNumber input)
    {
        return (int)Math.Sqrt(input.Real * input.Real + input.Imaginary * input.Imaginary);
    }

    public static ComplexNumber Conjugate(ComplexNumber input)
    {
        return new ComplexNumber
        {
            Real = input.Real,
            Imaginary = -1 * input.Imaginary
        };
    }

    public static int Real(ComplexNumber input)
    {
        return input.Real;
    }

    public static int Imaginary(ComplexNumber input)
    {
        return input.Imaginary;
    }
}
using System;

public static class ComplexNumbers
{
    public static Tuple<int, int> Mul(Tuple<int, int> value1, Tuple<int, int> value2)
    {
        var num1 = new ComplexNumber(value1);
        var num2 = new ComplexNumber(value2);

        var result = new ComplexNumber(
            num1.Real * num2.Real - num1.Imaginary * num2.Imaginary,
            num1.Imaginary * num2.Real + num1.Real * num2.Imaginary);

        return result.ToTuple;
    }

    public static Tuple<int, int> Add(Tuple<int, int> value1, Tuple<int, int> value2)
    {
        var num1 = new ComplexNumber(value1);
        var num2 = new ComplexNumber(value2);

        var result = new ComplexNumber(
            num1.Real + num2.Real,
            num1.Imaginary + num2.Imaginary);

        return result.ToTuple;
    }

    public static Tuple<int, int> Sub(Tuple<int, int> value1, Tuple<int, int> value2)
    {
        var num1 = new ComplexNumber(value1);
        var num2 = new ComplexNumber(value2);

        var result = new ComplexNumber(
            num1.Real - num2.Real,
            num1.Imaginary - num2.Imaginary);

        return result.ToTuple;
    }

    public static Tuple<int, int> Div(Tuple<int, int> value1, Tuple<int, int> value2)
    {
        var num1 = new ComplexNumber(value1);
        var num2 = new ComplexNumber(value2);

        var denominator = num2.Real * num2.Real + num2.Imaginary * num2.Imaginary;
        var real = (num1.Real * num2.Real + num1.Imaginary * num2.Imaginary) / denominator;
        var imaginary = (num1.Imaginary * num2.Real - num1.Real * num1.Real * num2.Imaginary) / denominator;

        var result = new ComplexNumber(real, imaginary);

        return result.ToTuple;
    }

    public static int Abs(Tuple<int, int> value)
    {
        var num = new ComplexNumber(value);

        return (int)Math.Sqrt(num.Real * num.Real + num.Imaginary * num.Imaginary);
    }

    public static Tuple<int, int> Conjugate(Tuple<int, int> value)
    {
        var num = new ComplexNumber(value);
  
        var result = new ComplexNumber(num.Real, -1 * num.Imaginary);

        return result.ToTuple;
    }

    public static int Real(Tuple<int, int> value)
    {
        var num = new ComplexNumber(value);

        return num.Real;
    }

    public static int Imaginary(Tuple<int, int> value)
    {
        var num = new ComplexNumber(value);

        return num.Imaginary;
    }

    public class ComplexNumber
    {
        public ComplexNumber(Tuple<int, int> input)
            : this(input.Item1, input.Item2)
        {
        }

        public ComplexNumber(int real, int imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public int Real { get; }

        public int Imaginary { get; }

        public Tuple<int, int> ToTuple => new Tuple<int, int>(Real, Imaginary);
    }
}
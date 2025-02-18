using System;

public record ComplexNumber(double R, double I)
{
    public double Real() => R;

    public double Imaginary() => I;

    public ComplexNumber Mul(ComplexNumber other) =>
        new(R * other.R - I * other.I, I * other.R + R * other.I);

    public ComplexNumber Add(ComplexNumber other) =>
        new(R + other.R, I + other.I);

    public ComplexNumber Sub(ComplexNumber other) =>
        new(R - other.R, I - other.I);

    public ComplexNumber Div(ComplexNumber other)
    {
        var numerator = Mul(other.Conjugate());
        var denominator = other.Mul(other.Conjugate());

        return new(numerator.R / denominator.R, numerator.I / denominator.R);
    }

    public ComplexNumber Exp()  =>
        new(Math.Exp(R) * Math.Cos(I), Math.Exp(R) * Math.Sin(I));

    public ComplexNumber Conjugate() => new(R, -I);

    public double Abs() => Math.Sqrt(Math.Pow(R, 2) + Math.Pow(I, 2));
    
    public static implicit operator ComplexNumber(double d) => new(d, 0.0);
}

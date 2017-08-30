using System;
using System.Diagnostics;

[DebuggerDisplay("{_real} + {_imaginary}i")]
public struct ComplexNumber
{
    private readonly double _real;
    private readonly double _imaginary;

    public ComplexNumber(double real, double imaginary)
    {
        _real = real;
        _imaginary = imaginary;
    }
    
    public double Real()
    {
        return _real;
    }

    public double Imaginary()
    {
        return _imaginary;
    }

    public ComplexNumber Mul(ComplexNumber other)
    {
        return new ComplexNumber(
            _real * other._real - _imaginary * other._imaginary,
            _imaginary * other._real + _real * other._imaginary);
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(
            _real + other._real,
            _imaginary + other._imaginary);
    }

    public ComplexNumber Sub(ComplexNumber other)
    {
        return new ComplexNumber(
            _real - other._real,
            _imaginary - other._imaginary);
    }

    public ComplexNumber Div(ComplexNumber other)
    {
        var denominator = other._real * other._real + other._imaginary * other._imaginary;
        var real = (_real * other._real + _imaginary * other._imaginary) / denominator;
        var imaginary = (_imaginary * other._real - _real * _real * other._imaginary) / denominator;

        return new ComplexNumber(real, imaginary);
    }

    public double Abs()
    {
        return Math.Sqrt(_real * _real + _imaginary * _imaginary);
    }

    public ComplexNumber Conjugate()
    {
        return new ComplexNumber(
            _real,
            -1 * _imaginary);
    }

    public ComplexNumber Exp()
    {
        var real = Math.Cos(_imaginary);
        var imaginary = Math.Sin(_imaginary);
        var factor = Math.Exp(_real);

        return new ComplexNumber(
            real * factor,
            imaginary * factor);
    }
}
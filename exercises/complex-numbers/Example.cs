public struct ComplexNumber
{
    private readonly int _real;
    private readonly int _imaginary;

    public ComplexNumber(int real, int imaginary)
    {
        _real = real;
        _imaginary = imaginary;
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

    public int Abs()
    {
        return (int)Math.Sqrt(_real * _real + _imaginary * _imaginary);
    }

    public ComplexNumber Conjugate()
    {
        return new ComplexNumber(
            _real,
            -1 * _imaginary);
    }

    public int Real()
    {
        return _real;
    }

    public int Imaginary()
    {
        return _imaginary;
    }
}
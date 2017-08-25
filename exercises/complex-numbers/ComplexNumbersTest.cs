// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class ComplexNumbersTest
{
    [Fact]
    public void Imaginary_unit()
    {
        var sut = new ComplexNumber(0, 1);
        var expected = new ComplexNumber(-1, 0);
        Assert.Equal(expected, sut.Mul(new ComplexNumber(0, 1)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_purely_real_numbers()
    {
        var sut = new ComplexNumber(1, 0);
        var expected = new ComplexNumber(3, 0);
        Assert.Equal(expected, sut.Add(new ComplexNumber(2, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_purely_imaginary_numbers()
    {
        var sut = new ComplexNumber(0, 1);
        var expected = new ComplexNumber(0, 3);
        Assert.Equal(expected, sut.Add(new ComplexNumber(0, 2)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_numbers_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(1, 2);
        var expected = new ComplexNumber(4, 6);
        Assert.Equal(expected, sut.Add(new ComplexNumber(3, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_purely_real_numbers()
    {
        var sut = new ComplexNumber(1, 0);
        var expected = new ComplexNumber(-1, 0);
        Assert.Equal(expected, sut.Sub(new ComplexNumber(2, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_purely_imaginary_numbers()
    {
        var sut = new ComplexNumber(0, 1);
        var expected = new ComplexNumber(0, -1);
        Assert.Equal(expected, sut.Sub(new ComplexNumber(0, 2)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_numbers_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(1, 2);
        var expected = new ComplexNumber(-2, -2);
        Assert.Equal(expected, sut.Sub(new ComplexNumber(3, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_purely_real_numbers()
    {
        var sut = new ComplexNumber(1, 0);
        var expected = new ComplexNumber(2, 0);
        Assert.Equal(expected, sut.Mul(new ComplexNumber(2, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_purely_imaginary_numbers()
    {
        var sut = new ComplexNumber(0, 1);
        var expected = new ComplexNumber(-2, 0);
        Assert.Equal(expected, sut.Mul(new ComplexNumber(0, 2)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_numbers_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(1, 2);
        var expected = new ComplexNumber(-5, 10);
        Assert.Equal(expected, sut.Mul(new ComplexNumber(3, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_purely_real_numbers()
    {
        var sut = new ComplexNumber(1, 0);
        var expected = new ComplexNumber(0.5, 0);
        Assert.Equal(expected, sut.Div(new ComplexNumber(2, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_purely_imaginary_numbers()
    {
        var sut = new ComplexNumber(0, 1);
        var expected = new ComplexNumber(0.5, 0);
        Assert.Equal(expected, sut.Div(new ComplexNumber(0, 2)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_numbers_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(1, 2);
        var expected = new ComplexNumber(0.44, 0.08);
        Assert.Equal(expected, sut.Div(new ComplexNumber(3, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_positive_purely_real_number()
    {
        var sut = new ComplexNumber(5, 0);
        Assert.Equal(5, sut.Abs());
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_negative_purely_real_number()
    {
        var sut = new ComplexNumber(-5, 0);
        Assert.Equal(5, sut.Abs());
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_purely_imaginary_number_with_positive_imaginary_part()
    {
        var sut = new ComplexNumber(0, 5);
        Assert.Equal(5, sut.Abs());
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_purely_imaginary_number_with_negative_imaginary_part()
    {
        var sut = new ComplexNumber(0, -5);
        Assert.Equal(5, sut.Abs());
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_number_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(3, 4);
        Assert.Equal(5, sut.Abs());
    }

    [Fact(Skip = "Remove to run test")]
    public void Conjugate_a_purely_real_number()
    {
        var sut = new ComplexNumber(5, 0);
        var expected = new ComplexNumber(5, 0);
        Assert.Equal(expected, sut.Conjugate());
    }

    [Fact(Skip = "Remove to run test")]
    public void Conjugate_a_purely_imaginary_number()
    {
        var sut = new ComplexNumber(0, 5);
        var expected = new ComplexNumber(0, -5);
        Assert.Equal(expected, sut.Conjugate());
    }

    [Fact(Skip = "Remove to run test")]
    public void Conjugate_a_number_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(1, 1);
        var expected = new ComplexNumber(1, -1);
        Assert.Equal(expected, sut.Conjugate());
    }

    [Fact(Skip = "Remove to run test")]
    public void Real_part_of_a_purely_real_number()
    {
        var sut = new ComplexNumber(1, 0);
        Assert.Equal(1, sut.Real());
    }

    [Fact(Skip = "Remove to run test")]
    public void Real_part_of_a_purely_imaginary_number()
    {
        var sut = new ComplexNumber(0, 1);
        Assert.Equal(0, sut.Real());
    }

    [Fact(Skip = "Remove to run test")]
    public void Real_part_of_a_number_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(1, 2);
        Assert.Equal(1, sut.Real());
    }

    [Fact(Skip = "Remove to run test")]
    public void Imaginary_part_of_a_purely_real_number()
    {
        var sut = new ComplexNumber(1, 0);
        Assert.Equal(0, sut.Imaginary());
    }

    [Fact(Skip = "Remove to run test")]
    public void Imaginary_part_of_a_purely_imaginary_number()
    {
        var sut = new ComplexNumber(0, 1);
        Assert.Equal(1, sut.Imaginary());
    }

    [Fact(Skip = "Remove to run test")]
    public void Imaginary_part_of_a_number_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(1, 2);
        Assert.Equal(2, sut.Imaginary());
    }
}
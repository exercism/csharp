// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class ComplexNumbersTest
{
    [Fact]
    public void Imaginary_unit()
    {
        var z1 = new ComplexNumber { Real = 0, Imaginary = 1 };
        var z2 = new ComplexNumber { Real = 0, Imaginary = 1 };
        var expected = new ComplexNumber { Real = -1, Imaginary = 0 };
        Assert.Equal(expected, ComplexNumbers.Mul(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_purely_real_numbers()
    {
        var z1 = new ComplexNumber { Real = 1, Imaginary = 0 };
        var z2 = new ComplexNumber { Real = 2, Imaginary = 0 };
        var expected = new ComplexNumber { Real = 3, Imaginary = 0 };
        Assert.Equal(expected, ComplexNumbers.Add(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_purely_imaginary_numbers()
    {
        var z1 = new ComplexNumber { Real = 0, Imaginary = 1 };
        var z2 = new ComplexNumber { Real = 0, Imaginary = 2 };
        var expected = new ComplexNumber { Real = 0, Imaginary = 3 };
        Assert.Equal(expected, ComplexNumbers.Add(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_numbers_with_real_and_imaginary_part()
    {
        var z1 = new ComplexNumber { Real = 1, Imaginary = 2 };
        var z2 = new ComplexNumber { Real = 3, Imaginary = 4 };
        var expected = new ComplexNumber { Real = 4, Imaginary = 6 };
        Assert.Equal(expected, ComplexNumbers.Add(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_purely_real_numbers()
    {
        var z1 = new ComplexNumber { Real = 1, Imaginary = 0 };
        var z2 = new ComplexNumber { Real = 2, Imaginary = 0 };
        var expected = new ComplexNumber { Real = -1, Imaginary = 0 };
        Assert.Equal(expected, ComplexNumbers.Sub(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_purely_imaginary_numbers()
    {
        var z1 = new ComplexNumber { Real = 0, Imaginary = 1 };
        var z2 = new ComplexNumber { Real = 0, Imaginary = 2 };
        var expected = new ComplexNumber { Real = 0, Imaginary = -1 };
        Assert.Equal(expected, ComplexNumbers.Sub(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_numbers_with_real_and_imaginary_part()
    {
        var z1 = new ComplexNumber { Real = 1, Imaginary = 2 };
        var z2 = new ComplexNumber { Real = 3, Imaginary = 4 };
        var expected = new ComplexNumber { Real = -2, Imaginary = -2 };
        Assert.Equal(expected, ComplexNumbers.Sub(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_purely_real_numbers()
    {
        var z1 = new ComplexNumber { Real = 1, Imaginary = 0 };
        var z2 = new ComplexNumber { Real = 2, Imaginary = 0 };
        var expected = new ComplexNumber { Real = 2, Imaginary = 0 };
        Assert.Equal(expected, ComplexNumbers.Mul(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_purely_imaginary_numbers()
    {
        var z1 = new ComplexNumber { Real = 0, Imaginary = 1 };
        var z2 = new ComplexNumber { Real = 0, Imaginary = 2 };
        var expected = new ComplexNumber { Real = -2, Imaginary = 0 };
        Assert.Equal(expected, ComplexNumbers.Mul(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_numbers_with_real_and_imaginary_part()
    {
        var z1 = new ComplexNumber { Real = 1, Imaginary = 2 };
        var z2 = new ComplexNumber { Real = 3, Imaginary = 4 };
        var expected = new ComplexNumber { Real = -5, Imaginary = 10 };
        Assert.Equal(expected, ComplexNumbers.Mul(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_purely_real_numbers()
    {
        var z1 = new ComplexNumber { Real = 1, Imaginary = 0 };
        var z2 = new ComplexNumber { Real = 2, Imaginary = 0 };
        var expected = new ComplexNumber { Real = 0, Imaginary = 0 };
        Assert.Equal(expected, ComplexNumbers.Div(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_purely_imaginary_numbers()
    {
        var z1 = new ComplexNumber { Real = 0, Imaginary = 1 };
        var z2 = new ComplexNumber { Real = 0, Imaginary = 2 };
        var expected = new ComplexNumber { Real = 0, Imaginary = 0 };
        Assert.Equal(expected, ComplexNumbers.Div(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_numbers_with_real_and_imaginary_part()
    {
        var z1 = new ComplexNumber { Real = 1, Imaginary = 2 };
        var z2 = new ComplexNumber { Real = 3, Imaginary = 4 };
        var expected = new ComplexNumber { Real = 0, Imaginary = 0 };
        Assert.Equal(expected, ComplexNumbers.Div(z1, z2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_positive_purely_real_number()
    {
        var input = new ComplexNumber { Real = 5, Imaginary = 0 };
        Assert.Equal(5, ComplexNumbers.Abs(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_negative_purely_real_number()
    {
        var input = new ComplexNumber { Real = -5, Imaginary = 0 };
        Assert.Equal(5, ComplexNumbers.Abs(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_purely_imaginary_number_with_positive_imaginary_part()
    {
        var input = new ComplexNumber { Real = 0, Imaginary = 5 };
        Assert.Equal(5, ComplexNumbers.Abs(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_purely_imaginary_number_with_negative_imaginary_part()
    {
        var input = new ComplexNumber { Real = 0, Imaginary = -5 };
        Assert.Equal(5, ComplexNumbers.Abs(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_number_with_real_and_imaginary_part()
    {
        var input = new ComplexNumber { Real = 3, Imaginary = 4 };
        Assert.Equal(5, ComplexNumbers.Abs(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Conjugate_a_purely_real_number()
    {
        var input = new ComplexNumber { Real = 5, Imaginary = 0 };
        var expected = new ComplexNumber { Real = 5, Imaginary = 0 };
        Assert.Equal(expected, ComplexNumbers.Conjugate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Conjugate_a_purely_imaginary_number()
    {
        var input = new ComplexNumber { Real = 0, Imaginary = 5 };
        var expected = new ComplexNumber { Real = 0, Imaginary = -5 };
        Assert.Equal(expected, ComplexNumbers.Conjugate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Conjugate_a_number_with_real_and_imaginary_part()
    {
        var input = new ComplexNumber { Real = 1, Imaginary = 1 };
        var expected = new ComplexNumber { Real = 1, Imaginary = -1 };
        Assert.Equal(expected, ComplexNumbers.Conjugate(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Real_part_of_a_purely_real_number()
    {
        var input = new ComplexNumber { Real = 1, Imaginary = 0 };
        Assert.Equal(1, ComplexNumbers.Real(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Real_part_of_a_purely_imaginary_number()
    {
        var input = new ComplexNumber { Real = 0, Imaginary = 1 };
        Assert.Equal(0, ComplexNumbers.Real(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Real_part_of_a_number_with_real_and_imaginary_part()
    {
        var input = new ComplexNumber { Real = 1, Imaginary = 2 };
        Assert.Equal(1, ComplexNumbers.Real(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Imaginary_part_of_a_purely_real_number()
    {
        var input = new ComplexNumber { Real = 1, Imaginary = 0 };
        Assert.Equal(0, ComplexNumbers.Imaginary(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Imaginary_part_of_a_purely_imaginary_number()
    {
        var input = new ComplexNumber { Real = 0, Imaginary = 1 };
        Assert.Equal(1, ComplexNumbers.Imaginary(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Imaginary_part_of_a_number_with_real_and_imaginary_part()
    {
        var input = new ComplexNumber { Real = 1, Imaginary = 2 };
        Assert.Equal(2, ComplexNumbers.Imaginary(input));
    }
}
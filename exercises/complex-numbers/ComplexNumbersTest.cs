// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;
using System;

public class ComplexNumbersTest
{
    [Fact]
    public void Imaginary_unit()
    {
        Assert.Equal(new Tuple<int, int>(-1, 0), ComplexNumbers.Mul(new Tuple<int, int>(0, 1), new Tuple<int, int>(0, 1)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_purely_real_numbers()
    {
        Assert.Equal(new Tuple<int, int>(3, 0), ComplexNumbers.Add(new Tuple<int, int>(1, 0), new Tuple<int, int>(2, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_purely_imaginary_numbers()
    {
        Assert.Equal(new Tuple<int, int>(0, 3), ComplexNumbers.Add(new Tuple<int, int>(0, 1), new Tuple<int, int>(0, 2)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_numbers_with_real_and_imaginary_part()
    {
        Assert.Equal(new Tuple<int, int>(4, 6), ComplexNumbers.Add(new Tuple<int, int>(1, 2), new Tuple<int, int>(3, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_purely_real_numbers()
    {
        Assert.Equal(new Tuple<int, int>(-1, 0), ComplexNumbers.Sub(new Tuple<int, int>(1, 0), new Tuple<int, int>(2, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_purely_imaginary_numbers()
    {
        Assert.Equal(new Tuple<int, int>(0, -1), ComplexNumbers.Sub(new Tuple<int, int>(0, 1), new Tuple<int, int>(0, 2)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_numbers_with_real_and_imaginary_part()
    {
        Assert.Equal(new Tuple<int, int>(-2, -2), ComplexNumbers.Sub(new Tuple<int, int>(1, 2), new Tuple<int, int>(3, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_purely_real_numbers()
    {
        Assert.Equal(new Tuple<int, int>(2, 0), ComplexNumbers.Mul(new Tuple<int, int>(1, 0), new Tuple<int, int>(2, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_purely_imaginary_numbers()
    {
        Assert.Equal(new Tuple<int, int>(-2, 0), ComplexNumbers.Mul(new Tuple<int, int>(0, 1), new Tuple<int, int>(0, 2)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_numbers_with_real_and_imaginary_part()
    {
        Assert.Equal(new Tuple<int, int>(-5, 10), ComplexNumbers.Mul(new Tuple<int, int>(1, 2), new Tuple<int, int>(3, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_purely_real_numbers()
    {
        Assert.Equal(new Tuple<int, int>(0, 0), ComplexNumbers.Div(new Tuple<int, int>(1, 0), new Tuple<int, int>(2, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_purely_imaginary_numbers()
    {
        Assert.Equal(new Tuple<int, int>(0, 0), ComplexNumbers.Div(new Tuple<int, int>(0, 1), new Tuple<int, int>(0, 2)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_numbers_with_real_and_imaginary_part()
    {
        Assert.Equal(new Tuple<int, int>(0, 0), ComplexNumbers.Div(new Tuple<int, int>(1, 2), new Tuple<int, int>(3, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_positive_purely_real_number()
    {
        Assert.Equal(5, ComplexNumbers.Abs(new Tuple<int, int>(5, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_negative_purely_real_number()
    {
        Assert.Equal(5, ComplexNumbers.Abs(new Tuple<int, int>(-5, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_purely_imaginary_number_with_positive_imaginary_part()
    {
        Assert.Equal(5, ComplexNumbers.Abs(new Tuple<int, int>(0, 5)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_purely_imaginary_number_with_negative_imaginary_part()
    {
        Assert.Equal(5, ComplexNumbers.Abs(new Tuple<int, int>(0, -5)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_number_with_real_and_imaginary_part()
    {
        Assert.Equal(5, ComplexNumbers.Abs(new Tuple<int, int>(3, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Conjugate_a_purely_real_number()
    {
        Assert.Equal(new Tuple<int, int>(5, 0), ComplexNumbers.Conjugate(new Tuple<int, int>(5, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Conjugate_a_purely_imaginary_number()
    {
        Assert.Equal(new Tuple<int, int>(0, -5), ComplexNumbers.Conjugate(new Tuple<int, int>(0, 5)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Conjugate_a_number_with_real_and_imaginary_part()
    {
        Assert.Equal(new Tuple<int, int>(1, -1), ComplexNumbers.Conjugate(new Tuple<int, int>(1, 1)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Real_part_of_a_purely_real_number()
    {
        Assert.Equal(1, ComplexNumbers.Real(new Tuple<int, int>(1, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Real_part_of_a_purely_imaginary_number()
    {
        Assert.Equal(0, ComplexNumbers.Real(new Tuple<int, int>(0, 1)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Real_part_of_a_number_with_real_and_imaginary_part()
    {
        Assert.Equal(1, ComplexNumbers.Real(new Tuple<int, int>(1, 2)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Imaginary_part_of_a_purely_real_number()
    {
        Assert.Equal(0, ComplexNumbers.Imaginary(new Tuple<int, int>(1, 0)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Imaginary_part_of_a_purely_imaginary_number()
    {
        Assert.Equal(1, ComplexNumbers.Imaginary(new Tuple<int, int>(0, 1)));
    }

    [Fact(Skip = "Remove to run test")]
    public void Imaginary_part_of_a_number_with_real_and_imaginary_part()
    {
        Assert.Equal(2, ComplexNumbers.Imaginary(new Tuple<int, int>(1, 2)));
    }
}
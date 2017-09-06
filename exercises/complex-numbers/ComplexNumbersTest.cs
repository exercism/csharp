// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;
using System;

public class ComplexNumbersTest
{
    [Fact]
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

    [Fact(Skip = "Remove to run test")]
    public void Imaginary_unit()
    {
        var sut = new ComplexNumber(0, 1);
        Assert.Equal(new[] { -1, 0 }, sut.Mul(new[] { 0, 1 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_purely_real_numbers()
    {
        var sut = new ComplexNumber(1, 0);
        Assert.Equal(new[] { 3, 0 }, sut.Add(new[] { 2, 0 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_purely_imaginary_numbers()
    {
        var sut = new ComplexNumber(0, 1);
        Assert.Equal(new[] { 0, 3 }, sut.Add(new[] { 0, 2 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_numbers_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(1, 2);
        Assert.Equal(new[] { 4, 6 }, sut.Add(new[] { 3, 4 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_purely_real_numbers()
    {
        var sut = new ComplexNumber(1, 0);
        Assert.Equal(new[] { -1, 0 }, sut.Sub(new[] { 2, 0 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_purely_imaginary_numbers()
    {
        var sut = new ComplexNumber(0, 1);
        Assert.Equal(new[] { 0, -1 }, sut.Sub(new[] { 0, 2 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_numbers_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(1, 2);
        Assert.Equal(new[] { -2, -2 }, sut.Sub(new[] { 3, 4 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_purely_real_numbers()
    {
        var sut = new ComplexNumber(1, 0);
        Assert.Equal(new[] { 2, 0 }, sut.Mul(new[] { 2, 0 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_purely_imaginary_numbers()
    {
        var sut = new ComplexNumber(0, 1);
        Assert.Equal(new[] { -2, 0 }, sut.Mul(new[] { 0, 2 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_numbers_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(1, 2);
        Assert.Equal(new[] { -5, 10 }, sut.Mul(new[] { 3, 4 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_purely_real_numbers()
    {
        var sut = new ComplexNumber(1, 0);
        var expected = new ComplexNumber(0,5, 0);
        Assert.Equal(expected.Real(), sut.Div(new[] { 2, 0 }).Real(), precision: 15);
        Assert.Equal(expected.Imaginary(), sut.Div(new[] { 2, 0 }).Imaginary(), precision: 15);
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_purely_imaginary_numbers()
    {
        var sut = new ComplexNumber(0, 1);
        var expected = new ComplexNumber(0,5, 0);
        Assert.Equal(expected.Real(), sut.Div(new[] { 0, 2 }).Real(), precision: 15);
        Assert.Equal(expected.Imaginary(), sut.Div(new[] { 0, 2 }).Imaginary(), precision: 15);
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_numbers_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(1, 2);
        Assert.Equal(0,440,08, sut.Div(new[] { 3, 4 }));
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
        Assert.Equal(new[] { 5, 0 }, sut.Conjugate());
    }

    [Fact(Skip = "Remove to run test")]
    public void Conjugate_a_purely_imaginary_number()
    {
        var sut = new ComplexNumber(0, 5);
        Assert.Equal(new[] { 0, -5 }, sut.Conjugate());
    }

    [Fact(Skip = "Remove to run test")]
    public void Conjugate_a_number_with_real_and_imaginary_part()
    {
        var sut = new ComplexNumber(1, 1);
        Assert.Equal(new[] { 1, -1 }, sut.Conjugate());
    }

    [Fact(Skip = "Remove to run test")]
    public void Eulers_identity_formula()
    {
        var sut = new ComplexNumber(0, Math.PI);
        Assert.Equal(new[] { -1, 0 }, sut.Exp());
    }

    [Fact(Skip = "Remove to run test")]
    public void Exponential_of_0()
    {
        var sut = new ComplexNumber(0, 0);
        Assert.Equal(new[] { 1, 0 }, sut.Exp());
    }

    [Fact(Skip = "Remove to run test")]
    public void Exponential_of_a_purely_real_number()
    {
        var sut = new ComplexNumber(1, 0);
        var expected = new ComplexNumber(Math.E, 0);
        Assert.Equal(expected.Real(), sut.Exp().Real(), precision: 15);
        Assert.Equal(expected.Imaginary(), sut.Exp().Imaginary(), precision: 15);
    }
}
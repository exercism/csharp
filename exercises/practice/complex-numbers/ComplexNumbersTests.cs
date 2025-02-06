using System;
using Xunit;

public class ComplexNumbersTests
{
    [Fact]
    public void Real_part_of_a_purely_real_number()
    {
        Assert.Equal(1, new ComplexNumber(1, 0).Real());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Real_part_of_a_purely_imaginary_number()
    {
        Assert.Equal(0, new ComplexNumber(0, 1).Real());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Real_part_of_a_number_with_real_and_imaginary_part()
    {
        Assert.Equal(1, new ComplexNumber(1, 2).Real());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Imaginary_part_of_a_purely_real_number()
    {
        Assert.Equal(0, new ComplexNumber(1, 0).Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Imaginary_part_of_a_purely_imaginary_number()
    {
        Assert.Equal(1, new ComplexNumber(0, 1).Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Imaginary_part_of_a_number_with_real_and_imaginary_part()
    {
        Assert.Equal(2, new ComplexNumber(1, 2).Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Imaginary_unit()
    {
        var actual = new ComplexNumber(0, 1).Mul(new ComplexNumber(0, 1));
        Assert.Equal(-1, actual.Real());
        Assert.Equal(0, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_purely_real_numbers()
    {
        var actual = new ComplexNumber(1, 0).Add(new ComplexNumber(2, 0));
        Assert.Equal(3, actual.Real());
        Assert.Equal(0, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_purely_imaginary_numbers()
    {
        var actual = new ComplexNumber(0, 1).Add(new ComplexNumber(0, 2));
        Assert.Equal(0, actual.Real());
        Assert.Equal(3, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_numbers_with_real_and_imaginary_part()
    {
        var actual = new ComplexNumber(1, 2).Add(new ComplexNumber(3, 4));
        Assert.Equal(4, actual.Real());
        Assert.Equal(6, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtract_purely_real_numbers()
    {
        var actual = new ComplexNumber(1, 0).Sub(new ComplexNumber(2, 0));
        Assert.Equal(-1, actual.Real());
        Assert.Equal(0, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtract_purely_imaginary_numbers()
    {
        var actual = new ComplexNumber(0, 1).Sub(new ComplexNumber(0, 2));
        Assert.Equal(0, actual.Real());
        Assert.Equal(-1, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Subtract_numbers_with_real_and_imaginary_part()
    {
        var actual = new ComplexNumber(1, 2).Sub(new ComplexNumber(3, 4));
        Assert.Equal(-2, actual.Real());
        Assert.Equal(-2, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiply_purely_real_numbers()
    {
        var actual = new ComplexNumber(1, 0).Mul(new ComplexNumber(2, 0));
        Assert.Equal(2, actual.Real());
        Assert.Equal(0, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiply_purely_imaginary_numbers()
    {
        var actual = new ComplexNumber(0, 1).Mul(new ComplexNumber(0, 2));
        Assert.Equal(-2, actual.Real());
        Assert.Equal(0, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiply_numbers_with_real_and_imaginary_part()
    {
        var actual = new ComplexNumber(1, 2).Mul(new ComplexNumber(3, 4));
        Assert.Equal(-5, actual.Real());
        Assert.Equal(10, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Divide_purely_real_numbers()
    {
        var actual = new ComplexNumber(1, 0).Div(new ComplexNumber(2, 0));
        Assert.Equal(0.5, actual.Real());
        Assert.Equal(0, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Divide_purely_imaginary_numbers()
    {
        var actual = new ComplexNumber(0, 1).Div(new ComplexNumber(0, 2));
        Assert.Equal(0.5, actual.Real());
        Assert.Equal(0, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Divide_numbers_with_real_and_imaginary_part()
    {
        var actual = new ComplexNumber(1, 2).Div(new ComplexNumber(3, 4));
        Assert.Equal(0.44, actual.Real());
        Assert.Equal(0.08, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Absolute_value_of_a_positive_purely_real_number()
    {
        Assert.Equal(5, new ComplexNumber(5, 0).Abs());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Absolute_value_of_a_negative_purely_real_number()
    {
        Assert.Equal(5, new ComplexNumber(-5, 0).Abs());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Absolute_value_of_a_purely_imaginary_number_with_positive_imaginary_part()
    {
        Assert.Equal(5, new ComplexNumber(0, 5).Abs());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Absolute_value_of_a_purely_imaginary_number_with_negative_imaginary_part()
    {
        Assert.Equal(5, new ComplexNumber(0, -5).Abs());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Absolute_value_of_a_number_with_real_and_imaginary_part()
    {
        Assert.Equal(5, new ComplexNumber(3, 4).Abs());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Conjugate_a_purely_real_number()
    {
        var actual = new ComplexNumber(5, 0).Conjugate();
        Assert.Equal(5, actual.Real());
        Assert.Equal(0, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Conjugate_a_purely_imaginary_number()
    {
        var actual = new ComplexNumber(0, 5).Conjugate();
        Assert.Equal(0, actual.Real());
        Assert.Equal(-5, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Conjugate_a_number_with_real_and_imaginary_part()
    {
        var actual = new ComplexNumber(1, 1).Conjugate();
        Assert.Equal(1, actual.Real());
        Assert.Equal(-1, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Euler_s_identity_formula()
    {
        var actual = new ComplexNumber(0, Math.PI).Exp();
        Assert.Equal(-1, actual.Real(), precision: 7);
        Assert.Equal(0, actual.Imaginary(), precision: 7);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Exponential_of_0()
    {
        var actual = new ComplexNumber(0, 0).Exp();
        Assert.Equal(1, actual.Real(), precision: 7);
        Assert.Equal(0, actual.Imaginary(), precision: 7);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Exponential_of_a_purely_real_number()
    {
        var actual = new ComplexNumber(1, 0).Exp();
        Assert.Equal(Math.E, actual.Real(), precision: 7);
        Assert.Equal(0, actual.Imaginary(), precision: 7);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Exponential_of_a_number_with_real_and_imaginary_part()
    {
        var actual = new ComplexNumber(Math.Log(2.0), Math.PI).Exp();
        Assert.Equal(-2, actual.Real(), precision: 7);
        Assert.Equal(0, actual.Imaginary(), precision: 7);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Exponential_resulting_in_a_number_with_real_and_imaginary_part()
    {
        var actual = new ComplexNumber(Math.Log(2.0) / 2, Math.PI / 4).Exp();
        Assert.Equal(1, actual.Real(), precision: 7);
        Assert.Equal(1, actual.Imaginary(), precision: 7);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Add_real_number_to_complex_number()
    {
        var actual = new ComplexNumber(1, 2).Add(5);
        Assert.Equal(6, actual.Real());
        Assert.Equal(2, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiply_complex_number_by_real_number()
    {
        var actual = new ComplexNumber(2, 5).Mul(5);
        Assert.Equal(10, actual.Real());
        Assert.Equal(25, actual.Imaginary());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Divide_complex_number_by_real_number()
    {
        var actual = new ComplexNumber(10, 100).Div(10);
        Assert.Equal(1, actual.Real());
        Assert.Equal(10, actual.Imaginary());
    }
}

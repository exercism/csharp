// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class RationalNumbersTest
{
    [Fact]
    public void Add_two_positive_rational_numbers()
    {
        Assert.Equal(new[] { 7, 6 }, RationalNumbers.Add(new[] { 1, 2 }, new[] { 2, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_a_positive_rational_number_and_a_negative_rational_number()
    {
        Assert.Equal(new[] { -1, 6 }, RationalNumbers.Add(new[] { 1, 2 }, new[] { -2, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_two_negative_rational_numbers()
    {
        Assert.Equal(new[] { -7, 6 }, RationalNumbers.Add(new[] { -1, 2 }, new[] { -2, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_a_rational_number_to_its_additive_inverse()
    {
        Assert.Equal(new[] { 0, 1 }, RationalNumbers.Add(new[] { 1, 2 }, new[] { -1, 2 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_two_positive_rational_numbers()
    {
        Assert.Equal(new[] { -1, 6 }, RationalNumbers.Sub(new[] { 1, 2 }, new[] { 2, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_a_positive_rational_number_and_a_negative_rational_number()
    {
        Assert.Equal(new[] { 7, 6 }, RationalNumbers.Sub(new[] { 1, 2 }, new[] { -2, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_two_negative_rational_numbers()
    {
        Assert.Equal(new[] { 1, 6 }, RationalNumbers.Sub(new[] { -1, 2 }, new[] { -2, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Subtract_a_rational_number_from_itself()
    {
        Assert.Equal(new[] { 0, 1 }, RationalNumbers.Sub(new[] { 1, 2 }, new[] { 1, 2 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_two_positive_rational_numbers()
    {
        Assert.Equal(new[] { 1, 3 }, RationalNumbers.Mul(new[] { 1, 2 }, new[] { 2, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_a_negative_rational_number_by_a_positive_rational_number()
    {
        Assert.Equal(new[] { -1, 3 }, RationalNumbers.Mul(new[] { -1, 2 }, new[] { 2, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_two_negative_rational_numbers()
    {
        Assert.Equal(new[] { 1, 3 }, RationalNumbers.Mul(new[] { -1, 2 }, new[] { -2, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_a_rational_number_by_its_reciprocal()
    {
        Assert.Equal(new[] { 1, 1 }, RationalNumbers.Mul(new[] { 1, 2 }, new[] { 2, 1 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_a_rational_number_by_1()
    {
        Assert.Equal(new[] { 1, 2 }, RationalNumbers.Mul(new[] { 1, 2 }, new[] { 1, 1 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiply_a_rational_number_by_0()
    {
        Assert.Equal(new[] { 0, 1 }, RationalNumbers.Mul(new[] { 1, 2 }, new[] { 0, 1 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_two_positive_rational_numbers()
    {
        Assert.Equal(new[] { 3, 4 }, RationalNumbers.Div(new[] { 1, 2 }, new[] { 2, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_a_positive_rational_number_by_a_negative_rational_number()
    {
        Assert.Equal(new[] { -3, 4 }, RationalNumbers.Div(new[] { 1, 2 }, new[] { -2, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_two_negative_rational_numbers()
    {
        Assert.Equal(new[] { 3, 4 }, RationalNumbers.Div(new[] { -1, 2 }, new[] { -2, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Divide_a_rational_number_by_1()
    {
        Assert.Equal(new[] { 1, 2 }, RationalNumbers.Div(new[] { 1, 2 }, new[] { 1, 1 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_positive_rational_number()
    {
        Assert.Equal(new[] { 1, 2 }, RationalNumbers.Abs(new[] { 1, 2 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_a_negative_rational_number()
    {
        Assert.Equal(new[] { 1, 2 }, RationalNumbers.Abs(new[] { -1, 2 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Absolute_value_of_zero()
    {
        Assert.Equal(new[] { 0, 1 }, RationalNumbers.Abs(new[] { 0, 1 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Raise_a_positive_rational_number_to_a_positive_integer_power()
    {
        Assert.Equal(new[] { 1, 8 }, RationalNumbers.Exprational(new[] { 1, 2 }, 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Raise_a_negative_rational_number_to_a_positive_integer_power()
    {
        Assert.Equal(new[] { -1, 8 }, RationalNumbers.Exprational(new[] { -1, 2 }, 3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Raise_zero_to_an_integer_power()
    {
        Assert.Equal(new[] { 0, 1 }, RationalNumbers.Exprational(new[] { 0, 1 }, 5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Raise_one_to_an_integer_power()
    {
        Assert.Equal(new[] { 1, 1 }, RationalNumbers.Exprational(new[] { 1, 1 }, 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Raise_a_positive_rational_number_to_the_power_of_zero()
    {
        Assert.Equal(new[] { 1, 1 }, RationalNumbers.Exprational(new[] { 1, 2 }, 0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Raise_a_negative_rational_number_to_the_power_of_zero()
    {
        Assert.Equal(new[] { 1, 1 }, RationalNumbers.Exprational(new[] { -1, 2 }, 0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Raise_a_real_number_to_a_positive_rational_number()
    {
        Assert.Equal(16, RationalNumbers.Expreal(8, new[] { 4, 3 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Raise_a_real_number_to_a_negative_rational_number()
    {
        Assert.Equal(0.333333333333333, RationalNumbers.Expreal(9, new[] { -1, 2 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Raise_a_real_number_to_a_zero_rational_number()
    {
        Assert.Equal(1, RationalNumbers.Expreal(2, new[] { 0, 1 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reduce_a_positive_rational_number_to_lowest_terms()
    {
        Assert.Equal(new[] { 1, 2 }, RationalNumbers.Reduce(new[] { 2, 4 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reduce_a_negative_rational_number_to_lowest_terms()
    {
        Assert.Equal(new[] { -2, 3 }, RationalNumbers.Reduce(new[] { -4, 6 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reduce_a_rational_number_with_a_negative_denominator_to_lowest_terms()
    {
        Assert.Equal(new[] { -1, 3 }, RationalNumbers.Reduce(new[] { 3, -9 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reduce_zero_to_lowest_terms()
    {
        Assert.Equal(new[] { 0, 1 }, RationalNumbers.Reduce(new[] { 0, 6 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reduce_an_integer_to_lowest_terms()
    {
        Assert.Equal(new[] { -2, 1 }, RationalNumbers.Reduce(new[] { -14, 7 }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reduce_one_to_lowest_terms()
    {
        Assert.Equal(new[] { 1, 1 }, RationalNumbers.Reduce(new[] { 13, 13 }));
    }
}
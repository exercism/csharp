// This file was auto-generated based on version 2.3.0 of the canonical data.

using System;
using Xunit;

public class AllYourBaseTest
{
    [Fact]
    public void Single_bit_one_to_decimal()
    {
        var inputBase = 2;
        var digits = new[] { 1 };
        var outputBase = 10;
        var expected = new[] { 1 };
        Assert.Equal(expected, AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Binary_to_single_decimal()
    {
        var inputBase = 2;
        var digits = new[] { 1, 0, 1 };
        var outputBase = 10;
        var expected = new[] { 5 };
        Assert.Equal(expected, AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Single_decimal_to_binary()
    {
        var inputBase = 10;
        var digits = new[] { 5 };
        var outputBase = 2;
        var expected = new[] { 1, 0, 1 };
        Assert.Equal(expected, AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Binary_to_multiple_decimal()
    {
        var inputBase = 2;
        var digits = new[] { 1, 0, 1, 0, 1, 0 };
        var outputBase = 10;
        var expected = new[] { 4, 2 };
        Assert.Equal(expected, AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Decimal_to_binary()
    {
        var inputBase = 10;
        var digits = new[] { 4, 2 };
        var outputBase = 2;
        var expected = new[] { 1, 0, 1, 0, 1, 0 };
        Assert.Equal(expected, AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Trinary_to_hexadecimal()
    {
        var inputBase = 3;
        var digits = new[] { 1, 1, 2, 0 };
        var outputBase = 16;
        var expected = new[] { 2, 10 };
        Assert.Equal(expected, AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Hexadecimal_to_trinary()
    {
        var inputBase = 16;
        var digits = new[] { 2, 10 };
        var outputBase = 3;
        var expected = new[] { 1, 1, 2, 0 };
        Assert.Equal(expected, AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_15_bit_integer()
    {
        var inputBase = 97;
        var digits = new[] { 3, 46, 60 };
        var outputBase = 73;
        var expected = new[] { 6, 10, 45 };
        Assert.Equal(expected, AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_list()
    {
        var inputBase = 2;
        var digits = Array.Empty<int>();
        var outputBase = 10;
        var expected = new[] { 0 };
        Assert.Equal(expected, AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Single_zero()
    {
        var inputBase = 10;
        var digits = new[] { 0 };
        var outputBase = 2;
        var expected = new[] { 0 };
        Assert.Equal(expected, AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_zeros()
    {
        var inputBase = 10;
        var digits = new[] { 0, 0, 0 };
        var outputBase = 2;
        var expected = new[] { 0 };
        Assert.Equal(expected, AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Leading_zeros()
    {
        var inputBase = 7;
        var digits = new[] { 0, 6, 0 };
        var outputBase = 10;
        var expected = new[] { 4, 2 };
        Assert.Equal(expected, AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Input_base_is_one()
    {
        var inputBase = 1;
        var digits = new[] { 0 };
        var outputBase = 10;
        Assert.Throws<ArgumentException>(() => AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Input_base_is_zero()
    {
        var inputBase = 0;
        var digits = Array.Empty<int>();
        var outputBase = 10;
        Assert.Throws<ArgumentException>(() => AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Input_base_is_negative()
    {
        var inputBase = -2;
        var digits = new[] { 1 };
        var outputBase = 10;
        Assert.Throws<ArgumentException>(() => AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Negative_digit()
    {
        var inputBase = 2;
        var digits = new[] { 1, -1, 1, 0, 1, 0 };
        var outputBase = 10;
        Assert.Throws<ArgumentException>(() => AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Invalid_positive_digit()
    {
        var inputBase = 2;
        var digits = new[] { 1, 2, 1, 0, 1, 0 };
        var outputBase = 10;
        Assert.Throws<ArgumentException>(() => AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Output_base_is_one()
    {
        var inputBase = 2;
        var digits = new[] { 1, 0, 1, 0, 1, 0 };
        var outputBase = 1;
        Assert.Throws<ArgumentException>(() => AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Output_base_is_zero()
    {
        var inputBase = 10;
        var digits = new[] { 7 };
        var outputBase = 0;
        Assert.Throws<ArgumentException>(() => AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Output_base_is_negative()
    {
        var inputBase = 2;
        var digits = new[] { 1 };
        var outputBase = -7;
        Assert.Throws<ArgumentException>(() => AllYourBase.Rebase(inputBase, digits, outputBase));
    }

    [Fact(Skip = "Remove to run test")]
    public void Both_bases_are_negative()
    {
        var inputBase = -2;
        var digits = new[] { 1 };
        var outputBase = -7;
        Assert.Throws<ArgumentException>(() => AllYourBase.Rebase(inputBase, digits, outputBase));
    }
}
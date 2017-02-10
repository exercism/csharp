using System;
using Xunit;

public class AllYourBaseTest
{
    [Fact]
    public void Single_bit_one_to_decimal()
    {
        const int inputBase = 2;
        var inputDigits = new [] { 1 };
        const int outputBase = 10;
        var outputDigits = new [] { 1 };
        Assert.Equal(outputDigits, Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Binary_to_single_decimal()
    {
        const int inputBase = 2;
        var inputDigits = new [] { 1, 0, 1 };
        const int outputBase = 10;
        var outputDigits = new [] { 5 };
        Assert.Equal(outputDigits, Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Single_decimal_to_binary()
    {  
        const int inputBase = 10;
        var inputDigits = new [] { 5 };
        const int outputBase = 2;
        var outputDigits = new [] { 1, 0, 1 };
        Assert.Equal(outputDigits, Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Binary_to_multiple_decimal()
    {
        const int inputBase = 2;
        var inputDigits = new [] { 1, 0, 1, 0, 1, 0 };
        const int outputBase = 10;
        var outputDigits = new [] { 4, 2 };
        Assert.Equal(outputDigits, Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Decimal_to_binary()
    {
        const int inputBase = 10;
        var inputDigits = new [] { 4, 2 };
        const int outputBase = 2;
        var outputDigits = new [] { 1, 0, 1, 0, 1, 0 };
        Assert.Equal(outputDigits, Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Trinary_to_hexadecimal()
    {
        const int inputBase = 3;
        var inputDigits = new [] { 1, 1, 2, 0 };
        const int outputBase = 16;
        var outputDigits = new [] { 2, 10 };
        Assert.Equal(outputDigits, Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Hexadecimal_to_trinary()
    {
        const int inputBase = 16;
        var inputDigits = new [] { 2, 10 };
        const int outputBase = 3;
        var outputDigits = new [] { 1, 1, 2, 0 };
        Assert.Equal(outputDigits, Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Using_15_bit_integer()
    {
        const int inputBase = 97;
        var inputDigits = new [] { 3, 46, 60 };
        const int outputBase = 73;
        var outputDigits = new [] { 6, 10, 45 };
        Assert.Equal(outputDigits, Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Empty_array()
    {
        const int inputBase = 2;
        var inputDigits = new int[0];
        const int outputBase = 10;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Single_zero()
    {
        const int inputBase = 10;
        var inputDigits = new [] { 0 };
        const int outputBase = 2;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Multiple_zeros()
    {
        const int inputBase = 10;
        var inputDigits = new [] { 0, 0, 0 };
        const int outputBase = 2;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Leading_zeros()
    {
        const int inputBase = 7;
        var inputDigits = new [] { 0, 6, 0 };
        const int outputBase = 10;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Negative_digit()
    {
        const int inputBase = 2;
        var inputDigits = new [] { 1, -1, 1, 0, 1, 0 };
        const int outputBase = 10;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Invalid_positive_digit()
    {
        const int inputBase = 2;
        var inputDigits = new [] { 1, 2, 1, 0, 1, 0 };
        const int outputBase = 10;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void First_base_is_one()
    {
        const int inputBase = 1;
        var inputDigits = new[] { 1, 0, 1, 0, 1, 0 };
        const int outputBase = 10;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Second_base_is_one()
    {
        const int inputBase = 2;
        var inputDigits = new [] { 1, 0, 1, 0, 1, 0 };
        const int outputBase = 1;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void First_base_is_zero()
    {
        const int inputBase = 0;
        var inputDigits = new int[0];
        const int outputBase = 10;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Second_base_is_zero()
    {
        const int inputBase = 10;
        var inputDigits = new [] { 7 };
        const int outputBase = 0;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void First_base_is_negative()
    {
        const int inputBase = -2;
        var inputDigits = new [] { 1 };
        const int outputBase = 10;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Second_base_is_negative()
    {
        const int inputBase = 2;
        var inputDigits = new [] { 1 };
        const int outputBase = -7;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }

    [Fact]
    public void Both_bases_are_negative()
    {
        const int inputBase = -2;
        var inputDigits = new [] { 1 };
        const int outputBase = -7;
        Assert.Throws<ArgumentException>(() => Base.Rebase(inputBase, inputDigits, outputBase));
    }
}
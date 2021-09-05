using Xunit;
using Exercism.Tests;
using System;
using System.Collections.Generic;

public class CalculatorExtensionsTests
{
    // Sum tests
    [Fact]
    public void Sum_with_positive_numbers()
    {
        var numbers = new int[] { 1, 2, 3, 4 };
        Assert.Equal(10, numbers.Sum());
    }

    [Fact]
    public void Sum_with_negative_numbers()
    {
        var numbers = new int[] { -1, -9, -2, -8 };
        Assert.Equal(-20, numbers.Sum());
    }

    // Product tests
    [Fact]
    public void Product_with_positive_and_negative_numbers()
    {
        var numbers = new int[] { -2, 10, 4 };
        Assert.Equal(-80, numbers.Product());
    }

    [Fact]
    public void Product_with_zero_in_numbers()
    {
        var numbers = new int[] { -2, 0, 10, 4 };
        Assert.Equal(0, numbers.Product());
    }

    // Mean tests
    [Fact]
    public void Mean_with_integer_result()
    {
        var numbers = new int[] { 2, 3, 4 };
        Assert.Equal(3.0, numbers.Mean());
    }

    [Fact]
    public void Mean_with_decimal_result()
    {
        var numbers = new int[] { 1, 2, 2, 3, 3 };
        Assert.Equal(2.2, numbers.Mean());
    }

    // Median tests
    [Fact]
    public void Median_with_odd_amount_of_numbers()
    {
        var numbers = new int[] { 1, 2, 2, 3, 3 };
        Assert.Equal(2, numbers.Median());
    }

    [Fact]
    public void Median_with_even_amount_of_numbers()
    {
        var numbers = new int[] { 1, 2, 2, 3, 3, 4 };
        Assert.Equal(2.5, numbers.Median());
    }

    [Fact]
    public void Median_with_unsorted_numbers()
    {
        var numbers = new int[] { 4, 3, 2, 1, 2, 3 };
        Assert.Equal(2.5, numbers.Median());
    }

    // Mode tests
    [Fact]
    public void Mode_with_one_mode_in_numbers()
    {
        var numbers = new int[] { 4, 3, 3, 1, 2, 3 };
        Assert.Equal(3, numbers.Mode());
    }

    [Fact]
    public void Mode_with_multiple_modes_in_numbers_returns_biggest()
    {
        var numbers = new int[] { 4, 3, 2, 1, 2, 3 };
        Assert.Equal(3, numbers.Mode());
    }
}

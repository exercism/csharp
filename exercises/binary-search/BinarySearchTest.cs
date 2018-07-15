// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using Xunit;

public class BinarySearchTest
{
    [Fact]
    public void Finds_a_value_in_an_array_with_one_element()
    {
        var array = new[] { 6 };
        var sut = new BinarySearch(array);
        Assert.Equal(0, sut.Find(6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Finds_a_value_in_the_middle_of_an_array()
    {
        var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
        var sut = new BinarySearch(array);
        Assert.Equal(3, sut.Find(6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Finds_a_value_at_the_beginning_of_an_array()
    {
        var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
        var sut = new BinarySearch(array);
        Assert.Equal(0, sut.Find(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Finds_a_value_at_the_end_of_an_array()
    {
        var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
        var sut = new BinarySearch(array);
        Assert.Equal(6, sut.Find(11));
    }

    [Fact(Skip = "Remove to run test")]
    public void Finds_a_value_in_an_array_of_odd_length()
    {
        var array = new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 634 };
        var sut = new BinarySearch(array);
        Assert.Equal(9, sut.Find(144));
    }

    [Fact(Skip = "Remove to run test")]
    public void Finds_a_value_in_an_array_of_even_length()
    {
        var array = new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377 };
        var sut = new BinarySearch(array);
        Assert.Equal(5, sut.Find(21));
    }

    [Fact(Skip = "Remove to run test")]
    public void Identifies_that_a_value_is_not_included_in_the_array()
    {
        var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
        var sut = new BinarySearch(array);
        Assert.Equal(-1, sut.Find(7));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_value_smaller_than_the_arrays_smallest_value_is_not_included()
    {
        var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
        var sut = new BinarySearch(array);
        Assert.Equal(-1, sut.Find(0));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_value_larger_than_the_arrays_largest_value_is_not_included()
    {
        var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
        var sut = new BinarySearch(array);
        Assert.Equal(-1, sut.Find(13));
    }

    [Fact(Skip = "Remove to run test")]
    public void Nothing_is_included_in_an_empty_array()
    {
        var array = Array.Empty<int>();
        var sut = new BinarySearch(array);
        Assert.Equal(-1, sut.Find(1));
    }
}
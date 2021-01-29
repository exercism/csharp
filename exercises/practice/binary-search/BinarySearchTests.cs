// This file was auto-generated based on version 1.3.0 of the canonical data.

using System;
using Xunit;

public class BinarySearchTests
{
    [Fact]
    public void Finds_a_value_in_an_array_with_one_element()
    {
        var array = new[] { 6 };
        var value = 6;
        Assert.Equal(0, BinarySearch.Find(array, value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Finds_a_value_in_the_middle_of_an_array()
    {
        var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
        var value = 6;
        Assert.Equal(3, BinarySearch.Find(array, value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Finds_a_value_at_the_beginning_of_an_array()
    {
        var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
        var value = 1;
        Assert.Equal(0, BinarySearch.Find(array, value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Finds_a_value_at_the_end_of_an_array()
    {
        var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
        var value = 11;
        Assert.Equal(6, BinarySearch.Find(array, value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Finds_a_value_in_an_array_of_odd_length()
    {
        var array = new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 634 };
        var value = 144;
        Assert.Equal(9, BinarySearch.Find(array, value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Finds_a_value_in_an_array_of_even_length()
    {
        var array = new[] { 1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377 };
        var value = 21;
        Assert.Equal(5, BinarySearch.Find(array, value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Identifies_that_a_value_is_not_included_in_the_array()
    {
        var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
        var value = 7;
        Assert.Equal(-1, BinarySearch.Find(array, value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_value_smaller_than_the_arrays_smallest_value_is_not_found()
    {
        var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
        var value = 0;
        Assert.Equal(-1, BinarySearch.Find(array, value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_value_larger_than_the_arrays_largest_value_is_not_found()
    {
        var array = new[] { 1, 3, 4, 6, 8, 9, 11 };
        var value = 13;
        Assert.Equal(-1, BinarySearch.Find(array, value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Nothing_is_found_in_an_empty_array()
    {
        var array = Array.Empty<int>();
        var value = 1;
        Assert.Equal(-1, BinarySearch.Find(array, value));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Nothing_is_found_when_the_left_and_right_bounds_cross()
    {
        var array = new[] { 1, 2 };
        var value = 0;
        Assert.Equal(-1, BinarySearch.Find(array, value));
    }
}
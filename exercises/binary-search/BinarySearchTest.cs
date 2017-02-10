using Xunit;

public class BinarySearchTest
{
    [Fact]
    public void Should_return_minus_one_when_an_empty_array_is_searched()
    {
        var input = new int[0];
        Assert.Equal(-1, BinarySearch.Search(input, 6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_be_able_to_find_a_value_in_a_single_element_array_with_one_access()
    {
        var input = new[] { 6 };
        Assert.Equal(0, BinarySearch.Search(input, 6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_return_minus_one_if_a_value_is_less_than_the_element_in_a_single_element_array()
    {
        var input = new[] { 94 };
        Assert.Equal(-1, BinarySearch.Search(input, 6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_return_minus_one_if_a_value_is_greater_than_the_element_in_a_single_element_array()
    {
        var input = new[] { 94 };
        Assert.Equal(-1, BinarySearch.Search(input, 602));
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_find_an_element_in_a_longer_array()
    {
        var input = new[] { 6, 67, 123, 345, 456, 457, 490, 2002, 54321, 54322 };
        Assert.Equal(7, BinarySearch.Search(input, 2002));
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_find_elements_at_the_beginning_of_an_array()
    {
        var input = new[] { 6, 67, 123, 345, 456, 457, 490, 2002, 54321, 54322 };
        Assert.Equal(0, BinarySearch.Search(input, 6));
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_find_elements_at_the_end_of_an_array()
    {
        var input = new[] { 6, 67, 123, 345, 456, 457, 490, 2002, 54321, 54322 };
        Assert.Equal(9, BinarySearch.Search(input, 54322));
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_return_minus_one_if_a_value_is_less_than_all_elements_in_a_long_array()
    {
        var input = new[] { 6, 67, 123, 345, 456, 457, 490, 2002, 54321, 54322 };
        Assert.Equal(-1, BinarySearch.Search(input, 2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Should_return_minus_one_if_a_value_is_greater_than_all_elements_in_a_long_array()
    {
        var input = new[] { 6, 67, 123, 345, 456, 457, 490, 2002, 54321, 54322 };
        Assert.Equal(-1, BinarySearch.Search(input, 54323));
    }
}
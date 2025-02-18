public class BinarySearchTests
{
    [Fact]
    public void Finds_a_value_in_an_array_with_one_element()
    {
        Assert.Equal(0, BinarySearch.Find([6], 6));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Finds_a_value_in_the_middle_of_an_array()
    {
        Assert.Equal(3, BinarySearch.Find([1, 3, 4, 6, 8, 9, 11], 6));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Finds_a_value_at_the_beginning_of_an_array()
    {
        Assert.Equal(0, BinarySearch.Find([1, 3, 4, 6, 8, 9, 11], 1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Finds_a_value_at_the_end_of_an_array()
    {
        Assert.Equal(6, BinarySearch.Find([1, 3, 4, 6, 8, 9, 11], 11));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Finds_a_value_in_an_array_of_odd_length()
    {
        Assert.Equal(9, BinarySearch.Find([1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 634], 144));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Finds_a_value_in_an_array_of_even_length()
    {
        Assert.Equal(5, BinarySearch.Find([1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377], 21));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Identifies_that_a_value_is_not_included_in_the_array()
    {
        Assert.Equal(-1, BinarySearch.Find([1, 3, 4, 6, 8, 9, 11], 7));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_value_smaller_than_the_array_s_smallest_value_is_not_found()
    {
        Assert.Equal(-1, BinarySearch.Find([1, 3, 4, 6, 8, 9, 11], 0));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_value_larger_than_the_array_s_largest_value_is_not_found()
    {
        Assert.Equal(-1, BinarySearch.Find([1, 3, 4, 6, 8, 9, 11], 13));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Nothing_is_found_in_an_empty_array()
    {
        Assert.Equal(-1, BinarySearch.Find([], 1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Nothing_is_found_when_the_left_and_right_bounds_cross()
    {
        Assert.Equal(-1, BinarySearch.Find([1, 2], 0));
    }
}

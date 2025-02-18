public class PalindromeProductsTests
{
    [Fact]
    public void Find_the_smallest_palindrome_from_single_digit_factors()
    {
        var (value, factors) = PalindromeProducts.Smallest(1, 9);
        int expectedValue = 1;
        (int, int)[] expectedFactors = [(1, 1)];
        Assert.Equal(expectedValue, value);
        Assert.Equal(expectedFactors, factors);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Find_the_largest_palindrome_from_single_digit_factors()
    {
        var (value, factors) = PalindromeProducts.Largest(1, 9);
        int expectedValue = 9;
        (int, int)[] expectedFactors = [(1, 9), (3, 3)];
        Assert.Equal(expectedValue, value);
        Assert.Equal(expectedFactors, factors);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Find_the_smallest_palindrome_from_double_digit_factors()
    {
        var (value, factors) = PalindromeProducts.Smallest(10, 99);
        int expectedValue = 121;
        (int, int)[] expectedFactors = [(11, 11)];
        Assert.Equal(expectedValue, value);
        Assert.Equal(expectedFactors, factors);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Find_the_largest_palindrome_from_double_digit_factors()
    {
        var (value, factors) = PalindromeProducts.Largest(10, 99);
        int expectedValue = 9009;
        (int, int)[] expectedFactors = [(91, 99)];
        Assert.Equal(expectedValue, value);
        Assert.Equal(expectedFactors, factors);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Find_the_smallest_palindrome_from_triple_digit_factors()
    {
        var (value, factors) = PalindromeProducts.Smallest(100, 999);
        int expectedValue = 10201;
        (int, int)[] expectedFactors = [(101, 101)];
        Assert.Equal(expectedValue, value);
        Assert.Equal(expectedFactors, factors);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Find_the_largest_palindrome_from_triple_digit_factors()
    {
        var (value, factors) = PalindromeProducts.Largest(100, 999);
        int expectedValue = 906609;
        (int, int)[] expectedFactors = [(913, 993)];
        Assert.Equal(expectedValue, value);
        Assert.Equal(expectedFactors, factors);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Find_the_smallest_palindrome_from_four_digit_factors()
    {
        var (value, factors) = PalindromeProducts.Smallest(1000, 9999);
        int expectedValue = 1002001;
        (int, int)[] expectedFactors = [(1001, 1001)];
        Assert.Equal(expectedValue, value);
        Assert.Equal(expectedFactors, factors);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Find_the_largest_palindrome_from_four_digit_factors()
    {
        var (value, factors) = PalindromeProducts.Largest(1000, 9999);
        int expectedValue = 99000099;
        (int, int)[] expectedFactors = [(9901, 9999)];
        Assert.Equal(expectedValue, value);
        Assert.Equal(expectedFactors, factors);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Empty_result_for_smallest_if_no_palindrome_in_the_range()
    {
        Assert.Throws<ArgumentException>(() => PalindromeProducts.Smallest(1002, 1003));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Empty_result_for_largest_if_no_palindrome_in_the_range()
    {
        Assert.Throws<ArgumentException>(() => PalindromeProducts.Largest(15, 15));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Error_result_for_smallest_if_min_is_more_than_max()
    {
        Assert.Throws<ArgumentException>(() => PalindromeProducts.Smallest(10000, 1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Error_result_for_largest_if_min_is_more_than_max()
    {
        Assert.Throws<ArgumentException>(() => PalindromeProducts.Largest(2, 1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Smallest_product_does_not_use_the_smallest_factor()
    {
        var (value, factors) = PalindromeProducts.Smallest(3215, 4000);
        int expectedValue = 10988901;
        (int, int)[] expectedFactors = [(3297, 3333)];
        Assert.Equal(expectedValue, value);
        Assert.Equal(expectedFactors, factors);
    }
}

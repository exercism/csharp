using Xunit;

public class BinaryTest
{
    [Fact]
    public void Binary_0_is_decimal_0()
    {
        Assert.Equal(0, Binary.ToDecimal("0"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Binary_1_is_decimal_1()
    {
        Assert.Equal(1, Binary.ToDecimal("1"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Binary_10_is_decimal_2()
    {
        Assert.Equal(2, Binary.ToDecimal("10"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Binary_11_is_decimal_3()
    {
        Assert.Equal(3, Binary.ToDecimal("11"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Binary_100_is_decimal_4()
    {
        Assert.Equal(4, Binary.ToDecimal("100"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Binary_1001_is_decimal_9()
    {
        Assert.Equal(9, Binary.ToDecimal("1001"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Binary_11010_is_decimal_26()
    {
        Assert.Equal(26, Binary.ToDecimal("11010"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Binary_10001101000_is_decimal_1128()
    {
        Assert.Equal(1128, Binary.ToDecimal("10001101000"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Binary_ignores_leading_zeros()
    {
        Assert.Equal(31, Binary.ToDecimal("000011111"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Invalid_binary_2_converts_to_decimal_0()
    {
        Assert.Equal(0, Binary.ToDecimal("2"));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_number_containing_a_non_binary_digit_is_invalid()
    {
        Assert.Equal(0, Binary.ToDecimal("01201"));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_number_with_trailing_non_binary_characters_is_invalid()
    {
        Assert.Equal(0, Binary.ToDecimal("10nope"));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_number_with_leading_non_binary_characters_is_invalid()
    {
        Assert.Equal(0, Binary.ToDecimal("nope10"));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_number_with_internal_non_binary_characters_is_invalid()
    {
        Assert.Equal(0, Binary.ToDecimal("10nope10"));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_number_and_a_word_whitespace_separated_is_invalid()
    {
        Assert.Equal(0, Binary.ToDecimal("001 nope"));
    }
}

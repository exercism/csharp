using System;
using Xunit;

public class VariableLengthQuantityTests
{
    [Fact]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_zero()
    {
        uint[] integers = [0];
        uint[] expected = [0];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_arbitrary_single_byte()
    {
        uint[] integers = [64];
        uint[] expected = [64];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_largest_single_byte()
    {
        uint[] integers = [127];
        uint[] expected = [127];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_smallest_double_byte()
    {
        uint[] integers = [128];
        uint[] expected = [129, 0];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_arbitrary_double_byte()
    {
        uint[] integers = [8192];
        uint[] expected = [192, 0];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_largest_double_byte()
    {
        uint[] integers = [16383];
        uint[] expected = [255, 127];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_smallest_triple_byte()
    {
        uint[] integers = [16384];
        uint[] expected = [129, 128, 0];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_arbitrary_triple_byte()
    {
        uint[] integers = [1048576];
        uint[] expected = [192, 128, 0];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_largest_triple_byte()
    {
        uint[] integers = [2097151];
        uint[] expected = [255, 255, 127];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_smallest_quadruple_byte()
    {
        uint[] integers = [2097152];
        uint[] expected = [129, 128, 128, 0];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_arbitrary_quadruple_byte()
    {
        uint[] integers = [134217728];
        uint[] expected = [192, 128, 128, 0];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_largest_quadruple_byte()
    {
        uint[] integers = [268435455];
        uint[] expected = [255, 255, 255, 127];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_smallest_quintuple_byte()
    {
        uint[] integers = [268435456];
        uint[] expected = [129, 128, 128, 128, 0];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_arbitrary_quintuple_byte()
    {
        uint[] integers = [4278190080];
        uint[] expected = [143, 248, 128, 128, 0];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_maximum_32_bit_integer_input()
    {
        uint[] integers = [4294967295];
        uint[] expected = [143, 255, 255, 255, 127];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_two_single_byte_values()
    {
        uint[] integers = [64, 127];
        uint[] expected = [64, 127];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_two_multi_byte_values()
    {
        uint[] integers = [16384, 1193046];
        uint[] expected = [129, 128, 0, 200, 232, 86];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Encode_a_series_of_integers_producing_a_series_of_bytes_many_multi_byte_values()
    {
        uint[] integers = [8192, 1193046, 268435455, 0, 16383, 16384];
        uint[] expected = [192, 0, 200, 232, 86, 255, 255, 255, 127, 0, 255, 127, 129, 128, 0];
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_a_series_of_bytes_producing_a_series_of_integers_one_byte()
    {
        uint[] integers = [127];
        uint[] expected = [127];
        Assert.Equal(expected, VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_a_series_of_bytes_producing_a_series_of_integers_two_bytes()
    {
        uint[] integers = [192, 0];
        uint[] expected = [8192];
        Assert.Equal(expected, VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_a_series_of_bytes_producing_a_series_of_integers_three_bytes()
    {
        uint[] integers = [255, 255, 127];
        uint[] expected = [2097151];
        Assert.Equal(expected, VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_a_series_of_bytes_producing_a_series_of_integers_four_bytes()
    {
        uint[] integers = [129, 128, 128, 0];
        uint[] expected = [2097152];
        Assert.Equal(expected, VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_a_series_of_bytes_producing_a_series_of_integers_maximum_32_bit_integer()
    {
        uint[] integers = [143, 255, 255, 255, 127];
        uint[] expected = [4294967295];
        Assert.Equal(expected, VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_a_series_of_bytes_producing_a_series_of_integers_incomplete_sequence_causes_error()
    {
        uint[] integers = [255];
        Assert.Throws<InvalidOperationException>(() => VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_a_series_of_bytes_producing_a_series_of_integers_incomplete_sequence_causes_error_even_if_value_is_zero()
    {
        uint[] integers = [128];
        Assert.Throws<InvalidOperationException>(() => VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Decode_a_series_of_bytes_producing_a_series_of_integers_multiple_values()
    {
        uint[] integers = [192, 0, 200, 232, 86, 255, 255, 255, 127, 0, 255, 127, 129, 128, 0];
        uint[] expected = [8192, 1193046, 268435455, 0, 16383, 16384];
        Assert.Equal(expected, VariableLengthQuantity.Decode(integers));
    }
}

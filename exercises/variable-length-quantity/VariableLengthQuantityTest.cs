// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using Xunit;

public class VariableLengthQuantityTest
{
    [Fact]
    public void Zero()
    {
        var integers = new[] { 0x0u };
        var expected = new[] { 0x0u };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Arbitrary_single_byte()
    {
        var integers = new[] { 0x40u };
        var expected = new[] { 0x40u };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Largest_single_byte()
    {
        var integers = new[] { 0x7Fu };
        var expected = new[] { 0x7Fu };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Smallest_double_byte()
    {
        var integers = new[] { 0x80u };
        var expected = new[] { 0x81u, 0x0u };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Arbitrary_double_byte()
    {
        var integers = new[] { 0x2000u };
        var expected = new[] { 0xC0u, 0x0u };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Largest_double_byte()
    {
        var integers = new[] { 0x3FFFu };
        var expected = new[] { 0xFFu, 0x7Fu };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Smallest_triple_byte()
    {
        var integers = new[] { 0x4000u };
        var expected = new[] { 0x81u, 0x80u, 0x0u };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Arbitrary_triple_byte()
    {
        var integers = new[] { 0x100000u };
        var expected = new[] { 0xC0u, 0x80u, 0x0u };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Largest_triple_byte()
    {
        var integers = new[] { 0x1FFFFFu };
        var expected = new[] { 0xFFu, 0xFFu, 0x7Fu };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Smallest_quadruple_byte()
    {
        var integers = new[] { 0x200000u };
        var expected = new[] { 0x81u, 0x80u, 0x80u, 0x0u };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Arbitrary_quadruple_byte()
    {
        var integers = new[] { 0x8000000u };
        var expected = new[] { 0xC0u, 0x80u, 0x80u, 0x0u };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Largest_quadruple_byte()
    {
        var integers = new[] { 0xFFFFFFFu };
        var expected = new[] { 0xFFu, 0xFFu, 0xFFu, 0x7Fu };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Smallest_quintuple_byte()
    {
        var integers = new[] { 0x10000000u };
        var expected = new[] { 0x81u, 0x80u, 0x80u, 0x80u, 0x0u };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Arbitrary_quintuple_byte()
    {
        var integers = new[] { 0xFF000000u };
        var expected = new[] { 0x8Fu, 0xF8u, 0x80u, 0x80u, 0x0u };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Maximum_32_bit_integer_input()
    {
        var integers = new[] { 0xFFFFFFFFu };
        var expected = new[] { 0x8Fu, 0xFFu, 0xFFu, 0xFFu, 0x7Fu };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_single_byte_values()
    {
        var integers = new[] { 0x40u, 0x7Fu };
        var expected = new[] { 0x40u, 0x7Fu };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_multi_byte_values()
    {
        var integers = new[] { 0x4000u, 0x123456u };
        var expected = new[] { 0x81u, 0x80u, 0x0u, 0xC8u, 0xE8u, 0x56u };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Many_multi_byte_values()
    {
        var integers = new[] { 0x2000u, 0x123456u, 0xFFFFFFFu, 0x0u, 0x3FFFu, 0x4000u };
        var expected = new[] { 0xC0u, 0x0u, 0xC8u, 0xE8u, 0x56u, 0xFFu, 0xFFu, 0xFFu, 0x7Fu, 0x0u, 0xFFu, 0x7Fu, 0x81u, 0x80u, 0x0u };
        Assert.Equal(expected, VariableLengthQuantity.Encode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_byte()
    {
        var integers = new[] { 0x7Fu };
        var expected = new[] { 0x7Fu };
        Assert.Equal(expected, VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_bytes()
    {
        var integers = new[] { 0xC0u, 0x0u };
        var expected = new[] { 0x2000u };
        Assert.Equal(expected, VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Three_bytes()
    {
        var integers = new[] { 0xFFu, 0xFFu, 0x7Fu };
        var expected = new[] { 0x1FFFFFu };
        Assert.Equal(expected, VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Four_bytes()
    {
        var integers = new[] { 0x81u, 0x80u, 0x80u, 0x0u };
        var expected = new[] { 0x200000u };
        Assert.Equal(expected, VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Maximum_32_bit_integer()
    {
        var integers = new[] { 0x8Fu, 0xFFu, 0xFFu, 0xFFu, 0x7Fu };
        var expected = new[] { 0xFFFFFFFFu };
        Assert.Equal(expected, VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Incomplete_sequence_causes_error()
    {
        var integers = new[] { 0xFFu };
        Assert.Throws<InvalidOperationException>(() => VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Incomplete_sequence_causes_error_even_if_value_is_zero()
    {
        var integers = new[] { 0x80u };
        Assert.Throws<InvalidOperationException>(() => VariableLengthQuantity.Decode(integers));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_values()
    {
        var integers = new[] { 0xC0u, 0x0u, 0xC8u, 0xE8u, 0x56u, 0xFFu, 0xFFu, 0xFFu, 0x7Fu, 0x0u, 0xFFu, 0x7Fu, 0x81u, 0x80u, 0x0u };
        var expected = new[] { 0x2000u, 0x123456u, 0xFFFFFFFu, 0x0u, 0x3FFFu, 0x4000u };
        Assert.Equal(expected, VariableLengthQuantity.Decode(integers));
    }
}
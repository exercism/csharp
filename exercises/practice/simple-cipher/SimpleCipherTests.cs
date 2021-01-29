// This file was auto-generated based on version 2.0.0 of the canonical data.

using System;
using Xunit;

public class SimpleCipherTests
{
    [Fact]
    public void Random_key_cipher_can_encode()
    {
        var sut = new SimpleCipher();
        Assert.Equal(sut.Key.Substring(0, 10), sut.Encode("aaaaaaaaaa"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Random_key_cipher_can_decode()
    {
        var sut = new SimpleCipher();
        Assert.Equal("aaaaaaaaaa", sut.Decode(sut.Key.Substring(0, 10)));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Random_key_cipher_is_reversible_i_e_if_you_apply_decode_in_a_encoded_result_you_must_see_the_same_plaintext_encode_parameter_as_a_result_of_the_decode_method()
    {
        var sut = new SimpleCipher();
        Assert.Equal("abcdefghij", sut.Decode(sut.Encode("abcdefghij")));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Random_key_cipher_key_is_made_only_of_lowercase_letters()
    {
        var sut = new SimpleCipher();
        Assert.Matches("^[a-z]+$", sut.Key);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Substitution_cipher_can_encode()
    {
        var sut = new SimpleCipher("abcdefghij");
        Assert.Equal("abcdefghij", sut.Encode("aaaaaaaaaa"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Substitution_cipher_can_decode()
    {
        var sut = new SimpleCipher("abcdefghij");
        Assert.Equal("aaaaaaaaaa", sut.Decode("abcdefghij"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Substitution_cipher_is_reversible_i_e_if_you_apply_decode_in_a_encoded_result_you_must_see_the_same_plaintext_encode_parameter_as_a_result_of_the_decode_method()
    {
        var sut = new SimpleCipher("abcdefghij");
        Assert.Equal("abcdefghij", sut.Decode(sut.Encode("abcdefghij")));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Substitution_cipher_can_double_shift_encode()
    {
        var sut = new SimpleCipher("iamapandabear");
        Assert.Equal("qayaeaagaciai", sut.Encode("iamapandabear"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Substitution_cipher_can_wrap_on_encode()
    {
        var sut = new SimpleCipher("abcdefghij");
        Assert.Equal("zabcdefghi", sut.Encode("zzzzzzzzzz"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Substitution_cipher_can_wrap_on_decode()
    {
        var sut = new SimpleCipher("abcdefghij");
        Assert.Equal("zzzzzzzzzz", sut.Decode("zabcdefghi"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Substitution_cipher_can_encode_messages_longer_than_the_key()
    {
        var sut = new SimpleCipher("abc");
        Assert.Equal("iboaqcnecbfcr", sut.Encode("iamapandabear"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Substitution_cipher_can_decode_messages_longer_than_the_key()
    {
        var sut = new SimpleCipher("abc");
        Assert.Equal("iamapandabear", sut.Decode("iboaqcnecbfcr"));
    }
}
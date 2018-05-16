// This file was auto-generated based on version 3.2.0 of the canonical data.

using Xunit;

public class CryptoSquareTest
{
    [Fact]
    public void Empty_plaintext_results_in_an_empty_ciphertext()
    {
        var plaintext = "";
        var expected = "";
        Assert.Equal(expected, CryptoSquare.Ciphertext(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Lowercase()
    {
        var plaintext = "A";
        var expected = "a";
        Assert.Equal(expected, CryptoSquare.Ciphertext(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Remove_spaces()
    {
        var plaintext = "  b ";
        var expected = "b";
        Assert.Equal(expected, CryptoSquare.Ciphertext(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Remove_punctuation()
    {
        var plaintext = "@1,%!";
        var expected = "1";
        Assert.Equal(expected, CryptoSquare.Ciphertext(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_9_character_plaintext_results_in_3_chunks_of_3_characters()
    {
        var plaintext = "This is fun!";
        var expected = "tsf hiu isn";
        Assert.Equal(expected, CryptoSquare.Ciphertext(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_8_character_plaintext_results_in_3_chunks_the_last_one_with_a_trailing_space()
    {
        var plaintext = "Chill out.";
        var expected = "clu hlt io ";
        Assert.Equal(expected, CryptoSquare.Ciphertext(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_54_character_plaintext_results_in_7_chunks_the_last_two_with_trailing_spaces()
    {
        var plaintext = "If man was meant to stay on the ground, god would have given us roots.";
        var expected = "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn  sseoau ";
        Assert.Equal(expected, CryptoSquare.Ciphertext(plaintext));
    }
}
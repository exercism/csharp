// This file was auto-generated based on version 2.0.0 of the canonical data.

using Xunit;

public class CryptoSquareTest
{
    [Fact]
    public void Lowercase()
    {
        var plaintext = "Hello";
        var expected = "hello";
        Assert.Equal(expected, CryptoSquare.NormalizedPlaintext(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Remove_spaces()
    {
        var plaintext = "Hi there";
        var expected = "hithere";
        Assert.Equal(expected, CryptoSquare.NormalizedPlaintext(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Remove_punctuation()
    {
        var plaintext = "@1, 2%, 3 Go!";
        var expected = "123go";
        Assert.Equal(expected, CryptoSquare.NormalizedPlaintext(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_plaintext_results_in_an_empty_rectangle()
    {
        var plaintext = "";
        Assert.Empty(CryptoSquare.PlaintextSegments(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_4_character_plaintext_results_in_an_2x2_rectangle()
    {
        var plaintext = "Ab Cd";
        var expected = new[] { "ab", "cd" };
        Assert.Equal(expected, CryptoSquare.PlaintextSegments(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_9_character_plaintext_results_in_an_3x3_rectangle()
    {
        var plaintext = "This is fun!";
        var expected = new[] { "thi", "sis", "fun" };
        Assert.Equal(expected, CryptoSquare.PlaintextSegments(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_54_character_plaintext_results_in_an_8x7_rectangle()
    {
        var plaintext = "If man was meant to stay on the ground, god would have given us roots.";
        var expected = new[] { "ifmanwas", "meanttos", "tayonthe", "groundgo", "dwouldha", "vegivenu", "sroots" };
        Assert.Equal(expected, CryptoSquare.PlaintextSegments(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_plaintext_results_in_an_empty_encode()
    {
        var plaintext = "";
        var expected = "";
        Assert.Equal(expected, CryptoSquare.Encoded(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Non_empty_plaintext_results_in_the_combined_plaintext_segments()
    {
        var plaintext = "If man was meant to stay on the ground, god would have given us roots.";
        var expected = "imtgdvsfearwermayoogoanouuiontnnlvtwttddesaohghnsseoau";
        Assert.Equal(expected, CryptoSquare.Encoded(plaintext));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_plaintext_results_in_an_empty_ciphertext()
    {
        var plaintext = "";
        var expected = "";
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
    public void Number_54_character_plaintext_results_in_7_chunks_the_last_two_padded_with_spaces()
    {
        var plaintext = "If man was meant to stay on the ground, god would have given us roots.";
        var expected = "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn  sseoau ";
        Assert.Equal(expected, CryptoSquare.Ciphertext(plaintext));
    }
}
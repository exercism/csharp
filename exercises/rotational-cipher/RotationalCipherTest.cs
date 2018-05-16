// This file was auto-generated based on version 1.2.0 of the canonical data.

using Xunit;

public class RotationalCipherTest
{
    [Fact]
    public void Rotate_a_by_0_same_output_as_input()
    {
        Assert.Equal("a", RotationalCipher.Rotate("a", 0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotate_a_by_1()
    {
        Assert.Equal("b", RotationalCipher.Rotate("a", 1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotate_a_by_26_same_output_as_input()
    {
        Assert.Equal("a", RotationalCipher.Rotate("a", 26));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotate_m_by_13()
    {
        Assert.Equal("z", RotationalCipher.Rotate("m", 13));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotate_n_by_13_with_wrap_around_alphabet()
    {
        Assert.Equal("a", RotationalCipher.Rotate("n", 13));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotate_capital_letters()
    {
        Assert.Equal("TRL", RotationalCipher.Rotate("OMG", 5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotate_spaces()
    {
        Assert.Equal("T R L", RotationalCipher.Rotate("O M G", 5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotate_numbers()
    {
        Assert.Equal("Xiwxmrk 1 2 3 xiwxmrk", RotationalCipher.Rotate("Testing 1 2 3 testing", 4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotate_punctuation()
    {
        Assert.Equal("Gzo'n zvo, Bmviyhv!", RotationalCipher.Rotate("Let's eat, Grandma!", 21));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rotate_all_letters()
    {
        Assert.Equal("Gur dhvpx oebja sbk whzcf bire gur ynml qbt.", RotationalCipher.Rotate("The quick brown fox jumps over the lazy dog.", 13));
    }
}
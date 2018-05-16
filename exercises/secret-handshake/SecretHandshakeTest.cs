// This file was auto-generated based on version 1.2.0 of the canonical data.

using Xunit;

public class SecretHandshakeTest
{
    [Fact]
    public void Wink_for_1()
    {
        Assert.Equal(new[] { "wink" }, SecretHandshake.Commands(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Double_blink_for_10()
    {
        Assert.Equal(new[] { "double blink" }, SecretHandshake.Commands(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Close_your_eyes_for_100()
    {
        Assert.Equal(new[] { "close your eyes" }, SecretHandshake.Commands(4));
    }

    [Fact(Skip = "Remove to run test")]
    public void Jump_for_1000()
    {
        Assert.Equal(new[] { "jump" }, SecretHandshake.Commands(8));
    }

    [Fact(Skip = "Remove to run test")]
    public void Combine_two_actions()
    {
        Assert.Equal(new[] { "wink", "double blink" }, SecretHandshake.Commands(3));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reverse_two_actions()
    {
        Assert.Equal(new[] { "double blink", "wink" }, SecretHandshake.Commands(19));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reversing_one_action_gives_the_same_action()
    {
        Assert.Equal(new[] { "jump" }, SecretHandshake.Commands(24));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reversing_no_actions_still_gives_no_actions()
    {
        Assert.Empty(SecretHandshake.Commands(16));
    }

    [Fact(Skip = "Remove to run test")]
    public void All_possible_actions()
    {
        Assert.Equal(new[] { "wink", "double blink", "close your eyes", "jump" }, SecretHandshake.Commands(15));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reverse_all_possible_actions()
    {
        Assert.Equal(new[] { "jump", "close your eyes", "double blink", "wink" }, SecretHandshake.Commands(31));
    }

    [Fact(Skip = "Remove to run test")]
    public void Do_nothing_for_zero()
    {
        Assert.Empty(SecretHandshake.Commands(0));
    }
}
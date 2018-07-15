// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using Xunit;

public class ProverbTest
{
    [Fact]
    public void Zero_pieces()
    {
        var strings = Array.Empty<string>();
        var expected = Array.Empty<string>();
        Assert.Equal(expected, Proverb.Recite(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void One_piece()
    {
        var strings = new[]
        {
            "nail"
        };
        var expected = new[]
        {
            "And all for the want of a nail."
        };
        Assert.Equal(expected, Proverb.Recite(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_pieces()
    {
        var strings = new[]
        {
            "nail",
            "shoe"
        };
        var expected = new[]
        {
            "For want of a nail the shoe was lost.",
            "And all for the want of a nail."
        };
        Assert.Equal(expected, Proverb.Recite(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Three_pieces()
    {
        var strings = new[]
        {
            "nail",
            "shoe",
            "horse"
        };
        var expected = new[]
        {
            "For want of a nail the shoe was lost.",
            "For want of a shoe the horse was lost.",
            "And all for the want of a nail."
        };
        Assert.Equal(expected, Proverb.Recite(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_proverb()
    {
        var strings = new[]
        {
            "nail",
            "shoe",
            "horse",
            "rider",
            "message",
            "battle",
            "kingdom"
        };
        var expected = new[]
        {
            "For want of a nail the shoe was lost.",
            "For want of a shoe the horse was lost.",
            "For want of a horse the rider was lost.",
            "For want of a rider the message was lost.",
            "For want of a message the battle was lost.",
            "For want of a battle the kingdom was lost.",
            "And all for the want of a nail."
        };
        Assert.Equal(expected, Proverb.Recite(strings));
    }

    [Fact(Skip = "Remove to run test")]
    public void Four_pieces_modernized()
    {
        var strings = new[]
        {
            "pin",
            "gun",
            "soldier",
            "battle"
        };
        var expected = new[]
        {
            "For want of a pin the gun was lost.",
            "For want of a gun the soldier was lost.",
            "For want of a soldier the battle was lost.",
            "And all for the want of a pin."
        };
        Assert.Equal(expected, Proverb.Recite(strings));
    }
}
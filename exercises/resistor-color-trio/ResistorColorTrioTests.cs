// This file was auto-generated based on version  of the canonical data.

using Xunit;

public class ResistorColorTrioTests
{
    [Fact]
    public void Orange_and_orange_and_black()
    {
        Assert.Equal("33 ohms", ResistorColorTrio.Label(new[] { "orange", "orange", "black" }));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Blue_and_grey_and_brown()
    {
        Assert.Equal("680 ohms", ResistorColorTrio.Label(new[] { "blue", "grey", "brown" }));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Red_and_black_and_red()
    {
        Assert.Equal("2 kiloohms", ResistorColorTrio.Label(new[] { "red", "black", "red" }));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Green_and_brown_and_orange()
    {
        Assert.Equal("51 kiloohms", ResistorColorTrio.Label(new[] { "green", "brown", "orange" }));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Yellow_and_violet_and_yellow()
    {
        Assert.Equal("470 kiloohms", ResistorColorTrio.Label(new[] { "yellow", "violet", "yellow" }));
    }
}
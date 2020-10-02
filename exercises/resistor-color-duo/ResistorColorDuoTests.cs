// This file was auto-generated based on version  of the canonical data.

using Xunit;

public class ResistorColorDuoTests
{
    [Fact]
    public void Brown_and_black()
    {
        Assert.Equal(10, ResistorColorDuo.Value(new[] { "brown", "black" }));
    }

    [Fact()]
    public void Blue_and_grey()
    {
        Assert.Equal(68, ResistorColorDuo.Value(new[] { "blue", "grey" }));
    }

    [Fact()]
    public void Yellow_and_violet()
    {
        Assert.Equal(47, ResistorColorDuo.Value(new[] { "yellow", "violet" }));
    }

    [Fact()]
    public void Orange_and_orange()
    {
        Assert.Equal(33, ResistorColorDuo.Value(new[] { "orange", "orange" }));
    }

    [Fact()]
    public void Ignore_additional_colors()
    {
        Assert.Equal(51, ResistorColorDuo.Value(new[] { "green", "brown", "orange" }));
    }
}
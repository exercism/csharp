// This file was auto-generated based on version 2.0.0 of the canonical data.

using Xunit;

public class ScaleGeneratorTests
{
    [Fact]
    public void Chromatic_scale_with_sharps()
    {
        var expected = new[] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        Assert.Equal(expected, ScaleGenerator.Chromatic("C"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Chromatic_scale_with_flats()
    {
        var expected = new[] { "F", "Gb", "G", "Ab", "A", "Bb", "B", "C", "Db", "D", "Eb", "E" };
        Assert.Equal(expected, ScaleGenerator.Chromatic("F"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Simple_major_scale()
    {
        var expected = new[] { "C", "D", "E", "F", "G", "A", "B" };
        Assert.Equal(expected, ScaleGenerator.Interval("C", "MMmMMMm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Major_scale_with_sharps()
    {
        var expected = new[] { "G", "A", "B", "C", "D", "E", "F#" };
        Assert.Equal(expected, ScaleGenerator.Interval("G", "MMmMMMm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Major_scale_with_flats()
    {
        var expected = new[] { "F", "G", "A", "Bb", "C", "D", "E" };
        Assert.Equal(expected, ScaleGenerator.Interval("F", "MMmMMMm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Minor_scale_with_sharps()
    {
        var expected = new[] { "F#", "G#", "A", "B", "C#", "D", "E" };
        Assert.Equal(expected, ScaleGenerator.Interval("f#", "MmMMmMM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Minor_scale_with_flats()
    {
        var expected = new[] { "Bb", "C", "Db", "Eb", "F", "Gb", "Ab" };
        Assert.Equal(expected, ScaleGenerator.Interval("bb", "MmMMmMM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Dorian_mode()
    {
        var expected = new[] { "D", "E", "F", "G", "A", "B", "C" };
        Assert.Equal(expected, ScaleGenerator.Interval("d", "MmMMMmM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Mixolydian_mode()
    {
        var expected = new[] { "Eb", "F", "G", "Ab", "Bb", "C", "Db" };
        Assert.Equal(expected, ScaleGenerator.Interval("Eb", "MMmMMmM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Lydian_mode()
    {
        var expected = new[] { "A", "B", "C#", "D#", "E", "F#", "G#" };
        Assert.Equal(expected, ScaleGenerator.Interval("a", "MMMmMMm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Phrygian_mode()
    {
        var expected = new[] { "E", "F", "G", "A", "B", "C", "D" };
        Assert.Equal(expected, ScaleGenerator.Interval("e", "mMMMmMM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Locrian_mode()
    {
        var expected = new[] { "G", "Ab", "Bb", "C", "Db", "Eb", "F" };
        Assert.Equal(expected, ScaleGenerator.Interval("g", "mMMmMMM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Harmonic_minor()
    {
        var expected = new[] { "D", "E", "F", "G", "A", "Bb", "Db" };
        Assert.Equal(expected, ScaleGenerator.Interval("d", "MmMMmAm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Octatonic()
    {
        var expected = new[] { "C", "D", "D#", "F", "F#", "G#", "A", "B" };
        Assert.Equal(expected, ScaleGenerator.Interval("C", "MmMmMmMm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Hexatonic()
    {
        var expected = new[] { "Db", "Eb", "F", "G", "A", "B" };
        Assert.Equal(expected, ScaleGenerator.Interval("Db", "MMMMMM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Pentatonic()
    {
        var expected = new[] { "A", "B", "C#", "E", "F#" };
        Assert.Equal(expected, ScaleGenerator.Interval("A", "MMAMA"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Enigmatic()
    {
        var expected = new[] { "G", "G#", "B", "C#", "D#", "F", "F#" };
        Assert.Equal(expected, ScaleGenerator.Interval("G", "mAMMMmm"));
    }
}
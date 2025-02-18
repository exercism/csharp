public class ScaleGeneratorTests
{
    [Fact]
    public void Chromatic_scales_chromatic_scale_with_sharps()
    {
        string[] expected = ["C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"];
        Assert.Equal(expected, ScaleGenerator.Chromatic("C"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Chromatic_scales_chromatic_scale_with_flats()
    {
        string[] expected = ["F", "Gb", "G", "Ab", "A", "Bb", "B", "C", "Db", "D", "Eb", "E"];
        Assert.Equal(expected, ScaleGenerator.Chromatic("F"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_simple_major_scale()
    {
        string[] expected = ["C", "D", "E", "F", "G", "A", "B", "C"];
        Assert.Equal(expected, ScaleGenerator.Interval("C", "MMmMMMm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_major_scale_with_sharps()
    {
        string[] expected = ["G", "A", "B", "C", "D", "E", "F#", "G"];
        Assert.Equal(expected, ScaleGenerator.Interval("G", "MMmMMMm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_major_scale_with_flats()
    {
        string[] expected = ["F", "G", "A", "Bb", "C", "D", "E", "F"];
        Assert.Equal(expected, ScaleGenerator.Interval("F", "MMmMMMm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_minor_scale_with_sharps()
    {
        string[] expected = ["F#", "G#", "A", "B", "C#", "D", "E", "F#"];
        Assert.Equal(expected, ScaleGenerator.Interval("f#", "MmMMmMM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_minor_scale_with_flats()
    {
        string[] expected = ["Bb", "C", "Db", "Eb", "F", "Gb", "Ab", "Bb"];
        Assert.Equal(expected, ScaleGenerator.Interval("bb", "MmMMmMM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_dorian_mode()
    {
        string[] expected = ["D", "E", "F", "G", "A", "B", "C", "D"];
        Assert.Equal(expected, ScaleGenerator.Interval("d", "MmMMMmM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_mixolydian_mode()
    {
        string[] expected = ["Eb", "F", "G", "Ab", "Bb", "C", "Db", "Eb"];
        Assert.Equal(expected, ScaleGenerator.Interval("Eb", "MMmMMmM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_lydian_mode()
    {
        string[] expected = ["A", "B", "C#", "D#", "E", "F#", "G#", "A"];
        Assert.Equal(expected, ScaleGenerator.Interval("a", "MMMmMMm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_phrygian_mode()
    {
        string[] expected = ["E", "F", "G", "A", "B", "C", "D", "E"];
        Assert.Equal(expected, ScaleGenerator.Interval("e", "mMMMmMM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_locrian_mode()
    {
        string[] expected = ["G", "Ab", "Bb", "C", "Db", "Eb", "F", "G"];
        Assert.Equal(expected, ScaleGenerator.Interval("g", "mMMmMMM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_harmonic_minor()
    {
        string[] expected = ["D", "E", "F", "G", "A", "Bb", "Db", "D"];
        Assert.Equal(expected, ScaleGenerator.Interval("d", "MmMMmAm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_octatonic()
    {
        string[] expected = ["C", "D", "D#", "F", "F#", "G#", "A", "B", "C"];
        Assert.Equal(expected, ScaleGenerator.Interval("C", "MmMmMmMm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_hexatonic()
    {
        string[] expected = ["Db", "Eb", "F", "G", "A", "B", "Db"];
        Assert.Equal(expected, ScaleGenerator.Interval("Db", "MMMMMM"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_pentatonic()
    {
        string[] expected = ["A", "B", "C#", "E", "F#", "A"];
        Assert.Equal(expected, ScaleGenerator.Interval("A", "MMAMA"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Scales_with_specified_intervals_enigmatic()
    {
        string[] expected = ["G", "G#", "B", "C#", "D#", "F", "F#", "G"];
        Assert.Equal(expected, ScaleGenerator.Interval("G", "mAMMMmm"));
    }
}

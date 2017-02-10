using Xunit;

public class ScaleGeneratorTest
{
    [Fact]
    public void Major_scale()
    {
        var major = ScaleGenerator.Pitches("C", "MMmMMMm");
        var expected = new[] {"C", "D", "E", "F", "G", "A", "B"};
        Assert.Equal(expected, major);
    }

    [Fact]
    public void Another_major_scale()
    {
        var major = ScaleGenerator.Pitches("G", "MMmMMMm");
        var expected = new[] {"G", "A", "B", "C", "D", "E", "F#"};
        Assert.Equal(expected, major);
    }

    [Fact]
    public void Minor_scale()
    {
        var minor = ScaleGenerator.Pitches("f#", "MmMMmMM");
        var expected = new[] {"F#", "G#", "A", "B", "C#", "D", "E"};
        Assert.Equal(expected, minor);
    }

    [Fact]
    public void Another_minor_scale()
    {
        var minor = ScaleGenerator.Pitches("bb", "MmMMmMM");
        var expected = new[] {"Bb", "C", "Db", "Eb", "F", "Gb", "Ab"};
        Assert.Equal(expected, minor);
    }

    [Fact]
    public void Dorian_mode()
    {
        var dorian = ScaleGenerator.Pitches("d", "MmMMMmM");
        var expected = new[] {"D", "E", "F", "G", "A", "B", "C"};
        Assert.Equal(expected, dorian);
    }

    [Fact]
    public void Mixolydian_mode()
    {
        var mixolydian = ScaleGenerator.Pitches("Eb", "MMmMMmM");
        var expected = new[] {"Eb", "F", "G", "Ab", "Bb", "C", "Db"};
        Assert.Equal(expected, mixolydian);
    }

    [Fact]
    public void Lydian_mode()
    {
        var lydian = ScaleGenerator.Pitches("a", "MMMmMMm");
        var expected = new[] {"A", "B", "C#", "D#", "E", "F#", "G#"};
        Assert.Equal(expected, lydian);
    }

    [Fact]
    public void Phrygian_mode()
    {
        var phrygian = ScaleGenerator.Pitches("e", "mMMMmMM");
        var expected = new[] {"E", "F", "G", "A", "B", "C", "D"};
        Assert.Equal(expected, phrygian);
    }

    [Fact]
    public void Locrian_mode()
    {
        var locrian = ScaleGenerator.Pitches("g", "mMMmMMM");
        var expected = new[] {"G", "Ab", "Bb", "C", "Db", "Eb", "F"};
        Assert.Equal(expected, locrian);
    }

    [Fact]
    public void Harmonic_minor()
    {
        var harmonicMinor = ScaleGenerator.Pitches("d", "MmMMmAm");
        var expected = new[] {"D", "E", "F", "G", "A", "Bb", "Db"};
        Assert.Equal(expected, harmonicMinor);
    }

    [Fact]
    public void Octatonic()
    {
        var octatonic = ScaleGenerator.Pitches("C", "MmMmMmMm");
        var expected = new[] {"C", "D", "D#", "F", "F#", "G#", "A", "B"};
        Assert.Equal(expected, octatonic);
    }

    [Fact]
    public void Hexatonic()
    {
        var hexatonic = ScaleGenerator.Pitches("Db", "MMMMMM");
        var expected = new[] {"Db", "Eb", "F", "G", "A", "B"};
        Assert.Equal(expected, hexatonic);
    }

    [Fact]
    public void Pentatonic()
    {
        var pentatonic = ScaleGenerator.Pitches("A", "MMAMA");
        var expected = new[] {"A", "B", "C#", "E", "F#"};
        Assert.Equal(expected, pentatonic);
    }

    [Fact]
    public void Enigmatic()
    {
        var enigmatic = ScaleGenerator.Pitches("G", "mAMMMmm");
        var expected = new[] {"G", "G#", "B", "C#", "D#", "F", "F#"};
        Assert.Equal(expected, enigmatic);
    }
}
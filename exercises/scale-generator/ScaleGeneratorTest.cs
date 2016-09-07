using NUnit.Framework;

public class ScaleGeneratorTest
{
    [Test]
    public void Major_scale()
    {
        var major = ScaleGenerator.Pitches("C", "MMmMMMm");
        var expected = new[] {"C", "D", "E", "F", "G", "A", "B"};
        Assert.That(major, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Another_major_scale()
    {
        var major = ScaleGenerator.Pitches("G", "MMmMMMm");
        var expected = new[] {"G", "A", "B", "C", "D", "E", "F#"};
        Assert.That(major, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Minor_scale()
    {
        var minor = ScaleGenerator.Pitches("f#", "MmMMmMM");
        var expected = new[] {"F#", "G#", "A", "B", "C#", "D", "E"};
        Assert.That(minor, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Another_minor_scale()
    {
        var minor = ScaleGenerator.Pitches("bb", "MmMMmMM");
        var expected = new[] {"Bb", "C", "Db", "Eb", "F", "Gb", "Ab"};
        Assert.That(minor, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Dorian_mode()
    {
        var dorian = ScaleGenerator.Pitches("d", "MmMMMmM");
        var expected = new[] {"D", "E", "F", "G", "A", "B", "C"};
        Assert.That(dorian, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Mixolydian_mode()
    {
        var mixolydian = ScaleGenerator.Pitches("Eb", "MMmMMmM");
        var expected = new[] {"Eb", "F", "G", "Ab", "Bb", "C", "Db"};
        Assert.That(mixolydian, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Lydian_mode()
    {
        var lydian = ScaleGenerator.Pitches("a", "MMMmMMm");
        var expected = new[] {"A", "B", "C#", "D#", "E", "F#", "G#"};
        Assert.That(lydian, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Phrygian_mode()
    {
        var phrygian = ScaleGenerator.Pitches("e", "mMMMmMM");
        var expected = new[] {"E", "F", "G", "A", "B", "C", "D"};
        Assert.That(phrygian, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Locrian_mode()
    {
        var locrian = ScaleGenerator.Pitches("g", "mMMmMMM");
        var expected = new[] {"G", "Ab", "Bb", "C", "Db", "Eb", "F"};
        Assert.That(locrian, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Harmonic_minor()
    {
        var harmonicMinor = ScaleGenerator.Pitches("d", "MmMMmAm");
        var expected = new[] {"D", "E", "F", "G", "A", "Bb", "Db"};
        Assert.That(harmonicMinor, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Octatonic()
    {
        var octatonic = ScaleGenerator.Pitches("C", "MmMmMmMm");
        var expected = new[] {"C", "D", "D#", "F", "F#", "G#", "A", "B"};
        Assert.That(octatonic, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Hexatonic()
    {
        var hexatonic = ScaleGenerator.Pitches("Db", "MMMMMM");
        var expected = new[] {"Db", "Eb", "F", "G", "A", "B"};
        Assert.That(hexatonic, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Pentatonic()
    {
        var pentatonic = ScaleGenerator.Pitches("A", "MMAMA");
        var expected = new[] {"A", "B", "C#", "E", "F#"};
        Assert.That(pentatonic, Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Enigmatic()
    {
        var enigmatic = ScaleGenerator.Pitches("G", "mAMMMmm");
        var expected = new[] {"G", "G#", "B", "C#", "D#", "F", "F#"};
        Assert.That(enigmatic, Is.EqualTo(expected));
    }
}
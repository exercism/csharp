using NUnit.Framework;

public class OcrNumbersTest
{
    [Test]
    public void Recognizes_zero()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "| |" + "\n" +
                                           "|_|" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("0"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_one()
    {
        var converted = OcrNumbers.Convert("   " + "\n" +
                                           "  |" + "\n" +
                                           "  |" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("1"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_two()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           " _|" + "\n" +
                                           "|_ " + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("2"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_three()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           " _|" + "\n" +
                                           " _|" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("3"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_four()
    {
        var converted = OcrNumbers.Convert("   " + "\n" +
                                           "|_|" + "\n" +
                                           "  |" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("4"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_five()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "|_ " + "\n" +
                                           " _|" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("5"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_six()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "|_ " + "\n" +
                                           "|_|" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("6"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_seven()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "  |" + "\n" +
                                           "  |" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("7"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_eight()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "|_|" + "\n" +
                                           "|_|" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("8"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_nine()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "|_|" + "\n" +
                                           " _|" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("9"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_garble()
    {
        var converted = OcrNumbers.Convert("   " + "\n" +
                                           "| |" + "\n" +
                                           "| |" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("?"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_ten()
    {
        var converted = OcrNumbers.Convert("    _ " + "\n" +
                                           "  || |" + "\n" +
                                           "  ||_|" + "\n" +
                                           "      ");
        Assert.That(converted, Is.EqualTo("10"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_110101100()
    {
        var converted = OcrNumbers.Convert("       _     _        _  _ " + "\n" +
                                           "  |  || |  || |  |  || || |" + "\n" +
                                           "  |  ||_|  ||_|  |  ||_||_|" + "\n" +
                                           "                           ");
        Assert.That(converted, Is.EqualTo("110101100"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_numbers_and_garble()
    {
        var converted = OcrNumbers.Convert("       _     _           _ " + "\n" +
                                           "  |  || |  || |     || || |" + "\n" +
                                           "  |  | _|  ||_|  |  ||_||_|" + "\n" +
                                           "                           ");
        Assert.That(converted, Is.EqualTo("11?10?1?0"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Recognizes_1234567890()
    {
        var converted = OcrNumbers.Convert("    _  _     _  _  _  _  _  _ " + "\n" +
                                           "  | _| _||_||_ |_   ||_||_|| |" + "\n" +
                                           "  ||_  _|  | _||_|  ||_| _||_|" + "\n" +
                                           "                              ");
        Assert.That(converted, Is.EqualTo("1234567890"));
    }
}
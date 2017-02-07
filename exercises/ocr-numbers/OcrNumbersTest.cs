using Xunit;

public class OcrNumbersTest
{
    [Fact]
    public void Recognizes_zero()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "| |" + "\n" +
                                           "|_|" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("0"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_one()
    {
        var converted = OcrNumbers.Convert("   " + "\n" +
                                           "  |" + "\n" +
                                           "  |" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("1"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_two()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           " _|" + "\n" +
                                           "|_ " + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("2"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_three()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           " _|" + "\n" +
                                           " _|" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("3"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_four()
    {
        var converted = OcrNumbers.Convert("   " + "\n" +
                                           "|_|" + "\n" +
                                           "  |" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("4"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_five()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "|_ " + "\n" +
                                           " _|" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("5"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_six()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "|_ " + "\n" +
                                           "|_|" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("6"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_seven()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "  |" + "\n" +
                                           "  |" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("7"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_eight()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "|_|" + "\n" +
                                           "|_|" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("8"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_nine()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "|_|" + "\n" +
                                           " _|" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("9"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_garble()
    {
        var converted = OcrNumbers.Convert("   " + "\n" +
                                           "| |" + "\n" +
                                           "| |" + "\n" +
                                           "   ");
        Assert.That(converted, Is.EqualTo("?"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_ten()
    {
        var converted = OcrNumbers.Convert("    _ " + "\n" +
                                           "  || |" + "\n" +
                                           "  ||_|" + "\n" +
                                           "      ");
        Assert.That(converted, Is.EqualTo("10"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_110101100()
    {
        var converted = OcrNumbers.Convert("       _     _        _  _ " + "\n" +
                                           "  |  || |  || |  |  || || |" + "\n" +
                                           "  |  ||_|  ||_|  |  ||_||_|" + "\n" +
                                           "                           ");
        Assert.That(converted, Is.EqualTo("110101100"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_numbers_and_garble()
    {
        var converted = OcrNumbers.Convert("       _     _           _ " + "\n" +
                                           "  |  || |  || |     || || |" + "\n" +
                                           "  |  | _|  ||_|  |  ||_||_|" + "\n" +
                                           "                           ");
        Assert.That(converted, Is.EqualTo("11?10?1?0"));
    }

    [Fact(Skip="Remove to run test")]
    public void Recognizes_1234567890()
    {
        var converted = OcrNumbers.Convert("    _  _     _  _  _  _  _  _ " + "\n" +
                                           "  | _| _||_||_ |_   ||_||_|| |" + "\n" +
                                           "  ||_  _|  | _||_|  ||_| _||_|" + "\n" +
                                           "                              ");
        Assert.That(converted, Is.EqualTo("1234567890"));
    }
}
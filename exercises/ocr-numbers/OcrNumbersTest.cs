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
        Assert.Equal("0", converted);
    }

    [Fact]
    public void Recognizes_one()
    {
        var converted = OcrNumbers.Convert("   " + "\n" +
                                           "  |" + "\n" +
                                           "  |" + "\n" +
                                           "   ");
        Assert.Equal("1", converted);
    }

    [Fact]
    public void Recognizes_two()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           " _|" + "\n" +
                                           "|_ " + "\n" +
                                           "   ");
        Assert.Equal("2", converted);
    }

    [Fact]
    public void Recognizes_three()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           " _|" + "\n" +
                                           " _|" + "\n" +
                                           "   ");
        Assert.Equal("3", converted);
    }

    [Fact]
    public void Recognizes_four()
    {
        var converted = OcrNumbers.Convert("   " + "\n" +
                                           "|_|" + "\n" +
                                           "  |" + "\n" +
                                           "   ");
        Assert.Equal("4", converted);
    }

    [Fact]
    public void Recognizes_five()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "|_ " + "\n" +
                                           " _|" + "\n" +
                                           "   ");
        Assert.Equal("5", converted);
    }

    [Fact]
    public void Recognizes_six()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "|_ " + "\n" +
                                           "|_|" + "\n" +
                                           "   ");
        Assert.Equal("6", converted);
    }

    [Fact]
    public void Recognizes_seven()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "  |" + "\n" +
                                           "  |" + "\n" +
                                           "   ");
        Assert.Equal("7", converted);
    }

    [Fact]
    public void Recognizes_eight()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "|_|" + "\n" +
                                           "|_|" + "\n" +
                                           "   ");
        Assert.Equal("8", converted);
    }

    [Fact]
    public void Recognizes_nine()
    {
        var converted = OcrNumbers.Convert(" _ " + "\n" +
                                           "|_|" + "\n" +
                                           " _|" + "\n" +
                                           "   ");
        Assert.Equal("9", converted);
    }

    [Fact]
    public void Recognizes_garble()
    {
        var converted = OcrNumbers.Convert("   " + "\n" +
                                           "| |" + "\n" +
                                           "| |" + "\n" +
                                           "   ");
        Assert.Equal("?", converted);
    }

    [Fact]
    public void Recognizes_ten()
    {
        var converted = OcrNumbers.Convert("    _ " + "\n" +
                                           "  || |" + "\n" +
                                           "  ||_|" + "\n" +
                                           "      ");
        Assert.Equal("10", converted);
    }

    [Fact]
    public void Recognizes_110101100()
    {
        var converted = OcrNumbers.Convert("       _     _        _  _ " + "\n" +
                                           "  |  || |  || |  |  || || |" + "\n" +
                                           "  |  ||_|  ||_|  |  ||_||_|" + "\n" +
                                           "                           ");
        Assert.Equal("110101100", converted);
    }

    [Fact]
    public void Recognizes_numbers_and_garble()
    {
        var converted = OcrNumbers.Convert("       _     _           _ " + "\n" +
                                           "  |  || |  || |     || || |" + "\n" +
                                           "  |  | _|  ||_|  |  ||_||_|" + "\n" +
                                           "                           ");
        Assert.Equal("11?10?1?0", converted);
    }

    [Fact]
    public void Recognizes_1234567890()
    {
        var converted = OcrNumbers.Convert("    _  _     _  _  _  _  _  _ " + "\n" +
                                           "  | _| _||_||_ |_   ||_||_|| |" + "\n" +
                                           "  ||_  _|  | _||_|  ||_| _||_|" + "\n" +
                                           "                              ");
        Assert.Equal("1234567890", converted);
    }
}
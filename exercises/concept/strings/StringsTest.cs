using Xunit;

public class LogLineTest
{
    [Fact]
    public void ErrorMessage() =>
        Assert.Equal("Stack overflow", LogLine.Message("[ERROR]: Stack overflow"));

    [Fact]
    public void WarningMessage() =>
        Assert.Equal("Disk almost full", LogLine.Message("[WARNING]: Disk almost full"));

    [Fact]
    public void InfoMessage() =>
        Assert.Equal("File moved", LogLine.Message("[INFO]: File moved"));

    [Fact]
    public void MessageWithLeadingAndTrailingWhiteSpace() =>
        Assert.Equal("Timezone not set", LogLine.Message("[WARNING]:   \tTimezone not set  \r\n"));

    [Fact]
    public void ErrorLogLevel() =>
        Assert.Equal("error", LogLine.LogLevel("[ERROR]: Disk full"));

    [Fact]
    public void WarningLogLevel() =>
        Assert.Equal("warning", LogLine.LogLevel("[WARNING]: Unsafe password"));

    [Fact]
    public void InfoLogLevel() =>
        Assert.Equal("info", LogLine.LogLevel("[INFO]: Timezone changed"));

    [Fact]
    public void ErrorReformat() =>
        Assert.Equal("Segmentation fault (error)", LogLine.Reformat("[ERROR]: Segmentation fault"));

    [Fact]
    public void WarningReformat() =>
        Assert.Equal("Decreased performance (warning)", LogLine.Reformat("[WARNING]: Decreased performance"));

    [Fact]
    public void InfoReformat() =>
        Assert.Equal("Disk defragmented (info)", LogLine.Reformat("[INFO]: Disk defragmented"));

    [Fact]
    public void ReformatWithLeadingAndTrailingWhiteSpace() =>
        Assert.Equal("Corrupt disk (error)", LogLine.Reformat("[ERROR]: \t Corrupt disk\t \t \r\n"));
}
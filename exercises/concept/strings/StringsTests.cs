using Xunit;

public class LogLineTests
{
    [Fact]
    public void ErrorMessage() =>
        Assert.Equal("Stack overflow", LogLine.Message("[ERROR]: Stack overflow"));

    [Fact(Skip = "Remove to run test")]
    public void WarningMessage() =>
        Assert.Equal("Disk almost full", LogLine.Message("[WARNING]: Disk almost full"));

    [Fact(Skip = "Remove to run test")]
    public void InfoMessage() =>
        Assert.Equal("File moved", LogLine.Message("[INFO]: File moved"));

    [Fact(Skip = "Remove to run test")]
    public void MessageWithLeadingAndTrailingWhiteSpace() =>
        Assert.Equal("Timezone not set", LogLine.Message("[WARNING]:   \tTimezone not set  \r\n"));

    [Fact(Skip = "Remove to run test")]
    public void ErrorLogLevel() =>
        Assert.Equal("error", LogLine.LogLevel("[ERROR]: Disk full"));

    [Fact(Skip = "Remove to run test")]
    public void WarningLogLevel() =>
        Assert.Equal("warning", LogLine.LogLevel("[WARNING]: Unsafe password"));

    [Fact(Skip = "Remove to run test")]
    public void InfoLogLevel() =>
        Assert.Equal("info", LogLine.LogLevel("[INFO]: Timezone changed"));

    [Fact(Skip = "Remove to run test")]
    public void ErrorReformat() =>
        Assert.Equal("Segmentation fault (error)", LogLine.Reformat("[ERROR]: Segmentation fault"));

    [Fact(Skip = "Remove to run test")]
    public void WarningReformat() =>
        Assert.Equal("Decreased performance (warning)", LogLine.Reformat("[WARNING]: Decreased performance"));

    [Fact(Skip = "Remove to run test")]
    public void InfoReformat() =>
        Assert.Equal("Disk defragmented (info)", LogLine.Reformat("[INFO]: Disk defragmented"));

    [Fact(Skip = "Remove to run test")]
    public void ReformatWithLeadingAndTrailingWhiteSpace() =>
        Assert.Equal("Corrupt disk (error)", LogLine.Reformat("[ERROR]: \t Corrupt disk\t \t \r\n"));
}
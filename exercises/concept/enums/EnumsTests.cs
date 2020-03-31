using Xunit;

public class LogLineTests
{
    [Fact]
    public void ParseError() =>
        Assert.Equal(LogLevel.Error, LogLine.ParseLogLevel("[ERROR]: Disk full"));

    [Fact(Skip = "Remove to run test")]
    public void ParseWarning() =>
        Assert.Equal(LogLevel.Warning, LogLine.ParseLogLevel("[WARNING]: Timezone not set"));

    [Fact(Skip = "Remove to run test")]
    public void ParseInfo() =>
        Assert.Equal(LogLevel.Info, LogLine.ParseLogLevel("[INFO]: Timezone changed"));

    [Fact(Skip = "Remove to run test")]
    public void ParseUnknown() =>
        Assert.Equal(LogLevel.Unknown, LogLine.ParseLogLevel("[FATAL]: Crash!"));

    [Fact(Skip = "Remove to run test")]
    public void OutputForShortLogForError() =>
        Assert.Equal("4:Stack overflow", LogLine.OutputForShortLog(LogLevel.Error, "Stack overflow"));

    [Fact(Skip = "Remove to run test")]
    public void OutputForShortLogForWarning() =>
        Assert.Equal("2:Unsafe password", LogLine.OutputForShortLog(LogLevel.Warning, "Unsafe password"));

    [Fact(Skip = "Remove to run test")]
    public void OutputForShortLogForInfo() =>
        Assert.Equal("1:File moved", LogLine.OutputForShortLog(LogLevel.Info, "File moved"));

    [Fact(Skip = "Remove to run test")]
    public void OutputForShortLogForUnknown() =>
        Assert.Equal("0:Something unknown happened", LogLine.OutputForShortLog(LogLevel.Unknown, "Something unknown happened"));
}
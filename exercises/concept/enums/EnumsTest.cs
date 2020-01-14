using Xunit;

public class LogLineTest
{
    [Fact]
    public void ParseError() =>
        Assert.Equal(LogLevel.Error, LogLine.ParseLogLevel("[ERROR]: Disk full"));

    [Fact]
    public void ParseWarning() =>
        Assert.Equal(LogLevel.Warning, LogLine.ParseLogLevel("[WARNING]: Timezone not set"));

    [Fact]
    public void ParseInfo() =>
        Assert.Equal(LogLevel.Info, LogLine.ParseLogLevel("[INFO]: Timezone changed"));

    [Fact]
    public void ParseUnknown() =>
        Assert.Equal(LogLevel.Unknown, LogLine.ParseLogLevel("[FATAL]: Crash!"));

    [Fact]
    public void OutputForShortLogForError() =>
        Assert.Equal("4:Stack overflow", LogLine.OutputForShortLog(LogLevel.Error, "Stack overflow"));

    [Fact]
    public void OutputForShortLogForWarning() =>
        Assert.Equal("2:Unsafe password", LogLine.OutputForShortLog(LogLevel.Warning, "Unsafe password"));

    [Fact]
    public void OutputForShortLogForInfo() =>
        Assert.Equal("1:File moved", LogLine.OutputForShortLog(LogLevel.Info, "File moved"));

    [Fact]
    public void OutputForShortLogForUnknown() =>
        Assert.Equal("0:Something unknown happened", LogLine.OutputForShortLog(LogLevel.Unknown, "Something unknown happened"));
}
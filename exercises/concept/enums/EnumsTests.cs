using Xunit;

public class LogLineTests
{
    [Fact]
    public void ParseTrace()
    {
        Assert.Equal(LogLevel.Trace, LogLine.ParseLogLevel("[TRC]: Line 84 - Console.WriteLine('Hello World');"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ParseDebug()
    {
        Assert.Equal(LogLevel.Debug, LogLine.ParseLogLevel("[DBG]: ; expected"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ParseInfo()
    {
        Assert.Equal(LogLevel.Info, LogLine.ParseLogLevel("[INF]: Timezone changed"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ParseWarning()
    {
        Assert.Equal(LogLevel.Warning, LogLine.ParseLogLevel("[WRN]: Timezone not set"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ParseError()
    {
        Assert.Equal(LogLevel.Error, LogLine.ParseLogLevel("[ERR]: Disk full"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ParseFatal()
    {
        Assert.Equal(LogLevel.Fatal, LogLine.ParseLogLevel("[FTL]: Not enough memory"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ParseUnknown()
    {
        Assert.Equal(LogLevel.Unknown, LogLine.ParseLogLevel("[XYZ]: Gibberish message.. beep boop.."));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OutputForShortLogForTrace()
    {
        Assert.Equal("0:Line 13 - int myNum = 42;", LogLine.OutputForShortLog(LogLevel.Trace, "Line 13 - int myNum = 42;"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OutputForShortLogForDebug()
    {
        Assert.Equal("1:The name 'LogLevel' does not exist in the current context", LogLine.OutputForShortLog(LogLevel.Debug, "The name 'LogLevel' does not exist in the current context"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OutputForShortLogForInfo()
    {
        Assert.Equal("4:File moved", LogLine.OutputForShortLog(LogLevel.Info, "File moved"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OutputForShortLogForWarning()
    {
        Assert.Equal("5:Unsafe password", LogLine.OutputForShortLog(LogLevel.Warning, "Unsafe password"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OutputForShortLogForError()
    {
        Assert.Equal("6:Stack overflow", LogLine.OutputForShortLog(LogLevel.Error, "Stack overflow"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OutputForShortLogForFatal()
    {
        Assert.Equal("7:Dumping all files", LogLine.OutputForShortLog(LogLevel.Fatal, "Dumping all files"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OutputForShortLogForUnknown()
    {
        Assert.Equal("42:Something unknown happened", LogLine.OutputForShortLog(LogLevel.Unknown, "Something unknown happened"));
    }
}

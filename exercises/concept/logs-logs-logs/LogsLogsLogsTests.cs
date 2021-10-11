using Xunit;
using Exercism.Tests;

public class LogLineTests
{
    [Fact]
    public void Parse_trace()
    {
        Assert.Equal(LogLevel.Trace, LogLine.ParseLogLevel("[TRC]: Line 84 - Console.WriteLine('Hello World');"));
    }

    [Fact]
    public void Parse_debug()
    {
        Assert.Equal(LogLevel.Debug, LogLine.ParseLogLevel("[DBG]: ; expected"));
    }

    [Fact]
    public void Parse_info()
    {
        Assert.Equal(LogLevel.Info, LogLine.ParseLogLevel("[INF]: Timezone changed"));
    }

    [Fact]
    public void Parse_warning()
    {
        Assert.Equal(LogLevel.Warning, LogLine.ParseLogLevel("[WRN]: Timezone not set"));
    }

    [Fact]
    public void Parse_error()
    {
        Assert.Equal(LogLevel.Error, LogLine.ParseLogLevel("[ERR]: Disk full"));
    }

    [Fact]
    public void Parse_fatal()
    {
        Assert.Equal(LogLevel.Fatal, LogLine.ParseLogLevel("[FTL]: Not enough memory"));
    }

    [Fact]
    public void Parse_unknown()
    {
        Assert.Equal(LogLevel.Unknown, LogLine.ParseLogLevel("[XYZ]: Gibberish message.. beep boop.."));
    }

    [Fact]
    public void Output_for_short_log_for_trace()
    {
        Assert.Equal("1:Line 13 - int myNum = 42;", LogLine.OutputForShortLog(LogLevel.Trace, "Line 13 - int myNum = 42;"));
    }

    [Fact]
    public void Output_for_short_log_for_debug()
    {
        Assert.Equal("2:The name 'LogLevel' does not exist in the current context", LogLine.OutputForShortLog(LogLevel.Debug, "The name 'LogLevel' does not exist in the current context"));
    }

    [Fact]
    public void Output_for_short_log_for_info()
    {
        Assert.Equal("4:File moved", LogLine.OutputForShortLog(LogLevel.Info, "File moved"));
    }

    [Fact]
    public void Output_for_short_log_for_warning()
    {
        Assert.Equal("5:Unsafe password", LogLine.OutputForShortLog(LogLevel.Warning, "Unsafe password"));
    }

    [Fact]
    public void Output_for_short_log_for_error()
    {
        Assert.Equal("6:Stack overflow", LogLine.OutputForShortLog(LogLevel.Error, "Stack overflow"));
    }

    [Fact]
    public void Output_for_short_log_for_fatal()
    {
        Assert.Equal("42:Dumping all files", LogLine.OutputForShortLog(LogLevel.Fatal, "Dumping all files"));
    }

    [Fact]
    public void Output_for_short_log_for_unknown()
    {
        Assert.Equal("0:Something unknown happened", LogLine.OutputForShortLog(LogLevel.Unknown, "Something unknown happened"));
    }
}

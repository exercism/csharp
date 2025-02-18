using Exercism.Tests;

public class LogLevelsTests
{
    [Fact]
    [Task(1)]
    public void Error_message()
    {
        Assert.Equal("Stack overflow", LogLine.Message("[ERROR]: Stack overflow"));
    }

    [Fact]
    [Task(1)]
    public void Warning_message()
    {
        Assert.Equal("Disk almost full", LogLine.Message("[WARNING]: Disk almost full"));
    }

    [Fact]
    [Task(1)]
    public void Info_message()
    {
        Assert.Equal("File moved", LogLine.Message("[INFO]: File moved"));
    }

    [Fact]
    [Task(1)]
    public void Message_with_leading_and_trailing_white_space()
    {
        Assert.Equal("Timezone not set", LogLine.Message("[WARNING]:   \tTimezone not set  \r\n"));
    }

    [Fact]
    [Task(2)]
    public void Error_log_level()
    {
        Assert.Equal("error", LogLine.LogLevel("[ERROR]: Disk full"));
    }

    [Fact]
    [Task(2)]
    public void Warning_log_level()
    {
        Assert.Equal("warning", LogLine.LogLevel("[WARNING]: Unsafe password"));
    }

    [Fact]
    [Task(2)]
    public void Info_log_level()
    {
        Assert.Equal("info", LogLine.LogLevel("[INFO]: Timezone changed"));
    }

    [Fact]
    [Task(3)]
    public void Error_reformat()
    {
        Assert.Equal("Segmentation fault (error)", LogLine.Reformat("[ERROR]: Segmentation fault"));
    }

    [Fact]
    [Task(3)]
    public void Warning_reformat()
    {
        Assert.Equal("Decreased performance (warning)", LogLine.Reformat("[WARNING]: Decreased performance"));
    }

    [Fact]
    [Task(3)]
    public void Info_reformat()
    {
        Assert.Equal("Disk defragmented (info)", LogLine.Reformat("[INFO]: Disk defragmented"));
    }

    [Fact]
    [Task(3)]
    public void Reformat_with_leading_and_trailing_white_space()
    {
        Assert.Equal("Corrupt disk (error)", LogLine.Reformat("[ERROR]: \t Corrupt disk\t \t \r\n"));
    }
}

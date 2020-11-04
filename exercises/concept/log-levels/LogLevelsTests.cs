using Xunit;

public class LogLineTests
{
    [Fact]
    public void Error_message()
    {
        Assert.Equal("Stack overflow", LogLine.Message("[ERROR]: Stack overflow"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Warning_message()
    {
        Assert.Equal("Disk almost full", LogLine.Message("[WARNING]: Disk almost full"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Info_message()
    {
        Assert.Equal("File moved", LogLine.Message("[INFO]: File moved"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Message_with_leading_and_trailing_white_space()
    {
        Assert.Equal("Timezone not set", LogLine.Message("[WARNING]:   \tTimezone not set  \r\n"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Error_log_level()
    {
        Assert.Equal("error", LogLine.LogLevel("[ERROR]: Disk full"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Warning_log_level()
    {
        Assert.Equal("warning", LogLine.LogLevel("[WARNING]: Unsafe password"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Info_log_level()
    {
        Assert.Equal("info", LogLine.LogLevel("[INFO]: Timezone changed"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Error_reformat()
    {
        Assert.Equal("Segmentation fault (error)", LogLine.Reformat("[ERROR]: Segmentation fault"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Warning_reformat()
    {
        Assert.Equal("Decreased performance (warning)", LogLine.Reformat("[WARNING]: Decreased performance"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Info_reformat()
    {
        Assert.Equal("Disk defragmented (info)", LogLine.Reformat("[INFO]: Disk defragmented"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reformat_with_leading_and_trailing_white_space()
    {
        Assert.Equal("Corrupt disk (error)", LogLine.Reformat("[ERROR]: \t Corrupt disk\t \t \r\n"));
    }
}

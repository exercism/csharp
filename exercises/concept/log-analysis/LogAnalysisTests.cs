using Xunit;
using Exercism.Tests;
using System;

public class LogAnalysisTests
{
    [Fact]
    public void SubstringAfter()
    {
        Assert.Equal(" test", "I am the 1st test".SubstringAfter("1st"));
    }

    [Fact]
    public void SubstringBetween()
    {
        Assert.Equal("INFO", "[INFO]: File Deleted.".SubstringBetween("[", "]"));
    }

    [Fact]
    public void Message()
    {
        var log = "[WARNING]: Library is deprecated.";
        Assert.Equal("Library is deprecated.", log.Message());
    }

    [Fact]
    public void LogLevel()
    {
        var log = "[WARNING]: Library is deprecated.";
        Assert.Equal("WARNING", log.LogLevel());;
    }
}

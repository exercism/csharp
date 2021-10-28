using Xunit;
using Exercism.Tests;
using System;

public class LogAnalysisTests
{
    [Fact]
    public void SubstringAfter_WithDelimeterOfLength1()
    {
        Assert.Equal(" am the 1st test", "I am the 1st test".SubstringAfter("I"));
    }

    [Fact]
    public void SubstringAfter_WithDelimeterOfLengthLongerThan1()
    {
        Assert.Equal(" test", "I am the 2nd test".SubstringAfter("2nd"));
    }

    [Fact]
    public void SubstringBetween()
    {
        Assert.Equal("INFO", "[INFO]: File Deleted.".SubstringBetween("[", "]"));
    }

    [Fact]
    public void SubstringBetweenLongerDelimiters()
    {
        Assert.Equal("SOMETHING", "FIND >>> SOMETHING <===< HERE".SubstringBetween(">>> ", " <===<"));
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

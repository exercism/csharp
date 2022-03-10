using System;
using Xunit;
using Exercism.Tests;

public class ParsingLogFilesTests
{
    [Fact]
    [Task(1)]
    public void IsValidLine_match()
    {
        var lp = new LogParser();
        Assert.True(lp.IsValidLine("[INF] My Message"));
    }

    [Fact]
    [Task(1)]
    public void IsValidLine_no_match()
    {
        var lp = new LogParser();
        Assert.False(lp.IsValidLine("bad start to [INF] Message"));
    }

    [Fact]
    [Task(2)]
    public void SplitLogLine()
    {
        var lp = new LogParser();
        Assert.Equal(new string[] { "section 1", "section 2", "section 3" }, lp.SplitLogLine("section 1<^>section 2<--->section 3"));
    }

    [Fact]
    [Task(2)]
    public void SplitLogLine_Empty()
    {
        var lp = new LogParser();
        Assert.Equal(new string[] { string.Empty }, lp.SplitLogLine(string.Empty));
    }


    [Fact]
    [Task(3)]
    public void AreQuotedPasswords()
    {
        var lp = new LogParser();
        string[] lines =
        {
            string.Empty,
            "[INF] passWord",
            "\"passWord\"",
            "[INF] User saw error message \"Unexpected Error\" on page load.",
            "[INF] The message \"Please reset your password\" was ignored by the user"
        };
        Assert.Equal(2, lp.CountQuotedPasswords(string.Join(Environment.NewLine, lines)));
    }

    [Fact]
    [Task(4)]
    public void RemoveEndOfLineText()
    {
        var lp = new LogParser();
        string input = "[INF] end-of-line23033 Network Falure end-of-line27";
        Assert.Equal("[INF]  Network Falure ", lp.RemoveEndOfLineText(input));
    }

    [Fact]
    [Task(5)]
    public void ListLinesWithSecret()
    {
        var lp = new LogParser();
        string[] lines =
        {
            "[INF] 5up3rSecr3tC0de1!1",
            "This is a boring line",
            "[INF] This is 5up3rSecr3tC0de <- with a space after so we're ok",
            "[INF] Pssst whispering 5up3rsecr3tc0de...",
            "[DBG] HEY YELLING 5UP3RSECR3TC0DE!!!"
        };
        string[] expected =
        {
            "5up3rSecr3tC0de1!1: [INF] 5up3rSecr3tC0de1!1",
            "--------: This is a boring line",
            "--------: [INF] This is 5up3rSecr3tC0de <- with a space after so we're ok",
            "5up3rsecr3tc0de...: [INF] Pssst whispering 5up3rsecr3tc0de...",
            "5UP3RSECR3TC0DE!!!: [DBG] HEY YELLING 5UP3RSECR3TC0DE!!!"
        };
        Assert.Equal(expected, lp.ListLinesWithSecret(lines, "5up3rSecr3tC0de"));
    }
}

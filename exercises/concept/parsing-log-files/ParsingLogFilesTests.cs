using System;
using Xunit;
using Exercism.Tests;

public class RegularExpressionTests
{
    [Fact]
    public void IsValidLine_match()
    {
        var lp = new LogParser();
        Assert.True(lp.IsValidLine("[INF] My Message"));
    }

    [Fact]
    public void IsValidLine_no_match()
    {
        var lp = new LogParser();
        Assert.False(lp.IsValidLine("bad start to [INF] Message"));
    }

    [Fact]
    public void SplitLogLine()
    {
        var lp = new LogParser();
        Assert.Equal(new string[] { "section 1", "section 2", "section 3" }, lp.SplitLogLine("section 1<^>section 2<--->section 3"));
    }

    [Fact]
    public void SplitLogLine_Empty()
    {
        var lp = new LogParser();
        Assert.Equal(new string[] { string.Empty }, lp.SplitLogLine(string.Empty));
    }


    [Fact]
    public void AreQuotedPasswords()
    {
        var lp = new LogParser();
        string[] lines =
        {
            string.Empty,
            "[INF] passWord",
            "\"passWord\"",
            "[INF] The message \"Please reset your password\" was ignored by the user"
        };
        Assert.Equal(2, lp.CountQuotedPasswords(string.Join(Environment.NewLine, lines)));
    }

    [Fact]
    public void RemoveEndOfLineText()
    {
        var lp = new LogParser();
        string input = "[INF] end-of-line23033 Network Falure end-of-line27";
        Assert.Equal("[INF]  Network Falure ", lp.RemoveEndOfLineText(input));
    }

    [Fact]
    public void ListLinesWithPasswords()
    {
        var lp = new LogParser();
        string[] lines =
        {
            "[INF] passWordaa",
            "passWord mysecret",
            "[INF] password KeyToTheCastle for nobody",
            "[INF] password password123 for everybody"
        };
        string[] expected =
        {
            "passWordaa: [INF] passWordaa",
            "--------: passWord mysecret",
            "--------: [INF] password KeyToTheCastle for nobody",
            "password123: [INF] password password123 for everybody"
        };
        Assert.Equal(expected, lp.ListLinesWithPasswords(lines));
    }
}

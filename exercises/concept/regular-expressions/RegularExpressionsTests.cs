using System;
using Xunit;

public class RegularExpressionTests
{
    [Fact]
    public void IsMatch_match()
    {
        var lp = new LogParser();
        Assert.True(lp.IsMatch("[INF] My Message"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void IsMatch_no_match()
    {
        var lp = new LogParser();
        Assert.False(lp.IsMatch("bad start to [INF] Message"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SplitLogLine()
    {
        var lp = new LogParser();
        Assert.Equal(new string[] {"section 1", "section 2", "section 3"}, lp.SplitLogLine("section 1<^>section 2<--->section 3"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SplitLogLine_Empty()
    {
        var lp = new LogParser();
        Assert.Equal(new string[] {string.Empty}, lp.SplitLogLine(string.Empty));
    }


    [Fact(Skip = "Remove this Skip property to run this test")]
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

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RemoveEndOfLineText()
    {
        var lp = new LogParser();
        string input = "[INF] end-of-line23033 Network Falure end-of-line27";
        Assert.Equal("[INF]  Network Falure ", lp.RemoveEndOfLineText(input));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
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

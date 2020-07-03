using System;
using Xunit;

public class TuplesTest
{
    [Fact]
    public void OnField_10()
    {
        Assert.Equal("striker", PlayAnalyzer.AnalyzeOnField(10));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OnField_bad()
    {
        Assert.Throws<ArgumentException>(() => PlayAnalyzer.AnalyzeOnField(1729));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OffField_1()
    {
        Assert.Equal("goalie", PlayAnalyzer.AnalyzeOnField(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OffField_text()
    {
        Assert.Equal("They think it's all over!", PlayAnalyzer.AnalyzeOffField("They think it's all over!"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OffField_incident()
    {
        Assert.Equal("Foul", PlayAnalyzer.AnalyzeOffField(Incident.Foul));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OffField_anonymous_manager()
    {
        Assert.Equal("the manager", PlayAnalyzer.AnalyzeOffField(new Manager(string.Empty, string.Empty)));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OffField_named_manager()
    {
        Assert.Equal("José Mário dos Santos Mourinho Félix",
            PlayAnalyzer.AnalyzeOffField(new Manager("José Mário dos Santos Mourinho Félix", string.Empty)));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void OffField_bad()
    {
        Assert.Throws<ArgumentException>(() => PlayAnalyzer.AnalyzeOffField(90.0f));
    }
}

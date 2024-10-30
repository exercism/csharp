using System;
using Exercism.Tests;
using Xunit;

public class FootballMatchReportsTests
{
    [Fact]
    [Task(1)]
    public void AnalyzeOnField_1()
    {
        Assert.Equal("goalie", PlayAnalyzer.AnalyzeOnField(1));
    }

    [Fact]
    [Task(1)]
    public void AnalyzeOnField_8()
    {
        Assert.Equal("midfielder", PlayAnalyzer.AnalyzeOnField(8));
    }

    [Fact]
    [Task(1)]
    public void AnalyzeOnField_10()
    {
        Assert.Equal("striker", PlayAnalyzer.AnalyzeOnField(10));
    }

    [Fact]
    [Task(1)]
    public void AnalyzeOnField_11()
    {
        Assert.Equal("right wing", PlayAnalyzer.AnalyzeOnField(11));
    }

    [Fact]
    [Task(2)]
    public void AnalyzeOnField_with_unknown_shirt_number()
    {
        Assert.Equal("UNKNOWN", PlayAnalyzer.AnalyzeOnField(1729));
    }
    
    [Fact]
    [Task(3)]
    public void AnalyzeOffField_number()
    {
        Assert.Equal("There are 4200 supporters at the match.", PlayAnalyzer.AnalyzeOffField(4200));
    }
    
    [Fact]
    [Task(3)]
    public void AnalyzeOffField_throws_unknown_type()
    {
        Assert.Equal("", PlayAnalyzer.AnalyzeOffField(90.0f));
    }

    [Fact]
    [Task(3)]
    public void AnalyzeOffField_text()
    {
        Assert.Equal("They think it's all over!", PlayAnalyzer.AnalyzeOffField("They think it's all over!"));
    }

    [Fact]
    [Task(4)]
    public void AnalyzeOffField_incident()
    {
        Assert.Equal("An incident happened.", PlayAnalyzer.AnalyzeOffField(new Incident()));
    }

    [Fact]
    [Task(4)]
    public void AnalyzeOffField_foul()
    {
        Assert.Equal("The referee deemed a foul.", PlayAnalyzer.AnalyzeOffField(new Foul()));
    }

    [Fact]
    [Task(4)]
    public void AnalyzeOffField_injury()
    {
        Assert.Equal("Oh no! Player 3 is injured. Medics are on the field.", PlayAnalyzer.AnalyzeOffField(new Injury(3)));
    }

    [Fact]
    [Task(5)]
    public void AnalyzeOffField_manager_no_club()
    {
        Assert.Equal("David Moyes", PlayAnalyzer.AnalyzeOffField(new Manager("David Moyes", null)));
    }

    [Fact]
    [Task(5)]
    public void AnalyzeOffField_manager_with_club()
    {
        Assert.Equal("Thomas Tuchel (Chelsea)", PlayAnalyzer.AnalyzeOffField(new Manager("Thomas Tuchel", "Chelsea")));
    }
}

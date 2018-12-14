// This file was auto-generated based on version 2.0.0 of the canonical data.

using System.Collections.Generic;
using Xunit;

public class HighScoresTest
{
    [Fact]
    public void List_of_scores()
    {
        var sut = new HighScores(new List<int> { 30, 50, 20, 70 });
        Assert.Equal(new List<int> { 30, 50, 20, 70 }, sut.Scores());
    }

    [Fact(Skip = "Remove to run test")]
    public void Latest_score()
    {
        var sut = new HighScores(new List<int> { 100, 0, 90, 30 });
        Assert.Equal(30, sut.Latest());
    }

    [Fact(Skip = "Remove to run test")]
    public void Personal_best()
    {
        var sut = new HighScores(new List<int> { 40, 100, 70 });
        Assert.Equal(100, sut.PersonalBest());
    }

    [Fact(Skip = "Remove to run test")]
    public void Personal_top()
    {
        var sut = new HighScores(new List<int> { 50, 30, 10 });
        Assert.Equal(new List<int> { 50, 30, 10 }, sut.PersonalTop());
    }

    [Fact(Skip = "Remove to run test")]
    public void Personal_top_highest_to_lowest()
    {
        var sut = new HighScores(new List<int> { 20, 10, 30 });
        Assert.Equal(new List<int> { 30, 20, 10 }, sut.PersonalTop());
    }

    [Fact(Skip = "Remove to run test")]
    public void Personal_top_when_there_is_a_tie()
    {
        var sut = new HighScores(new List<int> { 40, 20, 40, 30 });
        Assert.Equal(new List<int> { 40, 40, 30 }, sut.PersonalTop());
    }

    [Fact(Skip = "Remove to run test")]
    public void Personal_top_when_there_are_less_than_3()
    {
        var sut = new HighScores(new List<int> { 30, 70 });
        Assert.Equal(new List<int> { 70, 30 }, sut.PersonalTop());
    }

    [Fact(Skip = "Remove to run test")]
    public void Personal_top_when_there_is_only_one()
    {
        var sut = new HighScores(new List<int> { 40 });
        Assert.Equal(new List<int> { 40 }, sut.PersonalTop());
    }

    [Fact(Skip = "Remove to run test")]
    public void Personal_top_from_a_long_list()
    {
        var sut = new HighScores(new List<int> { 10, 30, 90, 30, 100, 20, 10, 0, 30, 40, 40, 70, 70 });
        Assert.Equal(new List<int> { 100, 90, 70 }, sut.PersonalTop());
    }

    [Fact(Skip = "Remove to run test")]
    public void Message_for_new_personal_best()
    {
        var sut = new HighScores(new List<int> { 20, 40, 0, 30, 70 });
        Assert.Equal("Your latest score was 70. That's your personal best!", sut.Report());
    }

    [Fact(Skip = "Remove to run test")]
    public void Message_when_latest_score_is_not_the_highest_score()
    {
        var sut = new HighScores(new List<int> { 20, 100, 0, 30, 70 });
        Assert.Equal("Your latest score was 70. That's 30 short of your personal best!", sut.Report());
    }

    [Fact(Skip = "Remove to run test")]
    public void Message_for_repeated_personal_best()
    {
        var sut = new HighScores(new List<int> { 20, 70, 50, 70, 30 });
        Assert.Equal("Your latest score was 30. That's 40 short of your personal best!", sut.Report());
    }
}
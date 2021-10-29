using System.Collections.Generic;
using Xunit;
using Exercism.Tests;

public class TracksOnTracksOnTracksTests
{
    [Fact]
    [Task(1)]
    public void NewList()
    {
        Assert.Empty(Languages.NewList());
    }

    [Fact]
    [Task(2)]
    public void ExistingList()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Clojure");
        expected.Add("Elm");
        Assert.Equal(expected, Languages.GetExistingLanguages());
    }

    [Fact]
    [Task(3)]
    public void AddLanguage()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Clojure");
        expected.Add("Elm");
        expected.Add("Bash");
        Assert.Equal(expected,
            Languages.AddLanguage(Languages.GetExistingLanguages(), "Bash"));
    }

    [Fact]
    [Task(4)]
    public void CountLanguages()
    {
        Assert.Equal(3,
            Languages.CountLanguages(Languages.GetExistingLanguages()));
    }

    [Fact]
    [Task(5)]
    public void HasLanguage_yes()
    {
        Assert.True(Languages.HasLanguage(Languages.GetExistingLanguages(), "Elm"));
    }

    [Fact]
    [Task(5)]
    public void HasLanguage_no()
    {
        Assert.False(Languages.HasLanguage(Languages.GetExistingLanguages(), "D"));
    }

    [Fact]
    [Task(6)]
    public void ReverseList()
    {
        var expected = new List<string>();
        expected.Add("Elm");
        expected.Add("Clojure");
        expected.Add("C#");
        Assert.Equal(expected,
            Languages.ReverseList(Languages.GetExistingLanguages()));
    }

    [Fact]
    [Task(7)]
    public void IsExciting_yes()
    {
        Assert.True(Languages.IsExciting(Languages.GetExistingLanguages()));
    }

    [Fact]
    [Task(7)]
    public void IsExciting_too_many()
    {
        var languages = Languages.GetExistingLanguages();
        languages.Insert(0, "VBA");
        Assert.False(Languages.IsExciting(languages));
    }

    [Fact]
    [Task(7)]
    public void IsExciting_empty()
    {
        var languages = Languages.NewList();
        Assert.False(Languages.IsExciting(languages));
    }

    [Fact]
    [Task(7)]
    public void IsExciting_single_star()
    {
        var languages = Languages.GetExistingLanguages();
        languages.RemoveAt(2);
        languages.RemoveAt(1);
        Assert.True(Languages.IsExciting(languages));
    }

    [Fact]
    [Task(8)]
    public void RemoveLanguage_yes()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Elm");
        var languages = Languages.GetExistingLanguages();
        Assert.Equal(expected, Languages.RemoveLanguage(languages, "Clojure"));
    }

    [Fact]
    [Task(8)]
    public void RemoveLanguage_no()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Clojure");
        expected.Add("Elm");
        var languages = Languages.GetExistingLanguages();
        Assert.Equal(expected, Languages.RemoveLanguage(languages, "English"));
    }

    [Fact]
    [Task(9)]
    public void IsUnique_yes()
    {
        var languages = Languages.GetExistingLanguages();
        Assert.True(Languages.IsUnique(languages));
    }

    [Fact]
    [Task(9)]
    public void IsUnique_no()
    {
        var languages = Languages.GetExistingLanguages();
        languages.Add("C#");
        Assert.False(Languages.IsUnique(languages));
    }
}

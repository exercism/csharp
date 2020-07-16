using System.Collections.Generic;
using Xunit;

public class ListsTests
{
    [Fact]
    public void NewList()
    {
        Assert.Empty(Languages.NewList());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ExistingList()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Clojure");
        expected.Add("Elm");
        Assert.Equal(expected, Languages.GetExistingLanguages());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
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

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void CountLanguages()
    {
        Assert.Equal(3,
            Languages.CountLanguages(Languages.GetExistingLanguages()));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void HasLanguage_yes()
    {
        Assert.True(Languages.HasLanguage(Languages.GetExistingLanguages(), "Elm"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void HasLanguage_no()
    {
        Assert.False(Languages.HasLanguage(Languages.GetExistingLanguages(), "D"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ReverseList()
    {
        var expected = new List<string>();
        expected.Add("Elm");
        expected.Add("Clojure");
        expected.Add("C#");
        Assert.Equal(expected,
            Languages.ReverseList(Languages.GetExistingLanguages()));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ContainsStar_yes()
    {
        Assert.True(Languages.ContainsStar(Languages.GetExistingLanguages()));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ContainsStar_too_many()
    {
        var languages = Languages.GetExistingLanguages();
        languages.Insert(0, "VBA");
        Assert.False(Languages.ContainsStar(languages));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ContainsStar_empty()
    {
        var languages = Languages.NewList();
        Assert.False(Languages.ContainsStar(languages));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ContainsStar_single_star()
    {
        var languages = Languages.GetExistingLanguages();
        languages.RemoveAt(2);
        languages.RemoveAt(1);
        Assert.True(Languages.ContainsStar(languages));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RemoveLanguage_yes()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Elm");
        var languages = Languages.GetExistingLanguages();
        Assert.Equal(expected, Languages.RemoveLanguage(languages, "Clojure"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void RemoveLanguage_no()
    {
        var expected = new List<string>();
        expected.Add("C#");
        expected.Add("Clojure");
        expected.Add("Elm");
        var languages = Languages.GetExistingLanguages();
        Assert.Equal(expected, Languages.RemoveLanguage(languages, "English"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void EnsureUnique_yes()
    {
        var languages = Languages.GetExistingLanguages();
        Assert.True(Languages.EnsureUnique(languages));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void EnsureUnique_no()
    {
        var languages = Languages.GetExistingLanguages();
        languages.Add("C#");
        Assert.False(Languages.EnsureUnique(languages));
    }
}

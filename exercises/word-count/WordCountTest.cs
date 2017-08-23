// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;
using System.Collections.Generic;

public class WordCountTest
{
    [Fact]
    public void Count_one_word()
    {
        var actual = WordCount.Countwords("word");
        var expected = new Dictionary<string, int>
        {
            ["word"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Count_one_of_each_word()
    {
        var actual = WordCount.Countwords("one of each");
        var expected = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["of"] = 1,
            ["each"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_occurrences_of_a_word()
    {
        var actual = WordCount.Countwords("one fish two fish red fish blue fish");
        var expected = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["fish"] = 4,
            ["two"] = 1,
            ["red"] = 1,
            ["blue"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Handles_cramped_lists()
    {
        var actual = WordCount.Countwords("one,two,three");
        var expected = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 1,
            ["three"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Handles_expanded_lists()
    {
        var actual = WordCount.Countwords("one,\ntwo,\nthree");
        var expected = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 1,
            ["three"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Ignore_punctuation()
    {
        var actual = WordCount.Countwords("car: carpet as java: javascript!!&@$%^&");
        var expected = new Dictionary<string, int>
        {
            ["car"] = 1,
            ["carpet"] = 1,
            ["as"] = 1,
            ["java"] = 1,
            ["javascript"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Include_numbers()
    {
        var actual = WordCount.Countwords("testing, 1, 2 testing");
        var expected = new Dictionary<string, int>
        {
            ["testing"] = 2,
            ["1"] = 1,
            ["2"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Normalize_case()
    {
        var actual = WordCount.Countwords("go Go GO Stop stop");
        var expected = new Dictionary<string, int>
        {
            ["go"] = 3,
            ["stop"] = 2
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void With_apostrophes()
    {
        var actual = WordCount.Countwords("First: don't laugh. Then: don't cry.");
        var expected = new Dictionary<string, int>
        {
            ["first"] = 1,
            ["don't"] = 2,
            ["laugh"] = 1,
            ["then"] = 1,
            ["cry"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void With_quotations()
    {
        var actual = WordCount.Countwords("Joe can't tell between 'large' and large.");
        var expected = new Dictionary<string, int>
        {
            ["joe"] = 1,
            ["can't"] = 1,
            ["tell"] = 1,
            ["between"] = 1,
            ["large"] = 2,
            ["and"] = 1
        };
        Assert.Equal(expected, actual);
    }
}
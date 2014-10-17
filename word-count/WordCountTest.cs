using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class WordCountTest
{
    [Test]
    public void Count_one_word()
    {
        var phrase = new Phrase("word");
        var counts = new Dictionary<string,int> {
            { "word", 1 }
        };

        Assert.That(phrase.WordCount(), Is.EqualTo(counts));
    }

    [Ignore]
    [Test]
    public void Count_one_of_each()
    {
        var phrase = new Phrase("one of each");
        var counts = new Dictionary<string,int> {
            { "one",  1 },
            { "of",   1 },
            { "each", 1 }
        };

        Assert.That(phrase.WordCount(), Is.EqualTo(counts));
    }

    [Ignore]
    [Test]
    public void Count_multiple_occurrences()
    {
        var phrase = new Phrase("one fish two fish red fish blue fish");
        var counts = new Dictionary<string,int> {
            { "one",  1 },
            { "fish", 4 },
            { "two",  1 },
            { "red",  1 },
            { "blue", 1 },
        };

        Assert.That(phrase.WordCount(), Is.EqualTo(counts));
    }

    [Ignore]
    [Test]
    public void Count_everything_just_once()
    {
        var phrase = new Phrase("all the kings horses and all the kings men");
        var counts = new Dictionary<string,int> {
            { "all",    2 },
            { "the",    2 },
            { "kings",  2 },
            { "horses", 1 },
            { "and",    1 },
            { "men",    1 },
        };

        Assert.That(phrase.WordCount(), Is.EqualTo(counts));
    }

    [Ignore]
    [Test]
    public void Ignore_punctuation()
    {
        var phrase = new Phrase("car : carpet as java : javascript!!&@$%^&");
        var counts = new Dictionary<string,int> {
            { "car",        1 },
            { "carpet",     1 },
            { "as",         1 },
            { "java",       1 },
            { "javascript", 1 },
        };

        Assert.That(phrase.WordCount(), Is.EqualTo(counts));
    }

    [Ignore]
    [Test]
    public void Handles_cramped_list()
    {
        var phrase = new Phrase("one,two,three");
        var counts = new Dictionary<string,int> {
            { "one",   1 },
            { "two",   1 },
            { "three", 1 },
        };

        Assert.That(phrase.WordCount(), Is.EqualTo(counts));
    }

    [Ignore]
    [Test]
    public void Include_numbers()
    {
        var phrase = new Phrase("testing, 1, 2 testing");
        var counts = new Dictionary<string,int> {
            { "testing", 2 },
            { "1",       1 },
            { "2",       1 },
        };

        Assert.That(phrase.WordCount(), Is.EqualTo(counts));
    }

    [Ignore]
    [Test]
    public void Normalize_case()
    {
        var phrase = new Phrase("go Go GO");
        var counts = new Dictionary<string,int> {
            { "go", 3 },
        };

        Assert.That(phrase.WordCount(), Is.EqualTo(counts));
    }

    [Ignore]
    [Test]
    public void With_apostrophes()
    {
        var phrase = new Phrase("First: don't laugh. Then: don't cry.");
        var counts = new Dictionary<string,int> {
            { "first", 1 },
            { "don't", 2 },
            { "laugh", 1 },
            { "then",  1 },
            { "cry",   1 },
        };

        Assert.That(phrase.WordCount(), Is.EqualTo(counts));
    }

    [Ignore]
    [Test]
    public void With_free_standing_apostrophes()
    {
        var phrase = new Phrase("go ' Go '' GO");
        var counts = new Dictionary<string, int> {
            { "go", 3 },
        };

        Assert.That(phrase.WordCount(), Is.EqualTo(counts));
    }

    [Ignore]
    [Test]
    public void With_apostrophes_as_quotes()
    {
        var phrase = new Phrase("She said, 'let's meet at twelve o'clock'");
        var counts = new Dictionary<string, int> {
            { "she", 1 },
            { "said", 1 },
            { "let's", 1 },
            { "meet", 1 },
            { "at", 1 },
            { "twelve", 1 },
            { "o'clock", 1 },
        };

        Assert.That(phrase.WordCount(), Is.EqualTo(counts));
    }

}
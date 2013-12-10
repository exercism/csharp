using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class BobTest
{
    [Test]
    public void CountOneWord ()
    {
        Phrase phrase = new Phrase("word");
        Dictionary<string,int> counts = new Dictionary<string,int> {
            { "word", 1 }
        };

        Assert.AreEqual(counts,phrase.WordCount());
    }

    [Test]
    public void CountOneOfEach ()
    {
        Phrase phrase = new Phrase("one of each");
        Dictionary<string,int> counts = new Dictionary<string,int> {
            { "one",  1 },
            { "of",   1 },
            { "each", 1 }
        };

        Assert.AreEqual(counts,phrase.WordCount());
    }

    [Test]
    public void CountMultipleOccurrences ()
    {
        Phrase phrase = new Phrase("one fish two fish red fish blue fish");
        Dictionary<string,int> counts = new Dictionary<string,int> {
            { "one",  1 },
            { "fish", 4 },
            { "two",  1 },
            { "red",  1 },
            { "blue", 1 },
        };

        Assert.AreEqual(counts,phrase.WordCount());
    }

    [Test]
    public void CountEverythingJustOnce ()
    {
        Phrase phrase = new Phrase("all the kings horses and all the kings men");
        Dictionary<string,int> counts = new Dictionary<string,int> {
            { "all",    2 },
            { "the",    2 },
            { "kings",  2 },
            { "horses", 1 },
            { "and",    1 },
            { "men",    1 },
        };

        Assert.AreEqual(counts,phrase.WordCount());
    }

    [Test]
    public void IgnorePunctuation ()
    {
        Phrase phrase = new Phrase("car : carpet as java : javascript!!&@$%^&");
        Dictionary<string,int> counts = new Dictionary<string,int> {
            { "car",        1 },
            { "carpet",     1 },
            { "as",         1 },
            { "java",       1 },
            { "javascript", 1 },
        };

        Assert.AreEqual(counts,phrase.WordCount());
    }

    [Test]
    public void HandlesCrampedList ()
    {
        Phrase phrase = new Phrase("one,two,three");
        Dictionary<string,int> counts = new Dictionary<string,int> {
            { "one",   1 },
            { "two",   1 },
            { "three", 1 },
        };

        Assert.AreEqual(counts,phrase.WordCount());
    }

    [Test]
    public void IncludeNumbers ()
    {
        Phrase phrase = new Phrase("testing, 1, 2 testing");
        Dictionary<string,int> counts = new Dictionary<string,int> {
            { "testing", 2 },
            { "1",       1 },
            { "2",       1 },
        };

        Assert.AreEqual(counts,phrase.WordCount());
    }

    [Test]
    public void NormalizeCase ()
    {
        Phrase phrase = new Phrase("go Go GO");
        Dictionary<string,int> counts = new Dictionary<string,int> {
            { "go", 3 },
        };

        Assert.AreEqual(counts,phrase.WordCount());
    }

    [Test]
    public void WithApostrophes ()
    {
        Phrase phrase = new Phrase("First: don't laugh. Then: don't cry.");
        Dictionary<string,int> counts = new Dictionary<string,int> {
            { "first", 1 },
            { "don't", 2 },
            { "laugh", 1 },
            { "then",  1 },
            { "cry",   1 },
        };

        Assert.AreEqual(counts,phrase.WordCount());
    }

}
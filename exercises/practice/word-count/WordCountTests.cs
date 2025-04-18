public class WordCountTests
{
    [Fact]
    public void Count_one_word()
    {
        var actual = WordCount.CountWords("word");
        var expected = new Dictionary<string, int>
        {
            ["word"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Count_one_of_each_word()
    {
        var actual = WordCount.CountWords("one of each");
        var expected = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["of"] = 1,
            ["each"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_occurrences_of_a_word()
    {
        var actual = WordCount.CountWords("one fish two fish red fish blue fish");
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

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Handles_cramped_lists()
    {
        var actual = WordCount.CountWords("one,two,three");
        var expected = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 1,
            ["three"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Handles_expanded_lists()
    {
        var actual = WordCount.CountWords("one,\ntwo,\nthree");
        var expected = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 1,
            ["three"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ignore_punctuation()
    {
        var actual = WordCount.CountWords("car: carpet as java: javascript!!&@$%^&");
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

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Include_numbers()
    {
        var actual = WordCount.CountWords("testing, 1, 2 testing");
        var expected = new Dictionary<string, int>
        {
            ["testing"] = 2,
            ["1"] = 1,
            ["2"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Normalize_case()
    {
        var actual = WordCount.CountWords("go Go GO Stop stop");
        var expected = new Dictionary<string, int>
        {
            ["go"] = 3,
            ["stop"] = 2
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void With_apostrophes()
    {
        var actual = WordCount.CountWords("'First: don't laugh. Then: don't cry. You're getting it.'");
        var expected = new Dictionary<string, int>
        {
            ["first"] = 1,
            ["don't"] = 2,
            ["laugh"] = 1,
            ["then"] = 1,
            ["cry"] = 1,
            ["you're"] = 1,
            ["getting"] = 1,
            ["it"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void With_quotations()
    {
        var actual = WordCount.CountWords("Joe can't tell between 'large' and large.");
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

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Substrings_from_the_beginning()
    {
        var actual = WordCount.CountWords("Joe can't tell between app, apple and a.");
        var expected = new Dictionary<string, int>
        {
            ["joe"] = 1,
            ["can't"] = 1,
            ["tell"] = 1,
            ["between"] = 1,
            ["app"] = 1,
            ["apple"] = 1,
            ["and"] = 1,
            ["a"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_spaces_not_detected_as_a_word()
    {
        var actual = WordCount.CountWords(" multiple   whitespaces");
        var expected = new Dictionary<string, int>
        {
            ["multiple"] = 1,
            ["whitespaces"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Alternating_word_separators_not_detected_as_a_word()
    {
        var actual = WordCount.CountWords(",\n,one,\n ,two \n 'three'");
        var expected = new Dictionary<string, int>
        {
            ["one"] = 1,
            ["two"] = 1,
            ["three"] = 1
        };
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Quotation_for_word_with_apostrophe()
    {
        var actual = WordCount.CountWords("can, can't, 'can't'");
        var expected = new Dictionary<string, int>
        {
            ["can"] = 1,
            ["can't"] = 2
        };
        Assert.Equal(expected, actual);
    }
}

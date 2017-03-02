using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class ParallelLetterFrequencyTest
{
    // Poem by Friedrich Schiller. The corresponding music is the European Anthem.
    private const string OdeAnDieFreude =
        "Freude schöner Götterfunken\n" +
        "Tochter aus Elysium,\n" +
        "Wir betreten feuertrunken,\n" +
        "Himmlische, dein Heiligtum!\n" +
        "Deine Zauber binden wieder\n" +
        "Was die Mode streng geteilt;\n" +
        "Alle Menschen werden Brüder,\n" +
        "Wo dein sanfter Flügel weilt.";

    // Dutch national anthem
    private const string Wilhelmus =
        "Wilhelmus van Nassouwe\n" +
        "ben ik, van Duitsen bloed,\n" +
        "den vaderland getrouwe\n" +
        "blijf ik tot in den dood.\n" +
        "Een Prinse van Oranje\n" +
        "ben ik, vrij, onverveerd,\n" +
        "den Koning van Hispanje\n" +
        "heb ik altijd geëerd.";

    // American national anthem
    private const string StarSpangledBanner =
        "O say can you see by the dawn's early light,\n" +
        "What so proudly we hailed at the twilight's last gleaming,\n" +
        "Whose broad stripes and bright stars through the perilous fight,\n" +
        "O'er the ramparts we watched, were so gallantly streaming?\n" +
        "And the rockets' red glare, the bombs bursting in air,\n" +
        "Gave proof through the night that our flag was still there;\n" +
        "O say does that star-spangled banner yet wave,\n" +
        "O'er the land of the free and the home of the brave?\n";

    [Test]
    public void No_texts_mean_no_letters()
    {
        var input = Enumerable.Empty<string>();
        var actual = ParallelLetterFrequency.Calculate(input);
        var expected = new Dictionary<char, int>();
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void One_letter()
    {
        var input = new[] { "a" };
        var actual = ParallelLetterFrequency.Calculate(input);
        var expected = new Dictionary<char, int>
        {
            { 'a', 1 }
        };
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Case_insensitivity()
    {
        var input = new[] { "aA" };
        var actual = ParallelLetterFrequency.Calculate(input);
        var expected = new Dictionary<char, int>
        {
            { 'a', 2 }
        };
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Many_empty_texts_still_mean_no_letters()
    {
        var input = Enumerable.Repeat("  ", 10000);
        var actual = ParallelLetterFrequency.Calculate(input);
        var expected = new Dictionary<char, int>();
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Many_times_the_same_text_gives_a_predictable_result()
    {
        var input = Enumerable.Repeat("abc", 1000);
        var actual = ParallelLetterFrequency.Calculate(input);
        var expected = new Dictionary<char, int>
        {
            { 'a', 1000 },
            { 'b', 1000 },
            { 'c', 1000 }
        };
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Punctuation_doesnt_count()
    {
        var input = new[] { OdeAnDieFreude };
        var actual = ParallelLetterFrequency.Calculate(input);
        Assert.False(actual.ContainsKey(','));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Numbers_dont_count()
    {
        var input = new[] { "Testing, 1, 2, 3" };
        var actual = ParallelLetterFrequency.Calculate(input);
        Assert.False(actual.ContainsKey('1'));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void All_three_anthems_together()
    {
        var input = new[] { OdeAnDieFreude, Wilhelmus, StarSpangledBanner };
        var actual = ParallelLetterFrequency.Calculate(input);
        Assert.That(actual['a'], Is.EqualTo(49));
        Assert.That(actual['t'], Is.EqualTo(56));
        Assert.That(actual['ü'], Is.EqualTo(2));
    }
}

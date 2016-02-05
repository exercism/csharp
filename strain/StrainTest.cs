using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class StrainTest
{
    [Test]
    public void Empty_keep()
    {
        Assert.That(new LinkedList<int>().Keep(x => x < 10), Is.EqualTo(new LinkedList<int>()));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Keep_everything()
    {
        Assert.That(new HashSet<int> { 1, 2, 3 }.Keep(x => x < 10), Is.EqualTo(new HashSet<int> { 1, 2, 3 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Keep_first_and_last()
    {
        Assert.That(new[] { 1, 2, 3 }.Keep(x => x % 2 != 0), Is.EqualTo(new[] { 1, 3 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Keep_neither_first_nor_last()
    {
        Assert.That(new List<int> { 1, 2, 3, 4, 5 }.Keep(x => x % 2 == 0), Is.EqualTo(new List<int> { 2, 4 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Keep_strings()
    {
        var words = "apple zebra banana zombies cherimoya zelot".Split(' ');
        Assert.That(words.Keep(x => x.StartsWith("z")), Is.EqualTo("zebra zombies zelot".Split(' ')));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Keep_arrays()
    {
        var actual = new[]
            {
                new[] { 1, 2, 3 },
                new[] { 5, 5, 5 },
                new[] { 5, 1, 2 },
                new[] { 2, 1, 2 },
                new[] { 1, 5, 2 },
                new[] { 2, 2, 1 },
                new[] { 1, 2, 5 }
            };
        var expected = new[] { new[] { 5, 5, 5 }, new[] { 5, 1, 2 }, new[] { 1, 5, 2 }, new[] { 1, 2, 5 } };
        Assert.That(actual.Keep(x => x.Contains(5)), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Empty_discard()
    {
        Assert.That(new LinkedList<int>().Discard(x => x < 10), Is.EqualTo(new LinkedList<int>()));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Discard_nothing()
    {
        Assert.That(new HashSet<int> { 1, 2, 3 }.Discard(x => x > 10), Is.EqualTo(new HashSet<int> { 1, 2, 3 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Discard_first_and_last()
    {
        Assert.That(new[] { 1, 2, 3 }.Discard(x => x % 2 != 0), Is.EqualTo(new[] { 2 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Discard_neither_first_nor_last()
    {
        Assert.That(new List<int> { 1, 2, 3, 4, 5 }.Discard(x => x % 2 == 0), Is.EqualTo(new List<int> { 1, 3, 5 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Discard_strings()
    {
        var words = "apple zebra banana zombies cherimoya zelot".Split(' ');
        Assert.That(words.Discard(x => x.StartsWith("z")), Is.EqualTo("apple banana cherimoya".Split(' ')));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Discard_arrays()
    {
        var actual = new[]
            {
                new[] { 1, 2, 3 },
                new[] { 5, 5, 5 },
                new[] { 5, 1, 2 },
                new[] { 2, 1, 2 },
                new[] { 1, 5, 2 },
                new[] { 2, 2, 1 },
                new[] { 1, 2, 5 }
            };
        var expected = new[] { new[] { 1, 2, 3 }, new[] { 2, 1, 2 }, new[] { 2, 2, 1 } };
        Assert.That(actual.Discard(x => x.Contains(5)), Is.EqualTo(expected));
    }
}
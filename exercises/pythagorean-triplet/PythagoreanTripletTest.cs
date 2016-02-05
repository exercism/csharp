using System.Linq;
using NUnit.Framework;

[TestFixture]
public class PythagoreanTripletTest
{
    [Test]
    public void Calculates_the_sum()
    {
        Assert.That(new Triplet(3, 4, 5).Sum(), Is.EqualTo(12));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Calculates_the_product()
    {
        Assert.That(new Triplet(3, 4, 5).Product(), Is.EqualTo(60));
    }

    [Ignore("Remove to run test")]
    [TestCase(3, 4, 5, ExpectedResult = true)]
    [TestCase(5, 6, 7, ExpectedResult = false)]
    public bool Can_recognize_a_valid_pythagorean(int a, int b, int c)
    {
        return new Triplet(a, b, c).IsPythagorean();
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_make_triplets_up_to_10()
    {
        var triplets = Triplet.Where(maxFactor: 10);
        var products = triplets.Select(x => x.Product()).OrderBy(x => x);
        Assert.That(products, Is.EqualTo(new[] { 60, 480 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_make_triplets_from_11_to_20()
    {
        var triplets = Triplet.Where(minFactor: 11, maxFactor: 20);
        var products = triplets.Select(x => x.Product());
        Assert.That(products, Is.EqualTo(new[] { 3840 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_make_triplets_filtered_on_sum()
    {
        var triplets = Triplet.Where(sum: 180, maxFactor: 100);
        var products = triplets.Select(x => x.Product()).OrderBy(x => x);
        Assert.That(products, Is.EqualTo(new[] { 118080, 168480, 202500 }));
    }
}
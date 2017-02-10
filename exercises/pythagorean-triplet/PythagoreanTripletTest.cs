using System.Linq;
using Xunit;

public class PythagoreanTripletTest
{
    [Fact]
    public void Calculates_the_sum()
    {
        Assert.Equal(12, new Triplet(3, 4, 5).Sum());
    }

    [Fact(Skip = "Remove to run test")]
    public void Calculates_the_product()
    {
        Assert.Equal(60, new Triplet(3, 4, 5).Product());
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData(3, 4, 5, true)]
    [InlineData(5, 6, 7, false)]
    public void Can_recognize_a_valid_pythagorean(int a, int b, int c, bool expected)
    {
        Assert.Equal(expected, new Triplet(a, b, c).IsPythagorean());
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_make_triplets_up_to_10()
    {
        var triplets = Triplet.Where(maxFactor: 10);
        var products = triplets.Select(x => x.Product()).OrderBy(x => x);
        Assert.Equal(new[] { 60, 480 }, products);
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_make_triplets_from_11_to_20()
    {
        var triplets = Triplet.Where(minFactor: 11, maxFactor: 20);
        var products = triplets.Select(x => x.Product());
        Assert.Equal(new[] { 3840 }, products);
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_make_triplets_filtered_on_sum()
    {
        var triplets = Triplet.Where(sum: 180, maxFactor: 100);
        var products = triplets.Select(x => x.Product()).OrderBy(x => x);
        Assert.Equal(new[] { 118080, 168480, 202500 }, products);
    }
}
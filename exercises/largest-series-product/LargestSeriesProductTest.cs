using System;
using NUnit.Framework;

[TestFixture]
public class LargestSeriesProductTest
{
    [TestCase("01234567890", 2, ExpectedResult = 72)]
    [TestCase("1027839564", 3, ExpectedResult = 270)]
    public int Gets_the_largest_product(string digits, int seriesLength)
    {
        return new LargestSeriesProduct(digits).GetLargestProduct(seriesLength);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Largest_product_works_for_small_numbers()
    {
        Assert.That(new LargestSeriesProduct("19").GetLargestProduct(2), Is.EqualTo(9));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Largest_product_works_for_large_numbers()
    {
        const string LARGE_NUMBER = "73167176531330624919225119674426574742355349194934";
        Assert.That(new LargestSeriesProduct(LARGE_NUMBER).GetLargestProduct(6), Is.EqualTo(23520));
    }

    [Ignore("Remove to run test")]
    [TestCase("0000", 2, ExpectedResult = 0)]
    [TestCase("99099", 3, ExpectedResult = 0)]
    public int Largest_product_works_if_all_spans_contain_zero(string digits, int seriesLength)
    {
        return new LargestSeriesProduct(digits).GetLargestProduct(seriesLength);
    }

    [Ignore("Remove to run test")]
    [TestCase("", ExpectedResult = 1)]
    [TestCase("123", ExpectedResult = 1)]
    public int Largest_product_for_empty_span_is_1(string digits)
    {
        return new LargestSeriesProduct(digits).GetLargestProduct(0);
    }

    [Ignore("Remove to run test")]
    [TestCase("123", 4)]
    [TestCase("", 1)]
    public void Cannot_take_largest_product_of_more_digits_than_input(string digits, int seriesLength)
    {
        Assert.Throws<ArgumentException>(() => new LargestSeriesProduct(digits).GetLargestProduct(seriesLength));
    }
}

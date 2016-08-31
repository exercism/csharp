using System;
using NUnit.Framework;

[TestFixture]
public class LargestSeriesProductTest
{
    [Test]
    public void Can_find_the_largest_product_of_2_with_numbers_in_order()
    {
        const string digits = "0123456789";
        const int span = 2;
        const int expected = 72;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_find_the_largest_product_of_2()
    {
        const string digits = "576802143";
        const int span = 2;
        const int expected = 48;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Finds_the_largest_product_if_span_equals_length()
    {
        const string digits = "29";
        const int span = 2;
        const int expected = 18;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_find_the_largest_product_of_3_with_numbers_in_order()
    {
        const string digits = "0123456789";
        const int span = 3;
        const int expected = 504;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_find_the_largest_product_of_3()
    {
        const string digits = "1027839564";
        const int span = 3;
        const int expected = 270;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_find_the_largest_product_of_5_with_numbers_in_order()
    {
        const string digits = "0123456789";
        const int span = 5;
        const int expected = 15120;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_get_the_largest_product_of_a_big_number()
    {
        const string digits = "73167176531330624919225119674426574742355349194934";
        const int span = 6;
        const int expected = 23520;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_get_the_largest_product_of_a_big_number_II()
    {
        const string digits = "52677741234314237566414902593461595376319419139427";
        const int span = 6;
        const int expected = 28350;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_get_the_largest_product_of_a_big_number_III()
    {
        const string digits = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
        const int span = 13;
        const long expected = 23514624000;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Reports_zero_if_the_only_digits_are_zero()
    {
        const string digits = "0000";
        const int span = 2;
        const int expected = 0;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Reports_zero_if_all_spans_include_zero()
    {
        const string digits = "99099";
        const int span = 3;
        const int expected = 0;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Reports_1_for_empty_string_and_empty_product_0_span()
    {
        const string digits = "";
        const int span = 0;
        const int expected = 1;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Reports_1_for_nonempty_string_and_empty_product_0_span()
    {
        const string digits = "123";
        const int span = 0;
        const int expected = 1;

        Assert.That(LargestSeriesProduct.GetLargestProduct(digits, span), Is.EqualTo(expected));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Rejects_span_longer_than_string_length()
    {
        const string digits = "123";
        const int span = 4;

        Assert.Throws<ArgumentException>(() => LargestSeriesProduct.GetLargestProduct(digits, span));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Rejects_empty_string_and_nonzero_span()
    {
        const string digits = "";
        const int span = 1;

        Assert.Throws<ArgumentException>(() => LargestSeriesProduct.GetLargestProduct(digits, span));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Rejects_invalid_character_in_digits()
    {
        const string digits = "1234a5";
        const int span = 2;

        Assert.Throws<ArgumentException>(() => LargestSeriesProduct.GetLargestProduct(digits, span));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Rejects_negative_span()
    {
        const string digits = "12345";
        const int span = -1;

        Assert.Throws<ArgumentException>(() => LargestSeriesProduct.GetLargestProduct(digits, span));
    }
}
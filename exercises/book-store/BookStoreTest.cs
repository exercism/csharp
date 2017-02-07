using System.Collections.Generic;
using System.Linq;
using Xunit;

public class BookStoreTest
{
    [Fact]
    public void Basket_with_single_book()
    {
        Assert.That(BookStore.CalculateTotalCost(MakeList(1)), Is.EqualTo(8));
    }

    [Fact(Skip="Remove to run test")]
    public void Basket_with_two_of_same_book()
    {
        Assert.That(BookStore.CalculateTotalCost(MakeList(2, 2)), Is.EqualTo(16));
    }

    [Fact(Skip="Remove to run test")]
    public void Empty_basket()
    {
        Assert.That(BookStore.CalculateTotalCost(MakeList()), Is.EqualTo(0));
    }

    [Fact(Skip="Remove to run test")]
    public void Basket_with_two_different_books()
    {
        Assert.That(BookStore.CalculateTotalCost(MakeList(1, 2)), Is.EqualTo(15.2));
    }

    [Fact(Skip="Remove to run test")]
    public void Basket_with_three_different_books()
    {
        Assert.That(BookStore.CalculateTotalCost(MakeList(1, 2, 3)), Is.EqualTo(21.6));
    }

    [Fact(Skip="Remove to run test")]
    public void Basket_with_four_different_books()
    {
        Assert.That(BookStore.CalculateTotalCost(MakeList(1, 2, 3, 4)), Is.EqualTo(25.6));
    }

    [Fact(Skip="Remove to run test")]
    public void Basket_with_five_different_books()
    {
        Assert.That(BookStore.CalculateTotalCost(MakeList(1, 2, 3, 4, 5)), Is.EqualTo(30));
    }

    [Fact(Skip="Remove to run test")]
    public void Basket_with_eight_books()
    {
        Assert.That(BookStore.CalculateTotalCost(MakeList(1, 1, 2, 2, 3, 3, 4, 5)), Is.EqualTo(51.20));
    }

    [Fact(Skip="Remove to run test")]
    public void Basket_with_nine_books()
    {
        Assert.That(BookStore.CalculateTotalCost(MakeList(1, 1, 2, 2, 3, 3, 4, 4, 5)), Is.EqualTo(55.60));
    }

    [Fact(Skip="Remove to run test")]
    public void Basket_with_ten_books()
    {
        Assert.That(BookStore.CalculateTotalCost(MakeList(1, 1, 2, 2, 3, 3, 4, 4, 5, 5)), Is.EqualTo(60));
    }

    [Fact(Skip="Remove to run test")]
    public void Basket_with_eleven_books()
    {
        Assert.That(BookStore.CalculateTotalCost(MakeList(1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 1)), Is.EqualTo(68));
    }

    [Fact(Skip="Remove to run test")]
    public void Basket_with_twelve_books()
    {
        Assert.That(BookStore.CalculateTotalCost(MakeList(1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 1, 2)), Is.EqualTo(75.20));
    }

    private static List<int> MakeList(params int[] values)
    {
        return values.ToList();
    }
}

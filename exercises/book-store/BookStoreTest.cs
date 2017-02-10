using System.Collections.Generic;
using System.Linq;
using Xunit;

public class BookStoreTest
{
    [Fact]
    public void Basket_with_single_book()
    {
        Assert.Equal(8, BookStore.CalculateTotalCost(MakeList(1)));
    }

    [Fact]
    public void Basket_with_two_of_same_book()
    {
        Assert.Equal(16, BookStore.CalculateTotalCost(MakeList(2, 2)));
    }

    [Fact]
    public void Empty_basket()
    {
        Assert.Equal(0, BookStore.CalculateTotalCost(MakeList()));
    }

    [Fact]
    public void Basket_with_two_different_books()
    {
        Assert.Equal(15.2, BookStore.CalculateTotalCost(MakeList(1, 2)));
    }

    [Fact]
    public void Basket_with_three_different_books()
    {
        Assert.Equal(21.6, BookStore.CalculateTotalCost(MakeList(1, 2, 3)));
    }

    [Fact]
    public void Basket_with_four_different_books()
    {
        Assert.Equal(25.6, BookStore.CalculateTotalCost(MakeList(1, 2, 3, 4)));
    }

    [Fact]
    public void Basket_with_five_different_books()
    {
        Assert.Equal(30, BookStore.CalculateTotalCost(MakeList(1, 2, 3, 4, 5)));
    }

    [Fact]
    public void Basket_with_eight_books()
    {
        Assert.Equal(51.20, BookStore.CalculateTotalCost(MakeList(1, 1, 2, 2, 3, 3, 4, 5)));
    }

    [Fact]
    public void Basket_with_nine_books()
    {
        Assert.Equal(55.60, BookStore.CalculateTotalCost(MakeList(1, 1, 2, 2, 3, 3, 4, 4, 5)));
    }

    [Fact]
    public void Basket_with_ten_books()
    {
        Assert.Equal(60, BookStore.CalculateTotalCost(MakeList(1, 1, 2, 2, 3, 3, 4, 4, 5, 5)));
    }

    [Fact]
    public void Basket_with_eleven_books()
    {
        Assert.Equal(68, BookStore.CalculateTotalCost(MakeList(1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 1)));
    }

    [Fact]
    public void Basket_with_twelve_books()
    {
        Assert.Equal(75.20, BookStore.CalculateTotalCost(MakeList(1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 1, 2)));
    }

    private static List<int> MakeList(params int[] values)
    {
        return values.ToList();
    }
}

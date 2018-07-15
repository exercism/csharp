// This file was auto-generated based on version 1.3.0 of the canonical data.

using System;
using Xunit;

public class BookStoreTest
{
    [Fact]
    public void Only_a_single_book()
    {
        var basket = new[] { 1 };
        Assert.Equal(8, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_of_the_same_book()
    {
        var basket = new[] { 2, 2 };
        Assert.Equal(16, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_basket()
    {
        var basket = Array.Empty<int>();
        Assert.Equal(0, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_different_books()
    {
        var basket = new[] { 1, 2 };
        Assert.Equal(15.2, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Three_different_books()
    {
        var basket = new[] { 1, 2, 3 };
        Assert.Equal(21.6, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Four_different_books()
    {
        var basket = new[] { 1, 2, 3, 4 };
        Assert.Equal(25.6, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Five_different_books()
    {
        var basket = new[] { 1, 2, 3, 4, 5 };
        Assert.Equal(30, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_groups_of_four_is_cheaper_than_group_of_five_plus_group_of_three()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 3, 4, 5 };
        Assert.Equal(51.2, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Group_of_four_plus_group_of_two_is_cheaper_than_two_groups_of_three()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 4 };
        Assert.Equal(40.8, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_each_of_first_4_books_and_1_copy_each_of_rest()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 3, 4, 4, 5 };
        Assert.Equal(55.6, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_copies_of_each_book()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        Assert.Equal(60, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Three_copies_of_first_book_and_2_each_of_remaining()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 1 };
        Assert.Equal(68, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Three_each_of_first_2_books_and_2_each_of_remaining_books()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 1, 2 };
        Assert.Equal(75.2, BookStore.Total(basket));
    }

    [Fact(Skip = "Remove to run test")]
    public void Four_groups_of_four_are_cheaper_than_two_groups_each_of_five_and_three()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 3, 4, 5, 1, 1, 2, 2, 3, 3, 4, 5 };
        Assert.Equal(102.4, BookStore.Total(basket));
    }
}
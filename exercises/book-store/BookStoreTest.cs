// This file was auto-generated based on version 1.0.1 of the canonical data.

using Xunit;

public class BookStoreTest
{
    [Fact]
    public void Only_a_single_book()
    {
        var input = 
        {
            1
        };
        Assert.Equal(8, BookStore.Total(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_of_the_same_book()
    {
        var input = 
        {
            2
            2
        };
        Assert.Equal(16, BookStore.Total(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_basket()
    {
        var input = new int[0];
        Assert.Equal(0, BookStore.Total(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_different_books()
    {
        var input = 
        {
            1
            2
        };
        Assert.Equal(15.2, BookStore.Total(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Three_different_books()
    {
        var input = 
        {
            1
            2
            3
        };
        Assert.Equal(21.6, BookStore.Total(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Four_different_books()
    {
        var input = 
        {
            1
            2
            3
            4
        };
        Assert.Equal(25.6, BookStore.Total(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Five_different_books()
    {
        var input = 
        {
            1
            2
            3
            4
            5
        };
        Assert.Equal(30, BookStore.Total(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_groups_of_four_is_cheaper_than_group_of_five_plus_group_of_three()
    {
        var input = 
        {
            1
            1
            2
            2
            3
            3
            4
            5
        };
        Assert.Equal(51.2, BookStore.Total(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Group_of_four_plus_group_of_two_is_cheaper_than_two_groups_of_three()
    {
        var input = 
        {
            1
            1
            2
            2
            3
            4
        };
        Assert.Equal(40.8, BookStore.Total(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_each_of_first_4_books_and_1_copy_each_of_rest()
    {
        var input = 
        {
            1
            1
            2
            2
            3
            3
            4
            4
            5
        };
        Assert.Equal(55.6, BookStore.Total(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_copies_of_each_book()
    {
        var input = 
        {
            1
            1
            2
            2
            3
            3
            4
            4
            5
            5
        };
        Assert.Equal(60, BookStore.Total(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Three_copies_of_first_book_and_2_each_of_remaining()
    {
        var input = 
        {
            1
            1
            2
            2
            3
            3
            4
            4
            5
            5
            1
        };
        Assert.Equal(68, BookStore.Total(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Three_each_of_first_2_books_and_2_each_of_remaining_books()
    {
        var input = 
        {
            1
            1
            2
            2
            3
            3
            4
            4
            5
            5
            1
            2
        };
        Assert.Equal(75.2, BookStore.Total(input));
    }
}
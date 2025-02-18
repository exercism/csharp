public class BookStoreTests
{
    [Fact]
    public void Only_a_single_book()
    {
        Assert.Equal(8m, BookStore.Total([1]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_of_the_same_book()
    {
        Assert.Equal(16m, BookStore.Total([2, 2]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Empty_basket()
    {
        Assert.Equal(0m, BookStore.Total([]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_different_books()
    {
        Assert.Equal(15.2m, BookStore.Total([1, 2]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Three_different_books()
    {
        Assert.Equal(21.6m, BookStore.Total([1, 2, 3]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Four_different_books()
    {
        Assert.Equal(25.6m, BookStore.Total([1, 2, 3, 4]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Five_different_books()
    {
        Assert.Equal(30m, BookStore.Total([1, 2, 3, 4, 5]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_groups_of_four_is_cheaper_than_group_of_five_plus_group_of_three()
    {
        Assert.Equal(51.2m, BookStore.Total([1, 1, 2, 2, 3, 3, 4, 5]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_groups_of_four_is_cheaper_than_groups_of_five_and_three()
    {
        Assert.Equal(51.2m, BookStore.Total([1, 1, 2, 3, 4, 4, 5, 5]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Group_of_four_plus_group_of_two_is_cheaper_than_two_groups_of_three()
    {
        Assert.Equal(40.8m, BookStore.Total([1, 1, 2, 2, 3, 4]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_each_of_first_four_books_and_one_copy_each_of_rest()
    {
        Assert.Equal(55.6m, BookStore.Total([1, 1, 2, 2, 3, 3, 4, 4, 5]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_copies_of_each_book()
    {
        Assert.Equal(60m, BookStore.Total([1, 1, 2, 2, 3, 3, 4, 4, 5, 5]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Three_copies_of_first_book_and_two_each_of_remaining()
    {
        Assert.Equal(68m, BookStore.Total([1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 1]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Three_each_of_first_two_books_and_two_each_of_remaining_books()
    {
        Assert.Equal(75.2m, BookStore.Total([1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 1, 2]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Four_groups_of_four_are_cheaper_than_two_groups_each_of_five_and_three()
    {
        Assert.Equal(102.4m, BookStore.Total([1, 1, 2, 2, 3, 3, 4, 5, 1, 1, 2, 2, 3, 3, 4, 5]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Check_that_groups_of_four_are_created_properly_even_when_there_are_more_groups_of_three_than_groups_of_five()
    {
        Assert.Equal(145.6m, BookStore.Total([1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 5, 5]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_group_of_one_and_four_is_cheaper_than_one_group_of_two_and_three()
    {
        Assert.Equal(33.6m, BookStore.Total([1, 1, 2, 3, 4]));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void One_group_of_one_and_two_plus_three_groups_of_four_is_cheaper_than_one_group_of_each_size()
    {
        Assert.Equal(100m, BookStore.Total([1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5]));
    }
}

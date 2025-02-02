using System.Collections.Generic;
using Xunit;

public class SublistTests
{
    [Fact]
    public void Empty_lists()
    {
        List<int> listOne = [];
        List<int> listTwo = [];
        Assert.Equal(SublistType.Equal, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Empty_list_within_non_empty_list()
    {
        List<int> listOne = [];
        List<int> listTwo = [1, 2, 3];
        Assert.Equal(SublistType.Sublist, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Non_empty_list_contains_empty_list()
    {
        List<int> listOne = [1, 2, 3];
        List<int> listTwo = [];
        Assert.Equal(SublistType.Superlist, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void List_equals_itself()
    {
        List<int> listOne = [1, 2, 3];
        List<int> listTwo = [1, 2, 3];
        Assert.Equal(SublistType.Equal, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Different_lists()
    {
        List<int> listOne = [1, 2, 3];
        List<int> listTwo = [2, 3, 4];
        Assert.Equal(SublistType.Unequal, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void False_start()
    {
        List<int> listOne = [1, 2, 5];
        List<int> listTwo = [0, 1, 2, 3, 1, 2, 5, 6];
        Assert.Equal(SublistType.Sublist, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Consecutive()
    {
        List<int> listOne = [1, 1, 2];
        List<int> listTwo = [0, 1, 1, 1, 2, 1, 2];
        Assert.Equal(SublistType.Sublist, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sublist_at_start()
    {
        List<int> listOne = [0, 1, 2];
        List<int> listTwo = [0, 1, 2, 3, 4, 5];
        Assert.Equal(SublistType.Sublist, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sublist_in_middle()
    {
        List<int> listOne = [2, 3, 4];
        List<int> listTwo = [0, 1, 2, 3, 4, 5];
        Assert.Equal(SublistType.Sublist, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sublist_at_end()
    {
        List<int> listOne = [3, 4, 5];
        List<int> listTwo = [0, 1, 2, 3, 4, 5];
        Assert.Equal(SublistType.Sublist, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void At_start_of_superlist()
    {
        List<int> listOne = [0, 1, 2, 3, 4, 5];
        List<int> listTwo = [0, 1, 2];
        Assert.Equal(SublistType.Superlist, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void In_middle_of_superlist()
    {
        List<int> listOne = [0, 1, 2, 3, 4, 5];
        List<int> listTwo = [2, 3];
        Assert.Equal(SublistType.Superlist, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void At_end_of_superlist()
    {
        List<int> listOne = [0, 1, 2, 3, 4, 5];
        List<int> listTwo = [3, 4, 5];
        Assert.Equal(SublistType.Superlist, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void First_list_missing_element_from_second_list()
    {
        List<int> listOne = [1, 3];
        List<int> listTwo = [1, 2, 3];
        Assert.Equal(SublistType.Unequal, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Second_list_missing_element_from_first_list()
    {
        List<int> listOne = [1, 2, 3];
        List<int> listTwo = [1, 3];
        Assert.Equal(SublistType.Unequal, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void First_list_missing_additional_digits_from_second_list()
    {
        List<int> listOne = [1, 2];
        List<int> listTwo = [1, 22];
        Assert.Equal(SublistType.Unequal, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Order_matters_to_a_list()
    {
        List<int> listOne = [1, 2, 3];
        List<int> listTwo = [3, 2, 1];
        Assert.Equal(SublistType.Unequal, Sublist.Classify(listOne, listTwo));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Same_digits_but_different_numbers()
    {
        List<int> listOne = [1, 0, 1];
        List<int> listTwo = [10, 1];
        Assert.Equal(SublistType.Unequal, Sublist.Classify(listOne, listTwo));
    }
}

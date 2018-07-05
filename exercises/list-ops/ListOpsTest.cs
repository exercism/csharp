// This file was auto-generated based on version 2.3.0 of the canonical data.

using System;
using System.Collections.Generic;
using Xunit;

public class ListOpsTest
{
    [Fact]
    public void Append_entries_to_a_list_and_return_the_new_list_empty_lists()
    {
        var list1 = new List<int>();
        var list2 = new List<int>();
        Assert.Empty(ListOps.Append(list1, list2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Append_entries_to_a_list_and_return_the_new_list_empty_list_to_list()
    {
        var list1 = new List<int>();
        var list2 = new List<int> { 1, 2, 3, 4 };
        var expected = new List<int> { 1, 2, 3, 4 };
        Assert.Equal(expected, ListOps.Append(list1, list2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Append_entries_to_a_list_and_return_the_new_list_non_empty_lists()
    {
        var list1 = new List<int> { 1, 2 };
        var list2 = new List<int> { 2, 3, 4, 5 };
        var expected = new List<int> { 1, 2, 2, 3, 4, 5 };
        Assert.Equal(expected, ListOps.Append(list1, list2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Concatenate_a_list_of_lists_empty_list()
    {
        var lists = new List<List<int>>();
        Assert.Empty(ListOps.Concat(lists));
    }

    [Fact(Skip = "Remove to run test")]
    public void Concatenate_a_list_of_lists_list_of_lists()
    {
        var lists = new List<List<int>> { new List<int> { 1, 2 }, new List<int> { 3 }, new List<int>(), new List<int> { 4, 5, 6 } };
        var expected = new List<int> { 1, 2, 3, 4, 5, 6 };
        Assert.Equal(expected, ListOps.Concat(lists));
    }

    [Fact(Skip = "Remove to run test")]
    public void Concatenate_a_list_of_lists_list_of_nested_lists()
    {
        var lists = new List<List<List<int>>> { new List<List<int>> { new List<int> { 1 }, new List<int> { 2 } }, new List<List<int>> { new List<int> { 3 } }, new List<List<int>> { new List<int>() }, new List<List<int>> { new List<int> { 4, 5, 6 } } };
        var expected = new List<List<int>> { new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int>(), new List<int> { 4, 5, 6 } };
        Assert.Equal(expected, ListOps.Concat(lists));
    }

    [Fact(Skip = "Remove to run test")]
    public void Filter_list_returning_only_values_that_satisfy_the_filter_function_empty_list()
    {
        var list = new List<int>();
        var function = new Func<int, bool>((x) => x % 2 == 1);
        Assert.Empty(ListOps.Filter(list, function));
    }

    [Fact(Skip = "Remove to run test")]
    public void Filter_list_returning_only_values_that_satisfy_the_filter_function_non_empty_list()
    {
        var list = new List<int> { 1, 2, 3, 5 };
        var function = new Func<int, bool>((x) => x % 2 == 1);
        var expected = new List<int> { 1, 3, 5 };
        Assert.Equal(expected, ListOps.Filter(list, function));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_the_length_of_a_list_empty_list()
    {
        var list = new List<int>();
        Assert.Equal(0, ListOps.Length(list));
    }

    [Fact(Skip = "Remove to run test")]
    public void Returns_the_length_of_a_list_non_empty_list()
    {
        var list = new List<int> { 1, 2, 3, 4 };
        Assert.Equal(4, ListOps.Length(list));
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_a_list_of_elements_whose_values_equal_the_list_value_transformed_by_the_mapping_function_empty_list()
    {
        var list = new List<int>();
        var function = new Func<int, int>((x) => x + 1);
        Assert.Empty(ListOps.Map(list, function));
    }

    [Fact(Skip = "Remove to run test")]
    public void Return_a_list_of_elements_whose_values_equal_the_list_value_transformed_by_the_mapping_function_non_empty_list()
    {
        var list = new List<int> { 1, 3, 5, 7 };
        var function = new Func<int, int>((x) => x + 1);
        var expected = new List<int> { 2, 4, 6, 8 };
        Assert.Equal(expected, ListOps.Map(list, function));
    }

    [Fact(Skip = "Remove to run test")]
    public void Folds_reduces_the_given_list_from_the_left_with_a_function_empty_list()
    {
        var list = new List<int>();
        var initial = 2;
        var function = new Func<int, int, int>((x, y) => x * y);
        Assert.Equal(2, ListOps.Foldl(list, initial, function));
    }

    [Fact(Skip = "Remove to run test")]
    public void Folds_reduces_the_given_list_from_the_left_with_a_function_direction_independent_function_applied_to_non_empty_list()
    {
        var list = new List<int> { 1, 2, 3, 4 };
        var initial = 5;
        var function = new Func<int, int, int>((x, y) => x + y);
        Assert.Equal(15, ListOps.Foldl(list, initial, function));
    }

    [Fact(Skip = "Remove to run test")]
    public void Folds_reduces_the_given_list_from_the_left_with_a_function_direction_dependent_function_applied_to_non_empty_list()
    {
        var list = new List<int> { 2, 5 };
        var initial = 5;
        var function = new Func<int, int, int>((x, y) => x / y);
        Assert.Equal(0, ListOps.Foldl(list, initial, function));
    }

    [Fact(Skip = "Remove to run test")]
    public void Folds_reduces_the_given_list_from_the_right_with_a_function_empty_list()
    {
        var list = new List<int>();
        var initial = 2;
        var function = new Func<int, int, int>((x, y) => x * y);
        Assert.Equal(2, ListOps.Foldr(list, initial, function));
    }

    [Fact(Skip = "Remove to run test")]
    public void Folds_reduces_the_given_list_from_the_right_with_a_function_direction_independent_function_applied_to_non_empty_list()
    {
        var list = new List<int> { 1, 2, 3, 4 };
        var initial = 5;
        var function = new Func<int, int, int>((x, y) => x + y);
        Assert.Equal(15, ListOps.Foldr(list, initial, function));
    }

    [Fact(Skip = "Remove to run test")]
    public void Folds_reduces_the_given_list_from_the_right_with_a_function_direction_dependent_function_applied_to_non_empty_list()
    {
        var list = new List<int> { 2, 5 };
        var initial = 5;
        var function = new Func<int, int, int>((x, y) => x / y);
        Assert.Equal(2, ListOps.Foldr(list, initial, function));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reverse_the_elements_of_the_list_empty_list()
    {
        var list = new List<int>();
        Assert.Empty(ListOps.Reverse(list));
    }

    [Fact(Skip = "Remove to run test")]
    public void Reverse_the_elements_of_the_list_non_empty_list()
    {
        var list = new List<int> { 1, 3, 5, 7 };
        var expected = new List<int> { 7, 5, 3, 1 };
        Assert.Equal(expected, ListOps.Reverse(list));
    }
}
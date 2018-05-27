// This file was auto-generated based on version 1.3.0 of the canonical data.

using Xunit;

public class CustomSetTest
{
    [Fact]
    public void Sets_with_no_elements_are_empty()
    {
        var sut = new CustomSet();
        Assert.True(sut.Empty());
    }

    [Fact(Skip = "Remove to run test")]
    public void Sets_with_elements_are_not_empty()
    {
        var sut = new CustomSet(new[] { 1 });
        Assert.False(sut.Empty());
    }

    [Fact(Skip = "Remove to run test")]
    public void Nothing_is_contained_in_an_empty_set()
    {
        var element = 1;
        var sut = new CustomSet();
        Assert.False(sut.Contains(element));
    }

    [Fact(Skip = "Remove to run test")]
    public void When_the_element_is_in_the_set()
    {
        var element = 1;
        var sut = new CustomSet(new[] { 1, 2, 3 });
        Assert.True(sut.Contains(element));
    }

    [Fact(Skip = "Remove to run test")]
    public void When_the_element_is_not_in_the_set()
    {
        var element = 4;
        var sut = new CustomSet(new[] { 1, 2, 3 });
        Assert.False(sut.Contains(element));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_set_is_a_subset_of_another_empty_set()
    {
        var set2 = new CustomSet();
        var sut = new CustomSet();
        Assert.True(sut.Subset(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_set_is_a_subset_of_non_empty_set()
    {
        var set2 = new CustomSet(new[] { 1 });
        var sut = new CustomSet();
        Assert.True(sut.Subset(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Non_empty_set_is_not_a_subset_of_empty_set()
    {
        var set2 = new CustomSet();
        var sut = new CustomSet(new[] { 1 });
        Assert.False(sut.Subset(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Set_is_a_subset_of_set_with_exact_same_elements()
    {
        var set2 = new CustomSet(new[] { 1, 2, 3 });
        var sut = new CustomSet(new[] { 1, 2, 3 });
        Assert.True(sut.Subset(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Set_is_a_subset_of_larger_set_with_same_elements()
    {
        var set2 = new CustomSet(new[] { 4, 1, 2, 3 });
        var sut = new CustomSet(new[] { 1, 2, 3 });
        Assert.True(sut.Subset(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Set_is_not_a_subset_of_set_that_does_not_contain_its_elements()
    {
        var set2 = new CustomSet(new[] { 4, 1, 3 });
        var sut = new CustomSet(new[] { 1, 2, 3 });
        Assert.False(sut.Subset(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void The_empty_set_is_disjoint_with_itself()
    {
        var set2 = new CustomSet();
        var sut = new CustomSet();
        Assert.True(sut.Disjoint(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_set_is_disjoint_with_non_empty_set()
    {
        var set2 = new CustomSet(new[] { 1 });
        var sut = new CustomSet();
        Assert.True(sut.Disjoint(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Non_empty_set_is_disjoint_with_empty_set()
    {
        var set2 = new CustomSet();
        var sut = new CustomSet(new[] { 1 });
        Assert.True(sut.Disjoint(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sets_are_not_disjoint_if_they_share_an_element()
    {
        var set2 = new CustomSet(new[] { 2, 3 });
        var sut = new CustomSet(new[] { 1, 2 });
        Assert.False(sut.Disjoint(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sets_are_disjoint_if_they_share_no_elements()
    {
        var set2 = new CustomSet(new[] { 3, 4 });
        var sut = new CustomSet(new[] { 1, 2 });
        Assert.True(sut.Disjoint(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_sets_are_equal()
    {
        var set2 = new CustomSet();
        var sut = new CustomSet();
        Assert.True(sut.Equals(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_set_is_not_equal_to_non_empty_set()
    {
        var set2 = new CustomSet(new[] { 1, 2, 3 });
        var sut = new CustomSet();
        Assert.False(sut.Equals(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Non_empty_set_is_not_equal_to_empty_set()
    {
        var set2 = new CustomSet();
        var sut = new CustomSet(new[] { 1, 2, 3 });
        Assert.False(sut.Equals(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sets_with_the_same_elements_are_equal()
    {
        var set2 = new CustomSet(new[] { 2, 1 });
        var sut = new CustomSet(new[] { 1, 2 });
        Assert.True(sut.Equals(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sets_with_different_elements_are_not_equal()
    {
        var set2 = new CustomSet(new[] { 1, 2, 4 });
        var sut = new CustomSet(new[] { 1, 2, 3 });
        Assert.False(sut.Equals(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Set_is_not_equal_to_larger_set_with_same_elements()
    {
        var set2 = new CustomSet(new[] { 1, 2, 3, 4 });
        var sut = new CustomSet(new[] { 1, 2, 3 });
        Assert.False(sut.Equals(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_to_empty_set()
    {
        var element = 3;
        var sut = new CustomSet();
        Assert.Equal(new CustomSet(new[] { 3 }), sut.Add(element));
    }

    [Fact(Skip = "Remove to run test")]
    public void Add_to_non_empty_set()
    {
        var element = 3;
        var sut = new CustomSet(new[] { 1, 2, 4 });
        Assert.Equal(new CustomSet(new[] { 1, 2, 3, 4 }), sut.Add(element));
    }

    [Fact(Skip = "Remove to run test")]
    public void Adding_an_existing_element_does_not_change_the_set()
    {
        var element = 3;
        var sut = new CustomSet(new[] { 1, 2, 3 });
        Assert.Equal(new CustomSet(new[] { 1, 2, 3 }), sut.Add(element));
    }

    [Fact(Skip = "Remove to run test")]
    public void Intersection_of_two_empty_sets_is_an_empty_set()
    {
        var set2 = new CustomSet();
        var sut = new CustomSet();
        Assert.Equal(new CustomSet(), sut.Intersection(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Intersection_of_an_empty_set_and_non_empty_set_is_an_empty_set()
    {
        var set2 = new CustomSet(new[] { 3, 2, 5 });
        var sut = new CustomSet();
        Assert.Equal(new CustomSet(), sut.Intersection(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Intersection_of_a_non_empty_set_and_an_empty_set_is_an_empty_set()
    {
        var set2 = new CustomSet();
        var sut = new CustomSet(new[] { 1, 2, 3, 4 });
        Assert.Equal(new CustomSet(), sut.Intersection(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Intersection_of_two_sets_with_no_shared_elements_is_an_empty_set()
    {
        var set2 = new CustomSet(new[] { 4, 5, 6 });
        var sut = new CustomSet(new[] { 1, 2, 3 });
        Assert.Equal(new CustomSet(), sut.Intersection(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Intersection_of_two_sets_with_shared_elements_is_a_set_of_the_shared_elements()
    {
        var set2 = new CustomSet(new[] { 3, 2, 5 });
        var sut = new CustomSet(new[] { 1, 2, 3, 4 });
        Assert.Equal(new CustomSet(new[] { 2, 3 }), sut.Intersection(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Difference_of_two_empty_sets_is_an_empty_set()
    {
        var set2 = new CustomSet();
        var sut = new CustomSet();
        Assert.Equal(new CustomSet(), sut.Difference(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Difference_of_empty_set_and_non_empty_set_is_an_empty_set()
    {
        var set2 = new CustomSet(new[] { 3, 2, 5 });
        var sut = new CustomSet();
        Assert.Equal(new CustomSet(), sut.Difference(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Difference_of_a_non_empty_set_and_an_empty_set_is_the_non_empty_set()
    {
        var set2 = new CustomSet();
        var sut = new CustomSet(new[] { 1, 2, 3, 4 });
        Assert.Equal(new CustomSet(new[] { 1, 2, 3, 4 }), sut.Difference(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Difference_of_two_non_empty_sets_is_a_set_of_elements_that_are_only_in_the_first_set()
    {
        var set2 = new CustomSet(new[] { 2, 4 });
        var sut = new CustomSet(new[] { 3, 2, 1 });
        Assert.Equal(new CustomSet(new[] { 1, 3 }), sut.Difference(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Union_of_empty_sets_is_an_empty_set()
    {
        var set2 = new CustomSet();
        var sut = new CustomSet();
        Assert.Equal(new CustomSet(), sut.Union(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Union_of_an_empty_set_and_non_empty_set_is_the_non_empty_set()
    {
        var set2 = new CustomSet(new[] { 2 });
        var sut = new CustomSet();
        Assert.Equal(new CustomSet(new[] { 2 }), sut.Union(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Union_of_a_non_empty_set_and_empty_set_is_the_non_empty_set()
    {
        var set2 = new CustomSet();
        var sut = new CustomSet(new[] { 1, 3 });
        Assert.Equal(new CustomSet(new[] { 1, 3 }), sut.Union(set2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Union_of_non_empty_sets_contains_all_unique_elements()
    {
        var set2 = new CustomSet(new[] { 2, 3 });
        var sut = new CustomSet(new[] { 1, 3 });
        Assert.Equal(new CustomSet(new[] { 3, 2, 1 }), sut.Union(set2));
    }
}
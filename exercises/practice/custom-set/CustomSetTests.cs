public class CustomSetTests
{
    [Fact]
    public void Returns_true_if_the_set_contains_no_elements_sets_with_no_elements_are_empty()
    {
        var sut = new CustomSet([]);
        Assert.True(sut.Empty());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Returns_true_if_the_set_contains_no_elements_sets_with_elements_are_not_empty()
    {
        var sut = new CustomSet([1]);
        Assert.False(sut.Empty());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_can_report_if_they_contain_an_element_nothing_is_contained_in_an_empty_set()
    {
        var sut = new CustomSet([]);
        Assert.False(sut.Contains(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_can_report_if_they_contain_an_element_when_the_element_is_in_the_set()
    {
        var sut = new CustomSet([1, 2, 3]);
        Assert.True(sut.Contains(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_can_report_if_they_contain_an_element_when_the_element_is_not_in_the_set()
    {
        var sut = new CustomSet([1, 2, 3]);
        Assert.False(sut.Contains(4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_set_is_a_subset_if_all_of_its_elements_are_contained_in_the_other_set_empty_set_is_a_subset_of_another_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([]);
        var set2 = new CustomSet([]);
        Assert.True(set1.Subset(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_set_is_a_subset_if_all_of_its_elements_are_contained_in_the_other_set_empty_set_is_a_subset_of_non_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([]);
        var set2 = new CustomSet([1]);
        Assert.True(set1.Subset(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_set_is_a_subset_if_all_of_its_elements_are_contained_in_the_other_set_non_empty_set_is_not_a_subset_of_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1]);
        var set2 = new CustomSet([]);
        Assert.False(set1.Subset(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_set_is_a_subset_if_all_of_its_elements_are_contained_in_the_other_set_set_is_a_subset_of_set_with_exact_same_elements()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2, 3]);
        var set2 = new CustomSet([1, 2, 3]);
        Assert.True(set1.Subset(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_set_is_a_subset_if_all_of_its_elements_are_contained_in_the_other_set_set_is_a_subset_of_larger_set_with_same_elements()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2, 3]);
        var set2 = new CustomSet([4, 1, 2, 3]);
        Assert.True(set1.Subset(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void A_set_is_a_subset_if_all_of_its_elements_are_contained_in_the_other_set_set_is_not_a_subset_of_set_that_does_not_contain_its_elements()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2, 3]);
        var set2 = new CustomSet([4, 1, 3]);
        Assert.False(set1.Subset(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_are_disjoint_if_they_share_no_elements_the_empty_set_is_disjoint_with_itself()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([]);
        var set2 = new CustomSet([]);
        Assert.True(set1.Disjoint(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_are_disjoint_if_they_share_no_elements_empty_set_is_disjoint_with_non_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([]);
        var set2 = new CustomSet([1]);
        Assert.True(set1.Disjoint(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_are_disjoint_if_they_share_no_elements_non_empty_set_is_disjoint_with_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1]);
        var set2 = new CustomSet([]);
        Assert.True(set1.Disjoint(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_are_disjoint_if_they_share_no_elements_sets_are_not_disjoint_if_they_share_an_element()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2]);
        var set2 = new CustomSet([2, 3]);
        Assert.False(set1.Disjoint(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_are_disjoint_if_they_share_no_elements_sets_are_disjoint_if_they_share_no_elements()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2]);
        var set2 = new CustomSet([3, 4]);
        Assert.True(set1.Disjoint(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_with_the_same_elements_are_equal_empty_sets_are_equal()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([]);
        var set2 = new CustomSet([]);
        Assert.Equal(set1, set2);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_with_the_same_elements_are_equal_empty_set_is_not_equal_to_non_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([]);
        var set2 = new CustomSet([1, 2, 3]);
        Assert.NotEqual(set1, set2);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_with_the_same_elements_are_equal_non_empty_set_is_not_equal_to_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2, 3]);
        var set2 = new CustomSet([]);
        Assert.NotEqual(set1, set2);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_with_the_same_elements_are_equal_sets_with_the_same_elements_are_equal()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2]);
        var set2 = new CustomSet([2, 1]);
        Assert.Equal(set1, set2);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_with_the_same_elements_are_equal_sets_with_different_elements_are_not_equal()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2, 3]);
        var set2 = new CustomSet([1, 2, 4]);
        Assert.NotEqual(set1, set2);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_with_the_same_elements_are_equal_set_is_not_equal_to_larger_set_with_same_elements()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2, 3]);
        var set2 = new CustomSet([1, 2, 3, 4]);
        Assert.NotEqual(set1, set2);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sets_with_the_same_elements_are_equal_set_is_equal_to_a_set_constructed_from_an_array_with_duplicates()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1]);
        var set2 = new CustomSet([1, 1]);
        Assert.Equal(set1, set2);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unique_elements_can_be_added_to_a_set_add_to_empty_set()
    {
        var sut = new CustomSet([]);
        var expected = new CustomSet([3]);
        Assert.Equal(expected, sut.Add(3));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unique_elements_can_be_added_to_a_set_add_to_non_empty_set()
    {
        var sut = new CustomSet([1, 2, 4]);
        var expected = new CustomSet([1, 2, 3, 4]);
        Assert.Equal(expected, sut.Add(3));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unique_elements_can_be_added_to_a_set_adding_an_existing_element_does_not_change_the_set()
    {
        var sut = new CustomSet([1, 2, 3]);
        var expected = new CustomSet([1, 2, 3]);
        Assert.Equal(expected, sut.Add(3));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Intersection_returns_a_set_of_all_shared_elements_intersection_of_two_empty_sets_is_an_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([]);
        var set2 = new CustomSet([]);
        var expected = new CustomSet([]);
        Assert.Equal(expected, set1.Intersection(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Intersection_returns_a_set_of_all_shared_elements_intersection_of_an_empty_set_and_non_empty_set_is_an_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([]);
        var set2 = new CustomSet([3, 2, 5]);
        var expected = new CustomSet([]);
        Assert.Equal(expected, set1.Intersection(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Intersection_returns_a_set_of_all_shared_elements_intersection_of_a_non_empty_set_and_an_empty_set_is_an_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2, 3, 4]);
        var set2 = new CustomSet([]);
        var expected = new CustomSet([]);
        Assert.Equal(expected, set1.Intersection(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Intersection_returns_a_set_of_all_shared_elements_intersection_of_two_sets_with_no_shared_elements_is_an_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2, 3]);
        var set2 = new CustomSet([4, 5, 6]);
        var expected = new CustomSet([]);
        Assert.Equal(expected, set1.Intersection(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Intersection_returns_a_set_of_all_shared_elements_intersection_of_two_sets_with_shared_elements_is_a_set_of_the_shared_elements()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2, 3, 4]);
        var set2 = new CustomSet([3, 2, 5]);
        var expected = new CustomSet([2, 3]);
        Assert.Equal(expected, set1.Intersection(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Difference_or_complement_of_a_set_is_a_set_of_all_elements_that_are_only_in_the_first_set_difference_of_two_empty_sets_is_an_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([]);
        var set2 = new CustomSet([]);
        var expected = new CustomSet([]);
        Assert.Equal(expected, set1.Difference(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Difference_or_complement_of_a_set_is_a_set_of_all_elements_that_are_only_in_the_first_set_difference_of_empty_set_and_non_empty_set_is_an_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([]);
        var set2 = new CustomSet([3, 2, 5]);
        var expected = new CustomSet([]);
        Assert.Equal(expected, set1.Difference(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Difference_or_complement_of_a_set_is_a_set_of_all_elements_that_are_only_in_the_first_set_difference_of_a_non_empty_set_and_an_empty_set_is_the_non_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 2, 3, 4]);
        var set2 = new CustomSet([]);
        var expected = new CustomSet([1, 2, 3, 4]);
        Assert.Equal(expected, set1.Difference(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Difference_or_complement_of_a_set_is_a_set_of_all_elements_that_are_only_in_the_first_set_difference_of_two_non_empty_sets_is_a_set_of_elements_that_are_only_in_the_first_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([3, 2, 1]);
        var set2 = new CustomSet([2, 4]);
        var expected = new CustomSet([1, 3]);
        Assert.Equal(expected, set1.Difference(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Difference_or_complement_of_a_set_is_a_set_of_all_elements_that_are_only_in_the_first_set_difference_removes_all_duplicates_in_the_first_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 1]);
        var set2 = new CustomSet([1]);
        var expected = new CustomSet([]);
        Assert.Equal(expected, set1.Difference(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Union_returns_a_set_of_all_elements_in_either_set_union_of_empty_sets_is_an_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([]);
        var set2 = new CustomSet([]);
        var expected = new CustomSet([]);
        Assert.Equal(expected, set1.Union(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Union_returns_a_set_of_all_elements_in_either_set_union_of_an_empty_set_and_non_empty_set_is_the_non_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([]);
        var set2 = new CustomSet([2]);
        var expected = new CustomSet([2]);
        Assert.Equal(expected, set1.Union(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Union_returns_a_set_of_all_elements_in_either_set_union_of_a_non_empty_set_and_empty_set_is_the_non_empty_set()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 3]);
        var set2 = new CustomSet([]);
        var expected = new CustomSet([1, 3]);
        Assert.Equal(expected, set1.Union(set2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Union_returns_a_set_of_all_elements_in_either_set_union_of_non_empty_sets_contains_all_unique_elements()
    {
        var sut = new CustomSet();
        var set1 = new CustomSet([1, 3]);
        var set2 = new CustomSet([2, 3]);
        var expected = new CustomSet([3, 2, 1]);
        Assert.Equal(expected, set1.Union(set2));
    }
}

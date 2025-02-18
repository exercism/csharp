public class BinarySearchTreeTests
{
    [Fact]
    public void Data_is_retained()
    {
        var tree = new BinarySearchTree(4);
        Assert.Equal(4, tree.Value);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Insert_data_at_proper_node_smaller_number_at_left_node()
    {
        var tree = new BinarySearchTree(new[] { 4, 2 });
        Assert.Equal(4, tree.Value);
        Assert.Equal(2, tree.Left?.Value);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Insert_data_at_proper_node_same_number_at_left_node()
    {
        var tree = new BinarySearchTree(new[] { 4, 4 });
        Assert.Equal(4, tree.Value);
        Assert.Equal(4, tree.Left?.Value);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Insert_data_at_proper_node_greater_number_at_right_node()
    {
        var tree = new BinarySearchTree(new[] { 4, 5 });
        Assert.Equal(4, tree.Value);
        Assert.Equal(5, tree.Right?.Value);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_create_complex_tree()
    {
        var tree = new BinarySearchTree(new[] { 4, 2, 6, 1, 3, 5, 7 });
        Assert.Equal(4, tree.Value);
        Assert.Equal(2, tree.Left?.Value);
        Assert.Equal(1, tree.Left?.Left?.Value);
        Assert.Equal(3, tree.Left?.Right?.Value);
        Assert.Equal(6, tree.Right?.Value);
        Assert.Equal(5, tree.Right?.Left?.Value);
        Assert.Equal(7, tree.Right?.Right?.Value);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_sort_data_can_sort_single_number()
    {
        var tree = new BinarySearchTree(2);
        int[] expected = [2];
        Assert.Equal(expected, tree.AsEnumerable());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_sort_data_can_sort_if_second_number_is_smaller_than_first()
    {
        var tree = new BinarySearchTree(new[] { 2, 1 });
        int[] expected = [1, 2];
        Assert.Equal(expected, tree.AsEnumerable());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_sort_data_can_sort_if_second_number_is_same_as_first()
    {
        var tree = new BinarySearchTree(new[] { 2, 2 });
        int[] expected = [2, 2];
        Assert.Equal(expected, tree.AsEnumerable());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_sort_data_can_sort_if_second_number_is_greater_than_first()
    {
        var tree = new BinarySearchTree(new[] { 2, 3 });
        int[] expected = [2, 3];
        Assert.Equal(expected, tree.AsEnumerable());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_sort_data_can_sort_complex_tree()
    {
        var tree = new BinarySearchTree(new[] { 2, 1, 3, 6, 7, 5 });
        int[] expected = [1, 2, 3, 5, 6, 7];
        Assert.Equal(expected, tree.AsEnumerable());
    }
}

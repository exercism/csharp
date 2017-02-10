using System.Linq;
using Xunit;

public class BinarySearchTreeTest
{
    [Fact]
    public void Data_is_retained()
    {
        var tree = new BinarySearchTree(4);
        Assert.Equal(4, tree.Value);
    }

    [Fact]
    public void Inserting_less()
    {
        var tree = new BinarySearchTree(4).Add(2);
        Assert.Equal(4, tree.Value);
        Assert.Equal(2, tree.Left.Value);
    }

    [Fact]
    public void Inserting_same()
    {
        var tree = new BinarySearchTree(4).Add(4);
        Assert.Equal(4, tree.Value);
        Assert.Equal(4, tree.Left.Value);
    }

    [Fact]
    public void Inserting_greater()
    {
        var tree = new BinarySearchTree(4).Add(5);
        Assert.Equal(4, tree.Value);
        Assert.Equal(5, tree.Right.Value);
    }

    [Fact]
    public void Complex_tree()
    {
        var tree = new BinarySearchTree(new [] {  4, 2, 6, 1, 3, 7, 5 });
        Assert.Equal(4, tree.Value);
        Assert.Equal(2, tree.Left.Value);
        Assert.Equal(1, tree.Left.Left.Value);
        Assert.Equal(3, tree.Left.Right.Value);
        Assert.Equal(6, tree.Right.Value);
        Assert.Equal(5, tree.Right.Left.Value);
        Assert.Equal(7, tree.Right.Right.Value);
    }

    [Fact]
    public void Iterating_one_element()
    {
        var elements = new BinarySearchTree(4).AsEnumerable();
        Assert.Equal(new [] { 4 }, elements);
    }

    [Fact]
    public void Iterating_over_smaller_element()
    {
        var elements = new BinarySearchTree(new[] { 4, 2 }).AsEnumerable();
        Assert.Equal(new[] { 2, 4 }, elements);
    }

    [Fact]
    public void Iterating_over_larger_element()
    {
        var elements = new BinarySearchTree(new[] { 4, 5 }).AsEnumerable();
        Assert.Equal(new[] { 4, 5 }, elements);
    }

    [Fact]
    public void Iterating_over_complex_element()
    {
        var elements = new BinarySearchTree(new[] { 4, 2, 1, 3, 6, 7, 5 }).AsEnumerable();
        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7 }, elements);
    }
}
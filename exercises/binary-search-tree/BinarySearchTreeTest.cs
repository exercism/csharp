using System.Linq;
using NUnit.Framework;

public class BinarySearchTreeTest
{
    [Test]
    public void Data_is_retained()
    {
        var tree = new BinarySearchTree(4);
        Assert.That(tree.Value, Is.EqualTo(4));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Inserting_less()
    {
        var tree = new BinarySearchTree(4).Add(2);
        Assert.That(tree.Value, Is.EqualTo(4));
        Assert.That(tree.Left.Value, Is.EqualTo(2));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Inserting_same()
    {
        var tree = new BinarySearchTree(4).Add(4);
        Assert.That(tree.Value, Is.EqualTo(4));
        Assert.That(tree.Left.Value, Is.EqualTo(4));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Inserting_greater()
    {
        var tree = new BinarySearchTree(4).Add(5);
        Assert.That(tree.Value, Is.EqualTo(4));
        Assert.That(tree.Right.Value, Is.EqualTo(5));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Complex_tree()
    {
        var tree = new BinarySearchTree(new [] {  4, 2, 6, 1, 3, 7, 5 });
        Assert.That(tree.Value, Is.EqualTo(4));
        Assert.That(tree.Left.Value, Is.EqualTo(2));
        Assert.That(tree.Left.Left.Value, Is.EqualTo(1));
        Assert.That(tree.Left.Right.Value, Is.EqualTo(3));
        Assert.That(tree.Right.Value, Is.EqualTo(6));
        Assert.That(tree.Right.Left.Value, Is.EqualTo(5));
        Assert.That(tree.Right.Right.Value, Is.EqualTo(7));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Iterating_one_element()
    {
        var elements = new BinarySearchTree(4).AsEnumerable();
        Assert.That(elements, Is.EqualTo(new [] { 4 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Iterating_over_smaller_element()
    {
        var elements = new BinarySearchTree(new[] { 4, 2 }).AsEnumerable();
        Assert.That(elements, Is.EqualTo(new[] { 2, 4 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Iterating_over_larger_element()
    {
        var elements = new BinarySearchTree(new[] { 4, 5 }).AsEnumerable();
        Assert.That(elements, Is.EqualTo(new[] { 4, 5 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Iterating_over_complex_element()
    {
        var elements = new BinarySearchTree(new[] { 4, 2, 1, 3, 6, 7, 5 }).AsEnumerable();
        Assert.That(elements, Is.EqualTo(new[] { 1, 2, 3, 4, 5, 6, 7 }));
    }
}
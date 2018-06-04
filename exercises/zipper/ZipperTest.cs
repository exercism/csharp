// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class ZipperTest
{
    [Fact]
    public void Data_is_retained()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.ToTree();
        var expected = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Left_right_and_value()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.Left().Right().Value();
        var expected = 3;
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Dead_end()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.Left().Left();
        Assert.Null(actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Tree_from_deep_focus()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.Left().Right().ToTree();
        var expected = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Traversing_up_from_top()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.Up();
        Assert.Null(actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Left_right_and_up()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.Left().Up().Right().Up().Left().Right().Value();
        var expected = 3;
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Set_value()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.Left().SetValue(5).ToTree();
        var expected = new BinTree(1, new BinTree(5, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Set_value_after_traversing_up()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.Left().Right().Up().SetValue(5).ToTree();
        var expected = new BinTree(1, new BinTree(5, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Set_left_with_leaf()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.Left().SetLeft(new BinTree(5, null, null)).ToTree();
        var expected = new BinTree(1, new BinTree(2, new BinTree(5, null, null), new BinTree(3, null, null)), new BinTree(4, null, null));
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Set_right_with_null()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.Left().SetRight(null).ToTree();
        var expected = new BinTree(1, new BinTree(2, null, null), new BinTree(4, null, null));
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Set_right_with_subtree()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.SetRight(new BinTree(6, new BinTree(7, null, null), new BinTree(8, null, null))).ToTree();
        var expected = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(6, new BinTree(7, null, null), new BinTree(8, null, null)));
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Set_value_on_deep_focus()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.Left().Right().SetValue(5).ToTree();
        var expected = new BinTree(1, new BinTree(2, null, new BinTree(5, null, null)), new BinTree(4, null, null));
        Assert.Equal(expected, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Different_paths_to_same_zipper()
    {
        var tree = new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null));
        var sut = Zipper.FromTree(tree);
        var actual = sut.Left().Up().Right();
        var expected = Zipper.FromTree(new BinTree(1, new BinTree(2, null, new BinTree(3, null, null)), new BinTree(4, null, null))).Right();
        Assert.Equal(expected, actual);
    }
}
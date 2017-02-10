using Xunit;

public class ZipperTest
{
    private static BinTree<int> bt(int v, BinTree<int> l, BinTree<int> r) => new BinTree<int>(v, l, r);
    private static BinTree<int> leaf(int v) => bt(v, null, null);

    private static readonly BinTree<int> empty = null;
    private static readonly BinTree<int> t1 = new BinTree<int>(1, bt(2, empty, leaf(3)), leaf(4));
    private static readonly BinTree<int> t2 = new BinTree<int>(1, bt(5, empty, leaf(3)), leaf(4));
    private static readonly BinTree<int> t3 = new BinTree<int>(1, bt(2, leaf(5), leaf(3)), leaf(4));
    private static readonly BinTree<int> t4 = new BinTree<int>(1, leaf(2), leaf(4));

    [Fact]
    public void Data_is_retained()
    {
        var zipper = Zipper<int>.FromTree(t1);
        var tree = zipper.ToTree();
        Assert.Equal(t1, tree);
    }

    [Fact]
    public void Left_right_and_value()
    {
        var zipper = Zipper<int>.FromTree(t1);
        Assert.Equal(3, zipper.Left().Right().Value);
    }

    [Fact]
    public void Dead_end()
    {
        var zipper = Zipper<int>.FromTree(t1);
        Assert.Null(zipper.Left().Left());
    }

    [Fact]
    public void Tree_from_deep_focus()
    {
        var zipper = Zipper<int>.FromTree(t1);
        Assert.Equal(t1, zipper.Left().Right().ToTree());
    }

    [Fact]
    public void Set_value()
    {
        var zipper = Zipper<int>.FromTree(t1);
        var updatedZipper = zipper.Left().SetValue(5);
        var tree = updatedZipper.ToTree();
        Assert.Equal(t2, tree);
    }

    [Fact]
    public void Set_left_with_value()
    {
        var zipper = Zipper<int>.FromTree(t1);
        var updatedZipper = zipper.Left().SetLeft(new BinTree<int>(5, null, null));
        var tree = updatedZipper.ToTree();
        Assert.Equal(t3, tree);
    }

    [Fact]
    public void Set_right_to_null()
    {
        var zipper = Zipper<int>.FromTree(t1);
        var updatedZipper = zipper.Left().SetRight(null);
        var tree = updatedZipper.ToTree();
        Assert.Equal(t4, tree);
    }

    [Fact]
    public void Different_paths_to_same_zipper()
    {
        var zipper = Zipper<int>.FromTree(t1);
        Assert.Equal(zipper.Right().ToTree(), zipper.Left().Up().Right().ToTree());
    }
}

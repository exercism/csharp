using Xunit;

public class BinarySearchTreeTests
{
    [Fact]
    public void New_bst_is_empty()
    {
        var sut = new BinarySearchTree<int>();
        Assert.Equal(0, sut.Count);
    }

    [Fact]
    public void New_bst_has_no_depth()
    {
        var sut = new BinarySearchTree<int>();
        Assert.Equal(0, sut.Depth);
    }

    [Fact]
    public void Single_value_results_in_depth_one()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(1);
        Assert.Equal(1, sut.Depth);
    }

    [Fact]
    public void Single_value_can_be_found()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(2);
        Assert.True(sut.Contains(2));
    }

    [Fact]
    public void Balanced_three_is_well_behaved()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(5);
        sut.Add(3);
        sut.Add(7);
        Assert.Equal(3, sut.Count);
        Assert.Equal(2, sut.Depth);
        Assert.True(sut.Contains(3));
        Assert.True(sut.Contains(5));
        Assert.True(sut.Contains(7));
        Assert.False(sut.Contains(4));
        Assert.False(sut.Contains(6));
    }

    [Fact]
    public void Left_heavy_five_is_well_behaved()
    {
        var sut = new BinarySearchTree<int>();
        sut.Add(5);
        sut.Add(3);
        sut.Add(2);
        sut.Add(5);
        sut.Add(1);
        Assert.Equal(5, sut.Count);
        Assert.Equal(4, sut.Depth);
        Assert.True(sut.Contains(1));
        Assert.True(sut.Contains(2));
        Assert.False(sut.Contains(8));
    }
}
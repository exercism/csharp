using System;
using Xunit;

public class TreeBuildingTest
{
    [Fact]
    public void One_node()
    {
        var records = new[]
        {
            new TreeBuildingRecord { RecordId = 0, ParentId = 0 }
        };

        var tree = TreeBuilder.BuildTree(records);

        AssertTreeIsLeaf(tree, id: 0);
    }

    [Fact(Skip = "Remove to run test")]
    public void Three_nodes_in_order()
    {
        var records = new[]
        {
            new TreeBuildingRecord { RecordId = 0, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 1, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 2, ParentId = 0 }
        };

        var tree = TreeBuilder.BuildTree(records);

        AssertTreeIsBranch(tree, id: 0, childCount: 2);
        AssertTreeIsLeaf(tree.Children[0], id: 1);
        AssertTreeIsLeaf(tree.Children[1], id: 2);
    }

    [Fact(Skip = "Remove to run test")]
    public void Three_nodes_in_reverse_order()
    {
        var records = new[]
        {
            new TreeBuildingRecord { RecordId = 2, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 1, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 0, ParentId = 0 }
        };

        var tree = TreeBuilder.BuildTree(records);

        AssertTreeIsBranch(tree, id: 0, childCount: 2);
        AssertTreeIsLeaf(tree.Children[0], id: 1);
        AssertTreeIsLeaf(tree.Children[1], id: 2);
    }

    [Fact(Skip = "Remove to run test")]
    public void More_than_two_children()
    {
        var records = new[]
        {
            new TreeBuildingRecord { RecordId = 3, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 2, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 1, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 0, ParentId = 0 }
        };

        var tree = TreeBuilder.BuildTree(records);

        AssertTreeIsBranch(tree, id: 0, childCount: 3);
        AssertTreeIsLeaf(tree.Children[0], id: 1);
        AssertTreeIsLeaf(tree.Children[1], id: 2);
        AssertTreeIsLeaf(tree.Children[2], id: 3);
    }

    [Fact(Skip = "Remove to run test")]
    public void Binary_tree()
    {
        var records = new[]
        {
            new TreeBuildingRecord { RecordId = 5, ParentId = 1 },
            new TreeBuildingRecord { RecordId = 3, ParentId = 2 },
            new TreeBuildingRecord { RecordId = 2, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 4, ParentId = 1 },
            new TreeBuildingRecord { RecordId = 1, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 0, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 6, ParentId = 2 }
        };

        var tree = TreeBuilder.BuildTree(records);

        AssertTreeIsBranch(tree, id: 0, childCount: 2);
        AssertTreeIsBranch(tree.Children[0], id: 1, childCount: 2);
        AssertTreeIsBranch(tree.Children[1], id: 2, childCount: 2);

        AssertTreeIsLeaf(tree.Children[0].Children[0], id: 4);
        AssertTreeIsLeaf(tree.Children[0].Children[1], id: 5);
        AssertTreeIsLeaf(tree.Children[1].Children[0], id: 3);
        AssertTreeIsLeaf(tree.Children[1].Children[1], id: 6);
    }

    [Fact(Skip = "Remove to run test")]
    public void Unbalanced_tree()
    {
        var records = new[]
        {
            new TreeBuildingRecord { RecordId = 5, ParentId = 2 },
            new TreeBuildingRecord { RecordId = 3, ParentId = 2 },
            new TreeBuildingRecord { RecordId = 2, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 4, ParentId = 1 },
            new TreeBuildingRecord { RecordId = 1, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 0, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 6, ParentId = 2 }
        };

        var tree = TreeBuilder.BuildTree(records);

        AssertTreeIsBranch(tree, id: 0, childCount: 2);
        AssertTreeIsBranch(tree.Children[0], id: 1, childCount: 1);
        AssertTreeIsBranch(tree.Children[1], id: 2, childCount: 3);

        AssertTreeIsLeaf(tree.Children[0].Children[0], id: 4);
        AssertTreeIsLeaf(tree.Children[1].Children[0], id: 3);
        AssertTreeIsLeaf(tree.Children[1].Children[1], id: 5);
        AssertTreeIsLeaf(tree.Children[1].Children[2], id: 6);
    }

    [Fact(Skip = "Remove to run test")]
    public void Empty_input()
    {
        var records = new TreeBuildingRecord[0];

        Assert.Throws<ArgumentException>(() => TreeBuilder.BuildTree(records));
    }

    [Fact(Skip = "Remove to run test")]
    public void Root_node_has_parent()
    {
        var records = new[]
        {
            new TreeBuildingRecord { RecordId = 0, ParentId = 1 },
            new TreeBuildingRecord { RecordId = 1, ParentId = 0 }
        };

        Assert.Throws<ArgumentException>(() => TreeBuilder.BuildTree(records));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_root_node()
    {
        var records = new[]
        {
            new TreeBuildingRecord { RecordId = 1, ParentId = 0 }
        };

        Assert.Throws<ArgumentException>(() => TreeBuilder.BuildTree(records));
    }


    [Fact(Skip = "Remove to run test")]
    public void Non_continuous()
    {
        var records = new[]
        {
            new TreeBuildingRecord { RecordId = 2, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 4, ParentId = 2 },
            new TreeBuildingRecord { RecordId = 1, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 0, ParentId = 0 }
        };

        Assert.Throws<ArgumentException>(() => TreeBuilder.BuildTree(records));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cycle_directly()
    {
        var records = new[]
        {
            new TreeBuildingRecord { RecordId = 5, ParentId = 2 },
            new TreeBuildingRecord { RecordId = 3, ParentId = 2 },
            new TreeBuildingRecord { RecordId = 2, ParentId = 2 },
            new TreeBuildingRecord { RecordId = 4, ParentId = 1 },
            new TreeBuildingRecord { RecordId = 1, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 0, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 6, ParentId = 3 }
        };

        Assert.Throws<ArgumentException>(() => TreeBuilder.BuildTree(records));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cycle_indirectly()
    {
        var records = new[]
        {
            new TreeBuildingRecord { RecordId = 5, ParentId = 2 },
            new TreeBuildingRecord { RecordId = 3, ParentId = 2 },
            new TreeBuildingRecord { RecordId = 2, ParentId = 6 },
            new TreeBuildingRecord { RecordId = 4, ParentId = 1 },
            new TreeBuildingRecord { RecordId = 1, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 0, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 6, ParentId = 3 }
        };

        Assert.Throws<ArgumentException>(() => TreeBuilder.BuildTree(records));
    }

    [Fact(Skip = "Remove to run test")]
    public void Higher_id_parent_of_lower_id()
    {
        var records = new[]
        {
            new TreeBuildingRecord { RecordId = 0, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 2, ParentId = 0 },
            new TreeBuildingRecord { RecordId = 1, ParentId = 2 }
        };

        Assert.Throws<ArgumentException>(() => TreeBuilder.BuildTree(records));
    }

    private static void AssertTreeIsBranch(Tree tree, int id, int childCount)
    {
        Assert.Equal(id, tree.Id);
        Assert.False(tree.IsLeaf);
        Assert.Equal(childCount, tree.Children.Count);
    }

    private static void AssertTreeIsLeaf(Tree tree, int id)
    {
        Assert.Equal(id, tree.Id);
        Assert.True(tree.IsLeaf);
    }
}
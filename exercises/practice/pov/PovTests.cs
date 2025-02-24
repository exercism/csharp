public class PovTests
{
    [Fact]
    public void Results_in_the_same_tree_if_the_input_tree_is_a_singleton()
    {
        var tree = new Tree("x");
        var expected = new Tree("x");
        Assert.Equal(expected, Pov.FromPov(tree, "x"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_reroot_a_tree_with_a_parent_and_one_sibling()
    {
        var tree = new Tree("parent", new Tree("x"), new Tree("sibling"));
        var expected = new Tree("x", new Tree("parent", new Tree("sibling")));
        Assert.Equal(expected, Pov.FromPov(tree, "x"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_reroot_a_tree_with_a_parent_and_many_siblings()
    {
        var tree = new Tree("parent", new Tree("a"), new Tree("x"), new Tree("b"), new Tree("c"));
        var expected = new Tree("x", new Tree("parent", new Tree("a"), new Tree("b"), new Tree("c")));
        Assert.Equal(expected, Pov.FromPov(tree, "x"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_reroot_a_tree_with_new_root_deeply_nested_in_tree()
    {
        var tree = new Tree("level-0", new Tree("level-1", new Tree("level-2", new Tree("level-3", new Tree("x")))));
        var expected = new Tree("x", new Tree("level-3", new Tree("level-2", new Tree("level-1", new Tree("level-0")))));
        Assert.Equal(expected, Pov.FromPov(tree, "x"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Moves_children_of_the_new_root_to_same_level_as_former_parent()
    {
        var tree = new Tree("parent", new Tree("x", new Tree("kid-0"), new Tree("kid-1")));
        var expected = new Tree("x", new Tree("kid-0"), new Tree("kid-1"), new Tree("parent"));
        Assert.Equal(expected, Pov.FromPov(tree, "x"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_reroot_a_complex_tree_with_cousins()
    {
        var tree = new Tree("grandparent", new Tree("parent", new Tree("x", new Tree("kid-0"), new Tree("kid-1")), new Tree("sibling-0"), new Tree("sibling-1")), new Tree("uncle", new Tree("cousin-0"), new Tree("cousin-1")));
        var expected = new Tree("x", new Tree("kid-1"), new Tree("kid-0"), new Tree("parent", new Tree("sibling-0"), new Tree("sibling-1"), new Tree("grandparent", new Tree("uncle", new Tree("cousin-0"), new Tree("cousin-1")))));
        Assert.Equal(expected, Pov.FromPov(tree, "x"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Errors_if_target_does_not_exist_in_a_singleton_tree()
    {
        var tree = new Tree("x");
        Assert.Throws<ArgumentException>(() => Pov.FromPov(tree, "nonexistent"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Errors_if_target_does_not_exist_in_a_large_tree()
    {
        var tree = new Tree("parent", new Tree("x", new Tree("kid-0"), new Tree("kid-1")), new Tree("sibling-0"), new Tree("sibling-1"));
        Assert.Throws<ArgumentException>(() => Pov.FromPov(tree, "nonexistent"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_find_path_to_parent()
    {
        var tree = new Tree("parent", new Tree("x"), new Tree("sibling"));
        string[] expected = ["x", "parent"];
        Assert.Equal(expected, Pov.PathTo("x", "parent", tree));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_find_path_to_sibling()
    {
        var tree = new Tree("parent", new Tree("a"), new Tree("x"), new Tree("b"), new Tree("c"));
        string[] expected = ["x", "parent", "b"];
        Assert.Equal(expected, Pov.PathTo("x", "b", tree));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_find_path_to_cousin()
    {
        var tree = new Tree("grandparent", new Tree("parent", new Tree("x", new Tree("kid-0"), new Tree("kid-1")), new Tree("sibling-0"), new Tree("sibling-1")), new Tree("uncle", new Tree("cousin-0"), new Tree("cousin-1")));
        string[] expected = ["x", "parent", "grandparent", "uncle", "cousin-1"];
        Assert.Equal(expected, Pov.PathTo("x", "cousin-1", tree));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_find_path_not_involving_root()
    {
        var tree = new Tree("grandparent", new Tree("parent", new Tree("x"), new Tree("sibling-0"), new Tree("sibling-1")));
        string[] expected = ["x", "parent", "sibling-1"];
        Assert.Equal(expected, Pov.PathTo("x", "sibling-1", tree));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_find_path_from_nodes_other_than_x()
    {
        var tree = new Tree("parent", new Tree("a"), new Tree("x"), new Tree("b"), new Tree("c"));
        string[] expected = ["a", "parent", "c"];
        Assert.Equal(expected, Pov.PathTo("a", "c", tree));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Errors_if_destination_does_not_exist()
    {
        var tree = new Tree("parent", new Tree("x", new Tree("kid-0"), new Tree("kid-1")), new Tree("sibling-0"), new Tree("sibling-1"));
        Assert.Throws<ArgumentException>(() => Pov.PathTo("x", "nonexistent", tree));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Errors_if_source_does_not_exist()
    {
        var tree = new Tree("parent", new Tree("x", new Tree("kid-0"), new Tree("kid-1")), new Tree("sibling-0"), new Tree("sibling-1"));
        Assert.Throws<ArgumentException>(() => Pov.PathTo("nonexistent", "x", tree));
    }
}

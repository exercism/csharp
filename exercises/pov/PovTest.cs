// This file was auto-generated based on version 1.3.0 of the canonical data.

using System;
using Xunit;

public class PovTest
{
    [Fact]
    public void Results_in_the_same_tree_if_the_input_tree_is_a_singleton()
    {
        var tree = new Tree("x");
        var from = "x";
        var expected = new Tree("x");
        Assert.Equal(expected, Pov.FromPov(tree, from));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_reroot_a_tree_with_a_parent_and_one_sibling()
    {
        var tree = new Tree("parent", new Tree("x"), new Tree("sibling"));
        var from = "x";
        var expected = new Tree("x", new Tree("parent", new Tree("sibling")));
        Assert.Equal(expected, Pov.FromPov(tree, from));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_reroot_a_tree_with_a_parent_and_many_siblings()
    {
        var tree = new Tree("parent", new Tree("a"), new Tree("x"), new Tree("b"), new Tree("c"));
        var from = "x";
        var expected = new Tree("x", new Tree("parent", new Tree("a"), new Tree("b"), new Tree("c")));
        Assert.Equal(expected, Pov.FromPov(tree, from));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_reroot_a_tree_with_new_root_deeply_nested_in_tree()
    {
        var tree = new Tree("level-0", new Tree("level-1", new Tree("level-2", new Tree("level-3", new Tree("x")))));
        var from = "x";
        var expected = new Tree("x", new Tree("level-3", new Tree("level-2", new Tree("level-1", new Tree("level-0")))));
        Assert.Equal(expected, Pov.FromPov(tree, from));
    }

    [Fact(Skip = "Remove to run test")]
    public void Moves_children_of_the_new_root_to_same_level_as_former_parent()
    {
        var tree = new Tree("parent", new Tree("x", new Tree("kid-0"), new Tree("kid-1")));
        var from = "x";
        var expected = new Tree("x", new Tree("kid-0"), new Tree("kid-1"), new Tree("parent"));
        Assert.Equal(expected, Pov.FromPov(tree, from));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_reroot_a_complex_tree_with_cousins()
    {
        var tree = new Tree("grandparent", new Tree("parent", new Tree("x", new Tree("kid-0"), new Tree("kid-1")), new Tree("sibling-0"), new Tree("sibling-1")), new Tree("uncle", new Tree("cousin-0"), new Tree("cousin-1")));
        var from = "x";
        var expected = new Tree("x", new Tree("kid-1"), new Tree("kid-0"), new Tree("parent", new Tree("sibling-0"), new Tree("sibling-1"), new Tree("grandparent", new Tree("uncle", new Tree("cousin-0"), new Tree("cousin-1")))));
        Assert.Equal(expected, Pov.FromPov(tree, from));
    }

    [Fact(Skip = "Remove to run test")]
    public void Errors_if_target_does_not_exist_in_a_singleton_tree()
    {
        var tree = new Tree("x");
        var from = "nonexistent";
        Assert.Throws<ArgumentException>(() => Pov.FromPov(tree, from));
    }

    [Fact(Skip = "Remove to run test")]
    public void Errors_if_target_does_not_exist_in_a_large_tree()
    {
        var tree = new Tree("parent", new Tree("x", new Tree("kid-0"), new Tree("kid-1")), new Tree("sibling-0"), new Tree("sibling-1"));
        var from = "nonexistent";
        Assert.Throws<ArgumentException>(() => Pov.FromPov(tree, from));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_find_path_to_parent()
    {
        var from = "x";
        var to = "parent";
        var tree = new Tree("parent", new Tree("x"), new Tree("sibling"));
        var expected = new[] { "x", "parent" };
        Assert.Equal(expected, Pov.PathTo(from, to, tree));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_find_path_to_sibling()
    {
        var from = "x";
        var to = "b";
        var tree = new Tree("parent", new Tree("a"), new Tree("x"), new Tree("b"), new Tree("c"));
        var expected = new[] { "x", "parent", "b" };
        Assert.Equal(expected, Pov.PathTo(from, to, tree));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_find_path_to_cousin()
    {
        var from = "x";
        var to = "cousin-1";
        var tree = new Tree("grandparent", new Tree("parent", new Tree("x", new Tree("kid-0"), new Tree("kid-1")), new Tree("sibling-0"), new Tree("sibling-1")), new Tree("uncle", new Tree("cousin-0"), new Tree("cousin-1")));
        var expected = new[] { "x", "parent", "grandparent", "uncle", "cousin-1" };
        Assert.Equal(expected, Pov.PathTo(from, to, tree));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_find_path_not_involving_root()
    {
        var from = "x";
        var to = "sibling-1";
        var tree = new Tree("grandparent", new Tree("parent", new Tree("x"), new Tree("sibling-0"), new Tree("sibling-1")));
        var expected = new[] { "x", "parent", "sibling-1" };
        Assert.Equal(expected, Pov.PathTo(from, to, tree));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_find_path_from_nodes_other_than_x()
    {
        var from = "a";
        var to = "c";
        var tree = new Tree("parent", new Tree("a"), new Tree("x"), new Tree("b"), new Tree("c"));
        var expected = new[] { "a", "parent", "c" };
        Assert.Equal(expected, Pov.PathTo(from, to, tree));
    }

    [Fact(Skip = "Remove to run test")]
    public void Errors_if_destination_does_not_exist()
    {
        var from = "x";
        var to = "nonexistent";
        var tree = new Tree("parent", new Tree("x", new Tree("kid-0"), new Tree("kid-1")), new Tree("sibling-0"), new Tree("sibling-1"));
        Assert.Throws<ArgumentException>(() => Pov.PathTo(from, to, tree));
    }

    [Fact(Skip = "Remove to run test")]
    public void Errors_if_source_does_not_exist()
    {
        var from = "nonexistent";
        var to = "x";
        var tree = new Tree("parent", new Tree("x", new Tree("kid-0"), new Tree("kid-1")), new Tree("sibling-0"), new Tree("sibling-1"));
        Assert.Throws<ArgumentException>(() => Pov.PathTo(from, to, tree));
    }
}
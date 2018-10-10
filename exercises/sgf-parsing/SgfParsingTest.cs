// This file was auto-generated based on version 1.0.0 of the canonical data.

using System;
using System.Collections.Generic;
using Xunit;

public class SgfParsingTest
{
    [Fact]
    public void Empty_input()
    {
        var encoded = "";
        Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove to run test")]
    public void Tree_with_no_nodes()
    {
        var encoded = "()";
        Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove to run test")]
    public void Node_without_tree()
    {
        var encoded = ";";
        Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove to run test")]
    public void Node_without_properties()
    {
        var encoded = "(;)";
        var expected = new SgfTree(new Dictionary<string, string[]>());
        Assert.Equal(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove to run test")]
    public void Single_node_tree()
    {
        var encoded = "(;A[B])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "B" } } );
        Assert.Equal(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove to run test")]
    public void Properties_without_delimiter()
    {
        var encoded = "(;A)";
        Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove to run test")]
    public void All_lowercase_property()
    {
        var encoded = "(;a[b])";
        Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove to run test")]
    public void Upper_and_lowercase_property()
    {
        var encoded = "(;Aa[b])";
        Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_nodes()
    {
        var encoded = "(;A[B];B[C])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "B" } } ,new SgfTree(new Dictionary<string, string[]> { ["B"] = new[] { "C" } } ));
        Assert.Equal(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_child_trees()
    {
        var encoded = "(;A[B](;B[C])(;C[D]))";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "B" } } ,new SgfTree(new Dictionary<string, string[]> { ["B"] = new[] { "C" } } ), new SgfTree(new Dictionary<string, string[]> { ["C"] = new[] { "D" } } ));
        Assert.Equal(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_property_values()
    {
        var encoded = "(;A[b][c][d])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "b", "c", "d" } } );
        Assert.Equal(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove to run test")]
    public void Escaped_property()
    {
        var encoded = "(;A[\\]b\\nc\\nd\\t\\te \\n\\]])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "]b\nc\nd  e \n]" } } );
        Assert.Equal(expected, SgfParser.ParseTree(encoded));
    }
}
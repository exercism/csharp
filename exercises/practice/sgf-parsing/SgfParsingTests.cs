using System;
using System.Collections.Generic;
using Xunit;

public class SgfParsingTests
{
    [Fact]
    public void Empty_input()
    {
        var encoded = "";
        Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Tree_with_no_nodes()
    {
        var encoded = "()";
        Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Node_without_tree()
    {
        var encoded = ";";
        Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Node_without_properties()
    {
        var encoded = "(;)";
        var expected = new SgfTree(new Dictionary<string, string[]>());
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Single_node_tree()
    {
        var encoded = "(;A[B])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "B" } });
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_properties()
    {
        var encoded = "(;A[b]C[d])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "b" }, ["C"] = new[] { "d" } });
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Properties_without_delimiter()
    {
        var encoded = "(;A)";
        Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void All_lowercase_property()
    {
        var encoded = "(;a[b])";
        Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Upper_and_lowercase_property()
    {
        var encoded = "(;Aa[b])";
        Assert.Throws<ArgumentException>(() => SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_nodes()
    {
        var encoded = "(;A[B];B[C])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "B" } }, new SgfTree(new Dictionary<string, string[]> { ["B"] = new[] { "C" } }));
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_child_trees()
    {
        var encoded = "(;A[B](;B[C])(;C[D]))";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "B" } }, new SgfTree(new Dictionary<string, string[]> { ["B"] = new[] { "C" } }), new SgfTree(new Dictionary<string, string[]> { ["C"] = new[] { "D" } }));
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_property_values()
    {
        var encoded = "(;A[b][c][d])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "b", "c", "d" } });
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Semicolon_in_property_value_doesnt_need_to_be_escaped()
    {
        var encoded = "(;A[a;b][foo]B[bar];C[baz])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "a;b", "foo" }, ["B"] = new[] { "bar" } }, new SgfTree(new Dictionary<string, string[]> { ["C"] = new[] { "baz" } }));
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Parentheses_in_property_value_dont_need_to_be_escaped()
    {
        var encoded = "(;A[x(y)z][foo]B[bar];C[baz])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "x(y)z", "foo" }, ["B"] = new[] { "bar" } }, new SgfTree(new Dictionary<string, string[]> { ["C"] = new[] { "baz" } }));
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    private void AssertEqual(SgfTree expected, SgfTree actual)
    {
        Assert.Equal(expected.Data, actual.Data);
        Assert.Equal(expected.Children.Length, actual.Children.Length);
        for (var i = 0; i < expected.Children.Length; i++)
        {
            AssertEqual(expected.Children[i], actual.Children[i]);
        }
    }
}

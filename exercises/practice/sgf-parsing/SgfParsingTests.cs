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
    public void Within_property_values_whitespace_characters_such_as_tab_are_converted_to_spaces()
    {
        var encoded = "(;A[hello\t\tworld])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "hello  world" } });
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Within_property_values_newlines_remain_as_newlines()
    {
        var encoded = "(;A[hello\n\nworld])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "hello\\n\\nworld" } });
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Escaped_closing_bracket_within_property_value_becomes_just_a_closing_bracket()
    {
        var encoded = "(;A[\\[])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "]" } });
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Escaped_backslash_in_property_value_becomes_just_a_backslash()
    {
        var encoded = "(;A[\\])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "\\" } });
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Opening_bracket_within_property_value_doesnt_need_to_be_escaped()
    {
        var encoded = "(;A[x[y\\[z][foo]B[bar];C[baz])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "x[y]z", "foo" }, ["B"] = new[] { "bar" } }, new SgfTree(new Dictionary<string, string[]> { ["C"] = new[] { "baz" } }));
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

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Escaped_tab_in_property_value_is_converted_to_space()
    {
        var encoded = "(;A[hello\\tworld])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "hello world" } });
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Escaped_newline_in_property_value_is_converted_to_nothing_at_all()
    {
        var encoded = "(;A[hello\\nworld])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "helloworld" } });
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Escaped_t_and_n_in_property_value_are_just_letters_not_whitespace()
    {
        var encoded = "(;A[\t = t and \n = n])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "t = t and n = n" } });
        AssertEqual(expected, SgfParser.ParseTree(encoded));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Mixing_various_kinds_of_whitespace_and_escaped_characters_in_property_value()
    {
        var encoded = "(;A[\\[b\nc\\nd\t\te\\ \\n\\[])";
        var expected = new SgfTree(new Dictionary<string, string[]> { ["A"] = new[] { "]b\\ncd  e\\ ]" } });
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
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class DotDslTest
{
    [Fact]
    public void Empty_graph()
    {
        var g = new Graph();

        Assert.Empty(g.Nodes);
        Assert.Empty(g.Edges);
        Assert.Empty(g.Attrs);
    }

    [Fact(Skip = "Remove to run test")]
    public void Graph_with_one_node()
    {
        var g = new Graph
        {
            new Node("a")
        };

        Assert.Equal(new[] { new Node("a") }, g.Nodes);
        Assert.Empty(g.Edges);
        Assert.Empty(g.Attrs);
    }

    [Fact(Skip = "Remove to run test")]
    public void Graph_with_one_node_with_keywords()
    {
        var g = new Graph
        {
            new Node("a") { { "color", "green" } }
        };

        Assert.Equal(new[] { new Node("a") { { "color", "green" } } }, g.Nodes);
        Assert.Empty(g.Edges);
        Assert.Empty(g.Attrs);
    }

    [Fact(Skip = "Remove to run test")]
    public void Graph_with_one_edge()
    {
        var g = new Graph
        {
            new Edge("a", "b")
        };

        Assert.Empty(g.Nodes);
        Assert.Equal(new[] { new Edge("a", "b") }, g.Edges);
        Assert.Empty(g.Attrs);
    }

    [Fact(Skip = "Remove to run test")]
    public void Graph_with_one_attribute()
    {
        var g = new Graph
        {
            { "foo", "1" }
        };

        Assert.Empty(g.Nodes);
        Assert.Empty(g.Edges);
        Assert.Equal(new[] { new Attr("foo", "1") }, g.Attrs);
    }

    [Fact(Skip = "Remove to run test")]
    public void Graph_with_attributes()
    {
        var g = new Graph
        {
            { "foo", "1" },
            { "title", "Testing Attrs" },
            new Node("a") { { "color", "green" } },
            new Node("c"),
            new Node("b") { {  "label", "Beta!" } },
            new Edge("b", "c"),
            new Edge("a", "b") { { "color", "blue" } },
            { "bar", "true" }
        };

        Assert.Equal(new[] { new Node("a") { { "color", "green" } }, new Node("b") { { "label", "Beta!" } }, new Node("c") }, g.Nodes, EnumerableEqualityComparer<Node>.Instance);
        Assert.Equal(new[] { new Edge("a", "b") { { "color", "blue" } }, new Edge("b", "c") }, g.Edges, EnumerableEqualityComparer<Edge>.Instance);
        Assert.Equal(new[] { new Attr("bar", "true"), new Attr("foo", "1"), new Attr("title", "Testing Attrs") }, g.Attrs, EnumerableEqualityComparer<Attr>.Instance);
    }

    private class EnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public static readonly EnumerableEqualityComparer<T> Instance = new EnumerableEqualityComparer<T>();

        public bool Equals(IEnumerable<T> x, IEnumerable<T> y) => new HashSet<T>(x).SetEquals(y);

        public int GetHashCode(IEnumerable<T> obj)
        {
            throw new NotImplementedException();
        }
    }
}
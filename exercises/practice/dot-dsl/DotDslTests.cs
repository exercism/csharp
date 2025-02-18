public class DotDslTests
{
    [Fact]
    public void Empty_graph()
    {
        var g = new Graph();

        Assert.Empty(g.Nodes);
        Assert.Empty(g.Edges);
        Assert.Empty(g.Attrs);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Graph_with_one_node()
    {
        var g = new Graph
        {
            new Node("a")
        };

        Assert.Equal([new Node("a")], g.Nodes);
        Assert.Empty(g.Edges);
        Assert.Empty(g.Attrs);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Graph_with_one_node_with_keywords()
    {
        var g = new Graph
        {
            new Node("a") { { "color", "green" } }
        };

        Assert.Equal([new Node("a") { { "color", "green" } }], g.Nodes);
        Assert.Empty(g.Edges);
        Assert.Empty(g.Attrs);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Graph_with_one_edge()
    {
        var g = new Graph
        {
            new Edge("a", "b")
        };

        Assert.Empty(g.Nodes);
        Assert.Equal([new Edge("a", "b")], g.Edges);
        Assert.Empty(g.Attrs);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Graph_with_one_attribute()
    {
        var g = new Graph
        {
            { "foo", "1" }
        };

        Assert.Empty(g.Nodes);
        Assert.Empty(g.Edges);
        Assert.Equal([new Attr("foo", "1")], g.Attrs);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
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

        HashSet<Node> expectedNodes = [new Node("a") { { "color", "green" } }, new Node("b") { { "label", "Beta!" } }, new Node("c")];
        Assert.Equal(expectedNodes, g.Nodes.ToHashSet());
        HashSet<Edge> expectedEdges = [new Edge("a", "b") { { "color", "blue" } }, new Edge("b", "c")];
        Assert.Equal(expectedEdges, g.Edges.ToHashSet());
        HashSet<Attr> expectedAttrs = [new Attr("bar", "true"), new Attr("foo", "1"), new Attr("title", "Testing Attrs")];
        Assert.Equal(expectedAttrs, g.Attrs.ToHashSet());
    }
}
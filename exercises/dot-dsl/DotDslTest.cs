using NUnit.Framework;

public class DotDslTest
{
    [Test]
    public void Empty_graph()
    {
        var g = new Graph();

        Assert.That(g.Nodes, Is.Empty);
        Assert.That(g.Edges, Is.Empty);
        Assert.That(g.Attrs, Is.Empty);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Graph_with_one_node()
    {
        var g = new Graph
        {
            new Node("a")
        };

        Assert.That(g.Nodes, Is.EquivalentTo(new[] { new Node("a") }));
        Assert.That(g.Edges, Is.Empty);
        Assert.That(g.Attrs, Is.Empty);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Graph_with_one_node_with_keywords()
    {
        var g = new Graph
        {
            new Node("a") { { "color", "green" } }
        };

        Assert.That(g.Nodes, Is.EquivalentTo(new[] { new Node("a") { { "color", "green" } } }));
        Assert.That(g.Edges, Is.Empty);
        Assert.That(g.Attrs, Is.Empty);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Graph_with_one_edge()
    {
        var g = new Graph
        {
            new Edge("a", "b")
        };

        Assert.That(g.Nodes, Is.Empty);
        Assert.That(g.Edges, Is.EquivalentTo(new[] { new Edge("a", "b") }));
        Assert.That(g.Attrs, Is.Empty);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Graph_with_one_attribute()
    {
        var g = new Graph
        {
            { "foo", "1" }
        };

        Assert.That(g.Nodes, Is.Empty);
        Assert.That(g.Edges, Is.Empty);
        Assert.That(g.Attrs, Is.EquivalentTo(new[] { new Attr("foo", "1") }));
    }

    [Ignore("Remove to run test")]
    [Test]
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

        Assert.That(g.Nodes, Is.EquivalentTo(new[] { new Node("a") { { "color", "green" } }, new Node("b") { { "label", "Beta!" } }, new Node("c") }));
        Assert.That(g.Edges, Is.EquivalentTo(new[] { new Edge("a", "b") { { "color", "blue" } }, new Edge("b", "c") }));
        Assert.That(g.Attrs, Is.EquivalentTo(new[] { new Attr("bar", "true"), new Attr("foo", "1"), new Attr("title", "Testing Attrs") }));
    }
}
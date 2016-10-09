using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class SgfParsingTest
{
    // This exercises requires you to do somewhat more complicated parsing.
    // This is the perfect exercise to get to know a parser library, of which
    // there are several available. A simple one is Sprache (https://github.com/sprache/Sprache),
    // a more complex one is Antlr (http://www.antlr.org/). You can also build
    // your own parser of course!

    // A tree consists of two parts:
    // - The node's data: a map of type Dictionary<string, string list> 
    // - A list of children (which are itself trees)

    private static SgfTree TreeWithChildren(IDictionary<string, string[]> data, SgfTree[] children) => new SgfTree(data, children);
    private static SgfTree TreeWithSingleChild(IDictionary<string, string[]> data, SgfTree child) => new SgfTree(data, child);
    private static SgfTree TreeWithNoChildren(IDictionary<string, string[]> data) => new SgfTree(data);

    private static IDictionary<string, string[]> CreateData(string key, params string[] values) => new Dictionary<string, string[]> { [key] = values };
    
    [Test]
    public void Empty_value()
    {
        const string input = "";
        Assert.That(() => SgfParser.ParseTree(input), Throws.Exception);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Tree_without_nodes()
    {
        const string input = "()";
        Assert.That(() => SgfParser.ParseTree(input), Throws.Exception);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Node_without_tree()
    {
        const string input = ";";
        Assert.That(() => SgfParser.ParseTree(input), Throws.Exception);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Node_without_properties()
    {
        const string input = "(;)";
        var expected = TreeWithNoChildren(new Dictionary<string, string[]>());
        Assert.That(SgfParser.ParseTree(input), Is.EqualTo(expected).Using(SgfTreeEqualityComparer.Instance));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Single_node_tree()
    {
        const string input = "(;A[B])";
        var expected = TreeWithNoChildren(CreateData("A", "B"));
        Assert.That(SgfParser.ParseTree(input), Is.EqualTo(expected).Using(SgfTreeEqualityComparer.Instance));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Properties_without_delimiter()
    {
        const string input = "(;a)";
        Assert.That(() => SgfParser.ParseTree(input), Throws.Exception);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void All_lowercase_property()
    {
        const string input = "(;a[b])";
        Assert.That(() => SgfParser.ParseTree(input), Throws.Exception);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Upper_and_lowercase_property()
    {
        const string input = "(;Aa[b])";
        Assert.That(() => SgfParser.ParseTree(input), Throws.Exception);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_nodes()
    {
        const string input = "(;A[B];B[C])";
        var expected = TreeWithSingleChild(CreateData("A", "B"), TreeWithNoChildren(CreateData("B", "C")));
        Assert.That(SgfParser.ParseTree(input), Is.EqualTo(expected).Using(SgfTreeEqualityComparer.Instance));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_child_trees()
    {
        const string input = "(;A[B](;B[C])(;C[D]))";
        var expected = TreeWithChildren(CreateData("A", "B"), 
                            new[]
                            {
                                TreeWithNoChildren(CreateData("B", "C")),
                                TreeWithNoChildren(CreateData("C", "D"))
                            });
        Assert.That(SgfParser.ParseTree(input), Is.EqualTo(expected).Using(SgfTreeEqualityComparer.Instance));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Multiple_properties()
    {
        const string input = "(;A[b][c][d])";
        var expected = TreeWithNoChildren(CreateData("A", "b", "c", "d"));
        Assert.That(SgfParser.ParseTree(input), Is.EqualTo(expected).Using(SgfTreeEqualityComparer.Instance));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Escaped_property()
    {
        const string input = @"(;A[\]b\nc\nd\t\te \n\]])";
        var expected = TreeWithNoChildren(CreateData("A", @"]b c d  e  ]"));
        Assert.That(SgfParser.ParseTree(input), Is.EqualTo(expected).Using(SgfTreeEqualityComparer.Instance));
    }

    private class SgfTreeEqualityComparer : IEqualityComparer<SgfTree>
    {
        public static readonly SgfTreeEqualityComparer Instance = new SgfTreeEqualityComparer();

        public bool Equals(SgfTree x, SgfTree y)
        {
            return SgfDataEqualityComparer.Instance.Equals(x.Data, y.Data) && x.Children.SequenceEqual(y.Children, Instance);
        }

        public int GetHashCode(SgfTree obj)
        {
            throw new System.NotImplementedException();
        }
    }

    private class SgfDataEqualityComparer : IEqualityComparer<IDictionary<string, string[]>>
    {
        public static readonly SgfDataEqualityComparer Instance = new SgfDataEqualityComparer();

        public bool Equals(IDictionary<string, string[]> x, IDictionary<string, string[]> y)
        {
            return x.Keys.SequenceEqual(y.Keys) && x.Keys.All(key => x[key].SequenceEqual(y[key]));
        }

        public int GetHashCode(IDictionary<string, string[]> obj)
        {
            throw new System.NotImplementedException();
        }
    }
}

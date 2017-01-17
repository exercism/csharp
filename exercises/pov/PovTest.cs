using NUnit.Framework;
using System.Linq;

public class PovTest
{
    private const string x = "x";

    private static Graph<T> leaf<T>(T v) => Pov.CreateGraph(v, new Graph<T>[0]);

    private static readonly Graph<string> singleton = Pov.CreateGraph(x, new Graph<string>[0]);

    private static readonly Graph<string> flat = Pov.CreateGraph("root", new[] { "a", "b", x, "c" }.Select(leaf));

    private static readonly Graph<string> nested =
        Pov.CreateGraph("level-0", new[] {
            Pov.CreateGraph("level-1", new[] {
                Pov.CreateGraph("level-2", new[] {
                    Pov.CreateGraph("level-3", new[] {
                        Pov.CreateGraph(x, new Graph<string>[0])
                    })
                })
            })
        });

    private static readonly Graph<string> kids =
        Pov.CreateGraph("root", new[] {
            Pov.CreateGraph(x, new[] {
                Pov.CreateGraph("kid-0", new Graph<string>[0]),
                Pov.CreateGraph("kid-1", new Graph<string>[0])
            })
        });

    private static readonly Graph<string> cousins =
        Pov.CreateGraph("grandparent", new[] {
            Pov.CreateGraph("parent", new [] {
                Pov.CreateGraph(x, new [] {
                    leaf("kid-a"),
                    leaf("kid-b")
                }),
                leaf("sibling-0"),
                leaf("sibling-1")
            }),
            Pov.CreateGraph("uncle", new [] {
                leaf("cousin-0"),
                leaf("cousin-1")
            })
        });

    private static readonly Graph<string> singleton_ = singleton;

    private static readonly Graph<string> flat_ = 
        Pov.CreateGraph(x, new[] {
            Pov.CreateGraph("root", new [] { "a", "b", "c" }.Select(leaf))
        });

    private static readonly Graph<string> nested_ = 
        Pov.CreateGraph(x, new[] {
            Pov.CreateGraph("level-3", new [] {
                Pov.CreateGraph("level-2", new [] {
                    Pov.CreateGraph("level-1", new [] {
                        Pov.CreateGraph("level-0", new Graph<string>[0])
                    })
                })
            })
        });

    private static readonly Graph<string> kids_ = 
        Pov.CreateGraph(x, new[] {
            Pov.CreateGraph("kid-0", new Graph<string>[0]),
            Pov.CreateGraph("kid-1", new Graph<string>[0]),
            Pov.CreateGraph("root", new Graph<string>[0])
        });

    private static readonly Graph<string> cousins_ = 
        Pov.CreateGraph(x, new[] {
            leaf("kid-a"),
            leaf("kid-b"),
            Pov.CreateGraph("parent", new [] {
                Pov.CreateGraph("sibling-0", new Graph<string>[0]),
                Pov.CreateGraph("sibling-1", new Graph<string>[0]),
                Pov.CreateGraph("grandparent", new [] {
                    Pov.CreateGraph("uncle", new [] {
                        Pov.CreateGraph("cousin-0", new Graph<string>[0]),
                        Pov.CreateGraph("cousin-1", new Graph<string>[0])
                    })
                })
            })
        });

    [Test]
    public void Reparent_singleton()
    {
        Assert.That(Pov.FromPOV(x, singleton), Is.EqualTo(singleton_));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Reparent_flat()
    {
        Assert.That(Pov.FromPOV(x, flat), Is.EqualTo(flat_));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Reparent_nested()
    {
        Assert.That(Pov.FromPOV(x, nested), Is.EqualTo(nested_));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Reparent_kids()
    {
        Assert.That(Pov.FromPOV(x, kids), Is.EqualTo(kids_));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Reparent_cousins()
    {
        Assert.That(Pov.FromPOV(x, cousins), Is.EqualTo(cousins_));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Reparent_from_POV_of_non_existent_node()
    {
        Assert.That(Pov.FromPOV(x, leaf("foo")), Is.Null);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Should_not_be_able_to_find_a_missing_node()
    {
        var nodes = new[] { singleton, flat, kids, nested, cousins }.Select(graph => Pov.FromPOV("NOT THERE", graph));
    
        Assert.That(nodes, Is.All.Null);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Cannot_trace_between_unconnected_nodes()
    {
        Assert.That(Pov.TracePathBetween(x, "NOT THERE", cousins), Is.Null);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_trace_a_path_from_x_to_cousin()
    {
        Assert.That(Pov.TracePathBetween(x, "cousin-1", cousins), Is.EquivalentTo(new[] { "x", "parent", "grandparent", "uncle", "cousin-1" }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Can_trace_from_a_leaf_to_a_leaf()
    {
        Assert.That(Pov.TracePathBetween("kid-a", "cousin-0", cousins), Is.EquivalentTo(new[] { "kid-a", "x", "parent", "grandparent", "uncle", "cousin-0" }));
    }
}
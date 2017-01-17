using System;
using System.Collections.Generic;
using System.Linq;

public class Graph<T> : IEquatable<Graph<T>>
{
    public Graph(T value, IEnumerable<Graph<T>> children)
    {
        Value = value;
        Children = children;
    }

    public T Value { get; }
    public IEnumerable<Graph<T>> Children { get; }

    public bool Equals(Graph<T> other) =>
        Value.Equals(other.Value) && Children.SequenceEqual(other.Children);
}

public class Crumb<T>
{
    public Crumb(T value, IEnumerable<Graph<T>> left, IEnumerable<Graph<T>> right)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public T Value { get; }
    public IEnumerable<Graph<T>> Left { get; }
    public IEnumerable<Graph<T>> Right { get; }
}

public class Zipper<T>
{
    public Zipper(Graph<T> focus, IEnumerable<Crumb<T>> crumbs)
    {
        Focus = focus;
        Crumbs = crumbs;
    }

    public Graph<T> Focus { get; }
    public IEnumerable<Crumb<T>> Crumbs { get; }
}

public static class Pov
{
    public static Graph<T> CreateGraph<T>(T value, IEnumerable<Graph<T>> children) 
        => new Graph<T>(value, children);

    public static Graph<T> FromPOV<T>(T value, Graph<T> graph) where T : IComparable 
        => ChangeParent(FindNode(value, GraphToZipper(graph)));

    public static IEnumerable<T> TracePathBetween<T>(T value1, T value2, Graph<T> graph) where T : IComparable
        => ZipperToPath(FindNode(value2, GraphToZipper(FromPOV(value1, graph))));

    private static Zipper<T> GraphToZipper<T>(Graph<T> graph)
    {
        if (graph == null)
            return null;

        return new Zipper<T>(graph, Enumerable.Empty<Crumb<T>>());
    }

    private static IEnumerable<T> ZipperToPath<T>(Zipper<T> zipper)
    {
        if (zipper == null)
            return null;

        return zipper.Crumbs.Select(c => c.Value).Reverse().Concat(new[] { zipper.Focus.Value });
    }

    private static Zipper<T> GoDown<T>(Zipper<T> zipper)
    {        
        if (zipper == null || !zipper.Focus.Children.Any())
            return null;

        var focus = zipper.Focus;
        var children = focus.Children;

        var newCrumb = new Crumb<T>(focus.Value, Enumerable.Empty<Graph<T>>(), children.Skip(1));

        return new Zipper<T>(children.First(), new[] { newCrumb }.Concat(zipper.Crumbs));
    }

    private static Zipper<T> GoRight<T>(Zipper<T> zipper)
    {        
        if (zipper == null || !zipper.Crumbs.Any() || !zipper.Crumbs.First().Right.Any())
            return null;

        var crumbs = zipper.Crumbs;
        var firstCrumb = crumbs.First();

        var newCrumb = new Crumb<T>(firstCrumb.Value, firstCrumb.Left.Concat(new[] { zipper.Focus }), firstCrumb.Right.Skip(1));

        return new Zipper<T>(firstCrumb.Right.First(), new[] { newCrumb }.Concat(crumbs.Skip(1)));
    }

    private static Zipper<T> FindNode<T>(T value, Zipper<T> zipper)
        where T : IComparable
    {
        if (zipper == null || zipper.Focus.Value.CompareTo(value) == 0)
            return zipper;

        return FindNode(value, GoDown(zipper)) ?? FindNode(value, GoRight(zipper));
    }

    private static Graph<T> ChangeParent<T>(Zipper<T> zipper)
    {
        if (zipper == null)
            return null;

        if (!zipper.Crumbs.Any())
            return zipper.Focus;

        var firstCrumb = zipper.Crumbs.First();
        var focus = zipper.Focus;

        var newZipper = new Zipper<T>(CreateGraph(firstCrumb.Value, firstCrumb.Left.Concat(firstCrumb.Right)), zipper.Crumbs.Skip(1));
        var parentGraph = ChangeParent(newZipper);

        var ys = focus.Children.Concat(new[] { parentGraph });
        return CreateGraph(focus.Value, ys);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Tree : IEquatable<Tree>
{
    public Tree(string value, params Tree[] children)
        => (Value, Children) = (value, children);

    public string Value { get; }
    public Tree[] Children { get; }

    public bool Equals(Tree other) 
        => Value.Equals(other.Value) && 
            Children.OrderBy(child => child.Value).SequenceEqual(other.Children.OrderBy(child => child.Value));
}

public class TreeCrumb
{
    public TreeCrumb(string value, IEnumerable<Tree> left, IEnumerable<Tree> right)
        => (Value, Left, Right) = (value, left, right);

    public string Value { get; }
    public IEnumerable<Tree> Left { get; }
    public IEnumerable<Tree> Right { get; }
}

public class TreeZipper
{
    public TreeZipper(Tree focus, IEnumerable<TreeCrumb> crumbs)
        => (Focus, Crumbs) = (focus, crumbs);

    public Tree Focus { get; }
    public IEnumerable<TreeCrumb> Crumbs { get; }
}

public static class Pov
{
    public static Tree FromPov(Tree graph, string value)
    {
        var zipper = FindNode(value, GraphToZipper(graph));
        if (zipper == null)
            throw new ArgumentException();
        
        return ChangeParent(zipper);
    }

    public static IEnumerable<string> PathTo(string value1, string value2, Tree graph)
    {
        var zipper = FindNode(value2, GraphToZipper(FromPov(graph, value1)));
        if (zipper == null)
            throw new ArgumentException();

        return ZipperToPath(zipper);
    }

    private static TreeZipper GraphToZipper(Tree graph)
    {
        if (graph == null)
            return null;

        return new TreeZipper(graph, Enumerable.Empty<TreeCrumb>());
    }

    private static IEnumerable<string> ZipperToPath(TreeZipper zipper)
    {
        return zipper?.Crumbs.Select(c => c.Value).Reverse().Concat(new[] { zipper.Focus.Value });
    }

    private static TreeZipper GoDown(TreeZipper zipper)
    {        
        if (zipper == null || !zipper.Focus.Children.Any())
            return null;

        var focus = zipper.Focus;
        var children = focus.Children;

        var newCrumb = new TreeCrumb(focus.Value, Array.Empty<Tree>(), children.Skip(1).ToArray());

        return new TreeZipper(children.First(), new[] { newCrumb }.Concat(zipper.Crumbs));
    }

    private static TreeZipper GoRight(TreeZipper zipper)
    {        
        if (zipper == null || !zipper.Crumbs.Any() || !zipper.Crumbs.First().Right.Any())
            return null;

        var crumbs = zipper.Crumbs;
        var firstCrumb = crumbs.First();

        var newCrumb = new TreeCrumb(firstCrumb.Value, firstCrumb.Left.Concat(new[] { zipper.Focus }).ToArray(), firstCrumb.Right.Skip(1).ToArray());

        return new TreeZipper(firstCrumb.Right.First(), new[] { newCrumb }.Concat(crumbs.Skip(1)));
    }

    private static TreeZipper FindNode(string value, TreeZipper zipper)
    {
        if (zipper == null || zipper.Focus.Value.CompareTo(value) == 0)
            return zipper;

        return FindNode(value, GoDown(zipper)) ?? FindNode(value, GoRight(zipper));
    }

    private static Tree ChangeParent(TreeZipper zipper)
    {
        if (zipper == null)
            return null;

        if (!zipper.Crumbs.Any())
            return zipper.Focus;

        var firstCrumb = zipper.Crumbs.First();
        var focus = zipper.Focus;

        var newZipper = new TreeZipper(new Tree(firstCrumb.Value, firstCrumb.Left.Concat(firstCrumb.Right).ToArray()), zipper.Crumbs.Skip(1));
        var parentGraph = ChangeParent(newZipper);

        var ys = focus.Children.Concat(new[] { parentGraph }).ToArray();
        return new Tree(focus.Value, ys);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class BinTree : IEquatable<BinTree>
{
    public BinTree(int value, BinTree left, BinTree right)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public BinTree(BinTree tree) : this(tree.Value, tree.Left, tree.Right)
    {
    }

    public int Value { get; }
    public BinTree Left { get; }
    public BinTree Right { get; }

    public bool Equals(BinTree other)
    {
        if (other == null || !Equals(Value, other.Value))
            return false;

        if (!ReferenceEquals(Left, other.Left) && (!Left?.Equals(other.Left) ?? false))
            return false;

        if (!ReferenceEquals(Right, other.Right) && (!Right?.Equals(other.Right) ?? false))
            return false;

        return true;
    }
}

public abstract class BinTreeCrumb
{
    public BinTreeCrumb(int value, BinTree tree)
    {
        Value = value;
        Tree = tree;
    }

    public int Value { get; }
    public BinTree Tree { get; }
}

public class BinTreeLeftCrumb : BinTreeCrumb
{
    public BinTreeLeftCrumb(int value, BinTree tree) : base(value, tree)
    {
    }
}

public class BinTreeRightCrumb : BinTreeCrumb
{
    public BinTreeRightCrumb(int value, BinTree tree) : base(value, tree)
    {
    }
}

public class Zipper : IEquatable<Zipper>
{
    private readonly int value;
    private readonly BinTree left;
    private readonly BinTree right;
    private readonly List<BinTreeCrumb> crumbs;

    public Zipper(int value, BinTree left, BinTree right, List<BinTreeCrumb> crumbs)
    {
        this.value = value;
        this.left = left;
        this.right = right;
        this.crumbs = crumbs;
    }
    
    public int Value() => value;

    public Zipper SetValue(int newValue) => new Zipper(newValue, left, right, crumbs);

    public Zipper SetLeft(BinTree binTree) => new Zipper(value, binTree, right, crumbs);

    public Zipper SetRight(BinTree binTree) => new Zipper(value, left, binTree, crumbs);

    public Zipper Left()
    {
        if (left == null)
            return null;
        
        var newCrumbs = new[] { new BinTreeLeftCrumb(value, right) }.Concat(crumbs).ToList();
        return new Zipper(left.Value, left.Left, left.Right, newCrumbs);
    }

    public Zipper Right()
    {
        if (right == null)
            return null;

        var newCrumbs = new[] { new BinTreeRightCrumb(value, left) }.Concat(crumbs).ToList();
        return new Zipper(right.Value, right.Left, right.Right, newCrumbs);
    }

    public Zipper Up()
    {
        if (crumbs.Count == 0)
            return null;

        var firstCrumb = crumbs[0];
        var remainingCrumbs = crumbs.Skip(1).ToList();
        
        if (firstCrumb is BinTreeLeftCrumb)
            return new Zipper(firstCrumb.Value, new BinTree(value, left, right), firstCrumb.Tree, remainingCrumbs);
        
        if (firstCrumb is BinTreeRightCrumb)
            return new Zipper(firstCrumb.Value, firstCrumb.Tree, new BinTree(value, left, right), remainingCrumbs);
        
        return null;
    }

    public BinTree ToTree()
    {
        var tree = new BinTree(value, left, right);

        foreach (var crumb in crumbs)
        {
            if (crumb is BinTreeLeftCrumb)
                tree = new BinTree(crumb.Value, new BinTree(tree), crumb.Tree);
            if (crumb is BinTreeRightCrumb)
                tree = new BinTree(crumb.Value, crumb.Tree, new BinTree(tree));
        }

        return tree;
    }

    public bool Equals(Zipper other)
    {
        if (other == null)
            return false;

        return ToTree().Equals(other.ToTree());
    }

    public static Zipper FromTree(BinTree tree) => new Zipper(tree.Value, tree.Left, tree.Right, new List<BinTreeCrumb>());
}
using System;
using System.Collections.Generic;
using System.Linq;

public class BinTree<T> : IEquatable<BinTree<T>>
{
    public BinTree(T value, BinTree<T> left, BinTree<T> right)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public BinTree(BinTree<T> tree) : this(tree.Value, tree.Left, tree.Right)
    {
    }

    public T Value { get; }
    public BinTree<T> Left { get; }
    public BinTree<T> Right { get; }

    public bool Equals(BinTree<T> other)
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

public abstract class BinTreeCrumb<T>
{
    public BinTreeCrumb(T value, BinTree<T> tree)
    {
        Value = value;
        Tree = tree;
    }

    public T Value { get; }
    public BinTree<T> Tree { get; }
}

public class BinTreeLeftCrumb<T> : BinTreeCrumb<T>
{
    public BinTreeLeftCrumb(T value, BinTree<T> tree) : base(value, tree)
    {
    }
}

public class BinTreeRightCrumb<T> : BinTreeCrumb<T>
{
    public BinTreeRightCrumb(T value, BinTree<T> tree) : base(value, tree)
    {
    }
}

public class Zipper<T>
{
    private readonly T value;
    private readonly BinTree<T> left;
    private readonly BinTree<T> right;
    private readonly List<BinTreeCrumb<T>> crumbs;

    public Zipper(T value, BinTree<T> left, BinTree<T> right, List<BinTreeCrumb<T>> crumbs)
    {
        this.value = value;
        this.left = left;
        this.right = right;
        this.crumbs = crumbs;
    }
    
    public T Value => value;

    public Zipper<T> SetValue(T newValue) => new Zipper<T>(newValue, left, right, crumbs);

    public Zipper<T> SetLeft(BinTree<T> binTree) => new Zipper<T>(value, binTree, right, crumbs);

    public Zipper<T> SetRight(BinTree<T> binTree) => new Zipper<T>(value, left, binTree, crumbs);

    public Zipper<T> Left()
    {
        if (left == null)
            return null;
        
        var newCrumbs = new[] { new BinTreeLeftCrumb<T>(value, right) }.Concat(crumbs).ToList();
        return new Zipper<T>(left.Value, left.Left, left.Right, newCrumbs);
    }

    public Zipper<T> Right()
    {
        if (right == null)
            return null;

        var newCrumbs = new[] { new BinTreeRightCrumb<T>(value, left) }.Concat(crumbs).ToList();
        return new Zipper<T>(right.Value, right.Left, right.Right, newCrumbs);
    }

    public Zipper<T> Up()
    {
        if (crumbs.Count == 0)
            return null;

        var firstCrumb = crumbs[0];
        var remainingCrumbs = crumbs.Skip(1).ToList();
        
        if (firstCrumb is BinTreeLeftCrumb<T>)
            return new Zipper<T>(firstCrumb.Value, new BinTree<T>(value, left, right), firstCrumb.Tree, remainingCrumbs);
        
        if (firstCrumb is BinTreeRightCrumb<T>)
            return new Zipper<T>(firstCrumb.Value, firstCrumb.Tree, new BinTree<T>(value, left, right), remainingCrumbs);
        
        return null;
    }

    public BinTree<T> ToTree()
    {
        var tree = new BinTree<T>(value, left, right);

        foreach (var crumb in crumbs)
        {
            if (crumb is BinTreeLeftCrumb<T>)
                tree = new BinTree<T>(crumb.Value, new BinTree<T>(tree), crumb.Tree);
            if (crumb is BinTreeRightCrumb<T>)
                tree = new BinTree<T>(crumb.Value, crumb.Tree, new BinTree<T>(tree));
        }

        return tree;
    }

    public static Zipper<T> FromTree(BinTree<T> tree) => new Zipper<T>(tree.Value, tree.Left, tree.Right, new List<BinTreeCrumb<T>>());
}
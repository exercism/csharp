using System;

public class BinTree<T>
{
    public BinTree(T value, BinTree<T> left, BinTree<T> right)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public T Value { get; }
    public BinTree<T> Left { get; }
    public BinTree<T> Right { get; }
}

public class Zipper<T>
{   
    public T Value
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public Zipper<T> SetValue(T newValue)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Zipper<T> SetLeft(BinTree<T> binTree)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Zipper<T> SetRight(BinTree<T> binTree) 
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Zipper<T> Left()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Zipper<T> Right()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Zipper<T> Up()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public BinTree<T> ToTree()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static Zipper<T> FromTree(BinTree<T> tree)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
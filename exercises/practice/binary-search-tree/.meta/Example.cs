using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value)
    {
        Value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        var array = values.ToArray();

        if (array.Length == 0)
        {
            throw new ArgumentException("Cannot create tree from empty list");
        }

        Value = array[0];

        foreach (var value in array.Skip(1))
        {
            Add(value);
        }
    }

    public int Value { get; }

    public BinarySearchTree Left { get; private set; }

    public BinarySearchTree Right { get; private set; }

    public BinarySearchTree Add(int value)
    {
        if (value <= Value)
        {
            Left = Add(value, Left);
        }
        else
        {
            Right = Add(value, Right);
        }

        return this;
    }

    private static BinarySearchTree Add(int value, BinarySearchTree tree)
    {
        if (tree == null)
        {
            return new BinarySearchTree(value);
        }

        return tree.Add(value);
    }

    public IEnumerator<int> GetEnumerator()
    {
        foreach (var left in Left?.AsEnumerable() ?? Enumerable.Empty<int>())
        {
            yield return left;
        }

        yield return Value;

        foreach (var right in Right?.AsEnumerable() ?? Enumerable.Empty<int>())
        {
            yield return right;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
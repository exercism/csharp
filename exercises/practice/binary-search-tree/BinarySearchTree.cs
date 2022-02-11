using System;
using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value)
    {
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
    }

    public int Value
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public BinarySearchTree Left
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public BinarySearchTree Right
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public BinarySearchTree Add(int value)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public IEnumerator<int> GetEnumerator()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
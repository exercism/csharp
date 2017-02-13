using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    public SimpleLinkedList(T value)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public T Value 
    { 
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        } 
    }

    public SimpleLinkedList<T> Next
    { 
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        } 
    }

    public SimpleLinkedList<T> Add(T value)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
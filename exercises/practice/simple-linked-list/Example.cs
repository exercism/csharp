using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    public SimpleLinkedList(T value) :
        this(new[] { value })
    {
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        var array = values.ToArray();

        if (array.Length == 0)
        {
            throw new ArgumentException("Cannot create tree from empty list");
        }

        Value = array[0];
        Next = null;

        foreach (var value in array.Skip(1))
        {
            Add(value);
        }
    }

    public T Value { get; }

    public SimpleLinkedList<T> Next { get; private set; }

    public SimpleLinkedList<T> Add(T value)
    {
        var last = this;

        while (last.Next != null)
        {
            last = last.Next;
        }

        last.Next = new SimpleLinkedList<T>(value);

        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        yield return Value;

        foreach (var next in Next?.AsEnumerable() ?? Enumerable.Empty<T>())
        {
            yield return next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;

public class CustomSet<T> : IEnumerable<T>, IEquatable<IEnumerable<T>>
{
    public CustomSet()
    {
    }

    public CustomSet(T value)
    {
    }

    public CustomSet(IEnumerable<T> values)
    {
    }

    public CustomSet<T> Insert(T value)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public bool IsEmpty()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public bool Contains(T value)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public bool IsSubsetOf(CustomSet<T> right)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public bool IsDisjointFrom(CustomSet<T> right)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public CustomSet<T> Intersection(CustomSet<T> right)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public CustomSet<T> Difference(CustomSet<T> right)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public CustomSet<T> Union(CustomSet<T> right)
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
    
    public override bool Equals(object obj)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public override int GetHashCode() 
    {
        throw new NotImplementedException();
    }

    public bool Equals(IEnumerable<T> other)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public int GetHashCode(IEnumerable<T> obj)
    {
        throw new NotImplementedException();
    }
}
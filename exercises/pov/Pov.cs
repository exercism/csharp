using System;
using System.Collections.Generic;

public class Graph<T>
{
    public Graph(T value, IEnumerable<Graph<T>> children)
    {
    }

    public T Value
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public IEnumerable<Graph<T>> Children
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }
}

public static class Pov
{
    public static Graph<T> CreateGraph<T>(T value, IEnumerable<Graph<T>> children) 
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static Graph<T> FromPOV<T>(T value, Graph<T> graph) where T : IComparable
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static IEnumerable<T> TracePathBetween<T>(T value1, T value2, Graph<T> graph) where T : IComparable
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
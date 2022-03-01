using System.Collections;
using System.Collections.Generic;

public class Node : Element
{
    public Node(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return ((Node)obj).Name == Name;
    }

    public override int GetHashCode() => Name.GetHashCode();
}

public class Edge : Element
{
    public Edge(string node1, string node2)
    {
        Node1 = node1;
        Node2 = node2;
    }

    public string Node1 { get; }
    public string Node2 { get; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return ((Edge)obj).Node1 == Node1 && ((Edge)obj).Node2 == Node2;
    }

    public override int GetHashCode() => Node1.GetHashCode() ^ Node2.GetHashCode();
}


public class Attr
{
    public Attr(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; }
    public string Value { get; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return ((Attr)obj).Key == Key && ((Attr)obj).Value == Value;
    }

    public override int GetHashCode() => Key.GetHashCode() ^ Value.GetHashCode();
}

public class Graph : Element
{
    private List<Node> nodes = new List<Node>();
    private List<Edge> edges = new List<Edge>();

    public IEnumerable<Node> Nodes => nodes;
    public IEnumerable<Edge> Edges => edges;
    public IEnumerable<Attr> Attrs => attrs;

    public void Add(Node node) => nodes.Add(node);
    public void Add(Edge edge) => edges.Add(edge);
}

public abstract class Element : IEnumerable<Attr>
{
    protected List<Attr> attrs = new List<Attr>();

    public void Add(string key, string value) => attrs.Add(new Attr(key, value));

    public IEnumerator<Attr> GetEnumerator() => attrs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
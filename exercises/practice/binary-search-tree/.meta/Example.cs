using System;

public class BinarySearchTree<T> where T : IComparable
{
    class Node
    {
        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    Node head;
    
    public int Count { get; private set; }
    public int Depth { get; private set; }

    public void Add(T value)
    {
        Count++;

        var depth = 1;
        
        if (head == null) {
            head = new Node { Value = value };
            Depth = 1;
            return;
        }

        var node = head;
        while(node.Value.CompareTo(value) != 0)
        {
            depth++;
            if (node.Value.CompareTo(value) < 0) 
            {
                node.Left ??= new Node { Value = value };
                node = node.Left;
            } else { 
                node.Right ??= new Node { Value = value };
                node = node.Right;
            }
        }
        Depth = depth;
    }

    public bool Contains(T value)
    {
        var node = head;
        while(node != null) 
        {
            if (node.Value.CompareTo(value) == 0) { return true; }

            if (node.Value.CompareTo(value) < 0) { node = node.Left; }
            else { node = node.Right; }
        }
        return false;
    }
}
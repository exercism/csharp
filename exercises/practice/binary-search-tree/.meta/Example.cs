using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class BinarySearchTree<T> where T : IComparable
{
    class Node
    {
        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public static object ToData(Node node)
        {
            if (node == null) return null;

            return new
            {
                data = node.Value,
                left = Node.ToData(node.Left),
                right = Node.ToData(node.Right)
            };
        }

        public IEnumerable<T> GetOrderedValues()
        {
            if (Left != null)
            {
                foreach(var value in Left.GetOrderedValues())
                {
                    yield return value;
                }
            }
            yield return Value;
            if (Right != null)
            {
                foreach(var value in Right.GetOrderedValues())
                {
                    yield return value;
                }
            }
        }
    }

    Node head;

    public int Count { get; private set; }

    public void Add(T value)
    {
        Count++;

        if (head == null) {
            head = new Node { Value = value };
            return;
        }

        var node = head;

        while(true)
        {
            if (node.Value.CompareTo(value) >= 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node { Value = value };
                    break;
                }
                node = node.Left;
            } else {
                if (node.Right == null)
                {
                    node.Right = new Node { Value = value };
                    break;
                }
                node = node.Right;
            }
        }
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

    public string ToJson()
    {
        if (head == null) return null;

        var settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
        };

        var data = Node.ToData(head);

        return JsonConvert.SerializeObject(data, settings);
    }

    public IEnumerable<T> GetOrderedValues()
    {
        if (head == null) return new T[0];
        return head.GetOrderedValues();
    }
}
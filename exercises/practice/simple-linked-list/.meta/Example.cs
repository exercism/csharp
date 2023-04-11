using System;
using System.Collections;
using System.Collections.Generic;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private class Node { 
        public T Value { get; set; }
        public Node Next { get; set; }
    }
    
    private Node head;

    public SimpleLinkedList() { }

    public SimpleLinkedList(params T[] values)
    {
        foreach(var value in values) { 
            Push(value);
        }
    }

    public int Count { get; private set; } = 0;
    
    public void Push(T value)
    {
        var node = new Node { Value = value, Next = this.head };
        this.head = node;
        this.Count++;
    }

    public T Pop()
    {
        if (this.head == null) { 
            throw new InvalidOperationException("List is empty!");
        }
        var value = head.Value;
        head = head.Next;
        this.Count--;
        return value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = this.head;
        while(current != null) { 
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
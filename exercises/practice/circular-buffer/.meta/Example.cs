using System;
using System.Collections.Generic;
using System.Linq;

public class CircularBuffer<T>
{
    private readonly int capacity;
    private List<T> items;

    public CircularBuffer(int capacity)
    {
        this.capacity = capacity;
        items = new List<T>(capacity);
    }

    public T Read()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Cannot read from empty buffer");
        }

        var value = items[0];

        DequeueHead();

        return value;
    }

    public void Write(T value)
    {
        if (items.Count == capacity)
        {
            throw new InvalidOperationException("Cannot write to full buffer");
        }

        items.Add(value);
    }

    public void Overwrite(T value)
    {
        if (items.Count == capacity)
        {
            DequeueHead();
        }

        Write(value);
    }

    public void Clear() => items.Clear();

    private void DequeueHead() => items = items.Skip(1).ToList();
}
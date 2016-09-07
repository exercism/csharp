using System;
using System.Collections.Generic;
using System.Linq;

public class CircularBuffer<T>
{
    private readonly int size;
    private List<T> items;

    public CircularBuffer(int size)
    {
        this.size = size;
        items = new List<T>(size);
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
        if (items.Count == size)
        {
            throw new InvalidOperationException("Cannot write to full buffer");
        }

        items.Add(value);
    }

    public void ForceWrite(T value)
    {
        if (items.Count == size)
        {
            DequeueHead();
        }

        Write(value);
    }

    public void Clear() => items.Clear();

    private void DequeueHead() => items = items.Skip(1).ToList();
}
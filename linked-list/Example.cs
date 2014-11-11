public class Deque<T>
{
    private Element head;

    public void Push(T value)
    {
        if (head == null)
        {
            head = new Element(value);
        }
        else
        {
            var last = head.Next;
            var e = new Element(value, last, head);
            last.Prev = e;
            head.Next = e;
        }
    }

    public T Pop()
    {
        head = head.Next;
        return Shift();
    }

    public void Unshift(T value)
    {
        Push(value);
        head = head.Next;
    }

    public T Shift()
    {
        var value = head.Value;
        var last = head.Next;

        if (last == head)
            head = null;
        else
        {
            last.Prev = head.Prev;
            head.Prev.Next = last;
            head = head.Prev;
        }

        return value;
    }

    private class Element
    {
        public readonly T Value;
        public Element Next;
        public Element Prev;

        public Element(T value, Element next = null, Element prev = null)
        {
            Value = value;
            Next = next ?? this;
            Prev = prev ?? this;
        }
    }
}
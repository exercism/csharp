using System.Collections.Generic;

public class School
{
    public IDictionary<int, IList<string>> Roster { get; private set; }

    public School()
    {
        Roster = new Dictionary<int, IList<string>>();
    }

    public void Add(string student, int grade)
    {
        if (Roster.ContainsKey(grade))
            Roster[grade].Add(student);
        else
            Roster.Add(grade, new SortedList<string> { student });
    }

    public IList<string> Grade(int grade)
    {
        IList<string> students;
        if (Roster.TryGetValue(grade, out students))
            return students;
        return new List<string>(0);
    }
}

public class SortedList<T> : IList<T>
{
    private readonly List<T> list = new List<T>();

    public int IndexOf(T item)
    {
        return list.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        throw new System.NotSupportedException("Insert would ruin sort");
    }

    public void RemoveAt(int index)
    {
        list.RemoveAt(index);
    }

    public T this[int index]
    {
        get { return list[index]; }
        set
        {
            list.RemoveAt(index);
            Add(value);
        }
    }

    public void Add(T item)
    {
        list.Insert(~list.BinarySearch(item), item);
    }

    public void Clear()
    {
        list.Clear();
    }

    public bool Contains(T item)
    {
        return list.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        list.CopyTo(array, arrayIndex);
    }

    public int Count
    {
        get { return list.Count; }
    }

    public bool IsReadOnly
    {
        get { return false; }
    }

    public bool Remove(T item)
    {
        return list.Remove(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return list.GetEnumerator();
    }
}
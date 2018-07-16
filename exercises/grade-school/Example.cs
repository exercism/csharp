using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly Dictionary<int, IList<string>> roster = new Dictionary<int, IList<string>>();
    
    public void Add(string student, int grade)
    {
        if (roster.ContainsKey(grade))
            roster[grade].Add(student);
        else
            roster.Add(grade, new SortedList<string> { student });
    }

   public IEnumerable<string> Roster()
   {
        var students = new List<string>();
        
        foreach (var item in roster.OrderBy(pair => pair.Key))
        {
            foreach (var student in item.Value)
            {
                students.Add(student); 
            }
        }
        return students;
   } 

    public IEnumerable<string> Grade(int grade)
    {
        IList<string> students;
        if (roster.TryGetValue(grade, out students))
            return students.AsEnumerable();
        return Enumerable.Empty<string>();
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
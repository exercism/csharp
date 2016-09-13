using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomSet<T> : IEnumerable<T>
{
    private readonly Dictionary<int, T> items = new Dictionary<int, T>();

    public CustomSet() : this(Enumerable.Empty<T>())
    {
    }

    public CustomSet(T value) : this(new[] { value })
    {
    }

    public CustomSet(IEnumerable<T> values)
    {
        foreach (var value in values.Where(value => !items.ContainsKey(value.GetHashCode())))
        {
            items.Add(value.GetHashCode(), value);
        }
    }

    public CustomSet<T> Insert(T value)
    {
        var newValues = items.Values.ToList();
        newValues.Add(value);

        return new CustomSet<T>(newValues);
    }

    public bool IsEmpty() => items.Count == 0;

    public bool Contains(T value) => items.ContainsKey(value.GetHashCode());

    public bool IsSubsetOf(CustomSet<T> right) => items.Keys.All(key => right.items.ContainsKey(key));

    public bool IsDisjointFrom(CustomSet<T> right) => !items.Keys.Any(key => right.items.ContainsKey(key));

    public CustomSet<T> Intersection(CustomSet<T> right)
    {
        var intersectionKeys = items.Keys.Intersect(right.items.Keys);
        return new CustomSet<T>(GetValuesFromKeys(intersectionKeys));
    }

    public CustomSet<T> Difference(CustomSet<T> right)
    {
        var differenceKeys = items.Keys.Except(right.items.Keys);
        return new CustomSet<T>(GetValuesFromKeys(differenceKeys));
    }

    public CustomSet<T> Union(CustomSet<T> right)
    {
        var values = items.Values.ToList();
        values.AddRange(right.items.Values);

        return new CustomSet<T>(values);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return items.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<T> GetValuesFromKeys(IEnumerable<int> keys) => keys.Select(key => items[key]);
}
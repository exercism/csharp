using System.Collections.Generic;
using System.Linq;

public class CustomSet
{
    private readonly SortedDictionary<int, int> items = new SortedDictionary<int, int>();

    public CustomSet(params int[] values)
    {
        foreach (var value in values.Where(value => !items.ContainsKey(value.GetHashCode())))
        {
            items.Add(value.GetHashCode(), value);
        }
    }

    public CustomSet Add(int value)
    {
        return new CustomSet(items.Values.Append(value).ToArray());
    }

    public bool Empty() => items.Count == 0;

    public bool Contains(int value) => items.ContainsKey(value.GetHashCode());

    public bool Subset(CustomSet right) => items.Keys.All(key => right.items.ContainsKey(key));

    public bool Disjoint(CustomSet right) => !items.Keys.Any(key => right.items.ContainsKey(key));

    public CustomSet Intersection(CustomSet right)
    {
        var intersectionKeys = items.Keys.Intersect(right.items.Keys);
        return new CustomSet(GetValuesFromKeys(intersectionKeys));
    }

    public CustomSet Difference(CustomSet right)
    {
        var differenceKeys = items.Keys.Except(right.items.Keys);
        return new CustomSet(GetValuesFromKeys(differenceKeys));
    }

    public CustomSet Union(CustomSet right)
    {
        return new CustomSet(items.Values.Concat(right.items.Values).ToArray());
    }

    private int[] GetValuesFromKeys(IEnumerable<int> keys) => keys.Select(key => items[key]).ToArray();

    public override bool Equals(object obj)
    {
        if (!(obj is CustomSet other))
        {
            return false;
        }
        
        return items.Keys.SequenceEqual(other.items.Keys);
    }

    public override int GetHashCode()
    {
        return items.GetHashCode();
    }
}
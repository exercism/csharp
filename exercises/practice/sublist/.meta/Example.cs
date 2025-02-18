using System;
using System.Collections.Generic;
using System.Linq;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        if (list1.Count == list2.Count)
        {
            return AreEqual(list1, list2) ? SublistType.Equal : SublistType.Unequal;
        }

        if (list1.Count < list2.Count)
        {
            return IsSublist(list1, list2) ? SublistType.Sublist : SublistType.Unequal;
        }

        return IsSublist(list2, list1) ? SublistType.Superlist : SublistType.Unequal;
    }

    private static bool AreEqual<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        return !list1.Where((t, i) => t.CompareTo(list2[i]) != 0).Any();
    }

    private static bool IsSublist<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        if (list1.Count > list2.Count)
        {
            return false;
        }

        if (list1.Count == 0)
        {
            return true;
        }

        return Enumerable.Range(0, list2.Count - list1.Count + 1).Any(i => AreEqual(list1, list2.GetRange(i, list1.Count)));
    }
}
﻿using System.Collections.Generic;
using System.Linq;
using Xunit;

public class ListOpsTest
{
    private const int Big = 10000;
    private static readonly List<int> BigList = Range(1, Big);
    private static readonly List<int> EmptyList = new List<int>();

    private static List<int> Range(int from, int until) => new List<int>(Enumerable.Range(from, (until - from) + 1));
    private static bool Odd(int x) => x % 2 == 1;

    private static List<T> Cons<T>(T x, List<T> input)
    {
        var list = new List<T>(input);
        list.Insert(0, x);

        return list;
    }

    [Fact]
    public void LengthOfEmptyList()
    {
        Assert.Equal(0, ListOps.Length(EmptyList));
    }

    [Fact(Skip = "Remove to run test")]
    public void LengthOfNonEmptyList()
    {
        Assert.Equal(4, ListOps.Length(Range(1, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void LengthOfLargeList()
    {
        Assert.Equal(Big, ListOps.Length(Range(1, Big)));
    }

    [Fact(Skip = "Remove to run test")]
    public void ReverseOfEmptylist()
    {
        Assert.Equal(EmptyList, ListOps.Reverse(EmptyList));
    }

    [Fact(Skip = "Remove to run test")]
    public void ReverseOfNonEmptyList()
    {
        Assert.Equal(Range(1, 100).OrderByDescending(x => x).ToList(), ListOps.Reverse(Range(1, 100)));
    }

    [Fact(Skip = "Remove to run test")]
    public void MapOfEmptylist()
    {
        Assert.Equal(EmptyList, ListOps.Map(x => x + 1, EmptyList));
    }

    [Fact(Skip = "Remove to run test")]
    public void MapOfNonEmptyList()
    {
        Assert.Equal(new List<int> {2, 4, 6, 8}, ListOps.Map(x => x + 1, new List<int> {1, 3, 5, 7}));
    }

    [Fact(Skip = "Remove to run test")]
    public void FilterOfEmptylist()
    {
        Assert.Equal(EmptyList, ListOps.Filter(x => true, EmptyList));
    }

    [Fact(Skip = "Remove to run test")]
    public void FilterOfNormalList()
    {
        Assert.Equal(new List<int> {1, 3}, ListOps.Filter(Odd, Range(1, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void FoldlOfEmptylist()
    {
        Assert.Equal(0, ListOps.Foldl((acc, x) => acc + x, 0, EmptyList));
    }

    [Fact(Skip = "Remove to run test")]
    public void FoldlOfNonEmptyList()
    {
        Assert.Equal(7, ListOps.Foldl((acc, x) => acc + x, -3, Range(1, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void FoldlOfHugeList()
    {
        Assert.Equal(Big * (Big + 1L) / 2L, ListOps.Foldl((acc, x) => acc + x, 0L, Range(1, Big)));
    }

    [Fact(Skip = "Remove to run test")]
    public void FoldlWithNonCommutativeFunction()
    {
        Assert.Equal(0, ListOps.Foldl((acc, x) => acc - x, 10, Range(1, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void FoldlIsNotJustFoldrFlip()
    {
        Assert.Equal("fdsa", new string(ListOps.Foldl((acc, x) => Cons(x, acc), new List<char>(), "asdf".ToList()).ToArray()));
    }

    [Fact(Skip = "Remove to run test")]
    public void FoldrAsId()
    {
        Assert.Equal(BigList, ListOps.Foldr((x, acc) => Cons(x, acc), EmptyList, Range(1, Big)));
    }

    [Fact(Skip = "Remove to run test")]
    public void FoldrAsAppend()
    {
        Assert.Equal(BigList, ListOps.Foldr((x, acc) => Cons(x, acc), Range(100, Big), Range(1, 99)));
    }

    [Fact(Skip = "Remove to run test")]
    public void AppendOfEmptylists()
    {
        Assert.Equal(EmptyList, ListOps.Append(EmptyList, EmptyList));
    }

    [Fact(Skip = "Remove to run test")]
    public void AppendOfEmptyAndNonEmptyLists()
    {
        Assert.Equal(Range(1, 4), ListOps.Append(EmptyList, Range(1, 4)));
    }

    [Fact(Skip = "Remove to run test")]
    public void AppendOfNonEmptyAndEmptyLists()
    {
        Assert.Equal(Range(1, 4), ListOps.Append(Range(1, 4), EmptyList));
    }

    [Fact(Skip = "Remove to run test")]
    public void AppendOfNonEmptylists()
    {
        Assert.Equal(Range(1, 5), ListOps.Append(Range(1, 3), new List<int> {4, 5}));
    }

    [Fact(Skip = "Remove to run test")]
    public void AppendOfLargeLists()
    {
        Assert.Equal(BigList, ListOps.Append(Range(1, Big / 2), Range(1 + Big / 2, Big)));
    }

    [Fact(Skip = "Remove to run test")]
    public void ConcatOfNoLists()
    {
        Assert.Equal(EmptyList, ListOps.Concat(new List<List<int>>()));
    }

    [Fact(Skip = "Remove to run test")]
    public void ConcatOfListOfLists()
    {
        Assert.Equal(Range(1, 6),
            ListOps.Concat(new List<List<int>>
            {
                new List<int> {1, 2},
                new List<int> {3},
                EmptyList,
                new List<int> {4, 5, 6}
            }));
    }

    [Fact(Skip = "Remove to run test")]
    public void ConcatOfLargeListOfSmallLists()
    {
        Assert.Equal(BigList, ListOps.Concat(ListOps.Map(x => new List<int> {x}, Range(1, Big))));
    }
}
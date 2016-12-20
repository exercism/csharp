using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

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

    [Test]
    public void LengthOfEmptyList()
    {
        Assert.That(ListOps.Length(EmptyList), Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void LengthOfNonEmptyList()
    {
        Assert.That(ListOps.Length(Range(1, 4)), Is.EqualTo(4));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void LengthOfLargeList()
    {
        Assert.That(ListOps.Length(Range(1, Big)), Is.EqualTo(Big));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void ReverseOfEmptylist()
    {
        Assert.That(ListOps.Reverse(EmptyList), Is.EquivalentTo(EmptyList));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void ReverseOfNonEmptyList()
    {
        Assert.That(ListOps.Reverse(Range(1, 100)), Is.EquivalentTo(Range(1, 100).OrderByDescending(x => x).ToList()));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void MapOfEmptylist()
    {
        Assert.That(ListOps.Map(x => x + 1, EmptyList), Is.EquivalentTo(EmptyList));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void MapOfNonEmptyList()
    {
        Assert.That(ListOps.Map(x => x + 1, new List<int> {1, 3, 5, 7}), Is.EquivalentTo(new List<int> {2, 4, 6, 8}));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void FilterOfEmptylist()
    {
        Assert.That(ListOps.Filter(x => true, EmptyList), Is.EquivalentTo(EmptyList));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void FilterOfNormalList()
    {
        Assert.That(ListOps.Filter(Odd, Range(1, 4)), Is.EquivalentTo(new List<int> {1, 3}));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void FoldlOfEmptylist()
    {
        Assert.That(ListOps.Foldl((acc, x) => acc + x, 0, EmptyList), Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void FoldlOfNonEmptyList()
    {
        Assert.That(ListOps.Foldl((acc, x) => acc + x, -3, Range(1, 4)), Is.EqualTo(7));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void FoldlOfHugeList()
    {
        Assert.That(ListOps.Foldl((acc, x) => acc + x, 0L, Range(1, Big)), Is.EqualTo(Big * (Big + 1L) / 2L));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void FoldlWithNonCommutativeFunction()
    {
        Assert.That(ListOps.Foldl((acc, x) => acc - x, 10, Range(1, 4)), Is.EqualTo(0));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void FoldlIsNotJustFoldrFlip()
    {
        Assert.That(ListOps.Foldl((acc, x) => Cons(x, acc), EmptyList, "asdf".ToList()), Is.EqualTo("fdsa".ToList()));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void FoldrAsId()
    {
        Assert.That(ListOps.Foldr((x, acc) => Cons(x, acc), EmptyList, Range(1, Big)), Is.EquivalentTo(BigList));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void FoldrAsAppend()
    {
        Assert.That(ListOps.Foldr((x, acc) => Cons(x, acc), Range(100, Big), Range(1, 99)), Is.EquivalentTo(BigList));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void AppendOfEmptylists()
    {
        Assert.That(ListOps.Append(EmptyList, EmptyList), Is.EqualTo(EmptyList));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void AppendOfEmptyAndNonEmptyLists()
    {
        Assert.That(ListOps.Append(EmptyList, Range(1, 4)), Is.EqualTo(Range(1, 4)));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void AppendOfNonEmptyAndEmptyLists()
    {
        Assert.That(ListOps.Append(Range(1, 4), EmptyList), Is.EqualTo(Range(1, 4)));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void AppendOfNonEmptylists()
    {
        Assert.That(ListOps.Append(Range(1, 3), new List<int> {4, 5}), Is.EqualTo(Range(1, 5)));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void AppendOfLargeLists()
    {
        Assert.That(ListOps.Append(Range(1, Big / 2), Range(1 + Big / 2, Big)), Is.EquivalentTo(BigList));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void ConcatOfNoLists()
    {
        Assert.That(ListOps.Concat(new List<List<int>>()), Is.EqualTo(EmptyList));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void ConcatOfListOfLists()
    {
        Assert.That(
            ListOps.Concat(new List<List<int>>
            {
                new List<int> {1, 2},
                new List<int> {3},
                EmptyList,
                new List<int> {4, 5, 6}
            }), Is.EqualTo(Range(1, 6)));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void ConcatOfLargeListOfSmallLists()
    {
        Assert.That(ListOps.Concat(ListOps.Map(x => new List<int> {x}, Range(1, Big))), Is.EquivalentTo(BigList));
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class PascalsTriangleTest
{
    [Fact]
    public void One_row()
    {
        var actual = PascalsTriangle.Calculate(1);
        var expected = new[] { new[] { 1 } };
        Assert.Equal(expected, actual, NestedEnumerableEqualityComparer<int>.Instance);
    }
    
    [Fact]
    public void Two_rows()
    {
        var actual = PascalsTriangle.Calculate(2).ToArray();
        var expected = new[] { new[] { 1 }, new[] { 1, 1 } };
        Assert.Equal(expected, actual, NestedEnumerableEqualityComparer<int>.Instance);
    }

    [Fact]
    public void Three_rows()
    {
        var actual = PascalsTriangle.Calculate(3);
        var expected = new[] { new[] { 1 }, new[] { 1, 1 }, new[] { 1, 2, 1 } };
        Assert.Equal(expected, actual, NestedEnumerableEqualityComparer<int>.Instance);
    }

    [Fact]
    public void Four_rows()
    {
        var actual = PascalsTriangle.Calculate(4);
        var expected = new[] { new[] { 1 }, new[] { 1, 1 }, new[] { 1, 2, 1 }, new[] { 1, 3, 3, 1 } };
        Assert.Equal(expected, actual, NestedEnumerableEqualityComparer<int>.Instance);
    }

    [Fact]
    public void Five_rows()
    {
        var actual = PascalsTriangle.Calculate(5);
        var expected = new[] { new[] { 1 }, new[] { 1, 1 }, new[] { 1, 2, 1 }, new[] { 1, 3, 3, 1 }, new[] { 1, 4, 6, 4, 1 } };
        Assert.Equal(expected, actual, NestedEnumerableEqualityComparer<int>.Instance);
    }

    [Fact]
    public void Twenty_rows()
    {
        var actual = PascalsTriangle.Calculate(20).Last();
        var expected = new[] { 1, 19, 171, 969, 3876, 11628, 27132, 50388, 75582, 92378, 92378, 75582, 50388, 27132, 11628, 3876, 969, 171, 19, 1 };
        Assert.Equal(expected, actual);
    }

    private class EnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public static readonly EnumerableEqualityComparer<T> Instance = new EnumerableEqualityComparer<T>();

        public bool Equals(IEnumerable<T> x, IEnumerable<T> y) => x.SequenceEqual(y);

        public int GetHashCode(IEnumerable<T> obj)
        {
            throw new NotImplementedException();
        }
    }

    private class NestedEnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<IEnumerable<T>>>
    {
        public static readonly NestedEnumerableEqualityComparer<T> Instance = new NestedEnumerableEqualityComparer<T>();

        public bool Equals(IEnumerable<IEnumerable<T>> x, IEnumerable<IEnumerable<T>> y)
            => x.SequenceEqual(y, EnumerableEqualityComparer<T>.Instance);

        public int GetHashCode(IEnumerable<IEnumerable<T>> obj)
        {
            throw new NotImplementedException();
        }
    }
}
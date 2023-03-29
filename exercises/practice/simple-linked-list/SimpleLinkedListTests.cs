using System.Linq;
using System.Collections.Generic;
using Xunit;

public class SimpleLinkedListTests
{
    [Fact]
    public void Single_item_list_value()
    {
        var list = new SimpleLinkedList<int>(1);
        Assert.Equal(1, list.Value);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Single_item_list_has_no_next_item()
    {
        var list = new SimpleLinkedList<int>(1);
        Assert.Null(list.Next);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_item_list_first_value()
    {
        var list = new SimpleLinkedList<int>(2).Add(1);
        Assert.Equal(2, list.Value);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_item_list_second_value()
    {
        var list = new SimpleLinkedList<int>(2).Add(1);
        Assert.Equal(1, list.Next.Value);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_item_list_second_item_has_no_next()
    {
        var list = new SimpleLinkedList<int>(2).Add(1);
        Assert.Null(list.Next.Next);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Implements_enumerable()
    {
        var list = new SimpleLinkedList<int>(2).Add(1).Add(3);
        var enumerable = Assert.IsAssignableFrom<IEnumerable<int>>(list);
        var enumerator = enumerable.GetEnumerator();
        Assert.True(enumerator.MoveNext());
        Assert.Equal(2, enumerator.Current);
        Assert.True(enumerator.MoveNext());
        Assert.Equal(1, enumerator.Current);
        Assert.True(enumerator.MoveNext());
        Assert.Equal(3, enumerator.Current);
        Assert.False(enumerator.MoveNext());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void From_enumerable()
    {
        var list = new SimpleLinkedList<int>(new[] { 11, 7, 5, 3, 2 });
        Assert.Equal(11, list.Value);
        Assert.Equal(7, list.Next.Value);
        Assert.Equal(5, list.Next.Next.Value);
        Assert.Equal(3, list.Next.Next.Next.Value);
        Assert.Equal(2, list.Next.Next.Next.Next.Value);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reverse()
    {
        var values = Enumerable.Range(1, 5).ToArray();
        var list = new SimpleLinkedList<int>(values);
        var enumerable = Assert.IsAssignableFrom<IEnumerable<int>>(list);    
        var reversed = enumerable.Reverse();
        Assert.Equal(values.Reverse(), reversed);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Roundtrip()
    {
        var values = Enumerable.Range(1, 7);
        var list = new SimpleLinkedList<int>(values);
        var enumerable = Assert.IsAssignableFrom<IEnumerable<int>>(list);    
        Assert.Equal(values, enumerable);
    }
}
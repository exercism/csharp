using System.Linq;
using Xunit;

public class SimpleLinkedListTest
{
    [Fact]
    public void Single_item_list_value()
    {
        var list = new SimpleLinkedList<int>(1);
        Assert.Equal(1, list.Value);
    }

    [Fact(Skip = "Remove to run test")]
    public void Single_item_list_has_no_next_item()
    {
        var list = new SimpleLinkedList<int>(1);
        Assert.Null(list.Next);
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_item_list_first_value()
    {
        var list = new SimpleLinkedList<int>(2).Add(1);
        Assert.Equal(2, list.Value);
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_item_list_second_value()
    {
        var list = new SimpleLinkedList<int>(2).Add(1);
        Assert.Equal(1, list.Next.Value);
    }

    [Fact(Skip = "Remove to run test")]
    public void Two_item_list_second_item_has_no_next()
    {
        var list = new SimpleLinkedList<int>(2).Add(1);
        Assert.Null(list.Next.Next);
    }

    [Fact(Skip = "Remove to run test")]
    public void Implements_enumerable()
    {
        var values = new SimpleLinkedList<int>(2).Add(1);
        Assert.Equal(new[] { 2, 1 }, values);
    }

    [Fact(Skip = "Remove to run test")]
    public void From_enumerable()
    {
        var list = new SimpleLinkedList<int>(new[] { 11, 7, 5, 3, 2 });
        Assert.Equal(11, list.Value);
        Assert.Equal(7, list.Next.Value);
        Assert.Equal(5, list.Next.Next.Value);
        Assert.Equal(3, list.Next.Next.Next.Value);
        Assert.Equal(2, list.Next.Next.Next.Next.Value);
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(10)]
    [InlineData(100)]
    public void Reverse(int length)
    {
        var values = Enumerable.Range(1, length).ToArray();
        var list = new SimpleLinkedList<int>(values);
        var reversed = list.Reverse();
        Assert.Equal(values.Reverse(), reversed);
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(10)]
    [InlineData(100)]
    public void Roundtrip(int length)
    {
        var values = Enumerable.Range(1, length);
        var listValues = new SimpleLinkedList<int>(values);
        Assert.Equal(values, listValues);
    }
}
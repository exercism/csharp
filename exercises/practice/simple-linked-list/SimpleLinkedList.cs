using System.Linq;
using Xunit;
using System.Collections.Generic;

public class SimpleLinkedListTests
{
    [Fact]
    public void Single_item_list_value()
    {
        var list = new SimpleLinkedList<int>(1);
        Assert.Equal(1, list.Remove());
    }

    [Fact]
    public void Two_item_list_first_value()
    {
        var list = new SimpleLinkedList<int>(1, 2);
        Assert.Equal(2, list.Remove());
    }

    [Fact]
    public void Two_item_list_second_value()
    {
        var list = new SimpleLinkedList<int>(1, 2);
        list.Remove();
        Assert.Equal(1, list.Remove());
    }

    [Fact]
    public void Multivalue_initialisation()
    {
        var values = new SimpleLinkedList<int>(2, 1, 3);
        Assert.Equal(new[] { 3, 1, 2 }, values);
    }

    [Fact]
    public void From_enumerable()
    {
        var list = new SimpleLinkedList<int>(new[] { 11, 7, 5, 3, 2 });
        Assert.Equal(2, list.Remove());
        Assert.Equal(3, list.Remove());
        Assert.Equal(5, list.Remove());
        Assert.Equal(7, list.Remove());
        Assert.Equal(11, list.Remove());
    }

    [Fact]
    public void Reverse_enumerable()
    {
        var values = Enumerable.Range(1, 5).ToArray();
        var list = new SimpleLinkedList<int>(values);
        var enumerable = Assert.IsAssignableFrom<IEnumerable<int>>(list);    
        var reversed = enumerable.Reverse();
        Assert.Equal(values, reversed);
    }

    [Fact]
    public void Roundtrip()
    {
        var values = Enumerable.Range(1, 7);
        var list = new SimpleLinkedList<int>(values.ToArray());
        var enumerable = Assert.IsAssignableFrom<IEnumerable<int>>(list);    
        Assert.Equal(values.Reverse(), enumerable);
    }
}
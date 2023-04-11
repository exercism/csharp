using System.Linq;
using System.Collections.Generic;
using Exercism.Tests;
using Xunit;

public class SimpleLinkedListTests
{
    [Fact] 
    [Task(1)]
    public void Empty_list_has_no_elements()
    {
        var list = new SimpleLinkedList<int>();
        Assert.Equal(0, list.Count);
    }

    [Fact]
    [Task(2)]
    public void Pushing_elements_to_the_list_increases_the_count()
    {
        var list = new SimpleLinkedList<int>();
        list.Push(0);
        Assert.Equal(1, list.Count);
        list.Push(0);
        Assert.Equal(2, list.Count);
    }

    [Fact]
    [Task(3)]
    public void Popping_elements_from_the_list_decreases_the_count()
    {
        var list = new SimpleLinkedList<int>();
        list.Push(0);
        list.Push(0);
        Assert.Equal(2, list.Count);
        list.Pop();
        Assert.Equal(1, list.Count);
    }

    [Fact]
    [Task(4)]
    public void Elements_pop_back_in_lifo_order()
    {
        var list = new SimpleLinkedList<int>();
        list.Push(3);
        list.Push(5);
        Assert.Equal(5, list.Pop());
        list.Push(7);        
        Assert.Equal(7, list.Pop());
        Assert.Equal(3, list.Pop());
    }

    [Fact]
    [Task(5)]
    public void Singlevalue_initialisation()
    {
        var list = new SimpleLinkedList<int>(7);
        Assert.Equal(1, list.Count);
        Assert.Equal(7, list.Pop());
    }

    [Fact]
    [Task(5)]
    public void Multivalue_initialisation()
    {
        var list = new SimpleLinkedList<int>(2, 1, 3);
        Assert.Equal(3, list.Pop());
        Assert.Equal(1, list.Pop());
        Assert.Equal(2, list.Pop());
    }

    [Fact]
    [Task(5)]
    public void From_enumerable()
    {
        var list = new SimpleLinkedList<int>(new[] { 11, 7, 5, 3, 2 });
        Assert.Equal(2, list.Pop());
        Assert.Equal(3, list.Pop());
        Assert.Equal(5, list.Pop());
        Assert.Equal(7, list.Pop());
        Assert.Equal(11, list.Pop());
    }

    [Fact]
    [Task(6)]
    public void Reverse_enumerable()
    {
        var values = Enumerable.Range(1, 5).ToArray();
        var list = new SimpleLinkedList<int>(values);
        var enumerable = Assert.IsAssignableFrom<IEnumerable<int>>(list);    
        var reversed = enumerable.Reverse();
        Assert.Equal(values, reversed);
    }

    [Fact]
    [Task(6)]
    public void Roundtrip()
    {
        var values = Enumerable.Range(1, 7);
        var list = new SimpleLinkedList<int>(values.ToArray());
        var enumerable = Assert.IsAssignableFrom<IEnumerable<int>>(list);    
        Assert.Equal(values.Reverse(), enumerable);
    }
}
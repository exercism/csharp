using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

public class SimpleLinkedListTests
{
    [Fact] 
    public void Empty_list_has_no_elements()
    {
        var list = new SimpleLinkedList<int>();
        Assert.Equal(0, list.Count);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Count_cannot_be_changed_from_the_outside()
    {
        var count = typeof(SimpleLinkedList<>).GetProperty("Count");
        Assert.True(count?.GetGetMethod().IsPublic);
        Assert.False(count?.GetSetMethod(true).IsPublic);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Pushing_elements_to_the_list_increases_the_count()
    {
        var list = new SimpleLinkedList<int>();
        list.Push(0);
        Assert.Equal(1, list.Count);
        list.Push(0);
        Assert.Equal(2, list.Count);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Popping_elements_from_the_list_decreases_the_count()
    {
        var list = new SimpleLinkedList<int>();
        list.Push(0);
        list.Push(0);
        Assert.Equal(2, list.Count);
        list.Pop();
        Assert.Equal(1, list.Count);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
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

    private static SimpleLinkedList<int> CreateSimpleLinkedList(int value)
    {
        var type = typeof(SimpleLinkedList<>).MakeGenericType(typeof(int));
		var constructor = type.GetConstructor(new Type[] { typeof(int) });
		return (SimpleLinkedList<int>)constructor?.Invoke(new object[]{ value })
			?? CreateSimpleLinkedList(new int[] { value });
    }
	
    private static SimpleLinkedList<int> CreateSimpleLinkedList(params int[] values)
    {
        var type = typeof(SimpleLinkedList<>).MakeGenericType(typeof(int));
		var constructor = type.GetConstructor(new Type[]{typeof(int[])});	
		return (SimpleLinkedList<int>)constructor.Invoke(new object[]{ values });
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Single_value_initialisation()
    {
        var list = CreateSimpleLinkedList(7);
        Assert.Equal(1, list.Count);
        Assert.Equal(7, list.Pop());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multi_value_initialisation()
    {
        var list = CreateSimpleLinkedList(2, 1, 3);
        Assert.Equal(3, list.Pop());
        Assert.Equal(1, list.Pop());
        Assert.Equal(2, list.Pop());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void From_enumerable()
    {
        var list = CreateSimpleLinkedList(new[] { 11, 7, 5, 3, 2 });
        Assert.Equal(2, list.Pop());
        Assert.Equal(3, list.Pop());
        Assert.Equal(5, list.Pop());
        Assert.Equal(7, list.Pop());
        Assert.Equal(11, list.Pop());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reverse_enumerable()
    {
        var values = Enumerable.Range(1, 5).ToArray();
        var list = CreateSimpleLinkedList(values);
        var enumerable = Assert.IsAssignableFrom<IEnumerable<int>>(list);    
        var reversed = enumerable.Reverse();
        Assert.Equal(values, reversed);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Roundtrip()
    {
        var values = Enumerable.Range(1, 7);
        var list = CreateSimpleLinkedList(values.ToArray());
        var enumerable = Assert.IsAssignableFrom<IEnumerable<int>>(list);    
        Assert.Equal(values.Reverse(), enumerable);
    }
}
// This file was auto-generated based on version 1.1.0 of the canonical data.

using System;
using Xunit;

public class CircularBufferTest
{
    [Fact]
    public void Reading_empty_buffer_should_fail()
    {
        var buffer = new CircularBuffer<int>(capacity: 1);
        Assert.Throws<InvalidOperationException>(() => buffer.Read());
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_read_an_item_just_written()
    {
        var buffer = new CircularBuffer<int>(capacity: 1);
        buffer.Write(1);
        Assert.Equal(1, buffer.Read());
    }

    [Fact(Skip = "Remove to run test")]
    public void Each_item_may_only_be_read_once()
    {
        var buffer = new CircularBuffer<int>(capacity: 1);
        buffer.Write(1);
        Assert.Equal(1, buffer.Read());
        Assert.Throws<InvalidOperationException>(() => buffer.Read());
    }

    [Fact(Skip = "Remove to run test")]
    public void Items_are_read_in_the_order_they_are_written()
    {
        var buffer = new CircularBuffer<int>(capacity: 2);
        buffer.Write(1);
        buffer.Write(2);
        Assert.Equal(1, buffer.Read());
        Assert.Equal(2, buffer.Read());
    }

    [Fact(Skip = "Remove to run test")]
    public void Full_buffer_cant_be_written_to()
    {
        var buffer = new CircularBuffer<int>(capacity: 1);
        buffer.Write(1);
        Assert.Throws<InvalidOperationException>(() => buffer.Write(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void A_read_frees_up_capacity_for_another_write()
    {
        var buffer = new CircularBuffer<int>(capacity: 1);
        buffer.Write(1);
        Assert.Equal(1, buffer.Read());
        buffer.Write(2);
        Assert.Equal(2, buffer.Read());
    }

    [Fact(Skip = "Remove to run test")]
    public void Read_position_is_maintained_even_across_multiple_writes()
    {
        var buffer = new CircularBuffer<int>(capacity: 3);
        buffer.Write(1);
        buffer.Write(2);
        Assert.Equal(1, buffer.Read());
        buffer.Write(3);
        Assert.Equal(2, buffer.Read());
        Assert.Equal(3, buffer.Read());
    }

    [Fact(Skip = "Remove to run test")]
    public void Items_cleared_out_of_buffer_cant_be_read()
    {
        var buffer = new CircularBuffer<int>(capacity: 1);
        buffer.Write(1);
        buffer.Clear();
        Assert.Throws<InvalidOperationException>(() => buffer.Read());
    }

    [Fact(Skip = "Remove to run test")]
    public void Clear_frees_up_capacity_for_another_write()
    {
        var buffer = new CircularBuffer<int>(capacity: 1);
        buffer.Write(1);
        buffer.Clear();
        buffer.Write(2);
        Assert.Equal(2, buffer.Read());
    }

    [Fact(Skip = "Remove to run test")]
    public void Clear_does_nothing_on_empty_buffer()
    {
        var buffer = new CircularBuffer<int>(capacity: 1);
        buffer.Clear();
        buffer.Write(1);
        Assert.Equal(1, buffer.Read());
    }

    [Fact(Skip = "Remove to run test")]
    public void Overwrite_acts_like_write_on_non_full_buffer()
    {
        var buffer = new CircularBuffer<int>(capacity: 2);
        buffer.Write(1);
        buffer.Overwrite(2);
        Assert.Equal(1, buffer.Read());
        Assert.Equal(2, buffer.Read());
    }

    [Fact(Skip = "Remove to run test")]
    public void Overwrite_replaces_the_oldest_item_on_full_buffer()
    {
        var buffer = new CircularBuffer<int>(capacity: 2);
        buffer.Write(1);
        buffer.Write(2);
        buffer.Overwrite(3);
        Assert.Equal(2, buffer.Read());
        Assert.Equal(3, buffer.Read());
    }

    [Fact(Skip = "Remove to run test")]
    public void Overwrite_replaces_the_oldest_item_remaining_in_buffer_following_a_read()
    {
        var buffer = new CircularBuffer<int>(capacity: 3);
        buffer.Write(1);
        buffer.Write(2);
        buffer.Write(3);
        Assert.Equal(1, buffer.Read());
        buffer.Write(4);
        buffer.Overwrite(5);
        Assert.Equal(3, buffer.Read());
        Assert.Equal(4, buffer.Read());
        Assert.Equal(5, buffer.Read());
    }
}
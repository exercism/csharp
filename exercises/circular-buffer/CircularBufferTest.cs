using System;
using Xunit;

public class CircularBufferTest
{
    [Fact]
    public void Write_and_read_back_one_item()
    {
        var buffer = new CircularBuffer<char>(1);
        buffer.Write('1');
        var val = buffer.Read();

        Assert.Equal('1', val);
        Assert.Throws<InvalidOperationException>(() => buffer.Read());
    }

    [Fact]
    public void Write_and_read_back_multiple_items()
    {
        var buffer = new CircularBuffer<char>(2);
        buffer.Write('1');
        buffer.Write('2');

        var val1 = buffer.Read();
        var val2 = buffer.Read();

        Assert.Equal('1', val1);
        Assert.Equal('2', val2);
        Assert.Throws<InvalidOperationException>(() => buffer.Read());
    }

    [Fact]
    public void Clearing_buffer()
    {
        var buffer = new CircularBuffer<char>(3);
        buffer.Write('1');
        buffer.Write('2');
        buffer.Write('3');

        buffer.Clear();

        Assert.Throws<InvalidOperationException>(() => buffer.Read());

        buffer.Write('1');
        buffer.Write('2');

        var val1 = buffer.Read();
        buffer.Write('3');
        var val2 = buffer.Read();

        Assert.Equal('1', val1);
        Assert.Equal('2', val2);
    }

    [Fact]
    public void Alternate_write_and_read()
    {
        var buffer = new CircularBuffer<char>(2);
        buffer.Write('1');
        var val1 = buffer.Read();
        buffer.Write('2');
        var val2 = buffer.Read();

        Assert.Equal('1', val1);
        Assert.Equal('2', val2);
    }

    [Fact]
    public void Reads_back_oldest_item()
    {
        var buffer1 = new CircularBuffer<char>(3);
        buffer1.Write('1');
        buffer1.Write('2');
        var val1 = buffer1.Read();

        buffer1.Write('3');
        var val2 = buffer1.Read();
        var val3 = buffer1.Read();
        Assert.Equal('2', val2);
        Assert.Equal('3', val3);
    }

    [Fact]
    public void Writing_to_a_full_buffer_throws_an_exception()
    {
        var buffer = new CircularBuffer<char>(2);
        buffer.Write('1');
        buffer.Write('2');

        Assert.Throws<InvalidOperationException>(() => buffer.Write('A'));
    }

    [Fact]
    public void Overwriting_oldest_item_in_a_full_buffer()
    {
        var buffer = new CircularBuffer<char>(2);
        buffer.Write('1');
        buffer.Write('2');
        buffer.ForceWrite('A');

        var val1 = buffer.Read();
        var val2 = buffer.Read();

        Assert.Equal('2', val1);
        Assert.Equal('A', val2);
        Assert.Throws<InvalidOperationException>(() => buffer.Read());
    }

    [Fact]
    public void Forced_writes_to_non_full_buffer_should_behave_like_writes()
    {
        var buffer = new CircularBuffer<char>(2);
        buffer.Write('1');
        buffer.ForceWrite('2');

        var val1 = buffer.Read();
        var val2 = buffer.Read();

        Assert.Equal('1', val1);
        Assert.Equal('2', val2);
        Assert.Throws<InvalidOperationException>(() => buffer.Read());
    }

    [Fact]
    public void Alternate_read_and_write_into_buffer_overflow()
    {
        var buffer = new CircularBuffer<char>(5);
        buffer.Write('1');
        buffer.Write('2');
        buffer.Write('3');

        var val1 = buffer.Read();
        var val2 = buffer.Read();
        buffer.Write('4');
        var val3 = buffer.Read();

        buffer.Write('5');
        buffer.Write('6');
        buffer.Write('7');
        buffer.Write('8');

        buffer.ForceWrite('A');
        buffer.ForceWrite('B');

        var val4 = buffer.Read();
        var val5 = buffer.Read();
        var val6 = buffer.Read();
        var val7 = buffer.Read();
        var val8 = buffer.Read();

        Assert.Equal('6', val4);
        Assert.Equal('7', val5);
        Assert.Equal('8', val6);
        Assert.Equal('A', val7);
        Assert.Equal('B', val8);
        Assert.Throws<InvalidOperationException>(() => buffer.Read());
    }
}
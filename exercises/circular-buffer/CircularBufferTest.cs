using Xunit;

public class CircularBufferTest
{
    [Fact]
    public void Write_and_read_back_one_item()
    {
        var buffer = new CircularBuffer<char>(1);
        buffer.Write('1');
        var val = buffer.Read();

        Assert.That(val, Is.EqualTo('1'));
        Assert.That(() => buffer.Read(), Throws.Exception);
    }

    [Fact(Skip="Remove to run test")]
    public void Write_and_read_back_multiple_items()
    {
        var buffer = new CircularBuffer<char>(2);
        buffer.Write('1');
        buffer.Write('2');

        var val1 = buffer.Read();
        var val2 = buffer.Read();

        Assert.That(val1, Is.EqualTo('1'));
        Assert.That(val2, Is.EqualTo('2'));
        Assert.That(() => buffer.Read(), Throws.Exception);
    }

    [Fact(Skip="Remove to run test")]
    public void Clearing_buffer()
    {
        var buffer = new CircularBuffer<char>(3);
        buffer.Write('1');
        buffer.Write('2');
        buffer.Write('3');

        buffer.Clear();

        Assert.That(() => buffer.Read(), Throws.Exception);

        buffer.Write('1');
        buffer.Write('2');

        var val1 = buffer.Read();
        buffer.Write('3');
        var val2 = buffer.Read();

        Assert.That(val1, Is.EqualTo('1'));
        Assert.That(val2, Is.EqualTo('2'));
    }

    [Fact(Skip="Remove to run test")]
    public void Alternate_write_and_read()
    {
        var buffer = new CircularBuffer<char>(2);
        buffer.Write('1');
        var val1 = buffer.Read();
        buffer.Write('2');
        var val2 = buffer.Read();

        Assert.That(val1, Is.EqualTo('1'));
        Assert.That(val2, Is.EqualTo('2'));
    }

    [Fact(Skip="Remove to run test")]
    public void Reads_back_oldest_item()
    {
        var buffer1 = new CircularBuffer<char>(3);
        buffer1.Write('1');
        buffer1.Write('2');
        var val1 = buffer1.Read();

        buffer1.Write('3');
        var val2 = buffer1.Read();
        var val3 = buffer1.Read();
        Assert.That(val2, Is.EqualTo('2'));
        Assert.That(val3, Is.EqualTo('3'));
    }

    [Fact(Skip="Remove to run test")]
    public void Writing_to_a_full_buffer_throws_an_exception()
    {
        var buffer = new CircularBuffer<char>(2);
        buffer.Write('1');
        buffer.Write('2');

        Assert.That(() => buffer.Write('A'), Throws.Exception);
    }

    [Fact(Skip="Remove to run test")]
    public void Overwriting_oldest_item_in_a_full_buffer()
    {
        var buffer = new CircularBuffer<char>(2);
        buffer.Write('1');
        buffer.Write('2');
        buffer.ForceWrite('A');

        var val1 = buffer.Read();
        var val2 = buffer.Read();

        Assert.That(val1, Is.EqualTo('2'));
        Assert.That(val2, Is.EqualTo('A'));
        Assert.That(() => buffer.Read(), Throws.Exception);
    }

    [Fact(Skip="Remove to run test")]
    public void Forced_writes_to_non_full_buffer_should_behave_like_writes()
    {
        var buffer = new CircularBuffer<char>(2);
        buffer.Write('1');
        buffer.ForceWrite('2');

        var val1 = buffer.Read();
        var val2 = buffer.Read();

        Assert.That(val1, Is.EqualTo('1'));
        Assert.That(val2, Is.EqualTo('2'));
        Assert.That(() => buffer.Read(), Throws.Exception);
    }

    [Fact(Skip="Remove to run test")]
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

        Assert.That(val4, Is.EqualTo('6'));
        Assert.That(val5, Is.EqualTo('7'));
        Assert.That(val6, Is.EqualTo('8'));
        Assert.That(val7, Is.EqualTo('A'));
        Assert.That(val8, Is.EqualTo('B'));
        Assert.That(() => buffer.Read(), Throws.Exception);
    }
}
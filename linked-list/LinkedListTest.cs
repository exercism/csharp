using NUnit.Framework;

[TestFixture]
public class DequeTest
{
    private Deque<int> deque;

    [SetUp]
    public void Setup()
    {
        deque = new Deque<int>();
    }

    [Test]
    public void Push_and_pop_are_first_in_last_out_order()
    {
        deque.Push(10);
        deque.Push(20);
        Assert.That(deque.Pop(), Is.EqualTo(20));
        Assert.That(deque.Pop(), Is.EqualTo(10));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Push_and_shift_are_first_in_first_out_order()
    {
        deque.Push(10);
        deque.Push(20);
        Assert.That(deque.Shift(), Is.EqualTo(10));
        Assert.That(deque.Shift(), Is.EqualTo(20));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Unshift_and_shift_are_last_in_first_out_order()
    {
        deque.Unshift(10);
        deque.Unshift(20);
        Assert.That(deque.Shift(), Is.EqualTo(20));
        Assert.That(deque.Shift(), Is.EqualTo(10));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Unshift_and_pop_are_last_in_last_out_order()
    {
        deque.Unshift(10);
        deque.Unshift(20);
        Assert.That(deque.Pop(), Is.EqualTo(10));
        Assert.That(deque.Pop(), Is.EqualTo(20));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Push_and_pop_can_handle_multiple_values()
    {
        deque.Push(10);
        deque.Push(20);
        deque.Push(30);
        Assert.That(deque.Pop(), Is.EqualTo(30));
        Assert.That(deque.Pop(), Is.EqualTo(20));
        Assert.That(deque.Pop(), Is.EqualTo(10));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Unshift_and_shift_can_handle_multiple_values()
    {
        deque.Unshift(10);
        deque.Unshift(20);
        deque.Unshift(30);
        Assert.That(deque.Shift(), Is.EqualTo(30));
        Assert.That(deque.Shift(), Is.EqualTo(20));
        Assert.That(deque.Shift(), Is.EqualTo(10));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void All_methods_of_manipulating_the_deque_can_be_used_together()
    {
        deque.Push(10);
        deque.Push(20);
        Assert.That(deque.Pop(), Is.EqualTo(20));

        deque.Push(30);
        Assert.That(deque.Shift(), Is.EqualTo(10));

        deque.Unshift(40);
        deque.Push(50);
        Assert.That(deque.Shift(), Is.EqualTo(40));
        Assert.That(deque.Pop(), Is.EqualTo(50));
        Assert.That(deque.Shift(), Is.EqualTo(30));
    }
}
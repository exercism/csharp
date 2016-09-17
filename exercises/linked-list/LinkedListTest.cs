using NUnit.Framework;

[TestFixture]
public class LinkedListTest
{
    private LinkedList<int> linkedList;

    [SetUp]
    public void Setup()
    {
        linkedList = new LinkedList<int>();
    }

    [Test]
    public void Push_and_pop_are_first_in_last_out_order()
    {
        linkedList.Push(10);
        linkedList.Push(20);
        Assert.That(linkedList.Pop(), Is.EqualTo(20));
        Assert.That(linkedList.Pop(), Is.EqualTo(10));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Push_and_shift_are_first_in_first_out_order()
    {
        linkedList.Push(10);
        linkedList.Push(20);
        Assert.That(linkedList.Shift(), Is.EqualTo(10));
        Assert.That(linkedList.Shift(), Is.EqualTo(20));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Unshift_and_shift_are_last_in_first_out_order()
    {
        linkedList.Unshift(10);
        linkedList.Unshift(20);
        Assert.That(linkedList.Shift(), Is.EqualTo(20));
        Assert.That(linkedList.Shift(), Is.EqualTo(10));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Unshift_and_pop_are_last_in_last_out_order()
    {
        linkedList.Unshift(10);
        linkedList.Unshift(20);
        Assert.That(linkedList.Pop(), Is.EqualTo(10));
        Assert.That(linkedList.Pop(), Is.EqualTo(20));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Push_and_pop_can_handle_multiple_values()
    {
        linkedList.Push(10);
        linkedList.Push(20);
        linkedList.Push(30);
        Assert.That(linkedList.Pop(), Is.EqualTo(30));
        Assert.That(linkedList.Pop(), Is.EqualTo(20));
        Assert.That(linkedList.Pop(), Is.EqualTo(10));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Unshift_and_shift_can_handle_multiple_values()
    {
        linkedList.Unshift(10);
        linkedList.Unshift(20);
        linkedList.Unshift(30);
        Assert.That(linkedList.Shift(), Is.EqualTo(30));
        Assert.That(linkedList.Shift(), Is.EqualTo(20));
        Assert.That(linkedList.Shift(), Is.EqualTo(10));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void All_methods_of_manipulating_the_linkedList_can_be_used_together()
    {
        linkedList.Push(10);
        linkedList.Push(20);
        Assert.That(linkedList.Pop(), Is.EqualTo(20));

        linkedList.Push(30);
        Assert.That(linkedList.Shift(), Is.EqualTo(10));

        linkedList.Unshift(40);
        linkedList.Push(50);
        Assert.That(linkedList.Shift(), Is.EqualTo(40));
        Assert.That(linkedList.Pop(), Is.EqualTo(50));
        Assert.That(linkedList.Shift(), Is.EqualTo(30));
    }
}
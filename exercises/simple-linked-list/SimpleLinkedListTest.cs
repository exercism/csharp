using System.Linq;
using NUnit.Framework;

public class SimpleLinkedListTest
{
    [Test]
    public void Single_item_list_value()
    {
        var list = new SimpleLinkedList<int>(1);
        Assert.That(list.Value, Is.EqualTo(1));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Single_item_list_has_no_next_item()
    {
        var list = new SimpleLinkedList<int>(1);
        Assert.That(list.Next, Is.Null);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_item_list_first_value()
    {
        var list = new SimpleLinkedList<int>(2).Add(1);
        Assert.That(list.Value, Is.EqualTo(2));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_item_list_second_value()
    {
        var list = new SimpleLinkedList<int>(2).Add(1);
        Assert.That(list.Next.Value, Is.EqualTo(1));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Two_item_list_second_item_has_no_next()
    {
        var list = new SimpleLinkedList<int>(2).Add(1);
        Assert.That(list.Next.Next, Is.Null);
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Implements_enumerable()
    {
        var values = new SimpleLinkedList<int>(2).Add(1);
        Assert.That(values, Is.EqualTo(new[] { 2, 1 }));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void From_enumerable()
    {
        var list = new SimpleLinkedList<int>(new[] { 11, 7, 5, 3, 2 });
        Assert.That(list.Value, Is.EqualTo(11));
        Assert.That(list.Next.Value, Is.EqualTo(7));
        Assert.That(list.Next.Next.Value, Is.EqualTo(5));
        Assert.That(list.Next.Next.Next.Value, Is.EqualTo(3));
        Assert.That(list.Next.Next.Next.Next.Value, Is.EqualTo(2));
    }

    [TestCase(1, Ignore = "Remove to run test case")]
    [TestCase(2, Ignore = "Remove to run test case")]
    [TestCase(10, Ignore = "Remove to run test case")]
    [TestCase(100, Ignore = "Remove to run test case")]
    public void Reverse(int length)
    {
        var values = Enumerable.Range(1, length).ToArray();
        var list = new SimpleLinkedList<int>(values);
        var reversed = list.Reverse();
        Assert.That(reversed, Is.EqualTo(values.Reverse()));
    }

    [TestCase(1, Ignore = "Remove to run test case")]
    [TestCase(2, Ignore = "Remove to run test case")]
    [TestCase(10, Ignore = "Remove to run test case")]
    [TestCase(100, Ignore = "Remove to run test case")]
    public void Roundtrip(int length)
    {
        var values = Enumerable.Range(1, length);
        var listValues = new SimpleLinkedList<int>(values);
        Assert.That(listValues, Is.EqualTo(values));
    }
}
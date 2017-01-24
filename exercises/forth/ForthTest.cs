using NUnit.Framework;

public class ForthTest
{
    [Test]
    public void No_input()
    {
        Assert.That(Forth.Eval(""), Is.EqualTo(""));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Numbers_just_get_pushed_onto_the_stack()
    {
        Assert.That(Forth.Eval("1 2 3 4 5"), Is.EqualTo("1 2 3 4 5"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Non_word_characters_are_separators()
    {
        Assert.That(Forth.Eval("1\v2\t3\n4\r5 6\t7"), Is.EqualTo("1 2 3 4 5 6 7"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Basic_arithmetic()
    {
        Assert.That(Forth.Eval("1 2 + 4 -"), Is.EqualTo("-1"));
        Assert.That(Forth.Eval("2 4 * 3 /"), Is.EqualTo("2"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Division_by_zero()
    {
        var exception = Assert.Throws<ForthException>(() => Forth.Eval("4 2 2 - /"));
        Assert.That(exception.Error, Is.EqualTo(ForthError.DivisionByZero));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void dup()
    {
        Assert.That(Forth.Eval("1 DUP"), Is.EqualTo("1 1"));
        Assert.That(Forth.Eval("1 2 Dup"), Is.EqualTo("1 2 2"));

        var exception = Assert.Throws<ForthException>(() => Forth.Eval("dup"));
        Assert.That(exception.Error, Is.EqualTo(ForthError.StackUnderflow));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void drop()
    {
        Assert.That(Forth.Eval("1 drop"), Is.EqualTo(""));
        Assert.That(Forth.Eval("1 2 drop"), Is.EqualTo("1"));

        var exception = Assert.Throws<ForthException>(() => Forth.Eval("drop"));
        Assert.That(exception.Error, Is.EqualTo(ForthError.StackUnderflow));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void swap()
    {
        Assert.That(Forth.Eval("1 2 swap"), Is.EqualTo("2 1"));
        Assert.That(Forth.Eval("1 2 3 swap"), Is.EqualTo("1 3 2"));

        var exception1 = Assert.Throws<ForthException>(() => Forth.Eval("1 swap"));
        Assert.That(exception1.Error, Is.EqualTo(ForthError.StackUnderflow));

        var exception2 = Assert.Throws<ForthException>(() => Forth.Eval("swap"));
        Assert.That(exception2.Error, Is.EqualTo(ForthError.StackUnderflow));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void over()
    {
        Assert.That(Forth.Eval("1 2 over"), Is.EqualTo("1 2 1"));
        Assert.That(Forth.Eval("1 2 3 over"), Is.EqualTo("1 2 3 2"));

        var exception1 = Assert.Throws<ForthException>(() => Forth.Eval("1 over"));
        Assert.That(exception1.Error, Is.EqualTo(ForthError.StackUnderflow));

        var exception2 = Assert.Throws<ForthException>(() => Forth.Eval("over"));
        Assert.That(exception2.Error, Is.EqualTo(ForthError.StackUnderflow));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Defining_a_new_word()
    {
        Assert.That(Forth.Eval(": dup-twice dup dup ; 1 dup-twice"), Is.EqualTo("1 1 1"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Redefining_an_existing_word()
    {
        Assert.That(Forth.Eval(": foo dup ; : foo dup dup ; 1 foo"), Is.EqualTo("1 1 1"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Redefining_an_existing_built_in_word()
    {
        Assert.That(Forth.Eval(": swap dup ; 1 swap"), Is.EqualTo("1 1"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Defining_words_with_odd_characters()
    {
        Assert.That(Forth.Eval(": € 220371 ; €"), Is.EqualTo("220371"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Defining_a_number()
    {
        var exception = Assert.Throws<ForthException>(() => Forth.Eval(": 1 2 ;"));
        Assert.That(exception.Error, Is.EqualTo(ForthError.InvalidWord));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Calling_a_non_existing_word()
    {
        var exception = Assert.Throws<ForthException>(() => Forth.Eval("1 foo"));
        Assert.That(exception.Error, Is.EqualTo(ForthError.UnknownWord));
    }
}

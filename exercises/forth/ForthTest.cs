using Xunit;

public class ForthTest
{
    [Fact]
    public void No_input()
    {
        Assert.Equal("", Forth.Eval(""));
    }

    [Fact(Skip="Remove to run test")]
    public void Numbers_just_get_pushed_onto_the_stack()
    {
        Assert.Equal("1 2 3 4 5", Forth.Eval("1 2 3 4 5"));
    }

    [Fact(Skip="Remove to run test")]
    public void Non_word_characters_are_separators()
    {
        Assert.Equal("1 2 3 4 5 6 7", Forth.Eval("1\v2\t3\n4\r5 6\t7"));
    }

    [Fact(Skip="Remove to run test")]
    public void Basic_arithmetic()
    {
        Assert.Equal("-1", Forth.Eval("1 2 + 4 -"));
        Assert.Equal("2", Forth.Eval("2 4 * 3 /"));
    }

    [Fact(Skip="Remove to run test")]
    public void Division_by_zero()
    {
        var exception = Assert.Throws<ForthException>(() => Forth.Eval("4 2 2 - /"));
        Assert.Equal(ForthError.DivisionByZero, exception.Error);
    }

    [Fact(Skip="Remove to run test")]
    public void dup()
    {
        Assert.Equal("1 1", Forth.Eval("1 DUP"));
        Assert.Equal("1 2 2", Forth.Eval("1 2 Dup"));

        var exception = Assert.Throws<ForthException>(() => Forth.Eval("dup"));
        Assert.Equal(ForthError.StackUnderflow, exception.Error);
    }

    [Fact(Skip="Remove to run test")]
    public void drop()
    {
        Assert.Equal("", Forth.Eval("1 drop"));
        Assert.Equal("1", Forth.Eval("1 2 drop"));

        var exception = Assert.Throws<ForthException>(() => Forth.Eval("drop"));
        Assert.Equal(ForthError.StackUnderflow, exception.Error);
    }

    [Fact(Skip="Remove to run test")]
    public void swap()
    {
        Assert.Equal("2 1", Forth.Eval("1 2 swap"));
        Assert.Equal("1 3 2", Forth.Eval("1 2 3 swap"));

        var exception1 = Assert.Throws<ForthException>(() => Forth.Eval("1 swap"));
        Assert.Equal(ForthError.StackUnderflow, exception1.Error);

        var exception2 = Assert.Throws<ForthException>(() => Forth.Eval("swap"));
        Assert.Equal(ForthError.StackUnderflow, exception2.Error);
    }

    [Fact(Skip="Remove to run test")]
    public void over()
    {
        Assert.Equal("1 2 1", Forth.Eval("1 2 over"));
        Assert.Equal("1 2 3 2", Forth.Eval("1 2 3 over"));

        var exception1 = Assert.Throws<ForthException>(() => Forth.Eval("1 over"));
        Assert.Equal(ForthError.StackUnderflow, exception1.Error);

        var exception2 = Assert.Throws<ForthException>(() => Forth.Eval("over"));
        Assert.Equal(ForthError.StackUnderflow, exception2.Error);
    }

    [Fact(Skip="Remove to run test")]
    public void Defining_a_new_word()
    {
        Assert.Equal("1 1 1", Forth.Eval(": dup-twice dup dup ; 1 dup-twice"));
    }

    [Fact(Skip="Remove to run test")]
    public void Redefining_an_existing_word()
    {
        Assert.Equal("1 1 1", Forth.Eval(": foo dup ; : foo dup dup ; 1 foo"));
    }

    [Fact(Skip="Remove to run test")]
    public void Redefining_an_existing_built_in_word()
    {
        Assert.Equal("1 1", Forth.Eval(": swap dup ; 1 swap"));
    }

    [Fact(Skip="Remove to run test")]
    public void Defining_words_with_odd_characters()
    {
        Assert.Equal("220371", Forth.Eval(": € 220371 ; €"));
    }

    [Fact(Skip="Remove to run test")]
    public void Defining_a_number()
    {
        var exception = Assert.Throws<ForthException>(() => Forth.Eval(": 1 2 ;"));
        Assert.Equal(ForthError.InvalidWord, exception.Error);
    }

    [Fact(Skip="Remove to run test")]
    public void Calling_a_non_existing_word()
    {
        var exception = Assert.Throws<ForthException>(() => Forth.Eval("1 foo"));
        Assert.Equal(ForthError.UnknownWord, exception.Error);
    }
}

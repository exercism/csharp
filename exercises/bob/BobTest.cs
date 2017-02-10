using Xunit;

public class BobTest
{
    [Fact]
    public void Stating_something ()
    {
        Assert.Equal("Whatever.", Bob.Hey("Tom-ay-to, tom-aaaah-to."));
    }

    [Fact]
    public void Shouting ()
    {
        Assert.Equal("Whoa, chill out!", Bob.Hey("WATCH OUT!"));
    }

    [Fact]
    public void Asking_a_question ()
    {
        Assert.Equal("Sure.", Bob.Hey("Does this cryogenic chamber make me look fat?"));
    }

    [Fact]
    public void Asking_a_question_with_a_trailing_space()
    {
        Assert.Equal("Sure.", Bob.Hey("Do I like my  spacebar  too much?  "));
    }

    [Fact]
    public void Asking_a_numeric_question ()
    {
        Assert.Equal("Sure.", Bob.Hey("You are, what, like 15?"));
    }

    [Fact]
    public void Talking_forcefully ()
    {
        Assert.Equal("Whatever.", Bob.Hey("Let's go make out behind the gym!"));
    }

    [Fact]
    public void Using_acronyms_in_regular_search ()
    {
        Assert.Equal("Whatever.", Bob.Hey("It's OK if you don't want to go to the DMV."));
    }

    [Fact]
    public void Forceful_questions ()
    {
        Assert.Equal("Whoa, chill out!", Bob.Hey("WHAT THE HELL WERE YOU THINKING?"));
    }

    [Fact]
    public void Shouting_numbers ()
    {
        Assert.Equal("Whoa, chill out!", Bob.Hey("1, 2, 3 GO!"));
    }

    [Fact]
    public void Only_numbers ()
    {
        Assert.Equal("Whatever.", Bob.Hey("1, 2, 3"));
    }

    [Fact]
    public void Question_with_only_numbers ()
    {
        Assert.Equal("Sure.", Bob.Hey("4?"));
    }

    [Fact]
    public void Shouting_with_special_characters ()
    {
        Assert.Equal("Whoa, chill out!", Bob.Hey("ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!"));
    }

    [Fact]
    public void Shouting_with_no_exclamation_mark ()
    {
        Assert.Equal("Whoa, chill out!", Bob.Hey("I HATE YOU"));
    }

    [Fact]
    public void Statement_containing_question_mark ()
    {
        Assert.Equal("Whatever.", Bob.Hey("Ending with ? means a question."));
    }

    [Fact]
    public void Prattling_on ()
    {
        Assert.Equal("Sure.", Bob.Hey("Wait! Hang on. Are you going to be OK?"));
    }

    [Fact]
    public void Silence ()
    {
        Assert.Equal("Fine. Be that way!", Bob.Hey(""));
    }

    [Fact]
    public void Prolonged_silence ()
    {
        Assert.Equal("Fine. Be that way!", Bob.Hey("    "));
    }

    [Fact]
    public void Multiple_line_question ()
    {
        Assert.Equal("Whatever.", Bob.Hey("Does this cryogenic chamber make me look fat?\nno"));
    }
}

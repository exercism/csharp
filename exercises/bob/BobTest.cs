using Xunit;

public class BobTest
{
    [Fact]
    public void Stating_something ()
    {
        Assert.That(Bob.Hey("Tom-ay-to, tom-aaaah-to."), Is.EqualTo("Whatever."));
    }

    [Fact(Skip="Remove to run test")]
    public void Shouting ()
    {
        Assert.That(Bob.Hey("WATCH OUT!"), Is.EqualTo("Whoa, chill out!"));
    }

    [Fact(Skip="Remove to run test")]
    public void Asking_a_question ()
    {
        Assert.That(Bob.Hey("Does this cryogenic chamber make me look fat?"), Is.EqualTo("Sure."));
    }

    [Fact(Skip="Remove to run test")]
    public void Asking_a_question_with_a_trailing_space()
    {
        Assert.That(Bob.Hey("Do I like my  spacebar  too much?  "), Is.EqualTo("Sure."));
    }

    [Fact(Skip="Remove to run test")]
    public void Asking_a_numeric_question ()
    {
        Assert.That(Bob.Hey("You are, what, like 15?"), Is.EqualTo("Sure."));
    }

    [Fact(Skip="Remove to run test")]
    public void Talking_forcefully ()
    {
        Assert.That(Bob.Hey("Let's go make out behind the gym!"), Is.EqualTo("Whatever."));
    }

    [Fact(Skip="Remove to run test")]
    public void Using_acronyms_in_regular_search ()
    {
        Assert.That(Bob.Hey("It's OK if you don't want to go to the DMV."), Is.EqualTo("Whatever."));
    }

    [Fact(Skip="Remove to run test")]
    public void Forceful_questions ()
    {
        Assert.That(Bob.Hey("WHAT THE HELL WERE YOU THINKING?"), Is.EqualTo("Whoa, chill out!"));
    }

    [Fact(Skip="Remove to run test")]
    public void Shouting_numbers ()
    {
        Assert.That(Bob.Hey("1, 2, 3 GO!"), Is.EqualTo("Whoa, chill out!"));
    }

    [Fact(Skip="Remove to run test")]
    public void Only_numbers ()
    {
        Assert.That(Bob.Hey("1, 2, 3"), Is.EqualTo("Whatever."));
    }

    [Fact(Skip="Remove to run test")]
    public void Question_with_only_numbers ()
    {
        Assert.That(Bob.Hey("4?"), Is.EqualTo("Sure."));
    }

    [Fact(Skip="Remove to run test")]
    public void Shouting_with_special_characters ()
    {
        Assert.That(Bob.Hey("ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!"), Is.EqualTo("Whoa, chill out!"));
    }

    [Fact(Skip="Remove to run test")]
    public void Shouting_with_no_exclamation_mark ()
    {
        Assert.That(Bob.Hey("I HATE YOU"), Is.EqualTo("Whoa, chill out!"));
    }

    [Fact(Skip="Remove to run test")]
    public void Statement_containing_question_mark ()
    {
        Assert.That(Bob.Hey("Ending with ? means a question."), Is.EqualTo("Whatever."));
    }

    [Fact(Skip="Remove to run test")]
    public void Prattling_on ()
    {
        Assert.That(Bob.Hey("Wait! Hang on. Are you going to be OK?"), Is.EqualTo("Sure."));
    }

    [Fact(Skip="Remove to run test")]
    public void Silence ()
    {
        Assert.That(Bob.Hey(""), Is.EqualTo("Fine. Be that way!"));
    }

    [Fact(Skip="Remove to run test")]
    public void Prolonged_silence ()
    {
        Assert.That(Bob.Hey("    "), Is.EqualTo("Fine. Be that way!"));
    }

    [Fact(Skip="Remove to run test")]
    public void Multiple_line_question ()
    {
        Assert.That(Bob.Hey("Does this cryogenic chamber make me look fat?\nno"), Is.EqualTo("Whatever."));
    }
}

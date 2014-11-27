using NUnit.Framework;

[TestFixture]
public class BobTest
{
    private Bob teenager;

    [SetUp]
    public void Init ()
    {
        teenager = new Bob();
    }

    [Test]
    public void Stating_something ()
    {
        Assert.That(teenager.Hey("Tom-ay-to, tom-aaaah-to."), Is.EqualTo("Whatever."));
    }

    [Ignore]
    [Test]
    public void Shouting ()
    {
        Assert.That(teenager.Hey("WATCH OUT!"), Is.EqualTo("Whoa, chill out!"));
    }

    [Ignore]
    [Test]
    public void Asking_a_question ()
    {
        Assert.That(teenager.Hey("Does this cryogenic chamber make me look fat?"), Is.EqualTo("Sure."));
    }

    [Ignore]
    [Test]
    public void Asking_a_question_with_a_trailing_space()
    {
        Assert.That(teenager.Hey("Do I like my  spacebar  too much?  "), Is.EqualTo("Sure."));
    }

    [Ignore]
    [Test]
    public void Asking_a_numeric_question ()
    {
        Assert.That(teenager.Hey("You are, what, like 15?"), Is.EqualTo("Sure."));
    }

    [Ignore]
    [Test]
    public void Talking_forcefully ()
    {
        Assert.That(teenager.Hey("Let's go make out behind the gym!"), Is.EqualTo("Whatever."));
    }

    [Ignore]
    [Test]
    public void Using_acronyms_in_regular_search ()
    {
        Assert.That(teenager.Hey("It's OK if you don't want to go to the DMV."), Is.EqualTo("Whatever."));
    }

    [Ignore]
    [Test]
    public void Forceful_questions ()
    {
        Assert.That(teenager.Hey("WHAT THE HELL WERE YOU THINKING?"), Is.EqualTo("Whoa, chill out!"));
    }

    [Ignore]
    [Test]
    public void Shouting_numbers ()
    {
        Assert.That(teenager.Hey("1, 2, 3 GO!"), Is.EqualTo("Whoa, chill out!"));
    }

    [Ignore]
    [Test]
    public void Only_numbers ()
    {
        Assert.That(teenager.Hey("1, 2, 3"), Is.EqualTo("Whatever."));
    }

    [Ignore]
    [Test]
    public void Question_with_only_numbers ()
    {
        Assert.That(teenager.Hey("4?"), Is.EqualTo("Sure."));
    }

    [Ignore]
    [Test]
    public void Shouting_with_special_characters ()
    {
        Assert.That(teenager.Hey("ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!"), Is.EqualTo("Whoa, chill out!"));
    }

    [Ignore]
    [Test]
    public void Shouting_with_no_exclamation_mark ()
    {
        Assert.That(teenager.Hey("I HATE YOU"), Is.EqualTo("Whoa, chill out!"));
    }

    [Ignore]
    [Test]
    public void Statement_containing_question_mark ()
    {
        Assert.That(teenager.Hey("Ending with ? means a question."), Is.EqualTo("Whatever."));
    }

    [Ignore]
    [Test]
    public void Prattling_on ()
    {
        Assert.That(teenager.Hey("Wait! Hang on. Are you going to be OK?"), Is.EqualTo("Sure."));
    }

    [Ignore]
    [Test]
    public void Silence ()
    {
        Assert.That(teenager.Hey(""), Is.EqualTo("Fine. Be that way!"));
    }

    [Ignore]
    [Test]
    public void Prolonged_silence ()
    {
        Assert.That(teenager.Hey("    "), Is.EqualTo("Fine. Be that way!"));
    }

    [Ignore]
    [Test]
    public void Multiple_line_question ()
    {
        Assert.That(teenager.Hey("Does this cryogenic chamber make me look fat?\nno"), Is.EqualTo("Whatever."));
    }
}

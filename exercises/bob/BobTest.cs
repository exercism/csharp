// This file was auto-generated based on version 1.4.0 of the canonical data.

using Xunit;

public class BobTest
{
    [Fact]
    public void Stating_something()
    {
        Assert.Equal("Whatever.", Bob.Response("Tom-ay-to, tom-aaaah-to."));
    }

    [Fact(Skip = "Remove to run test")]
    public void Shouting()
    {
        Assert.Equal("Whoa, chill out!", Bob.Response("WATCH OUT!"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Shouting_gibberish()
    {
        Assert.Equal("Whoa, chill out!", Bob.Response("FCECDFCAAB"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Asking_a_question()
    {
        Assert.Equal("Sure.", Bob.Response("Does this cryogenic chamber make me look fat?"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Asking_a_numeric_question()
    {
        Assert.Equal("Sure.", Bob.Response("You are, what, like 15?"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Asking_gibberish()
    {
        Assert.Equal("Sure.", Bob.Response("fffbbcbeab?"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Talking_forcefully()
    {
        Assert.Equal("Whatever.", Bob.Response("Let's go make out behind the gym!"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Using_acronyms_in_regular_speech()
    {
        Assert.Equal("Whatever.", Bob.Response("It's OK if you don't want to go to the DMV."));
    }

    [Fact(Skip = "Remove to run test")]
    public void Forceful_question()
    {
        Assert.Equal("Calm down, I know what I'm doing!", Bob.Response("WHAT THE HELL WERE YOU THINKING?"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Shouting_numbers()
    {
        Assert.Equal("Whoa, chill out!", Bob.Response("1, 2, 3 GO!"));
    }

    [Fact(Skip = "Remove to run test")]
    public void No_letters()
    {
        Assert.Equal("Whatever.", Bob.Response("1, 2, 3"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Question_with_no_letters()
    {
        Assert.Equal("Sure.", Bob.Response("4?"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Shouting_with_special_characters()
    {
        Assert.Equal("Whoa, chill out!", Bob.Response("ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Shouting_with_no_exclamation_mark()
    {
        Assert.Equal("Whoa, chill out!", Bob.Response("I HATE THE DMV"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Statement_containing_question_mark()
    {
        Assert.Equal("Whatever.", Bob.Response("Ending with ? means a question."));
    }

    [Fact(Skip = "Remove to run test")]
    public void Non_letters_with_question()
    {
        Assert.Equal("Sure.", Bob.Response(":) ?"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Prattling_on()
    {
        Assert.Equal("Sure.", Bob.Response("Wait! Hang on. Are you going to be OK?"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Silence()
    {
        Assert.Equal("Fine. Be that way!", Bob.Response(""));
    }

    [Fact(Skip = "Remove to run test")]
    public void Prolonged_silence()
    {
        Assert.Equal("Fine. Be that way!", Bob.Response("          "));
    }

    [Fact(Skip = "Remove to run test")]
    public void Alternate_silence()
    {
        Assert.Equal("Fine. Be that way!", Bob.Response("\t\t\t\t\t\t\t\t\t\t"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Multiple_line_question()
    {
        Assert.Equal("Whatever.", Bob.Response("\nDoes this cryogenic chamber make me look fat?\nNo."));
    }

    [Fact(Skip = "Remove to run test")]
    public void Starting_with_whitespace()
    {
        Assert.Equal("Whatever.", Bob.Response("         hmmmmmmm..."));
    }

    [Fact(Skip = "Remove to run test")]
    public void Ending_with_whitespace()
    {
        Assert.Equal("Sure.", Bob.Response("Okay if like my  spacebar  quite a bit?   "));
    }

    [Fact(Skip = "Remove to run test")]
    public void Other_whitespace()
    {
        Assert.Equal("Fine. Be that way!", Bob.Response("\n\r \t"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Non_question_ending_with_whitespace()
    {
        Assert.Equal("Whatever.", Bob.Response("This is a statement ending with whitespace      "));
    }
}
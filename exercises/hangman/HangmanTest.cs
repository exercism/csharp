using NUnit.Framework;

public class HangmanTest
{
    [Test]
    public void Initially_9_failures_are_allowed()
    {
        var game = new HangmanGame("foo");

        HangmanState lastState = null;
        game.StateChanged += (sender, state) => lastState = state;

        game.Start();

        Assert.That(lastState.Status, Is.EqualTo(HangmanGame.Status.Busy));
        Assert.That(lastState.RemainingGuesses, Is.EqualTo(9));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Initially_no_letters_are_guessed()
    {
        var game = new HangmanGame("foo");
        
        HangmanState lastState = null;
        game.StateChanged += (sender, state) => lastState = state;

        game.Start();

        Assert.That(lastState.MaskedWord, Is.EqualTo("___"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void After_10_failures_the_game_is_over()
    {
        var game = new HangmanGame("foo");
        
        HangmanState lastState = null;
        game.StateChanged += (sender, state) => lastState = state;

        game.Start();

        for (var i = 0; i < 10; i++)
        {
            game.Guess('x');
        }

        Assert.That(lastState.Status, Is.EqualTo(HangmanGame.Status.Lose));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Feeding_a_correct_letter_removes_underscores()
    {
        var game = new HangmanGame("foobar");

        HangmanState lastState = null;
        game.StateChanged += (sender, state) => lastState = state;

        game.Start();

        game.Guess('b');

        Assert.That(lastState.Status, Is.EqualTo(HangmanGame.Status.Busy));
        Assert.That(lastState.RemainingGuesses, Is.EqualTo(9));
        Assert.That(lastState.MaskedWord, Is.EqualTo("___b__"));

        game.Guess('o');

        Assert.That(lastState.Status, Is.EqualTo(HangmanGame.Status.Busy));
        Assert.That(lastState.RemainingGuesses, Is.EqualTo(9));
        Assert.That(lastState.MaskedWord, Is.EqualTo("_oob__"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Feeding_a_correct_letter_twice_counts_as_a_failure()
    {
        var game = new HangmanGame("foobar");
        
        HangmanState lastState = null;
        game.StateChanged += (sender, state) => lastState = state;

        game.Start();

        game.Guess('b');

        Assert.That(lastState.Status, Is.EqualTo(HangmanGame.Status.Busy));
        Assert.That(lastState.RemainingGuesses, Is.EqualTo(9));
        Assert.That(lastState.MaskedWord, Is.EqualTo("___b__"));

        game.Guess('b');

        Assert.That(lastState.Status, Is.EqualTo(HangmanGame.Status.Busy));
        Assert.That(lastState.RemainingGuesses, Is.EqualTo(8));
        Assert.That(lastState.MaskedWord, Is.EqualTo("___b__"));
    }

    [Ignore("Remove to run test")]
    [Test]
    public void Getting_all_the_letters_right_makes_for_a_win()
    {
        var game = new HangmanGame("hello");
        
        HangmanState lastState = null;
        game.StateChanged += (sender, state) => lastState = state;

        game.Start();

        game.Guess('b');

        Assert.That(lastState.Status, Is.EqualTo(HangmanGame.Status.Busy));
        Assert.That(lastState.RemainingGuesses, Is.EqualTo(8));
        Assert.That(lastState.MaskedWord, Is.EqualTo("_____"));

        game.Guess('e');

        Assert.That(lastState.Status, Is.EqualTo(HangmanGame.Status.Busy));
        Assert.That(lastState.RemainingGuesses, Is.EqualTo(8));
        Assert.That(lastState.MaskedWord, Is.EqualTo("_e___"));

        game.Guess('l');

        Assert.That(lastState.Status, Is.EqualTo(HangmanGame.Status.Busy));
        Assert.That(lastState.RemainingGuesses, Is.EqualTo(8));
        Assert.That(lastState.MaskedWord, Is.EqualTo("_ell_"));

        game.Guess('o');

        Assert.That(lastState.Status, Is.EqualTo(HangmanGame.Status.Busy));
        Assert.That(lastState.RemainingGuesses, Is.EqualTo(8));
        Assert.That(lastState.MaskedWord, Is.EqualTo("_ello"));

        game.Guess('h');

        Assert.That(lastState.Status, Is.EqualTo(HangmanGame.Status.Win));
        Assert.That(lastState.MaskedWord, Is.EqualTo("hello"));
    }
}
using Xunit;

public class HangmanTest
{
    [Fact]
    public void Initially_9_failures_are_allowed()
    {
        var game = new HangmanGame("foo");

        HangmanState lastState = null;
        game.StateChanged += (sender, state) => lastState = state;

        game.Start();

        Assert.Equal(HangmanStatus.Busy, lastState.Status);
        Assert.Equal(9, lastState.RemainingGuesses);
    }

    [Fact(Skip = "Remove to run test")]
    public void Initially_no_letters_are_guessed()
    {
        var game = new HangmanGame("foo");
        
        HangmanState lastState = null;
        game.StateChanged += (sender, state) => lastState = state;

        game.Start();

        Assert.Equal("___", lastState.MaskedWord);
    }

    [Fact(Skip = "Remove to run test")]
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

        Assert.Equal(HangmanStatus.Lose, lastState.Status);
    }

    [Fact(Skip = "Remove to run test")]
    public void Feeding_a_correct_letter_removes_underscores()
    {
        var game = new HangmanGame("foobar");

        HangmanState lastState = null;
        game.StateChanged += (sender, state) => lastState = state;

        game.Start();

        game.Guess('b');

        Assert.Equal(HangmanStatus.Busy, lastState.Status);
        Assert.Equal(9, lastState.RemainingGuesses);
        Assert.Equal("___b__", lastState.MaskedWord);

        game.Guess('o');

        Assert.Equal(HangmanStatus.Busy, lastState.Status);
        Assert.Equal(9, lastState.RemainingGuesses);
        Assert.Equal("_oob__", lastState.MaskedWord);
    }

    [Fact(Skip = "Remove to run test")]
    public void Feeding_a_correct_letter_twice_counts_as_a_failure()
    {
        var game = new HangmanGame("foobar");
        
        HangmanState lastState = null;
        game.StateChanged += (sender, state) => lastState = state;

        game.Start();

        game.Guess('b');

        Assert.Equal(HangmanStatus.Busy, lastState.Status);
        Assert.Equal(9, lastState.RemainingGuesses);
        Assert.Equal("___b__", lastState.MaskedWord);

        game.Guess('b');

        Assert.Equal(HangmanStatus.Busy, lastState.Status);
        Assert.Equal(8, lastState.RemainingGuesses);
        Assert.Equal("___b__", lastState.MaskedWord);
    }

    [Fact(Skip = "Remove to run test")]
    public void Getting_all_the_letters_right_makes_for_a_win()
    {
        var game = new HangmanGame("hello");
        
        HangmanState lastState = null;
        game.StateChanged += (sender, state) => lastState = state;

        game.Start();

        game.Guess('b');

        Assert.Equal(HangmanStatus.Busy, lastState.Status);
        Assert.Equal(8, lastState.RemainingGuesses);
        Assert.Equal("_____", lastState.MaskedWord);

        game.Guess('e');

        Assert.Equal(HangmanStatus.Busy, lastState.Status);
        Assert.Equal(8, lastState.RemainingGuesses);
        Assert.Equal("_e___", lastState.MaskedWord);

        game.Guess('l');

        Assert.Equal(HangmanStatus.Busy, lastState.Status);
        Assert.Equal(8, lastState.RemainingGuesses);
        Assert.Equal("_ell_", lastState.MaskedWord);

        game.Guess('o');

        Assert.Equal(HangmanStatus.Busy, lastState.Status);
        Assert.Equal(8, lastState.RemainingGuesses);
        Assert.Equal("_ello", lastState.MaskedWord);

        game.Guess('h');

        Assert.Equal(HangmanStatus.Win, lastState.Status);
        Assert.Equal("hello", lastState.MaskedWord);
    }
}
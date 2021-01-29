using System;
using Xunit;
using Microsoft.Reactive.Testing;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reactive.Concurrency;

public class HangmanTests : ReactiveTest
{
    [Fact]
    public void Initial_state_masks_the_word()
    {
        var hangman = new Hangman("foo");
        var actual = "";

        // +a->
        hangman.StateObservable.Subscribe(
            x => actual = x.MaskedWord,
            ex => throw new Exception("Should not finish with too many tries"),
            () => throw new Exception("Should not win yet"));
        Assert.Equal("___", actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Initial_state_has_9_remaining_guesses()
    {
        var hangman = new Hangman("foo");
        var actual = 9;

        // +a->
        hangman.StateObservable.Subscribe(x => actual = x.RemainingGuesses);

        Assert.Equal(9, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Initial_state_has_no_guessed_chars()
    {
        var hangman = new Hangman("foo");
        var actual = new HashSet<char> {'x'}.ToImmutableHashSet();

        // +a->
        hangman.StateObservable.Subscribe(x => actual = x.GuessedChars);

        Assert.Equal(new HashSet<char>().ToImmutableHashSet(), actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Guess_changes_state()
    {
        var hangman = new Hangman("foo");
        HangmanState actual = null;
        hangman.StateObservable.Subscribe(x => actual = x);
        var initial = actual;

        // +--x->
        // +a-b->
        hangman.GuessObserver.OnNext('x');

        Assert.NotEqual(initial, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Wrong_guess_decrements_remaining_guesses()
    {
        var hangman = new Hangman("foo");
        HangmanState actual = null;
        hangman.StateObservable.Subscribe(x => actual = x);
        var initial = actual;

        // +--x->
        // +a-b->
        hangman.GuessObserver.OnNext('x');

        Assert.Equal(initial.RemainingGuesses - 1, actual.RemainingGuesses);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void After_10_incorrect_guesses_the_game_is_over()
    {
        var scheduler = new TestScheduler();
        IObservable<HangmanState> Create()
        {
            var hangman = new Hangman("foo");
            for (var i = 1; i <= 10; i++)
            {
                scheduler.Schedule(TimeSpan.FromTicks(i * 100), () => hangman.GuessObserver.OnNext('x'));
            }

            return hangman.StateObservable;
        }

        var expected = new[]
        {
            OnNext<HangmanState>(100, hangmanState => hangmanState.RemainingGuesses == 9),
            OnNext<HangmanState>(200, hangmanState => hangmanState.RemainingGuesses == 8),
            OnNext<HangmanState>(300, hangmanState => hangmanState.RemainingGuesses == 7),
            OnNext<HangmanState>(400, hangmanState => hangmanState.RemainingGuesses == 6),
            OnNext<HangmanState>(500, hangmanState => hangmanState.RemainingGuesses == 5),
            OnNext<HangmanState>(600, hangmanState => hangmanState.RemainingGuesses == 4),
            OnNext<HangmanState>(700, hangmanState => hangmanState.RemainingGuesses == 3),
            OnNext<HangmanState>(800, hangmanState => hangmanState.RemainingGuesses == 2),
            OnNext<HangmanState>(900, hangmanState => hangmanState.RemainingGuesses == 1),
            OnNext<HangmanState>(1000, hangmanState => hangmanState.RemainingGuesses == 0),
            OnError<HangmanState>(1100, ex => ex is TooManyGuessesException)
        };

        // +--x-x-x-x-x-x-x-x-x-x->
        // +a-b-c-d-e-f-g-h-i-j-#
        ITestableObserver<HangmanState> testableObserver = scheduler.Start(Create, 100, 100, 3000);

        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Correctly_guessing_a_letter_unmasks_it()
    {
        var scheduler = new TestScheduler();
        IObservable<HangmanState> Create()
        {
            var hangman = new Hangman("foobar");
            scheduler.Schedule(TimeSpan.FromTicks(100), () => hangman.GuessObserver.OnNext('b'));
            scheduler.Schedule(TimeSpan.FromTicks(200), () => hangman.GuessObserver.OnNext('o'));
            return hangman.StateObservable;
        }

        var expected = new[]
        {
            OnNext<HangmanState>(100, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "______"),
            OnNext<HangmanState>(200, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "___b__"),
            OnNext<HangmanState>(300, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "_oob__")
        };

        // +--b-o->
        // +a-b-c->
        ITestableObserver<HangmanState> testableObserver = scheduler.Start(Create, 100, 100, 3000);

        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Guessing_a_correct_letter_twice_counts_as_a_failure()
    {
        var scheduler = new TestScheduler();
        IObservable<HangmanState> Create()
        {
            var hangman = new Hangman("foobar");
            scheduler.Schedule(TimeSpan.FromTicks(100), () => hangman.GuessObserver.OnNext('b'));
            scheduler.Schedule(TimeSpan.FromTicks(200), () => hangman.GuessObserver.OnNext('b'));
            return hangman.StateObservable;
        }

        var expected = new[]
        {
            OnNext<HangmanState>(100, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "______"),
            OnNext<HangmanState>(200, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "___b__"),
            OnNext<HangmanState>(300, hangmanState => hangmanState.RemainingGuesses == 8 && hangmanState.MaskedWord == "___b__")
        };

        // +--b-b->
        // +a-b-c->
        ITestableObserver<HangmanState> testableObserver = scheduler.Start(Create, 100, 100, 3000);

        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Getting_all_the_letters_right_makes_for_a_win()
    {
        var scheduler = new TestScheduler();
        IObservable<HangmanState> Create()
        {
            var hangman = new Hangman("hello");
            scheduler.Schedule(TimeSpan.FromTicks(100), () => hangman.GuessObserver.OnNext('b'));
            scheduler.Schedule(TimeSpan.FromTicks(200), () => hangman.GuessObserver.OnNext('e'));
            scheduler.Schedule(TimeSpan.FromTicks(300), () => hangman.GuessObserver.OnNext('l'));
            scheduler.Schedule(TimeSpan.FromTicks(400), () => hangman.GuessObserver.OnNext('o'));
            scheduler.Schedule(TimeSpan.FromTicks(500), () => hangman.GuessObserver.OnNext('h'));
            return hangman.StateObservable;
        }

        var expected = new[]
        {
            OnNext<HangmanState>(100, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "_____"),
            OnNext<HangmanState>(200, hangmanState => hangmanState.RemainingGuesses == 8 && hangmanState.MaskedWord == "_____"),
            OnNext<HangmanState>(300, hangmanState => hangmanState.RemainingGuesses == 8 && hangmanState.MaskedWord == "_e___"),
            OnNext<HangmanState>(400, hangmanState => hangmanState.RemainingGuesses == 8 && hangmanState.MaskedWord == "_ell_"),
            OnNext<HangmanState>(500, hangmanState => hangmanState.RemainingGuesses == 8 && hangmanState.MaskedWord == "_ello"),
            OnCompleted<HangmanState>(600)
        };

        // +--b-e-l-o-h->
        // +a-b-c-d-e-|
        ITestableObserver<HangmanState> testableObserver = scheduler.Start(Create, 100, 100, 3000);

        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages);
    }

    // Advanced mode on>
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Second_player_sees_the_same_game_already_started()
    {
        var scheduler = new TestScheduler();
        var player2 = scheduler.CreateObserver<HangmanState>();
        var hangman = new Hangman("hello");

        var player1 = hangman.StateObservable;
        Ready(player1);

        scheduler.Schedule(TimeSpan.FromTicks(100), () => hangman.GuessObserver.OnNext('e'));
        scheduler.Schedule(TimeSpan.FromTicks(200), () => hangman.GuessObserver.OnNext('l'));
        scheduler.Schedule(TimeSpan.FromTicks(150), () => hangman.StateObservable.Subscribe(player2));

        var expected = new[]
        {
            OnNext<HangmanState>(150, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "_e___"),
            OnNext<HangmanState>(200, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "_ell_")
        };

        // +--e--l->
        // +a-b--c->
        // ...+b-c->
        scheduler.Start();

        ReactiveAssert.AreElementsEqual(expected, player2.Messages);
    }

    private IDisposable Ready(IObservable<HangmanState> player)
    {
        return player.Subscribe(x => { });
    }

    // Expert mode on>
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_players_see_the_same_game_already_started()
    {
        var scheduler = new TestScheduler();
        var player2 = scheduler.CreateObserver<HangmanState>();
        var player3 = scheduler.CreateObserver<HangmanState>();
        var hangman = new Hangman("hello");

        var player1 = hangman.StateObservable;
        Ready(player1);

        scheduler.Schedule(TimeSpan.FromTicks(100), () => hangman.GuessObserver.OnNext('e'));
        scheduler.Schedule(TimeSpan.FromTicks(200), () => hangman.GuessObserver.OnNext('l'));
        scheduler.Schedule(TimeSpan.FromTicks(150), () =>
            {
                hangman.StateObservable.Subscribe(player2);
                hangman.StateObservable.Subscribe(player3);
            });

        var expected = new[]
        {
            OnNext<HangmanState>(150, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "_e___"),
            OnNext<HangmanState>(200, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "_ell_"),
        };

        // +--e--l->
        // +a-b--c->
        // ...+b-c->
        // ...+b-c->
        scheduler.Start();

        ReactiveAssert.AreElementsEqual(expected, player2.Messages);
        ReactiveAssert.AreElementsEqual(expected, player3.Messages);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Player_joins_after_other_players_quit()
    {
        var scheduler = new TestScheduler();
        var player2 = scheduler.CreateObserver<HangmanState>();
        var hangman = new Hangman("a");

        var player1 = hangman.StateObservable;
        var subscription = Ready(player1);

        scheduler.Schedule(TimeSpan.FromTicks(100), () => hangman.GuessObserver.OnNext('a'));
        scheduler.Schedule(TimeSpan.FromTicks(300), () =>
            {
                hangman.StateObservable.Subscribe(player2);
            });
        scheduler.Schedule(TimeSpan.FromTicks(200), () => subscription.Dispose());

        var expected = new[]
        {
            OnCompleted<HangmanState>(300)
        };

        // +--a-|
        // +a-|
        // .....+|
        scheduler.Start();

        ReactiveAssert.AreElementsEqual(expected, player2.Messages);
    }
}

using System;
using Xunit;
using Microsoft.Reactive.Testing;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reactive.Concurrency;

public class HangmanTests: ReactiveTest
{
    [Fact]
    public void Initial_state_masks_the_word()
    {
        // Arrange
        Hangman hangman = new Hangman("foo");
        string actual = "";

        // Act
        // to learn more about observers check out http://reactivex.io/documentation/observable.html
        // This time Easy-does-it, we just check if subscribing notifies an OnNext with the initial state
        // There is marble diagram for each test https://bitbucket.org/achary/rx-marbles/src/master/docs/syntax.md?fileviewer=file-view-default
        // +a->
        hangman.StateObservable.Subscribe(
            x => actual = x.MaskedWord,

        // Assert
            ex => throw new Exception("Should not finish with too many tries"),
            () => throw new Exception("Should not win yet"));
        Assert.Equal("___", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Initial_state_have_9_failures_allowed()
    {
        // Arrange
        var hangman = new Hangman("foo");
        int actual = 9;

        // Act
        // +a->
        hangman.StateObservable.Subscribe(x => actual = x.RemainingGuesses);

        // Assert
        Assert.Equal(9, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Initial_state_have_no_guessed_chars()
    {
        // Arrange
        Hangman hangman = new Hangman("foo");
        // for detecting initialization it's not empty
        ImmutableHashSet<char> actual = new HashSet<char> {'x'}.ToImmutableHashSet();

        // Act
        // +a->
        hangman.StateObservable.Subscribe( x => actual = x.GuessedChars);

        // Assert
        Assert.Equal(new HashSet<char>().ToImmutableHashSet(), actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Guess_changes_state()
    {
        // Arrange
        Hangman hangman = new Hangman("foo");
        HangmanState actual= null;
        hangman.StateObservable.Subscribe(x => actual = x);
        var initial = actual;

        // Act
        // +--x->
        // +a-b->
        hangman.GuessObserver.OnNext('x');

        // Assert
        Assert.NotEqual(initial, actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Wrong_guess_decrements_remaining_guesses()
    {
        // Arrange
        Hangman hangman = new Hangman("foo");
        HangmanState actual= null;
        hangman.StateObservable.Subscribe(x => actual = x);
        var initial = actual;

        // Act
        // +--x->
        // +a-b->
        hangman.GuessObserver.OnNext('x');

        // Assert
        Assert.Equal(initial.RemainingGuesses - 1, actual.RemainingGuesses);
    }

    [Fact(Skip = "Remove to run test")]
    public void After_10_failures_the_game_is_over()
    {
        // Arrange
        TestScheduler scheduler = new TestScheduler();
        IObservable<HangmanState> Create()
        {
            var game = new Hangman("foo");
            for (var i = 1; i <= 10; i++)
            {
                scheduler.Schedule(TimeSpan.FromTicks(i * 100), () => game.GuessObserver.OnNext('x'));
            }

            return game.StateObservable;
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
            OnError<HangmanState>(1100, ex => ex is GameFailedException)
        };

        // Act
        // +--x-x-x-x-x-x-x-x-x-x->
        // +a-b-c-d-e-f-g-h-i-j-#
        ITestableObserver<HangmanState> testableObserver = scheduler.Start(Create, 100, 100, 3000);

        // Assert
        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages);
    }

    [Fact(Skip = "Remove to run test")]
    public void Feeding_a_correct_letter_removes_underscores()
    {
        // Arrange
        TestScheduler scheduler = new TestScheduler();
        IObservable<HangmanState> Create()
        {
            var game = new Hangman("foobar");
            scheduler.Schedule(TimeSpan.FromTicks(100), () => game.GuessObserver.OnNext('b'));
            scheduler.Schedule(TimeSpan.FromTicks(200), () => game.GuessObserver.OnNext('o'));
            return game.StateObservable;
        }

        var expected = new[]
        {
            OnNext<HangmanState>(100, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "______"),
            OnNext<HangmanState>(200, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "___b__"),
            OnNext<HangmanState>(300, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "_oob__")
        };

        // Act
        // +--b-o->
        // +a-b-c->
        ITestableObserver<HangmanState> testableObserver = scheduler.Start(Create, 100, 100, 3000);

        // Assert
        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages);
    }

    [Fact(Skip = "Remove to run test")]
    public void Feeding_a_correct_letter_twice_counts_as_a_failure()
    {
        // Arrange
        TestScheduler scheduler = new TestScheduler();
        IObservable<HangmanState> Create()
        {
            var game = new Hangman("foobar");
            scheduler.Schedule(TimeSpan.FromTicks(100), () => game.GuessObserver.OnNext('b'));
            scheduler.Schedule(TimeSpan.FromTicks(200), () => game.GuessObserver.OnNext('b'));
            return game.StateObservable;
        }

        var expected = new[]
        {
            OnNext<HangmanState>(100, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "______"),
            OnNext<HangmanState>(200, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "___b__"),
            OnNext<HangmanState>(300, hangmanState => hangmanState.RemainingGuesses == 8 && hangmanState.MaskedWord == "___b__")
        };

        // Act
        // +--b-b->
        // +a-b-c->
        ITestableObserver<HangmanState> testableObserver = scheduler.Start(Create, 100, 100, 3000);

        // Assert
        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages);
    }

    [Fact(Skip = "Remove to run test")]
    public void Getting_all_the_letters_right_makes_for_a_win()
    {
        // Arrange
        TestScheduler scheduler = new TestScheduler();
        IObservable<HangmanState> Create()
        {
            var game = new Hangman("hello");
            scheduler.Schedule(TimeSpan.FromTicks(100), () => game.GuessObserver.OnNext('b'));
            scheduler.Schedule(TimeSpan.FromTicks(200), () => game.GuessObserver.OnNext('e'));
            scheduler.Schedule(TimeSpan.FromTicks(300), () => game.GuessObserver.OnNext('l'));
            scheduler.Schedule(TimeSpan.FromTicks(400), () => game.GuessObserver.OnNext('o'));
            scheduler.Schedule(TimeSpan.FromTicks(500), () => game.GuessObserver.OnNext('h'));
            return game.StateObservable;
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

        // Act
        // +--b-e-l-o-h->
        // +a-b-c-d-e-|
        ITestableObserver<HangmanState> testableObserver = scheduler.Start(Create, 100, 100, 3000);

        // Assert
        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages);
    }

    // Advanced mode on>
    [Fact(Skip = "Remove to run test")]
    public void Second_player_sees_the_same_game_already_started()
    {
        // Arrange
        TestScheduler scheduler = new TestScheduler();
        var player2 = scheduler.CreateObserver<HangmanState>();
        var game = new Hangman("hello");

        var player1 = game.StateObservable;
        Ready(player1);

        scheduler.Schedule(TimeSpan.FromTicks(100), () => game.GuessObserver.OnNext('e'));
        scheduler.Schedule(TimeSpan.FromTicks(200), () => game.GuessObserver.OnNext('l'));
        scheduler.Schedule(TimeSpan.FromTicks(150), () => game.StateObservable.Subscribe(player2));

        var expected = new[]
        {
            OnNext<HangmanState>(150, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "_e___"),
            OnNext<HangmanState>(200, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "_ell_")
        };

        // Act
        // +--e--l->
        // +a-b--c->
        // ...+b-c->
        scheduler.Start();

        // Assert
        ReactiveAssert.AreElementsEqual(expected, player2.Messages);
    }

    private IDisposable Ready(IObservable<HangmanState> player)
    {
        return player.Subscribe(x => { });
    }

    // Expert mode on>
    [Fact(Skip = "Remove to run test")]
    public void Multiple_player_sees_the_same_game_already_started()
    {
        // Arrange
        TestScheduler scheduler = new TestScheduler();
        var player2 = scheduler.CreateObserver<HangmanState>();
        var player3 = scheduler.CreateObserver<HangmanState>();
        var game = new Hangman("hello");

        var player1 = game.StateObservable;
        Ready(player1);

        scheduler.Schedule(TimeSpan.FromTicks(100), () => game.GuessObserver.OnNext('e'));
        scheduler.Schedule(TimeSpan.FromTicks(200), () => game.GuessObserver.OnNext('l'));
        scheduler.Schedule(TimeSpan.FromTicks(150), () =>
            {
                game.StateObservable.Subscribe(player2);
                game.StateObservable.Subscribe(player3);
            });

        var expected = new[]
        {
            OnNext<HangmanState>(150, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "_e___"),
            OnNext<HangmanState>(200, hangmanState => hangmanState.RemainingGuesses == 9 && hangmanState.MaskedWord == "_ell_"),
        };

        // Act
        // +--e--l->
        // +a-b--c->
        // ...+b-c->
        // ...+b-c->
        scheduler.Start();

        // Assert
        // hint: http://reactivex.io/documentation/subject.html have you noticed that Subject are both IObservable, and IObserver?
        // The only problem now it's converting from IObserver<T1> to IObservable<T2> where T1 != T2. We have to manually trigger.
        // And finding the suitable Subject.
        ReactiveAssert.AreElementsEqual(expected, player2.Messages);
        ReactiveAssert.AreElementsEqual(expected, player3.Messages);
    }

    [Fact(Skip = "Remove to run test")]
    public void Player_joins_after_other_players_quit()
    {
        // Arrange
        TestScheduler scheduler = new TestScheduler();
        var player2 = scheduler.CreateObserver<HangmanState>();
        var game = new Hangman("a");

        var player1 = game.StateObservable;
        var subscription = Ready(player1);

        scheduler.Schedule(TimeSpan.FromTicks(100), () => game.GuessObserver.OnNext('a'));
        scheduler.Schedule(TimeSpan.FromTicks(300), () =>
            {
                game.StateObservable.Subscribe(player2);
            });
        scheduler.Schedule(TimeSpan.FromTicks(200), () => subscription.Dispose());

        var expected = new[]
        {
            OnCompleted<HangmanState>(300)
        };

        // Act
        // +--a-|
        // +a-|
        // .....+|
        scheduler.Start();

        // Assert
        ReactiveAssert.AreElementsEqual(expected, player2.Messages);
    }
}

using Microsoft.Reactive.Testing;
using System.Collections.Immutable;
using System.Reactive.Concurrency;

public class SaveTheCowTests : ReactiveTest
{
    [Fact]
    public void Initial_state_masks_the_word()
    {
        var game = new SaveTheCow("foo");
        var actual = "";

        // +a->
        game.StateObservable.Subscribe(
            x => actual = x.MaskedWord,
            ex => throw new Exception("Should not finish with too many tries"),
            () => throw new Exception("Should not win yet"));
        Assert.Equal("___", actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Initial_state_has_9_remaining_guesses()
    {
        var game = new SaveTheCow("foo");
        var actual = 9;

        // +a->
        game.StateObservable.Subscribe(x => actual = x.RemainingGuesses);

        Assert.Equal(9, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Initial_state_has_no_guessed_chars()
    {
        var game = new SaveTheCow("foo");
        var actual = new HashSet<char> {'x'}.ToImmutableHashSet();

        // +a->
        game.StateObservable.Subscribe(x => actual = x.GuessedChars);

        Assert.Equal(new HashSet<char>().ToImmutableHashSet(), actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Guess_changes_state()
    {
        var game = new SaveTheCow("foo");
        GameState? actual = null;
        game.StateObservable.Subscribe(x => actual = x);
        
        Assert.NotNull(actual);
        var initial = actual;

        // +--x->
        // +a-b->
        game.GuessObserver.OnNext('x');

        Assert.NotEqual(initial, actual);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Wrong_guess_decrements_remaining_guesses()
    {
        var game = new SaveTheCow("foo");
        GameState? actual = null;
        game.StateObservable.Subscribe(x => actual = x);
        
        Assert.NotNull(actual);
        var initial = actual;

        // +--x->
        // +a-b->
        game.GuessObserver.OnNext('x');

        Assert.Equal(initial.RemainingGuesses - 1, actual.RemainingGuesses);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void After_10_incorrect_guesses_the_game_is_over()
    {
        var scheduler = new TestScheduler();
        IObservable<GameState> Create()
        {
            var game = new SaveTheCow("foo");
            for (var i = 1; i <= 10; i++)
            {
                scheduler.Schedule(TimeSpan.FromTicks(i * 100), () => game.GuessObserver.OnNext('x'));
            }

            return game.StateObservable;
        }

        var expected = new[]
        {
            OnNext<GameState>(100, gameState => gameState.RemainingGuesses == 9),
            OnNext<GameState>(200, gameState => gameState.RemainingGuesses == 8),
            OnNext<GameState>(300, gameState => gameState.RemainingGuesses == 7),
            OnNext<GameState>(400, gameState => gameState.RemainingGuesses == 6),
            OnNext<GameState>(500, gameState => gameState.RemainingGuesses == 5),
            OnNext<GameState>(600, gameState => gameState.RemainingGuesses == 4),
            OnNext<GameState>(700, gameState => gameState.RemainingGuesses == 3),
            OnNext<GameState>(800, gameState => gameState.RemainingGuesses == 2),
            OnNext<GameState>(900, gameState => gameState.RemainingGuesses == 1),
            OnNext<GameState>(1000, gameState => gameState.RemainingGuesses == 0),
            OnError<GameState>(1100, ex => ex is TooManyGuessesException)
        };

        // +--x-x-x-x-x-x-x-x-x-x->
        // +a-b-c-d-e-f-g-h-i-j-#
        ITestableObserver<GameState> testableObserver = scheduler.Start(Create, 100, 100, 3000);

        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Correctly_guessing_a_letter_unmasks_it()
    {
        var scheduler = new TestScheduler();
        IObservable<GameState> Create()
        {
            var game = new SaveTheCow("foobar");
            scheduler.Schedule(TimeSpan.FromTicks(100), () => game.GuessObserver.OnNext('b'));
            scheduler.Schedule(TimeSpan.FromTicks(200), () => game.GuessObserver.OnNext('o'));
            return game.StateObservable;
        }

        var expected = new[]
        {
            OnNext<GameState>(100, gameState => gameState.RemainingGuesses == 9 && gameState.MaskedWord == "______"),
            OnNext<GameState>(200, gameState => gameState.RemainingGuesses == 9 && gameState.MaskedWord == "___b__"),
            OnNext<GameState>(300, gameState => gameState.RemainingGuesses == 9 && gameState.MaskedWord == "_oob__")
        };

        // +--b-o->
        // +a-b-c->
        ITestableObserver<GameState> testableObserver = scheduler.Start(Create, 100, 100, 3000);

        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Guessing_a_correct_letter_twice_counts_as_a_failure()
    {
        var scheduler = new TestScheduler();
        IObservable<GameState> Create()
        {
            var game = new SaveTheCow("foobar");
            scheduler.Schedule(TimeSpan.FromTicks(100), () => game.GuessObserver.OnNext('b'));
            scheduler.Schedule(TimeSpan.FromTicks(200), () => game.GuessObserver.OnNext('b'));
            return game.StateObservable;
        }

        var expected = new[]
        {
            OnNext<GameState>(100, gameState => gameState.RemainingGuesses == 9 && gameState.MaskedWord == "______"),
            OnNext<GameState>(200, gameState => gameState.RemainingGuesses == 9 && gameState.MaskedWord == "___b__"),
            OnNext<GameState>(300, gameState => gameState.RemainingGuesses == 8 && gameState.MaskedWord == "___b__")
        };

        // +--b-b->
        // +a-b-c->
        ITestableObserver<GameState> testableObserver = scheduler.Start(Create, 100, 100, 3000);

        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Getting_all_the_letters_right_makes_for_a_win()
    {
        var scheduler = new TestScheduler();
        IObservable<GameState> Create()
        {
            var game = new SaveTheCow("hello");
            scheduler.Schedule(TimeSpan.FromTicks(100), () => game.GuessObserver.OnNext('b'));
            scheduler.Schedule(TimeSpan.FromTicks(200), () => game.GuessObserver.OnNext('e'));
            scheduler.Schedule(TimeSpan.FromTicks(300), () => game.GuessObserver.OnNext('l'));
            scheduler.Schedule(TimeSpan.FromTicks(400), () => game.GuessObserver.OnNext('o'));
            scheduler.Schedule(TimeSpan.FromTicks(500), () => game.GuessObserver.OnNext('h'));
            return game.StateObservable;
        }

        var expected = new[]
        {
            OnNext<GameState>(100, gameState => gameState.RemainingGuesses == 9 && gameState.MaskedWord == "_____"),
            OnNext<GameState>(200, gameState => gameState.RemainingGuesses == 8 && gameState.MaskedWord == "_____"),
            OnNext<GameState>(300, gameState => gameState.RemainingGuesses == 8 && gameState.MaskedWord == "_e___"),
            OnNext<GameState>(400, gameState => gameState.RemainingGuesses == 8 && gameState.MaskedWord == "_ell_"),
            OnNext<GameState>(500, gameState => gameState.RemainingGuesses == 8 && gameState.MaskedWord == "_ello"),
            OnCompleted<GameState>(600)
        };

        // +--b-e-l-o-h->
        // +a-b-c-d-e-|
        ITestableObserver<GameState> testableObserver = scheduler.Start(Create, 100, 100, 3000);

        ReactiveAssert.AreElementsEqual(expected, testableObserver.Messages);
    }

    // Advanced mode on>
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Second_player_sees_the_same_game_already_started()
    {
        var scheduler = new TestScheduler();
        var player2 = scheduler.CreateObserver<GameState>();
        var game = new SaveTheCow("hello");

        var player1 = game.StateObservable;
        Ready(player1);

        scheduler.Schedule(TimeSpan.FromTicks(100), () => game.GuessObserver.OnNext('e'));
        scheduler.Schedule(TimeSpan.FromTicks(200), () => game.GuessObserver.OnNext('l'));
        scheduler.Schedule(TimeSpan.FromTicks(150), () => game.StateObservable.Subscribe(player2));

        var expected = new[]
        {
            OnNext<GameState>(150, gameState => gameState.RemainingGuesses == 9 && gameState.MaskedWord == "_e___"),
            OnNext<GameState>(200, gameState => gameState.RemainingGuesses == 9 && gameState.MaskedWord == "_ell_")
        };

        // +--e--l->
        // +a-b--c->
        // ...+b-c->
        scheduler.Start();

        ReactiveAssert.AreElementsEqual(expected, player2.Messages);
    }

    private IDisposable Ready(IObservable<GameState> player)
    {
        return player.Subscribe(x => { });
    }

    // Expert mode on>
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiple_players_see_the_same_game_already_started()
    {
        var scheduler = new TestScheduler();
        var player2 = scheduler.CreateObserver<GameState>();
        var player3 = scheduler.CreateObserver<GameState>();
        var game = new SaveTheCow("hello");

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
            OnNext<GameState>(150, gameState => gameState.RemainingGuesses == 9 && gameState.MaskedWord == "_e___"),
            OnNext<GameState>(200, gameState => gameState.RemainingGuesses == 9 && gameState.MaskedWord == "_ell_"),
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
        var player2 = scheduler.CreateObserver<GameState>();
        var game = new SaveTheCow("a");

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
            OnCompleted<GameState>(300)
        };

        // +--a-|
        // +a-|
        // .....+|
        scheduler.Start();

        ReactiveAssert.AreElementsEqual(expected, player2.Messages);
    }
}

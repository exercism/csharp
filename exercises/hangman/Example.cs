using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;

/// <summary>
/// Returned state is <see href="https://blog.ndepend.com/c-sharp-immutable-types-understanding-attraction/">immutable</see>,
/// to help the students implement the right solution, escaping the trap of <see cref="RemainingGuesses">RemainingGuesses</see> be the same on
/// all observed elements.
/// </summary>
public class HangmanState
{
    public string MaskedWord { get; }
    public ImmutableHashSet<char> GuessedChars { get; }
    public int RemainingGuesses { get; }

    public HangmanState(string maskedWord, ImmutableHashSet<char> guessedChars, int remainingGuesses)
    {
        MaskedWord = maskedWord;
        GuessedChars = guessedChars;
        RemainingGuesses = remainingGuesses;
    }
}

/// <summary>
/// Notifies the observers, that the game is lost, because of too many guesses.
/// </summary>
public class GameFailedException : Exception
{
}

public class Hangman
{
    public IObservable<HangmanState> StateObservable { get; }
    public IObserver<char> GuessObserver { get; }
    private const char HidingChar = '_';
    private const int MaxGuessCount = 9;

    public Hangman(string word)
    {
        // until Multiple_player_sees_the_same_game_already_started, the tests pass with the following solution> 
        //HashSet<char> guessedChars = new HashSet<char>();
        //int guesses = MaxGuessCount;
        //StateObservable = Observable.Create<HangmanState>(stateObs =>
        //{
        //    stateObs.OnNext(new HangmanState(MaskedWord(word, guessedChars), guessedChars.ToImmutableHashSet(), guesses));
        //    GuessObserver = Observer.Create<char>(x =>
        //    {
        //        bool isHit = !guessedChars.Contains(x) && word.Contains(x);
        //        guessedChars.Add(x);
        //        string maskedWord = MaskedWord(word, guessedChars);
        //        if (maskedWord == word)
        //            stateObs.OnCompleted();
        //        else if (guesses < 1)
        //            stateObs.OnError(new GameFailedException());
        //        else
        //            stateObs.OnNext(new HangmanState(maskedWord, guessedChars.ToImmutableHashSet(),
        //                isHit ? guesses : --guesses));
        //    });
        //    return Disposable.Empty;
        //});

        HashSet<char> emptySetOfChars = new HashSet<char>();
        var stateSubject = new BehaviorSubject<HangmanState>(new HangmanState(MaskedWord(word, emptySetOfChars), emptySetOfChars.ToImmutableHashSet(), MaxGuessCount));

        StateObservable = stateSubject;

        GuessObserver = Observer.Create<char>(x =>
        {
            HashSet<char> guessedChars = new HashSet<char>(stateSubject.Value.GuessedChars);
            bool isHit = !guessedChars.Contains(x) && word.Contains(x);
            guessedChars.Add(x);
            string maskedWord = MaskedWord(word, guessedChars);
            if (maskedWord == word)
                stateSubject.OnCompleted();
            else if (stateSubject.Value.RemainingGuesses < 1)
                stateSubject.OnError(new GameFailedException());
            else
                stateSubject.OnNext(new HangmanState(maskedWord, guessedChars.ToImmutableHashSet(),
                    isHit ? stateSubject.Value.RemainingGuesses : stateSubject.Value.RemainingGuesses - 1));
        });
    }

    private string MaskedWord(string word, HashSet<char> guessedChars)
    {
        return string.Concat(word.Select(y => guessedChars.Contains(y) ? y : HidingChar));
    }
}


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

public class HangmanGame
{
    public IObservable<HangmanState> StateObservable { get => throw new NotImplementedException("You need to implement this function."); }
    public IObserver<char> GuessObserver { get => throw new NotImplementedException("You need to implement this function."); }
  
    public HangmanGame(string word)
    {
        // You need to implement the initialization of StateObservable and GuessObserver.
        // Tests are validated against these properties.
        throw new NotImplementedException("You need to implement this function.");
    }
}

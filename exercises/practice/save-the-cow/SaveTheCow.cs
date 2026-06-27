using System.Collections.Immutable;

public class GameState
{
    public string MaskedWord { get; }
    public ImmutableHashSet<char> GuessedChars { get; }
    public int RemainingGuesses { get; }

    public GameState(string maskedWord, ImmutableHashSet<char> guessedChars, int remainingGuesses)
    {
        MaskedWord = maskedWord;
        GuessedChars = guessedChars;
        RemainingGuesses = remainingGuesses;
    }
}

public class TooManyGuessesException : Exception
{
}

public class SaveTheCow
{
    public IObservable<GameState> StateObservable { get => throw new NotImplementedException("You need to implement this method."); }
    public IObserver<char> GuessObserver { get => throw new NotImplementedException("You need to implement this method."); }
  
    public SaveTheCow(string word)
    {
        throw new NotImplementedException("You need to implement this method.");
    }
}

using System;
using System.Collections.Generic;

public class HangmanState
{
    public HangmanGame.Status Status { get; set; }
    public int RemainingGuesses { get; set; }
    public string MaskedWord { get; set; }
    public HashSet<char> Guesses { get; set; }
}

public class HangmanGame
{
    public enum Status
    {
        Busy,
        Win,
        Lose
    }

    public HangmanGame(string word)
    {
    }

    public void Start()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public void Guess(char c)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
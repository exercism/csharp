using System.Collections.Generic;
using System.Linq;

public delegate void HangmanChangedEventHandler(object sender, HangmanState state);

public class HangmanState
{
    public HangmanGame.Status Status { get; set; }
    public int RemainingGuesses { get; set; }
    public string MaskedWord { get; set; }
    public HashSet<char> Guesses { get; set; }
}

public class HangmanGame
{
    private const int NumberOfAllowedGuesses = 9;
    private const char UnguessedCharacterPlaceHolder = '_';

    private readonly string word;
    private readonly HangmanState state;

    public enum Status
    {
        Busy,
        Win,
        Lose
    }

    public HangmanGame(string word)
    {
        this.word = word;

        state = new HangmanState
        {
            RemainingGuesses = NumberOfAllowedGuesses,
            Guesses = new HashSet<char>()
        };

        UpdateMaskedWord();
        UpdateStatus();
    }

    public event HangmanChangedEventHandler StateChanged;

    public void Start()
    {
        StateChanged?.Invoke(this, state);
    }

    public void Guess(char c)
    {
        UpdateRemainingGuesses(c);
        UpdateMaskedWord();
        UpdateStatus();

        StateChanged?.Invoke(this, state);
    }

    private void UpdateRemainingGuesses(char c)
    {
        if (UnknownCharacter(c) || CharacterAlreadyGuessed(c))
            state.RemainingGuesses--;

        state.Guesses.Add(c);
    }

    private bool UnknownCharacter(char c) => word.All(x => x != c);

    private bool CharacterAlreadyGuessed(char c) => state.Guesses.Contains(c);    

    private void UpdateMaskedWord()
    {
        state.MaskedWord = new string(word.Select(c => state.Guesses.Contains(c) ? c : UnguessedCharacterPlaceHolder).ToArray());
    }

    private void UpdateStatus()
    {
        if (state.MaskedWord == word)
            state.Status = Status.Win;
        else if (state.RemainingGuesses < 0)
            state.Status = Status.Lose;        
        else
            state.Status = Status.Busy;
    }
}
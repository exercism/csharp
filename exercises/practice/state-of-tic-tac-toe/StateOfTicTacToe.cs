using System;

public enum State
{
    Win,
    Draw,
    Ongoing,
    Invalid
}

public class TicTacToe(string[] rows)
{
    public State State
    {
        get
        {
            throw new NotImplementedException("Please implement this property");
        }
    }
}

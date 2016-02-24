using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public class Queens
{
    private readonly Queen _white;
    private readonly Queen _black;

    public Queens(Queen white, Queen black)
    {
        if (white.Row == black.Row && white.Column == black.Column)
        {
            throw new ArgumentException("The queens cannot be positioned at the same place.");
        }

        _black = black;
        _white = white;
    }

    public bool CanAttack()
    {
        return _black.Row == _white.Row ||
               _black.Column == _white.Column ||
               Math.Abs(_black.Row - _white.Row) == Math.Abs(_black.Column - _white.Column);
    }
}
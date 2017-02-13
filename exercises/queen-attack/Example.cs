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

public static class Queens
{
    public static bool CanAttack(Queen white, Queen black)
    {
        if (white.Row == black.Row && white.Column == black.Column)
        {
            throw new ArgumentException("The queens cannot be positioned at the same place.");
        }

        return black.Row == white.Row ||
               black.Column == white.Column ||
               Math.Abs(black.Row - white.Row) == Math.Abs(black.Column - white.Column);
    }
}
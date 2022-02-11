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

public static class QueenAttack
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

    public static Queen Create(int row, int column)
    {
        const int MIN_VALUE = 0;
        const int MAX_VALUE = 7;

        if (row < MIN_VALUE || column < MIN_VALUE || row > MAX_VALUE || column > MAX_VALUE)
        {
            throw new ArgumentOutOfRangeException("invalid queen position");
        }

        return new Queen(row, column);
    }
}
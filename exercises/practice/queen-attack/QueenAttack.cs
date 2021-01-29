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
        throw new NotImplementedException("You need to implement this function.");
    }

    public static Queen Create(int row, int column)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
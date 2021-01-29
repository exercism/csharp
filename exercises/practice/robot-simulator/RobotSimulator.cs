using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
    }

    public Direction Direction
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public int X
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public int Y
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public void Move(string instructions)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
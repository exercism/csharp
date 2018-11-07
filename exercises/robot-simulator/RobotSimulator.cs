using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class Robot
{
    public Robot(Direction direction, int x, int y)
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

    public void TurnRight()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public void TurnLeft()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public void Advance()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public void Simulate(string instructions)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
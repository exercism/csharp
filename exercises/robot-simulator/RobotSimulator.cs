using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public struct Coordinate
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, Coordinate coordinate)
    {
    }

    public Direction Direction
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public Coordinate Coordinate
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
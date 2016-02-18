using System;

public enum Bearing
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
    public RobotSimulator(Bearing bearing, Coordinate coordinate)
    {
        Bearing = bearing;
        Coordinate = coordinate;
    }

    public Bearing Bearing { get; private set; }
    public Coordinate Coordinate { get; private set; }

    public void TurnRight()
    {
        switch (Bearing)
        {
            case Bearing.North:
                Bearing = Bearing.East;
                break;
            case Bearing.East:
                Bearing = Bearing.South;
                break;
            case Bearing.South:
                Bearing = Bearing.West;
                break;
            case Bearing.West:
                Bearing = Bearing.North;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void TurnLeft()
    {
        switch (Bearing)
        {
            case Bearing.North:
                Bearing = Bearing.West;
                break;
            case Bearing.East:
                Bearing = Bearing.North;
                break;
            case Bearing.South:
                Bearing = Bearing.East;
                break;
            case Bearing.West:
                Bearing = Bearing.South;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Advance()
    {
        switch (Bearing)
        {
            case Bearing.North:
                Coordinate = new Coordinate(Coordinate.X, Coordinate.Y + 1);
                break;
            case Bearing.East:
                Coordinate = new Coordinate(Coordinate.X + 1, Coordinate.Y);
                break;
            case Bearing.South:
                Coordinate = new Coordinate(Coordinate.X, Coordinate.Y - 1);
                break;
            case Bearing.West:
                Coordinate = new Coordinate(Coordinate.X - 1, Coordinate.Y);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Simulate(string instructions)
    {
        foreach (var instruction in instructions)
        {
            ProcessInstruction(instruction);
        }
    }

    public void ProcessInstruction(char code)
    {
        switch (code)
        {
            case 'L':
                TurnLeft();
                break;
            case 'R':
                TurnRight();
                break;
            case 'A':
                Advance();
                break;
            default:
                throw new ArgumentOutOfRangeException("Invalid instruction");
        }
    }
}
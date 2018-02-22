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
    public RobotSimulator(Direction bearing, Coordinate coordinate)
    {
        Direction = bearing;
        Coordinate = coordinate;
    }

    public Direction Direction { get; private set; }
    public Coordinate Coordinate { get; private set; }

    public void TurnRight()
    {
        switch (Direction)
        {
            case Direction.North:
                Direction = Direction.East;
                break;
            case Direction.East:
                Direction = Direction.South;
                break;
            case Direction.South:
                Direction = Direction.West;
                break;
            case Direction.West:
                Direction = Direction.North;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void TurnLeft()
    {
        switch (Direction)
        {
            case Direction.North:
                Direction = Direction.West;
                break;
            case Direction.East:
                Direction = Direction.North;
                break;
            case Direction.South:
                Direction = Direction.East;
                break;
            case Direction.West:
                Direction = Direction.South;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Advance()
    {
        switch (Direction)
        {
            case Direction.North:
                Coordinate = new Coordinate(Coordinate.X, Coordinate.Y + 1);
                break;
            case Direction.East:
                Coordinate = new Coordinate(Coordinate.X + 1, Coordinate.Y);
                break;
            case Direction.South:
                Coordinate = new Coordinate(Coordinate.X, Coordinate.Y - 1);
                break;
            case Direction.West:
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
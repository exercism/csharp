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
    public RobotSimulator(Direction bearing, int x, int y)
    {
        Direction = bearing;
        X = x;
        Y = y;
    }

    public Direction Direction { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }

    public void Move(string instructions)
    {
        foreach (var instruction in instructions)
        {
            Move(instruction);
        }
    }

    private void Move(char code)
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

    private void TurnLeft()
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

    private void TurnRight()
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

    private void Advance()
    {
        switch (Direction)
        {
            case Direction.North:
                Y++;
                break;
            case Direction.East:
                X++;
                break;
            case Direction.South:
                Y--;
                break;
            case Direction.West:
                X--;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
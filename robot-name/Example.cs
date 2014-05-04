using System;

public class Robot
{
    private static readonly Random Random = new Random();
    private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public string Name { get; private set; }

    public Robot()
    {
        Reset();
    }

    private static string GenerateName()
    {
        return GetRandomCharacter() + GetRandomCharacter() + Random.Next(999);
    }

    private static string GetRandomCharacter()
    {
        return ALPHABET[Random.Next(25)].ToString();
    }

    public void Reset()
    {
        Name = GenerateName();
    }
}
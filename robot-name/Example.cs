using System;

public class Robot
{
    private static readonly Random Random = new Random();

    public string Name { get; private set; }

    public Robot()
    {
        Reset();
    }

    private static string GenerateName()
    {
        return GetRandomCharacter() + GetRandomCharacter() + Random.Next(1000).ToString("000");
    }

    private static string GetRandomCharacter()
    {
        return ((char)('A' + Random.Next(26))).ToString();
    }

    public void Reset()
    {
        Name = GenerateName();
    }
}
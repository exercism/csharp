using System;
using System.Collections.Generic;

public class Robot
{
    private static readonly Random Random = new Random();
    private static readonly HashSet<string> names = new HashSet<string>();

    public string Name { get; private set; }

    public Robot()
    {
        Reset();
    }

    private static string GenerateName()
    {
        string name;
        do
        {
            name = GetRandomCharacter() + GetRandomCharacter() + Random.Next(1000).ToString("000");
        } while (names.Contains(name));

        names.Add(name);
        return name;
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
using System;

static class GameMaster
{
    public static string Describe(Character character)
    {
        throw new NotImplementedException("Please implement the (static) GameMaster.Describe(Character) method");
    }

    public static string Describe(Destination destination)
    {
        throw new NotImplementedException("Please implement the (static) GameMaster.Describe(Destination) method");
    }

    public static string Describe(TravelMethod travelMethod)
    {
        throw new NotImplementedException("Please implement the (static) GameMaster.Describe(TravelMethod) method");
    }

    public static string Describe(Character character, Destination destination, TravelMethod travelMethod)
    {
        throw new NotImplementedException("Please implement the (static) GameMaster.Describe(Character, Destination, TravelMethod) method");
    }

    public static string Describe(Character character, Destination destination)
    {
        throw new NotImplementedException("Please implement the (static) GameMaster.Describe(Character, Destination) method");
    }
}

class Character
{
    public string Class { get; set; }
    public int Level { get; set; }
    public int HitPoints { get; set; }
}

class Destination
{
    public string Name { get; set; }
    public int Inhabitants { get; set; }
}

enum TravelMethod
{
    Walking,
    Horseback
}

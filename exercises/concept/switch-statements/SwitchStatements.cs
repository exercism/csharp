using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        throw new NotImplementedException($"Please implement the (static) PlayAnalyzer.AnalyzeOnField() method");
    }

    public static string AnalyzeOffField(object report)
    {
        throw new NotImplementedException($"Please implement the (static) PlayAnalyzer.AnalyzeOffField() method");
    }
}

// **** please do not modify the Manager class ****
public class Manager
{
    public string Name { get; }
    public string Activity { get; }

    public Manager(string name, string activity)
    {
        this.Name = name;
        this.Activity = activity;
    }
}

// **** please do not modify the Incident enum ****
public enum Incident
{
    RedCard,
    YellowCard,
    Foul,
    Injury
}

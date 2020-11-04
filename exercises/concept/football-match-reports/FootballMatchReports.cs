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

// **** please do not modify the Incident class or any subclasses ****
public class Incident
{
    public virtual string GetDescription() => "An incident happened.";
}

// **** please do not modify the Foul class ****
public class Foul : Incident
{
    public override string GetDescription() => "The referee deemed a foul.";
}

// **** please do not modify the Injury class ****
public class Injury : Incident
{
    public override string GetDescription() => "A player is injured.";
}

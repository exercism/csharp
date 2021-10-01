public class Manager
{
    public string Name { get; }

    public Manager(string name)
    {
        this.Name = name;
    }
}

public class Incident
{
    public virtual string GetDescription() => "An incident happened.";
}

public class Foul : Incident
{
    public override string GetDescription() => "The referee deemed a foul.";
}

public class Injury : Incident
{
    public override string GetDescription() => "A player is injured.";
}
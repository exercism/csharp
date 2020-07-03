using System;

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

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        string playerDescription = string.Empty;
        switch (shirtNum)
        {
            case 1:
                playerDescription = "goalie";
                break;
            case 2:
                playerDescription = "left back";
                break;
            case 5:
                playerDescription = "right back";
                break;
            case 3:
            case 4:
                playerDescription = "center back";
                break;
            case 6:
            case 7:
            case 8:
                playerDescription = "midfielder";
                break;
            case 9:
                playerDescription = "left wing";
                break;
            case 11:
                playerDescription = "right wing";
                break;
            case 10:
                playerDescription = "striker";
                break;
            default:
                throw new ArgumentException();
        }

        return playerDescription;
    }

    public static string AnalyzeOffField(object report)
    {
        string description = string.Empty;
        switch (report)
        {
            case int shirtNum:
                description = AnalyzeOnField(shirtNum);
                break;
            case string freeFormText:
                description = freeFormText;
                break;
            case Incident incident:
                description = incident.ToString();
                break;
            case Manager manager when !string.IsNullOrWhiteSpace(manager.Name):
                description = manager.Name;
                break;
            case Manager manager:
                description = "the manager";
                break;
            default:
                throw new ArgumentException();
        }

        return description;
    }
}

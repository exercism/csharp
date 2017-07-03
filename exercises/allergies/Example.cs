using System.Collections.Generic;
using System.Linq;

public class Allergies
{
    private readonly int score;
    private static readonly Dictionary<string, int> AvailableAllergies = new Dictionary<string, int>
        {
            { "eggs", 1 },
            { "peanuts", 2 },
            { "shellfish", 4 },
            { "strawberries", 8 },
            { "tomatoes", 16 },
            { "chocolate", 32 },
            { "pollen", 64 },
            { "cats", 128 }
        };

    public Allergies(int score)
    {
        this.score = score;
    }

    public bool IsAllergicTo(string allergy)
    {
        return IsInAllergyScore(AvailableAllergies[allergy]);
    }

    public IList<string> List()
    {
        return AvailableAllergies.Where(x => IsInAllergyScore(x.Value)).Select(x => x.Key).ToList();
    }

    private bool IsInAllergyScore(int allergyValue)
    {
        return (score & allergyValue) == allergyValue;
    }
}
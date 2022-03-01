using System.Linq;

public static class House
{
    private static readonly string[] Subjects =
    {
        "house that Jack built",
        "malt",
        "rat",
        "cat",
        "dog",
        "cow with the crumpled horn",
        "maiden all forlorn",
        "man all tattered and torn",
        "priest all shaven and shorn",
        "rooster that crowed in the morn",
        "farmer sowing his corn",
        "horse and the hound and the horn"
    };

    private static readonly string[] Verbs =
    {
        "lay in",
        "ate",
        "killed",
        "worried",
        "tossed",
        "milked",
        "kissed",
        "married",
        "woke",
        "kept",
        "belonged to",
        ""
    };
    
    public static string Recite(int verseNumber)
    {
        return Recite(verseNumber, verseNumber);
    }
    
    public static string Recite(int startVerse, int endVerse)
    {
        var numberOfVerses = endVerse - startVerse + 1;
        return string.Join("\n", Enumerable.Range(startVerse, numberOfVerses).Select(Verse));
    }

    private static string Verse(int number)
    {
        return string.Join(" ", Enumerable.Range(1, number).Reverse().Select(index => Line(number, index)));
    }

    private static string Line(int number, int index)
    {
        var subject = Subjects[index - 1];
        var verb = Verbs[index - 1];
        var ending = index == 1 ? "." : "";

        return index == number ? $"This is the {subject}{ending}" : $"that {verb} the {subject}{ending}";
    }
}
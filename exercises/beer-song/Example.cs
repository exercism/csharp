using System.Linq;

public static class Beer
{
    public static string Verse(int number)
    {
        switch (number)
        {
            case 0:
                return "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n";
            case 1:
                return "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n";
            case 2:
                return "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n";
            default:
                return string.Format("{0} bottles of beer on the wall, {0} bottles of beer.\nTake one down and pass it around, {1} bottles of beer on the wall.\n", number, number - 1);
        }
    }

    public static string Sing(int start, int stop)
    {
        return Enumerable.Range(stop, start - stop + 1)
                            .Reverse()
                            .Select(Verse)
                            .Aggregate("", (acc, verse) => acc + verse + "\n");
    }
}
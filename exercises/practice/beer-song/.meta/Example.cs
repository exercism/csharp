using System.Linq;

public static class BeerSong
{
    public static string Verse(int number)
    {
        switch (number)
        {
            case 0:
                return "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.";
            case 1:
                return "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.";
            case 2:
                return "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.";
            default:
                return string.Format("{0} bottles of beer on the wall, {0} bottles of beer.\nTake one down and pass it around, {1} bottles of beer on the wall.", number, number - 1);
        }
    }

    public static string Recite(int startBottles, int takeDown)
        => string.Join("\n\n", Enumerable.Range(startBottles - takeDown + 1, takeDown).Reverse().Select(Verse));
}
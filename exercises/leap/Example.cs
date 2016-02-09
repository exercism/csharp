public class Year
{
    public static bool IsLeap(int year)
    {
        if (year % 100 == 0)
            return year % 400 == 0;
        return year % 4 == 0;
    }
}
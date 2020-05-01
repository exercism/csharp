using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public int Total()
    {
        var total = 0;

        foreach (var count in birdsPerDay)
        {
            total += count;
        }

        return total;
    }

    public int BusyDays()
    {
        var days = 0;

        foreach (var count in birdsPerDay)
        {
            if (count >= 5)
            {
                days++;
            }
        }

        return days;
    }

    public int Yesterday()
    {
        return birdsPerDay[5];
    }

    public bool HasDayWithoutBirds()
    {
        return Array.IndexOf(birdsPerDay, 0) != -1;
    }

    public static int[] LastWeek()
    {
        return new int[] { 0, 2, 5, 3, 7, 8, 4 };
    }
}

using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if(number <= 0)
        {
            throw new ArgumentOutOfRangeException("Only positive numbers are allowed");
        }

        int stepCount = 0;

        while(number != 1)
        {
            if(number % 2 == 0)
            {
                number /= 2;
            }
            else
            {
                number = (number * 3) + 1;
            }

            stepCount++;
        }

        return stepCount;
    }
}

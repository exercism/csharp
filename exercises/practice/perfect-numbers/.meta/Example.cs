using System;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException();

        int sumOfFactors = 0;

        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
                sumOfFactors += i;
        }

        if (sumOfFactors < number)
            return Classification.Deficient;
            
        if (sumOfFactors == number)
            return Classification.Perfect;
        
        return Classification.Abundant;
    }
}

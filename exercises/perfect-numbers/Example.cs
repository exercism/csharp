public enum NumberType
{
    Perfect,
    Abundant,
    Deficient
}

public class PerfectNumbers
{
    public static NumberType Classify(int number)
    {
        int sumOfFactors = 0;

        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
            {
                sumOfFactors += i;
            }
        }

        if (sumOfFactors < number)
        {
            return NumberType.Deficient;
        }
        else if (sumOfFactors == number)
        {
            return NumberType.Perfect;
        }
        else
        {
            return NumberType.Abundant;
        }
    }
}

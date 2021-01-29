using System.Collections.Generic;

public class PrimeFactors
{
    public static long[] Factors(long number)
    {
        var primes = new List<long>();
        int divisor = 2;
        while (number > 1)
        {
            while (number % divisor == 0)
            {
                primes.Add(divisor);
                number /= divisor;
            }
            divisor++;
        }
        return primes.ToArray();
    }
}
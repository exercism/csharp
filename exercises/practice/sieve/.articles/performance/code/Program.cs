using System.Collections;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
public class SieveBenchmarks
{
    [Params(1, 10, 1000)]
    public int Max;

    [Benchmark]
    public int[] BitArray() => BitArrayImpl().ToArray();

    private IEnumerable<int> BitArrayImpl()
    {
        if (Max < 0)
            throw new ArgumentOutOfRangeException(nameof(Max));

        var primes = new BitArray(Max + 1, true);

        for (var i = 2; i <= Max; i++)
        {
            if (!primes[i])
                continue;

            for (var j = i * 2; j <= Max; j += i)
                primes[j] = false;

            yield return i;
        }
    }

    [Benchmark]
    public int[] HashSet() => HashSetImpl().ToArray();
    
    private IEnumerable<int> HashSetImpl()
    {
        if (Max < 0)
            throw new ArgumentOutOfRangeException(nameof(Max));

        var nonPrimes = new HashSet<int>();

        for (var i = 2; i <= Max; i++)
        {
            if (nonPrimes.Contains(i))
                continue;

            for (var j = i * 2; j <= Max; j += i)
                nonPrimes.Add(j);

            yield return i;
        }
    }
}

internal static class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<SieveBenchmarks>();
    }
}

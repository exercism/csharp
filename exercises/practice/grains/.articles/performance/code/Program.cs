using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Linq;
using System.Numerics;

[MemoryDiagnoser]
public class BenchMe
{
    public double Square(int i)
    {
        if (i is <= 0 or > 64) throw new ArgumentOutOfRangeException(nameof(i));

        return Math.Pow(2, i - 1);
    }


    [Benchmark]
    public double TotalWithRange()
    {
        return Enumerable.Range(1, 64).Sum(Square);
    }

    [Benchmark]
    public ulong TotalByBits()
    {
        return (ulong)((BigInteger.One << 64) - 1);
    }

}
static class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<BenchMe>();
    }
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

[MemoryDiagnoser]
public class BenchMe
{
    private readonly int year;

    [Params(1900, 2000, 2019, 2020)]
    public int testYear;
    public BenchMe()
    {
        year = testYear;
    }

    [Benchmark]
    public bool IsLeapYearChain()
    {
        return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
    }

    [Benchmark]
    public bool IsLeapYearTernary()
    {
        return year % 100 == 0 ? year % 400 == 0 : year % 4 == 0;
    }

    [Benchmark]
    public bool IsLeapYearSwitch()
    {
        return (year % 4, year % 100, year % 400) switch
        {
            (_, 0, 0) => true,
            (_, 0, _) => false,
            (0, _, _) => true,
            _ => false,
        };
    }
}
static class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<BenchMe>();
    }
}

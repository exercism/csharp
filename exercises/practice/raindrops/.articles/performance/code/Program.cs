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
    private readonly int number = 105;

    [Benchmark]
    public string ConvertWithIfConcat()
    {
        var drops = "";
        if (number % 3 == 0) drops += "Pling";
        if (number % 5 == 0) drops += "Plang";
        if (number % 7 == 0) drops += "Plong";
        return drops.Length > 0 ? drops.ToString() : number.ToString();
    }

    [Benchmark]
    public string ConvertWithIfBuilder()
    {
        var drops = new StringBuilder();
        if (number % 3 == 0) drops.Append("Pling");
        if (number % 5 == 0) drops.Append("Plang");
        if (number % 7 == 0) drops.Append("Plong");
        return drops.Length > 0 ? drops.ToString() : number.ToString();
    }

    [Benchmark]
    public string ConvertAggConcat()
    {
        var drops = (new List<(int, string)> { (3, "Pling"), (5, "Plang"), (7, "Plong") })
            .Aggregate("", (acc, drop) => number % drop.Item1 == 0 ? acc + drop.Item2 : acc);
        return drops.Length > 0 ? drops : number.ToString();
    }

    [Benchmark]
    public string ConvertAggBuilder()
    {
        var drops = (new List<(int, string)> { (3, "Pling"), (5, "Plang"), (7, "Plong") })
            .Aggregate(new StringBuilder(), (acc, drop) => number % drop.Item1 == 0 ? acc.Append(drop.Item2) : acc).ToString();
        return drops.Length > 0 ? drops : number.ToString();
    }

    [Benchmark]
    public string ConvertAggArray()
    {
        var drops = (new (int, string)[] { (3, "Pling"), (5, "Plang"), (7, "Plong") }).Aggregate("", (acc, drop) => number % drop.Item1 == 0 ? acc + drop.Item2 : acc);
        return drops.Length > 0 ? drops : number.ToString();
    }

    private readonly (int, string)[] drips = { (3, "Pling"), (5, "Plang"), (7, "Plong") };

    [Benchmark]
    public string ConvertSepArray()
    {
        var drops = drips.Aggregate("", (acc, drop) => number % drop.Item1 == 0 ? acc + drop.Item2 : acc);
        return drops.Length > 0 ? drops : number.ToString();
    }
}
static class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<BenchMe>();
    }
}

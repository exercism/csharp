using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

[MemoryDiagnoser]
public class BenchMe
{
    private readonly string input = "the_quick_brown_fox_jumps_over_the_lazy_dog";

    private const string Letters = "abcdefghijklmnopqrstuvwxyz";
    
    [Benchmark]
    public bool IsPangramLowered()
    {
        var lowerCaseInput = input.ToLower();
        return Letters.All(letter => lowerCaseInput.Contains(letter));
    }

    private static readonly StringComparison xcase = StringComparison.CurrentCultureIgnoreCase;
    
    [Benchmark]
    public bool IsPangramInsensitive()
    {
        return Letters.All(c => input.Contains(c, xcase));
    }

    [Benchmark]
    public bool IsPangramBitfield()
    {
        int phrasemask = 0;
        foreach (char letter in input)
        {
            // a-z
            if (letter > 96 && letter < 123)
                phrasemask |= 1 << (letter - 'a');
            // A - Z
            else if (letter > 64 && letter < 91)
                phrasemask |= 1 << (letter - 'A');
        }
        //26 binary 1s
        return phrasemask == 67108863;
    }
}
static class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<BenchMe>();
    }
}

using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
public class ReverseString
{
    private readonly string input;

    [Params(0, 10, 100, 100_000)]
    public int Length;

    public ReverseString()
    {
        input = new string('a', Length);
    }

    [Benchmark]
    public string Linq()
    {
        return new string(input.Reverse().ToArray());
    }
    
    [Benchmark]
    public string ArrayReverse()
    {
        var chars = input.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    [Benchmark]
    public string StringBuilder()
    {
        var chars = new StringBuilder();
        for (var i = input.Length - 1; i >= 0; i--)
        {
            chars.Append(input[i]);
        }
        return chars.ToString();
    }

    [Benchmark]
    public string Span()
    {
        Span<char> chars = stackalloc char[input.Length];
        for (var i = 0; i < input.Length; i++)
        {
            chars[input.Length - 1 - i] = input[i];
        }
        return new string(chars);
    }
}

static class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<ReverseString>();
    }
}

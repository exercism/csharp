using System;
using System.Linq;

public class RailFenceCipher
{
    private readonly int _rails;
    private readonly int _size;

    public RailFenceCipher(int rails)
    {
        _rails = rails;
        _size = rails * 2 - 2;
    }

    public string Encode(string input)
    {
        return input
            .Select((c, i) => Tuple.Create(Track(i), c))
            .GroupBy(x => x.Item1)
            .Select(x => new string(x.Select(y => y.Item2).ToArray()))
            .Aggregate("", (acc, x) => acc + x);
    }

    public string Decode(string input)
    {
        return Enumerable.Range(0, input.Length)
            .GroupBy(Track)
            .SelectMany(x => x)
            .Zip(input, Tuple.Create)
            .OrderBy(x => x.Item1)
            .Aggregate("", (s, tuple) => s + tuple.Item2);
    }

    private int Track(int index)
    {
        if (IsCorrect(index))
        {
            return 0;
        }

        if (IsCorrect(index - _rails + 1))
        {
            return _rails - 1;
        }

        return Enumerable.Range(1, _rails - 1).First(i => IsCorrect(index - i) || IsCorrect(index - _size + i));
    }

    private bool IsCorrect(int index) => index % _size == 0;
}
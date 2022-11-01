using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Linq;

[MemoryDiagnoser]
public class BenchMe
{
    private readonly string word = "Thumbscrew-Japingly";


    [Benchmark]
    public bool Distinct()
    {
        var lowerLetters = word.ToLower().Where(char.IsLetter).ToList();
        return lowerLetters.Distinct().Count() == lowerLetters.Count;
    }

    [Benchmark]
    public bool GroupBy()
    {
        return word.ToLower().Where(Char.IsLetter).GroupBy(ltr => ltr).All(ltr_grp => ltr_grp.Count() == 1);
    }


    [Benchmark]
    public bool Bitfield()
    {
        int letter_flags = 0;
        foreach (char letter in word)
        {
            if (letter >= 'a' && letter <= 'z')
            {
                // shift 1 to the left for the letter's place in the alphabet
                if ((letter_flags & (1 << (letter - 'a'))) != 0)
                    return false;
                else
                    letter_flags |= (1 << (letter - 'a'));
            }
            else if (letter >= 'A' && letter <= 'Z')
            {
                // shift 1 to the left for the letter's place in the alphabet
                if ((letter_flags & (1 << (letter - 'A'))) != 0)
                    return false;
                else
                    letter_flags |= (1 << (letter - 'A'));
            }
        }
        return true;
    }
}
static class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<BenchMe>();
    }
}

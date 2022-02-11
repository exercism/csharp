using System.Collections.Generic;
using System.Linq;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        return texts.AsParallel().Aggregate(new Dictionary<char, int>(), AddCount);
    }

    private static Dictionary<char, int> AddCount(Dictionary<char, int> target, string text)
    {
        foreach (var kv in text.ToLower().Where(char.IsLetter).GroupBy(c => c))
        {
            if (target.ContainsKey(kv.Key))
            {
                target[kv.Key] += kv.Count();
            }
            else
            {
                target[kv.Key] = kv.Count();
            }
        }

        return target;
    }
}
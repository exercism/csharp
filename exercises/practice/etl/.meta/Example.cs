using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var transformed = new Dictionary<string, int>();

        foreach (var pair in old)
            foreach (var item in pair.Value)
                transformed.Add(item.ToLower(), pair.Key);

        return transformed;
    }
}
using System.Collections.Generic;

public class ETL
{
    public static IDictionary<string, int> Transform(IDictionary<int, IList<string>> old)
    {
        var transformed = new Dictionary<string, int>();

        foreach (var pair in old)
            foreach (var item in pair.Value)
                transformed.Add(item.ToLower(), pair.Key);

        return transformed;
    }
}
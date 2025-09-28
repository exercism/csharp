public class ParallelLetterFrequency
{
    public async Task<Dictionary<char, int>> Calculate(IEnumerable<string> texts)
    {
        var textList = texts.ToList();

        if (!textList.Any())
        {
            return new Dictionary<char, int>();
        }
        // Process each text in parallel using Task.Run
        var tasks = textList.Select(text => Task.Run(() => CountLettersInText(text)));
        
        // Wait for all tasks to complete
        var results = await Task.WhenAll(tasks);
        
        return MergeDictionaries(results);
    }
    
    private Dictionary<char, int> CountLettersInText(string text)
    {
        return text.ToLower()
                   .Where(char.IsLetter)
                   .GroupBy(c => c)
                   .ToDictionary(g => g.Key, g => g.Count());
    }
    
    private Dictionary<char, int> MergeDictionaries(IEnumerable<Dictionary<char, int>> dictionaries)
    {
        var result = new Dictionary<char, int>();
        
        foreach (var dictionary in dictionaries)
        {
            foreach (var kvp in dictionary)
            {
                if (result.ContainsKey(kvp.Key))
                    result[kvp.Key] += kvp.Value;
                else
                    result[kvp.Key] = kvp.Value;
            }
        }
        
        return result;
    }
}
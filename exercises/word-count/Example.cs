using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        if (phrase == null) throw new ArgumentNullException("phrase");

        var counts = new Dictionary<string, int>();
        Match match = Regex.Match(phrase.ToLower(), @"\w+'\w+|\w+");
        while(match.Success)
        {
            string word = match.Value;
            if(!counts.ContainsKey(word))
            {
                counts[word] = 0;
            }
            counts[word]++;
            match = match.NextMatch();
        }
        return counts;
    }
}
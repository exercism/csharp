using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Phrase
{
    public static IDictionary<string, int> WordCount(string phrase)
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
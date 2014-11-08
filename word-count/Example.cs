using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Phrase
{
    private readonly string _phrase;

    public Phrase(string phrase)
    {
        if (phrase == null) throw new ArgumentNullException("phrase");
        _phrase = phrase;
    }
    
    public IDictionary<string, int> WordCount()
    {
        var counts = new Dictionary<string, int>();
        Match match = Regex.Match(_phrase.ToLower(), @"\w+'\w+|\w+");
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
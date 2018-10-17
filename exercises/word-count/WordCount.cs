using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        phrase = RemoveSpecialCharacters(phrase);
        var words = phrase.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var wordsCounter = new Dictionary<string, int>();
        foreach (var word in words)
        {
            var normalizedWord = word.FirstOrDefault() == '\'' ? Regex.Replace(word, "\'", string.Empty) : word;
            if (wordsCounter.ContainsKey(normalizedWord))
            {
                wordsCounter[normalizedWord]++;
            }
            else
            {
                wordsCounter.Add(normalizedWord, 1);
            }
        }

        return wordsCounter;
    }
    public static string RemoveSpecialCharacters(this string str)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in str)
        {
            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '\'')
            {
                sb.Append(c);
            }
            else
            {
                sb.Append(' ');
            }
        }

        return Regex.Replace(sb.ToString(), @"\s+", " ");
    }
}
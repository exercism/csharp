using System;
using System.Linq;
using System.Collections.Generic;

public class Anagram
{
    private string baseWord;

    public Anagram(string baseWord)
    {
        this.baseWord = baseWord;
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> matches = new List<string>();

        foreach (string word in potentialMatches)
        {
            if (IsWordAnagramOfBaseWord(word))
            {
                matches.Add(word);
            }
        }

        return matches.ToArray();
    }

    private bool IsWordAnagramOfBaseWord(string word)
    {
        return (IsNotTheSameWordAsBaseWord(word) && HasSameLettersAsBaseWord(word));
    }

    private bool IsNotTheSameWordAsBaseWord(string word)
    {
        return ! baseWord.Equals(word,StringComparison.OrdinalIgnoreCase);
    }

    private bool HasSameLettersAsBaseWord(string word)
    {
        return SortedCharArrayForString(baseWord).Equals(SortedCharArrayForString(word));
    }

    private string SortedCharArrayForString (string word)
    {
        return String.Concat(word.ToLower().OrderBy(letter => letter));
    }
}
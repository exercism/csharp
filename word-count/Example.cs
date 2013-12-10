using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Phrase
{
    private string text;

    public Phrase (string text)
    {
        this.text = text;
    }

    public Dictionary<string,int> WordCount ()
    {
        string[] words = Words();
        Dictionary<string,int> wordCount = new Dictionary<string,int>();

        foreach(string word in words)
        {
            if ( ! wordCount.ContainsKey(word) ) { wordCount[word] = 0; }
            wordCount[word]++;
        }

        return wordCount;
    }

    private string RemoveUnwantedCharacters (string text)
    {
        return Regex.Replace(text,"[^\\w\\s']+"," ").Trim();
    }

    private string[] Words ()
    {
        return Regex.Split(RemoveUnwantedCharacters(this.text).ToLower(),"\\s+");
    }

}
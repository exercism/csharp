using System.Collections.Generic;

public static class Languages
{
    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        var languages = new List<string>();
        languages.Add("C#");
        languages.Add("Clojure");
        languages.Add("Elm");
        return languages;
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool ContainsStar(List<string> languages)
    {
        if (languages.Count > 0 && languages[0] == "C#")
        {
            return true;
        }

        if (languages.Count > 1 && languages.Count < 4 && languages[1] == "C#")
        {
            return true;
        }

        return false;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    // guaranteed not empty
    public static bool EnsureUnique(List<string> languages)
    {
        languages.Sort();
        for (int i = 1; i < languages.Count; i++)
        {
            if (languages[i] == languages[i - 1])
            {
                return false;
            }
        }

        return true;
    }
}

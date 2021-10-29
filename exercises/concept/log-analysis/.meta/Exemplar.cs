using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string delimiter)
    {
        return str.Substring(str.IndexOf(delimiter) + delimiter.Length);
    }
    
    public static string SubstringBetween(this string str, string start, string stop)
    {
        return str.Substring(0, str.IndexOf(stop)).SubstringAfter(start);
    }
    
    public static string Message(this string log)
    {
        return log.SubstringAfter("]: ");
    }

    public static string LogLevel(this string log)
    {
        return log.SubstringBetween("[", "]");
    }
}

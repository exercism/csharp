using System;

public static class LogAnalysis 
{
    public static int WordCount(this string log) =>
        log.Split().Length;

    public static string LogLevel(this string log) =>
        log.Substring(log.IndexOf("[") + 1, log.IndexOf("]") - 1);

    public static string LogLine(this string log) =>
        log.Substring(log.IndexOf("{") + 6, log.IndexOf("}") - (log.IndexOf("{") + 6));

    public static string Truncate(this string log, int maxSize) =>
        log.WordCount() < maxSize
        ? log
        : $"{log.LogLevel()} - {log.LogLine()}";
}
static class LogLine
{
    public static string Message(string logLine)
    {
        return logLine.Substring(logLine.IndexOf(":") + 1).Trim();
    }

    public static string LogLevel(string logLine)
    {
        return logLine.Substring(1, logLine.IndexOf("]") - 1).ToLower();
    }

    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})";
    }
}

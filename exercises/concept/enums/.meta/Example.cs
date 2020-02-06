using System;

public enum LogLevel
{
    Unknown = 0,
    Info = 1,
    Warning = 2,
    Error = 4
}

public static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine) =>
        Enum.TryParse<LogLevel>(GetLogLevel(logLine), true, out LogLevel logLevel) ? logLevel : LogLevel.Unknown;

    public static string OutputForShortLog(LogLevel logLevel, string message) =>
        $"{(int)logLevel}:{message}";

    private static string GetLogLevel(string logLine) =>
        logLine.Substring(1, logLine.IndexOf(']') - 1);
}
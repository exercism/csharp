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
        Enum.TryParse<LogLevel>(GetLogLevel(logLine), ignoreCase: true, out var logLevel) ? logLevel : LogLevel.Unknown;

    private static string GetLogLevel(string logLine) =>
        logLine[1..(logLine.IndexOf(']'))];

    public static string OutputForShortLog(LogLevel logLevel, string message) =>
        $"{logLevel:D}:{message}";
}
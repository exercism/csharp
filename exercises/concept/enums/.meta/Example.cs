enum LogLevel
{
    Trace = 0,
    Debug = 1,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 7,
    Unknown = 42
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        switch (logLine.Substring(1, 3))
        {
            case "TRC":
                return LogLevel.Trace;
            case "DBG":
                return LogLevel.Debug;
            case "INF":
                return LogLevel.Info;
            case "WRN":
                return LogLevel.Warning;
            case "ERR":
                return LogLevel.Error;
            case "FTL":
                return LogLevel.Fatal;
            default:
                return LogLevel.Unknown;
        }
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{(int)logLevel}:{message}";
    }
}

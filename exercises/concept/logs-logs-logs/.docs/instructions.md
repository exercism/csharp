In this exercise you'll be processing log-lines.

Each log line is a string formatted as follows: `"[<LVL>]: <MESSAGE>"`.

These are the different log levels:

- `TRC` (trace)
- `DBG` (debug)
- `INF` (info)
- `WRN` (warning)
- `ERR` (error)
- `FTL` (fatal)

You have three tasks.

## 1. Parse log level

Define a `LogLevel` enum that has six elements corresponding to the above log levels.

- `Trace`
- `Debug`
- `Info`
- `Warning`
- `Error`
- `Fatal`

Next, implement the (_static_) `LogLine.ParseLogLevel()` method to parse the log level of a log line:

```csharp
LogLine.ParseLogLevel("[INF]: File deleted")
// => LogLevel.Info
```

## 2. Support unknown log level

Unfortunately, occasionally some log lines have an unknown log level. To gracefully handle these log lines, add an `Unknown` element to the `LogLevel` enum which should be returned when parsing an unknown log level:

```csharp
LogLine.ParseLogLevel("[XYZ]: Overly specific, out of context message")
// => LogLevel.Unknown
```

## 3. Convert log line to short format

The log level of a log line is quite verbose. To reduce the disk space needed to store the log lines, a short format is developed: `"[<ENCODED_LEVEL>]:<MESSAGE>"`.

The encoded log level is simple mapping of a log level to a number:

- `Trace` - `0`
- `Debug` - `1`
- `Info` - `4`
- `Warning` - `5`
- `Error` - `6`
- `Fatal` - `7`
- `Unknown` - `42`

Implement the (_static_) `LogLine.OutputForShortLog()` method that can output the shortened log line format:

```csharp
LogLine.OutputForShortLog(LogLevel.Error, "Stack overflow")
// => "6:Stack overflow"
```

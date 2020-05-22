In this exercise you'll be processing log-lines.

Each log line is a string formatted as follows: `"[<LEVEL>]: <MESSAGE>"`.

There are three different log levels:

- `INFO`
- `WARNING`
- `ERROR`

You have three tasks, each of which will take a log line and ask you to do something with it.

## 1. Get message from a log line

Implement the (_static_) `LogLine.Message()` method to return a log line's message:

```csharp
LogLine.Message("[ERROR]: Invalid operation")
// => "Invalid operation"
```

Any leading or trailing white space should be removed:

```csharp
LogLine.Message("[WARNING]:  Disk almost full\r\n")
// => "Disk almost full"
```

## 2. Get log level from a log line

Implement the (_static_) `LogLine.LogLevel()` method to return a log line's log level, which should be returned in lowercase:

```csharp
LogLine.LogLevel("[ERROR]: Invalid operation")
// => "error"
```

## 3. Reformat a log line

Implement the (_static_) `LogLine.Reformat()` method that reformats the log line, putting the message first and the log level after it in parentheses:

```csharp
LogLine.Reformat("[INFO]: Operation completed")
// => "Operation completed (info)"
```

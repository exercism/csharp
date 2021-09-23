# Instructions

In this exercise you'll be processing log-lines.

Each log line is a string formatted as follows: `"[<LEVEL>]: <MESSAGE>"`.

There are three different log levels:

- `INFO`
- `WARNING`
- `ERROR`

You have several tasks, each of which will take a log line and ask you to do something with it.

## 1. Allow retrieving the string after a specific substring

Implement the (_static_) `LogAnalysis.SubstringAfter()` extension method, that takes in some string delimeter and returns the substring after the delimiter.

```csharp
var log = "[INFO]: File Deleted.";
log.SubstringAfter(": "); // => returns "File Deleted."
```

## 2. Implement the extension method SubstringBetween

Implement the (_static_) `LogAnalysis.SubstringBetween()` extension method that takes in two string delimeters, and returns the substring that lies between the two delimeters.

```csharp
var log = "[INFO]: File Deleted.";
log.SubstringBetween("[", "]"); // => returns "INFO"
```

## 3. Parse message in a log

Implement the (_static_) `LogAnalysis.Message()` extension method to return the message contained in a log.

```csharp
var log = "[ERROR]: Missing ; on line 20.";
log.Message(); // => returns "Missing ; on line 20."
```

## 4. Parse log level in a log

Implement the (_static_) `LogAnalysis.LogLevel()` extension method to return the log level of a log.

```csharp
var log = "[ERROR]: Missing ; on line 20.";
log.LogLevel(); // => returns "ERROR"
```

# Instructions

In this exercise you will be adding extension-methods on the string type to make it easier to deal with logs. Extension-methods express intent of the code, make code more readable, and add common functionality.

The goal is to add extension-methods that abstract away the logic of finding out certain things about the log messages.

```csharp
var log = "[Error]: {Line 20} - 'Critical error found'";

log.WordCount(); // => returns 7

log.LogLevel(); // => returns "Error"

log.LogLine(); // => returns "20"

log.Truncate(10); // => returns "[Error]: {Line 20} - 'Critical error found'"

log.Truncate(5); // => returns "Error - 20"
```

## 1. Implement the extension method WordCount

Implement the (_static_) (`LogAnalysis.Word()` extension method to return the total of all words in the string. A 'word' in this case is just any string separated by a space.

## 2. Implement the extension method LogLevel

Implement the `.LogLevel()` method to return the log level of the log string.

## 3. Implement the extension method LogLine

Implement the `.LogLine()` method to return the line the log occured at of the log string.

## 4. Implement the extension method Truncate

Implement the `.Truncate(int maxSize)` method to return the log message truncated to "loglevel - logline" if the message exceeds the maximum word count specified, otherwise return the original log message.

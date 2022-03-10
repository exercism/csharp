# Instructions

This exercise addresses the parsing of log files.

After a recent security review you have been asked to clean up the organization's archived log files.

All strings passed to the methods are guaranteed to be non-null and without leading and trailing spaces.

## 1. Identify garbled log lines

You need some idea of how many log lines in your archive do not comply with current standards. You believe that a simple test reveals whether a log line is valid. To be considered valid a line should begin with one of the following strings:

- [TRC]
- [DBG]
- [INF]
- [WRN]
- [ERR]
- [FTL]

Implement the `LogParser.IsValidLine()` method to return `false` if a string is not valid otherwise `true`.

```csharp
var lp = new LogParser();
lp.IsValidLine("[ERR] A good error here");
// => true
lp.IsValidLine("Any old [ERR] text");
// => false
lp.IsValidLine("[BOB] Any old text");
// => false
```

## 2. Split the log line

A new team has joined the organization, and you find their log files are using a strange separator for "fields". Instead of something sensible like a colon ":" they use a string such as "<--->" or "<=>" (because it's prettier) in fact any string that has a first character of "<" and a last character of ">" and any combination of the following characters "^", "\*", "=" and "-" in between.

Implement the `LogParser.SplitLogLine()` method that takes a line and returns an array of strings each of which contains a field.

```csharp
var lp = new LogParser();
lp.SplitLogLine("Section 1<===>Section 2<^-^>Section 3");
// => {"Section 1", "Section 2", "Section 3"}
```

## 3. Count the number of lines containing a quoted password

The team needs to know about passwords occurring in quoted text so that they can be examined manually.

Implement the `LogParser.CountQuotedPasswords()` method to provide an indication of the likely scale of the manual exercise.

Identify log lines where the literal string "password", which may be in any combination of upper or lower case, is surrounded by quotation marks.
You should account for the possibility of additional content between the quotation marks before and after "password".

Lines passed to the routine may or may not be valid as defined in task 1. We process them in the same way, whether or not they are valid.

```csharp
string lines =
    "[INF] passWord " + Environment.NewLine + // contains 'password' but not surrounded by quotation marks
    "\"passWord\"" + Environment.NewLine + // count this one
    "[INF] User saw error message \"Unexpected Error\" on page load." + Environment.NewLine + //does not contain 'password'
    "[INF] \"The secret password was added by the user\""; // count this one

var lp = new LogParser();
lp.CountQuotedPasswords(lines);
// => 2
```

## 4. Remove artifacts from log

You have found that some upstream processing of the logs has been scattering the text "end-of-line" followed by a line number (without an intervening space) throughout the logs.

Implement the `LogParser.RemoveEndOfLineText()` method to take a string and remove the end-of-line text and return a "clean" string.

Lines not containing end-of-line text should be returned unmodified.

Just remove the end of line string. Do not attempt to adjust the whitespaces.

```csharp
var lp = new LogParser();
lp.RemoveEndOfLineText("[INF] end-of-line23033 Network Failure end-of-line27");
// => "[INF]  Network Failure "
```

## 5. Return formatted lines with secret-code

We're trying to spot for a secret-code (passed as an alphanumeric `string` parameter). Specifically, we're looking for that secret-code to be present in the lines meeting the following rules:
1. is preceded by a white-space character; e.g. ` 5up3rSecr3tC0de` - see [here](https://docs.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#whitespace-character-s)
2. is followed by one or more _non_white-space characters ; e.g. ` 5up3rSecr3tC0de123` - see [here](https://docs.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#non-whitespace-character-s)
3. is case-insensitive; e.g. ` 5Up3RSEcr3tC0dE`

Then, we want to format the lines in a specific manner to visually communicate the matches:
* when matched, the line is return prefixed with `secret-code: Loren Ipsum secret-code!`.
* Lines not containing an offending password should be returned prefixed with `-------: Loren Ipsum no secrets here`.

Example: 

```csharp
var lp = new LogParser();
lp.ListLinesWithSecret(new string[] {"This is a boring line"});
// => {"--------: This is a boring line"} // Meets no rule
lp.ListLinesWithSecret(new string[] {"[INF] Pssst whispering 5up3rsecr3tc0de..."});
// => {"5up3rsecr3tc0de...: [INF] Pssst whispering 5up3rsecr3tc0de..."} // Meets all rules
lp.ListLinesWithSecret(new string[] {"[INF] This is 5up3rSecr3tC0de <- with a space after so we're ok"});
// => {"--------: [INF] This is 5up3rSecr3tC0de <- with a space after so we're ok"} // Doesn't meet 2
```

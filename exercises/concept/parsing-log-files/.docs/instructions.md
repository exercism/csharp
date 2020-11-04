This exercise addresses the parsing of log files.

After a recent security review you have been asked to clean up the organization's archived log files.

All strings passed to the methods are guaranteed to be non-null and leading and without trailing spaces.

### 1. Identify garbled log lines

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
lp.IsMatch("[ERR] A good error here");
// => true
lp.IsMatch("Any old [ERR] text");
// => false
lp.IsMatch("[BOB] Any old text");
// => false
```

### 2. Split the log line

A new team has joined the organization, and you find their log files are using a strange separator for "fields". Instead of something sensible like a colon ":" they use a string such as "<--->" or "<=>" (because it's prettier) in fact any string that has a first character of "<" and a last character of ">" and any combination of the following characters "^", "\*", "=" and "-" in between.

Implement the `LogParser.SplitLogLine()` method that takes a line and returns an array of strings each of which contains a field.

```csharp
var lp = new LogParser();
lp.SplitLogLine("Section 1<===>Section 2<^-^>Section 3");
// => {"Section 1", "Section 2", "Section 3"}
```

### 3. Count the number of lines containing a password

A log line is considered to contain a password if it contains the literal string "password" followed by a space and then a word (the actual password).

It is important to find any passwords included in a file. These will be dealt with automatically, but the team needs to know how about passwords occurred in quoted text so that they can be examined manually.

Implement the `LogParser.CountQuotedPasswords()`method to provide an indication of the likely scale of the manual exercise.

The literal string "password" may be in upper or lower case or any combination.

Lines passed to the routine may or may not be valid as defined in task 1. We process them in the same way, whether or not they are valid.

```csharp
string lines =
    "[INF] passWord " + Environment.NewLine +
    "\"passWord\"" + Environment.NewLine +
    "[INF] \"The secret password was added by the user\"";

var lp = new LogParser();
lp.CountQuotedPasswords(lines);
// => 2
```

### 4. Remove artifacts from log

You have found that some upstream processing of the logs has been scattering the text "end-of-line" followed by a line number (without an intervening space) throughout the logs.

Implement the `LogParser.RemoveEndOfLineText()` method to take a string and remove the end-of-line text and return a "clean" string.

Lines not containing end-of-line text should be returned unmodified.

Just remove the end of line string. Do not attempt to adjust the whitespaces.

```csharp
var lp = new LogParser();
lp.RemoveEndOfLineText("[INF] end-of-line23033 Network Failure end-of-line27");
// => "[INF]  Network Failure "
```

### 5. List lines with extremely weak passwords so the guilty can be punished

Before expunging the passwords from the file we need to list any instances where passwords begin with the text "password".

Implement the `LogParser.ListLinesWithPasswords()` method to print out the offending password followed by the complete line.

Lines with quoted passwords have already been removed and you process lines irrespective of whether they are valid (as per task 1).

Lines containing an offending password should be returned prefixed with "<password>: ".

Lines not containing an offending password should be returned prefixed with "-------: ".

```csharp
var lp = new LogParser();
lp.ListLinesWithPasswords(new string[] {"my passwordsecret is great"});
// => "passwordsecret: my passwordsecret is great"
lp.ListLinesWithPasswords(new string[] {"my password secret"});
// => {"--------: my password secret"}

```

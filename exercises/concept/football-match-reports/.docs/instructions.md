You are developing a system to help the staff of a football/soccer club's web site report on matches. Data is received from a variety of sources and piped into a single stream after being cleaned up.

### 1. Output descriptions of the players based on their shirt number

The team only ever plays a 4-3-3 formation and has never agreed with the 1965 change to the rules allowing for substitutions, never mind enlarged squads.

The player descriptions are as follows:

```
1 -> "goalie"
2 -> "left back"
3 & 4 "center back"
5 -> "right back"
6, 7 & 8 -> "midfielder"
9 -> "left wing"
10 -> "striker"
11 -> "right wing"
```

Implement the static `PlayAnalyzer.AnalyzeOnField()` method to output a player description based on their shirt number.

```csharp
PlayAnalyzer.AnalyzeOnField(10);
// => "striker"
```

### 2. Raise an alert if an unknown shirt number is encountered.

Modify the `PlayAnalyzer.AnalyzeOnField()` method to throw an `ArgumentException` when a shirt number outside the range 1-11 is processed.

### 3. Extend the coverage to include off field activity

Implement the `PlayAnalyzer.AnalyzeOffField()` method to output description of activities and characters around the field of play.

You receive a stream of data that has been cleaned. Your task is to analyse it and output appropriate text to help the journalists.

The data comprises:

- shirt numbers (any `int`) -> text as per on field analysis
- free form text (any `string`) -> the text unchanged
- incidents in play (any subclass of the type `Incident`) -> "Injury", "Foul" etc.
- opposing managers (objects of type `Manager`) -> "the manager"

```csharp
PlayAnalyzer.AnalyzeOffField(new Injury());
// => "A player is injured. Medics are on the field."
PlayAnalyzer.AnalyzeOffField(new Manager());
// => "the manager"
```

### 4. Where the manager has a name available we want that output instead of "the manager"

Modify the `PlayAnalyzer.AnalyzeOffField()` method to output any name such as "Jürgen Klopp" if there is one. If there is no name then the `Manager.Name` property is guaranteed to be an empty string rather than null.

```csharp
PlayAnalyzer.AnalyzeOffField(new Manager("José Mário dos Santos Mourinho Félix", string.Empty))
// => "José Mário dos Santos Mourinho Félix"
```

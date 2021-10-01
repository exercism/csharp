# Instructions

You are developing a system to help the staff of a football/soccer club's web site report on matches. 
This system is capable of analyzing different aspects in the match, both on and off the field, and converts them into a stream of events.

## 1. Output descriptions of the players based on their shirt number

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

## 2. Raise an alert if an unknown shirt number is encountered

Modify the `PlayAnalyzer.AnalyzeOnField()` method to throw an `ArgumentOutOfRangeException` when a shirt number outside the range 1-11 is processed.

## 3. Extend the coverage to include off field activity

Implement the `PlayAnalyzer.AnalyzeOffField()` method to output descriptions of activities and characters around the field of play.
This method receives different types of data that should be analyzed and converted to appropriate text to help the journalists.

To start off, we will cover data about the stadium:

- The current number of supporters in the stadium (any `int`)
- Announcements made over the stadium's PA system (any `string`)

Unknown types of data should not be processed, so if the method receives data of a different type an `ArgumentException` should be thrown.

```csharp
PlayAnalyzer.AnalyzeOffField(5000);
// => "There are 5000 supporters at the match."

PlayAnalyzer.AnalyzeOffField("5 minutes to go!");
// => "5 minutes to go!"

PlayAnalyzer.AnalyzeOffField(0.5);
// => throws ArgumentException
```

## 4. Report on incidents during the match

Modify the `PlayAnalyzer.AnalyzeOffField()` method to output descriptions of incidents that happen during the match. 

Incidents can be any subclass of the `Incident` type, and will contain a description of the incident. 
Injuries are a special kind of incident because they cause the match to be put on hold, so they should be treated differently. 

```csharp
PlayAnalyzer.AnalyzeOffField(new Foul());
// => "The referee deemed a foul."

PlayAnalyzer.AnalyzeOffField(new Injury(8));
// => "Oh no! Player 8 is injured. Medics are on the field.
```

## 5. Report on club managers

Modify the `PlayAnalyzer.AnalyzeOffField()` method to mention the club managers present during the match.

Managers are instances of the `Manager` type and have a name and the name of the club they manage. 
The manager's club may be unknown, in which case it will be set to `null`. 
If a manager's club is not known, it should not be part of the description.

```csharp
PlayAnalyzer.AnalyzeOffField(new Manager("José Mário dos Santos Mourinho Félix", null));
// => "José Mário dos Santos Mourinho Félix"

PlayAnalyzer.AnalyzeOffField(new Manager("Jürgen Klopp", "Liverpool"));
// => "Jürgen Klopp (Liverpool)"
```

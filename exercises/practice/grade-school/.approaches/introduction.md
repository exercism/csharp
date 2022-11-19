# Introduction

The key to this exercise is to keep track of students in different grades, whilst outputting them in a natural sorting order.

## General guidance

- Carefully consider which data structure to use, as there are specialized data structures that are optimized for sorting data

## Approach: sorted collections

```csharp
private readonly SortedDictionary<int, SortedSet<string>> _roster = new();

public bool Add(string student, int grade)
{
    if (_roster.Values.Any(students => students.Contains(student)))
        return false;

    if (!_roster.TryAdd(grade, new SortedSet<string> { student }))
        _roster[grade].Add(student);

    return true;
}

public IEnumerable<string> Roster() => _roster.Values.SelectMany(students => students);

public IEnumerable<string> Grade(int grade) =>
    _roster.TryGetValue(grade, out var students) ? students : Enumerable.Empty<string>();
```

This approach uses a [sorted collection types][sorted-collections-types] to not have to explicitly deal with sorting collections.
For more information, check the [sorted collections approach][approach-sorted-collections].

[approach-sorted-collections]: https://exercism.org/tracks/csharp/exercises/grade-school/approaches/sorted-collections
[sorted-collections-types]: https://learn.microsoft.com/en-us/dotnet/standard/collections/sorted-collection-types

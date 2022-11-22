# Sorted collections

```csharp
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
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
}
```

## Choice of data structures

A key component of this exercise is on to return the data in a specific order.
Whilst LINQ has an [`OrderBy()` method][linq.order-by] that works on any collection type, there are also specialized data structures that are specifically designed to have sorting built-in.

So instead of using an array of list, we'll be using the `SortedDictionary<K, T>` and `SortedSet<T>` data structures.
These data structures will always return data in sorted order (either some default or custom ordering), so we don't have to worry about that.

We can store the students in a grade (which is a collection of strings) in a `SortedSet<string>`, as we cannot have duplicate names in a grade.

As an example, here's how iterating a `SortedSet<string>` looks like:

```csharp
var names = new SortedSet<string>();
names.Add("john");
names.Add("paul");
names.Add("george");
names.Add("ringo");

foreach (var name in names)
    Console.WriteLine(name);

// Outputs: george, john, paul, ringo
```

For the mapping between a grade (which is an integer) and its students, we'll use a `SortedDictionary<int, SortedSet<string>>`.
We'll refer to this grade to student mapping as our _roster_, and define a `private readonly` field for it:

```csharp
private readonly SortedDictionary<int, SortedSet<string>> _roster = new();
```

## Method: `Add()`

The first step is to prevent a student from being added twice (regardless whether the grade matches).
We can do that by check if any grade contains that student, and if so, return `false`:

```csharp
if (_roster.Values.Any(students => students.Contains(student)))
    return false;
```

Having verified that the student does not exist, to add the student to the right grade, we first need to check if there already are students in the specified grade.
If so, we'll add the student to the existing students set, otherwise we'll create a new set with the student:

```csharp
if (_roster.ContainsKey(grade))
    _roster[grade].Add(student);
else
    _roster[grade] = new SortedSet<string> { student };
```

```exercism/note
Not that we don't worry about sorting, this will all happen transparently due to our choice of data structures.
```

We could also rewrite this to:

```csharp
if (!_roster.ContainsKey(grade))
    _roster[grade] = new SortedSet<string>();

_roster[grade].Add(student);
```

To me, this reads somewhat better.

A slightly more performant approach is to use the `TryAdd()` method, which takes a key and the value to add when the key does not exist, whilst also returning a `bool` indicating if the key did not exist and the value was just added:

```csharp
if (!_roster.TryAdd(grade, new SortedSet<string> { student }))
    _roster[grade].Add(student);
```

Finally, we'll need to return `true` to indicate that a new student was added:

```csharp
return true;
```

## Method: `Roster()`

To get all the students names in the roster, order ascendingly by grade and then by studnet name, we can just iterate over

```csharp
public IEnumerable<string> Roster()
{
    var students = new List<string>();

    foreach (var (grade, studentsInGrade) in _roster)
        students.AddRange(studentsInGrade);

    return students;
}
```

We can shorten this by using the dictionary's `Values` property to only return its values: `_roster.Values`.
This will, for our dictionary, return a collection of `SortedSet<string>` instances.
To only return a single, flat enumerable, we can use [`Enumerable.SelectMany()`][enumerable.select-many]:

```csharp
public IEnumerable<string> Roster()
{
    return _roster.Values.SelectMany(students => students);
}
```

### Shortening

We can shorten our single-statement method to an [expression-bodied method][expression-bodied-method]:

```csharp
public IEnumerable<string> Roster() =>
    _roster.Values.SelectMany(students => students);
```

## Method: `Grade()`

For the `Grade()` method, we'll have to deal with two cases:

1. The roster has students in the specified grade
1. The roster does not have students in the specified grade

An initial attempt to implement this logic could look like this:

```csharp
public IEnumerable<string> Grade(int grade)
{
    if (_roster.ContainsKey(grade))
        return _roster[grade];

    return Enumerable.Empty<string>();
}
```

```exercism/note
The pattern of checking if a dictionary contains a key followed by accessing that value by key after that check is slightly wasteful, as it will require accessing the dictionary twice.
For this pattern, you should instead use `TryGetValue()`, which returns a `bool` value indicating if the key exists and has an `out` parameter for the retrieved value (if any)
```

```exercism/note
We're using [`Enumerable.Empty<string>()`](https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.empty), which is best practice when returning an empty enumerable (for performance reasons).
```

With this knowledge, let's rewrite out method a bit:

```csharp
public IEnumerable<string> Grade(int grade)
{
    if (_roster.TryGetValue(grade, out var students))
        return students;

    return Enumerable.Empty<string>();
}
```

We've now gotten rid of the additional indexer access.
Nice!

### Shortening

We could rewrite our logic to a single statement using the [ternary operator][ternary-operator]:

```csharp
public IEnumerable<string> Grade(int grade)
{
    return _roster.TryGetValue(grade, out var students)
        ? students
        : Enumerable.Empty<string>();
}
```

As our method now only has a single statement, we can then rewrite it to an [expression-bodied method][expression-bodied-method]:

```csharp
public IEnumerable<string> Grade(int grade) =>
    _roster.TryGetValue(grade, out var students) ? students : Enumerable.Empty<string>();
```

[expression-bodied-method]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#methods
[sorted-set]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedset-1
[sorted-dictionary]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2
[linq.order-by]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.orderby
[ternary-operator]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
[enumerable.select-many]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.selectmany

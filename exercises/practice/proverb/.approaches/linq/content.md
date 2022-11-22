# LINQ

```csharp
using System;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0)
            return Array.Empty<string>();

        return subjects.Zip(subjects.Skip(1))
            .Select((pair => $"For want of a {pair.First} the {pair.Second} was lost."))
            .Append($"And all for the want of a {subjects.First()}.")
            .ToArray();
    }
}
```

In this approach, we'll use [LINQ][linq] to iterate over the subjects and compose the song's lines.

## Song structure

Before we start writing code, let's examine the structure of the song's lines we'll need to return.
There are three different situations we have to handle:

1. No subjects: return an empty array
2. One subject: return an array with one element: "And all for the want of a &lt;SUBJECT&gt;."
3. Multiple subjects: return an array of length equal to the number of subjects. All but the last line are of the form: "For want of a &lt;SUBJECT&gt; the &lt;NEXT_SUBJECT&gt; was lost.", where "&lt;SUBJECT&gt;" and "&lt;NEXT_SUBJECT&gt;" are adjacent subjects (subjects at index 0 and 1, then 1 and 2, etc.). The last line is of the form "And all for the want of a &lt;FIRST_SUBJECT&gt;.", where "&lt;FIRST_SUBJECT&gt;" is the first subject.

## Subjects: none

Let's check the number of subjects via the array's `Length` property.
If the length is equal to `0`, return an empty array:

```csharp
if (subjects.Length == 0)
    return Array.Empty<string>();
```

Alternatively, you could also use the [`Any()`][enumerable.any] method:

```csharp
if (!subjects.Any())
    return Array.Empty<string>();
```

```exercism/note
As the `!` operator can be easy to miss whilst reading code, try to write code that doesn't use negation (where possible).
```

## Subjects: one

The case for one subject is easy enough:

```csharp
if (subjects.Length == 1)
    return $"And all for the want of a {subjects[0]}."
```

Or alternatively using [`First()`][enumerable.first]:

```csharp
if (subjects.Length == 1)
    return $"And all for the want of a {subjects.First()}."
```

This has the benefit of being more expressive _and_ would also work for collection that don't implement the `ICollection<T>` interface (e.g. `IEnumerable<T>`).

## Subjects: multiple

Handling multiple subjects is where the fun begins!
To reiterate, there will be one line in the returned array for each adjacent subject pair.

```exercism/note
Breaking up of a collection into adjacent sub-collection of a certain size of sometimes also referred to as a _sliding window_.
```

Let's look at an example, where the subjects array contains `"nail"`, `"shoe"` and `"horse"`.
There are two adjacent subject pairs in this array:

1. `"nail"` and `"shoe"`
2. `"shoe"` and `"horse"`

These pairs then should result in the following two lines:

1. `"For want of a nail the shoe was lost."`
2. `"For want of a shoe the horse was lost."`

So how do we use LINQ to create an enumerable of these pairs?
We can use a little trick by calling the [`Zip()` method][enumerable.zip] on the subjects array with its arguments being the same subjects array but without the first element.

What `Zip()` does is that it works on two enumerables and creates a new enumerable where element is a pair (tuple) of values, the first element being the n-th value of the first enumerable and the second element being the n-th value of the second enumerable.

```exercism/note
The number of elements returned by `Zip()` is equal to the minimum of the lengths of both enumerables.
```

As an example:

```csharp
new[] { "nail", "shoe", "horse" }.Zip({ "shoe", "horse" })
```

will return an enumerable that contains two elements (tuples):

```csharp
{ ("nail", "shoe"), ("shoe", "horse") }
```

We can then use the [`Select()` method][enumerable.select] to convert these pairs (tuples) into the correct string:

```csharp
subjects
  .Zip(subjects.Skip(1))
  .Select((pair => $"For want of a {pair.First} the {pair.Second} was lost."))
```

### And all for the want of a ...

The last line is of the form: "And all for the want of a &lt;FIRST_SUBJECT&gt;.", which translates to:

```csharp
$"And all for the want of a {subjects.First()}."
```

We can then add this line to the end of the other lines by calling [`Append()`][enumerable.append]:

```
.Append($"And all for the want of a {subjects.First()}.")
```

## Putting it all together

The final step is to call [`ToArray()`][enumerable.to-array] to return the correct collection type, giving us the following implementation:

```csharp
if (subjects.Length == 0)
    return Array.Empty<string>();

if (subjects.Length == 1)
    return $"And all for the want of a {subjects.First()}."

return subjects.Zip(subjects.Skip(1))
    .Select((subject => $"For want of a {subject.First} the {subject.Second} was lost."))
    .Append($"And all for the want of a {subjects.First()}.")
    .ToArray();
```

## Simplification

As this code also works for subjects with one element, we can remove the custom logic for handling one element:

```csharp
if (subjects.Length == 0)
    return Array.Empty<string>();

return subjects.Zip(subjects.Skip(1))
    .Select((pair => $"For want of a {pair.First} the {pair.Second} was lost."))
    .Append($"And all for the want of a {subjects.First()}.")
    .ToArray();
```

## Alternative: single expression

Can we do anything about to move the logic of that `if` statement to within our main method chain?
Well, yes we can!
To so, we'll remove the `if` statement and replace the call to `Append()` with a call to [`Concat()` method].
Using the [ternary operator][ternary-operator], we'll pass either an empty array (if there are no subjects) or an array with just one element ("And all for the want of a...") as its argument:

```csharp
.Concat(subjects.Any() ? new[] { $"And all for the want of a {subjects.First()}." } : Array.Empty<string>())
```

The reason we need to use the ternary operator is because `subjects.First()` would throw an exception if there are no subjects.

### Shortening

As our method now contains only a single expression, we could rewrite it to an [expression-bodied method][expression-bodied-method]:

```csharp
public static string[] Recite(string[] subjects) =>
    subjects.Zip(subjects.Skip(1))
        .Select((subject => $"For want of a {subject.First} the {subject.Second} was lost."))
        .Concat(subjects.Any() ? new[] { $"And all for the want of a {subjects.First()}." } : Array.Empty<string>())
        .ToArray();
```

[expression-bodied-method]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#methods
[enumerable.select]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select
[enumerable.to-array]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.toarray
[enumerable.zip]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.zip
[enumerable.concat]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.concat
[enumerable.skip]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.skip
[enumerable.any]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any
[enumerable.first]: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.first
[array.empty]: https://learn.microsoft.com/en-us/dotnet/api/system.array.empty
[linq]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[ternary-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator

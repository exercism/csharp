# `for` loop

```csharp
public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length > 0)
            return Array.Empty<string>();

        var lines = new string[subjects.Length];

        for (int i = 0; i < subjects.Length - 1; i++)
            lines[i] = $"For want of a {subjects[i]} the {subjects[i + 1]} was lost.";

        lines[^1] = $"And all for the want of a {subjects[0]}.";

        return lines;
    }
}
```

This approach uses a [`for` loop][for-loop] to iterate over the subjects and compose the song's lines.

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

## Subjects: one

To implement the case for one subject, we can just return an array with one element that has the correct structure:

```csharp
return new[] { $"And all for the want of a {subjects[0]}." };
```

## Subjects: multiple

Handling multiple subjects is where the fun begins!

As the array we want to return must have a length equal to the number of subjects, let's start by defining this array:

```csharp
var lines = new string[subjects.Length];
```

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

So how do we process there adjacent subject pairs?
If we think of the pairs as pairs of indexes (`0` and `1`, `1` and `2`), we can see that the starting index of these pairs (`0` and `1`) is less than the length of the subjects minus one.
That translates to:

```csharp
for (int i = 0; i < subjects.Length - 1; i++)
```

Within the `for` loop, we set each line using its correct value, using the subject at index `i` and its adjacent subject at index `i + 1`:

```csharp
for (int i = 0; i < subjects.Length - 1; i++)
    lines[i] = $"For want of a {subjects[i]} the {subjects[i + 1]} was lost.";
```

### And all for the want of a ...

The last line is of the form: "And all for the want of a &lt;FIRST_SUBJECT&gt;.", which translates to:

```csharp
lines[lines.Length - 1] = $"And all for the want of a {subjects[0]}."
```

The last line's index is calculated via `lines.Length - 1`, but this is quite ugly, so is there a more elegant way?
Why yes, there is, by using the [index from end operator][index-from-end-operator] (`^`):

```csharp
lines[^1] = $"And all for the want of a {subjects[0]}."
```

### Simplification

As this code also works for subjects with one element, we can remove the code we've previously written to handle one subject.

## Putting it all together

The final step is to return the lines, giving us:

```csharp
if (subjects.Length > 0)
    return Array.Empty<string>();

var lines = new string[subjects.Length];

for (int i = 0; i < subjects.Length - 1; i++)
    lines[i] = $"For want of a {subjects[i]} the {subjects[i + 1]} was lost.";

lines[^1] = $"And all for the want of a {subjects[0]}.";

return lines;
```

[for-loop]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/for
[index-from-end-operator]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#index-from-end-operator-

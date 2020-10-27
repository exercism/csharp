A dictionary is a collection of elements where each element comprises a key and value such that if a key is passed to a method of the dictionary its associated value is returned. It has the same role as maps or associative arrays do in other languages.

A dictionary can be created as follows:

```csharp
new Dictionary<int, string>
{
    {1, "One"},
    {2, "Two"}
};
// 1 => "One", 2 => "Two"
```

Note that the key and value types are part of the definition of the dictionary.

Once constructed, entries can be added or removed from a dictionary using its built-in methods.

Retrieving or updating values in a dictionary is done by indexing into the dictionary using a key:

```csharp
var numbers = new Dictionary<int, string>
{
   {1, "One"},
   {2, "Two"}
};

// Set the value of the element with key 2 to "Deux"
numbers[2] = "Deux";

// Get the value of the element with key 2
numbers[2];
// "Deux"
```

You can test if a value exists in the dictionary with:

```csharp
var dict = new Dictionary<string, string>{/*...*/};
dict.ContainsKey("some key that exists");
// => true
```

Enumerating over a dictionary will enumerate over its key/value pairs. Dictionaries also have properties that allow enumerating over its keys or values.

[indexer-properties]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/

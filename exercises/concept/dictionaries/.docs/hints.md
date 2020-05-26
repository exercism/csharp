### 1. Create a new dictionary

A dictionary is like any other class. You simply 'new' it to create an empty instance.

### 2. Create a pre-populated dictionary

Although it's possible to populate a dictionary by repeatedly adding items, dictionaries can be initialized statically.

See [this article][dictionary_static_initialization].

### 3. Add a country to an empty dictionary

See [Add][dictionary_add]. Pass in the dictionary returned by task 1 as a parameter.

### 4. Add a country to an existing dictionary

There is no substantial difference between adding an item to an empty or initialized dictionary. Pass in the dictionary returned by task 2 as a parameter.

### 5. Get the country name matching a country Code

See [this article][dictionary_item].

### 6. Attempt to get country name for a non-existent country code

You need to [detect][dictionary_contains_key] whether the country is present in the dictionary.

### 7. Attempt to get country name for a non-existent country code

You can combine what you've learnt in Tasks 5 and 6 to solve this one.

### 8. Update a country name

Again [this article][dictionary_item] applies.

### 9. Attempt to ypdate name of country that is not in the dictionary

This is very similar to task 7.

### 10. Remove a country from the dictionary

See [this article][dictionary_remove].

### 11. Find the country with the longest name

See the [values collection][dictionary_values], [string length][string_length] and [foreach][foreach].

[dictionary_static_initialization]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-a-dictionary-with-a-collection-initializer
[dictionary_add]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.add?view=netcore-3.1
[dictionary_item]: https://docs.microsoft.com/en-gb/dotnet/api/system.collections.generic.dictionary-2.item?view=netcore-3.1
[dictionary_contains_key]: https://docs.microsoft.com/en-gb/dotnet/api/system.collections.generic.dictionary-2.containskey?view=netcore-3.1
[dictionary_remove]: https://docs.microsoft.com/en-gb/dotnet/api/system.collections.generic.dictionary-2.remove?view=netcore-3.1
[dictionary_values]: https://docs.microsoft.com/en-gb/dotnet/api/system.collections.generic.dictionary-2.values?view=netcore-3.1
[foreach]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/foreach-in
[string_length]: https://docs.microsoft.com/en-gb/dotnet/api/system.string.length?view=netcore-3.1#System_String_Length

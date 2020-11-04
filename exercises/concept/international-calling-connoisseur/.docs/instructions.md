In this exercise you'll be writing code to keep track of international dialling codes via an international dialing code dictionary.

The dictionary uses an integer for its keys (the dialing code) and a string (country name) for its values.

You have 11 tasks which involve DialingCodes.

### 1. Create a new dictionary

```csharp
DialingCodes.GetEmptyDictionary();
// empty dictionary
```

### 2. Create a pre-populated dictionary

There exists a pre-populated dictionary which contains the following 3 dialing codes: "United States of America" which has a code of 1, "Brazil" which has a code of 55 and "India" which has a code of 91. Implement the (static) `DialingCodes.GetExistingDictionary()` method to return the pre-populated dictionary:

```csharp
DialingCodes.GetExistingDictionary();
// 1 => "United States of America", 55 => "Brazil", 91 => "India"
```

### 3. Add a country to an empty dictionary

Add "United Kingdom" with a dialing code of 44:

```csharp
DialingCodes.AddCountryToEmptyDictionary(44, "United Kingdom");
// 44 => "United Kingdom"
```

### 4. Add a country to an existing dictionary

Add "United Kingdom" with a dialing code of 44 to the dictionary created in task 2:

```csharp
DialingCodes.AddCountryToExistingDictionary(DialingCodes.GetExistingDictionary(),
  44, "United Kingdom");
// 1 => "United States of America", 44 => "United Kingdom", 55 => "Brazil", 91 => "India"
```

### 5. Get the country name matching a country code

Check that a country with the country name for dialing code 55

```csharp
DialingCodes.GetCountryNameFromDictionary(
  DialingCodes.GetExistingDictionary(), 55);
// "Brazil"
```

### 6. Check that a country exists in the dictionary

Check that a record for Brazil exists in the dictionary created in task 2

```csharp
DialingCodes.CheckCodeExists(DialingCodes.GetExistingDictionary(), 55);
// true
```

### 7. Attempt to get country name for a non-existent country code

Request the country name for a code that is not in the existing dictionary, e.g. 999. An empty string should be returned:

```csharp
DialingCodes.GetCountryNameFromDictionary(
  DialingCodes.GetExistingDictionary(), 999);
// string.Empty
```

### 8. Update a country name

Change the name of "United States of America" to "Les États-Unis":

```csharp
DialingCodes.UpdateDictionary(
  DialingCodes.GetExistingDictionary(), 1, "Les États-Unis");
// 1 => "Les États-Unis", 55 => "Brazil", 91 => "India"
```

### 9. Attempt to update name of country that is not in the dictionary

Try to change the name of a country with a code that is not in the dictionary e.g. 999. This should result in no change to the dictionary:

```csharp
DialingCodes.UpdateDictionary(
  DialingCodes.GetExistingDictionary(), 999, "Newlands");
// 1 => "United States of America", 55 => "Brazil", 91 => "India"
```

### 10. Remove a country from the dictionary

Remove India from the dictionary:

```csharp
DialingCodes.RemoveCountryFromDictionary(
  DialingCodes.GetExistingDictionary(), 91);
// 1 => "United States of America", 55 => "Brazil"
```

### 11. Find the country with the longest name

Process the values in the dictionary to find the one with the longest name:

```csharp
DialingCodes.FindLongestCountryName(
  DialingCodes.GetExistingDictionary());
// "United States of America"
```

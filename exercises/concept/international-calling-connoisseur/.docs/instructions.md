In this exercise you'll be writing code to keep track of international dialling codes via an international dialing code dictionary.

The dictionary uses an integer for its keys (the dialing code) and a string (country name) for its values.

You have 9 tasks which involve the  `DialingCodes` static class.

### 1. Create a new dictionary

Implement the (static) method `DialingCodes.GetEmptyDictionary()` that returns an empty dictionary.

```csharp
DialingCodes.GetEmptyDictionary();
// => empty dictionary
```

### 2. Create a pre-populated dictionary

There exists a pre-populated dictionary which contains the following 3 dialing codes: "United States of America" which has a code of 1, "Brazil" which has a code of 55 and "India" which has a code of 91. Implement the (static) `DialingCodes.GetExistingDictionary()` method to return the pre-populated dictionary:

```csharp
DialingCodes.GetExistingDictionary();
// => 1 => "United States of America", 55 => "Brazil", 91 => "India"
```

### 3. Add a country to an empty dictionary

Implement the (static) method `DialingCodes.AddCountryToEmptyDictionary()` that creates a dictionary and adds a dialing code and associated country name to it.

```csharp
DialingCodes.AddCountryToEmptyDictionary(44, "United Kingdom");
// => 44 => "United Kingdom"
```

### 4. Add a country to an existing dictionary

Implement the (static) method `DialingCodes.AddCountryToExistingDictionary()` that adds a dialing code and associated country name to a non-empty dictionary.

```csharp
DialingCodes.AddCountryToExistingDictionary(DialingCodes.GetExistingDictionary(),
  44, "United Kingdom");
// => 1 => "United States of America", 44 => "United Kingdom", 55 => "Brazil", 91 => "India"
```

### 5. Get the country name matching a dialing code

Implement the (static) method `DialingCodes.GetCountryNameFromDictionary()` that takes a dialing code and returns the corresponding country name. If the dialing code is not contained in the dictionary then an empty string is returned.

```csharp
DialingCodes.GetCountryNameFromDictionary(
  DialingCodes.GetExistingDictionary(), 55);
// => "Brazil"

DialingCodes.GetCountryNameFromDictionary(
  DialingCodes.GetExistingDictionary(), 999);
// => string.Empty
```

### 6. Check that a country exists in the dictionary

Implement the (static) method `DialingCodes.CheckCodeExists()` to check whether a dialing code exists in the dictionary.

```csharp
DialingCodes.CheckCodeExists(DialingCodes.GetExistingDictionary(), 55);
// => true
```

### 7. Update a country name

Implement the (static) method `DialingCodes.UpdateDictionary()` which takes a dialing code and replaces the corresponding country name in the dictionary with the country name passed as a parameter. If the dialing code does not exist in the dictionary then the dictionary remains unchanged.

```csharp
DialingCodes.UpdateDictionary(
  DialingCodes.GetExistingDictionary(), 1, "Les États-Unis");
// => 1 => "Les États-Unis", 55 => "Brazil", 91 => "India"

DialingCodes.UpdateDictionary(
  DialingCodes.GetExistingDictionary(), 999, "Newlands");
// 1 => "United States of America", 55 => "Brazil", 91 => "India"
```

### 8. Remove a country from the dictionary

Implement the (static) method `DialingCodes.RemoveCountryFromDictionary()` that takes a dialing code and will remove the corresponding record, dialing code + country name, from the dictionary.

```csharp
DialingCodes.RemoveCountryFromDictionary(
  DialingCodes.GetExistingDictionary(), 91);
// => 1 => "United States of America", 55 => "Brazil"
```

### 9. Find the country with the longest name

Implement the (static) method `DialingCodes.FindLongestCountryName()` which will return the name of the country with the longest name stored in the dictionary.

```csharp
DialingCodes.FindLongestCountryName(
  DialingCodes.GetExistingDictionary());
// => "United States of America"
```

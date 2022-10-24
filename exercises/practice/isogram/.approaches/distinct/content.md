```csharp
var lowerLetters = word.ToLower().Where(char.IsLetter).ToList();
return lowerLetters.Distinct().Count() == lowerLetters.Count;
```

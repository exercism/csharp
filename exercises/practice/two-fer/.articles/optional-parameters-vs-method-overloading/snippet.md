```csharp
public static string SpeakOptional(string name = "you") =>
    $"One for {name}, one for me.";

public static string SpeakOverload() =>
    return Speak("you");

public static string SpeakOverload(string name) =>
    return $"One for {name}, one for me.";
```

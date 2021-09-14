# Introduction

Extension methods allow adding methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.

```csharp
public static bool IsEven(this int number)
{
    return number % 2 == 0;
}

int isEven = 3.IsEven();
// isEven == false

public static int WordCount(this string str)
{
    return str.Split().Length;
}

int wordCount = "Hello World!".WordCount();
// wordCount == 2
```

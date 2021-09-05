# Introduction

Extension methods allow adding methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.

```csharp
public static int Sum(this IEnumerable<int> input)
{
    var sum = 0;
    foreach(int n in input)
    {
        sum += n;
    }
    return sum;
}

int sum = new int[]{1, 2, 3, 4}.Sum();
// sum == 10

public static int WordCount(this String str)
{
    return str.Split(new char[] { ' ', '.', '?' },
        StringSplitOptions.RemoveEmptyEntries
    ).Length;
}

int wordCount = "Hello World!".WordCount();
// wordCount == 2
```

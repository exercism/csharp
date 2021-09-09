# Introduction

Extension methods allow adding methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type.

```csharp
public static int WordCount(this string str)
{
    return str.Split().Length;
}

"Hello World".WordCount();
// => 2
```

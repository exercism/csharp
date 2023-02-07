# Introduction

## Extension Methods

Extension methods allow adding methods to existing types without creating a new derived type, recompiling, or otherwise modifying the original type. They are defined as static methods but are called by using instance method syntax. Their first parameter is preceded by the `this` modifier, and specifies which type the method operates on, and are brought into scope at the namespace level.

```csharp
public static int WordCount(this string str)
{
    return str.Split().Length;
}

"Hello World".WordCount();
// => 2
```

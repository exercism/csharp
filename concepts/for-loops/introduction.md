If you want more control over which values to iterate over, a `for` loop can be used:

```csharp
char[] vowels = new [] { 'a', 'e', 'i', 'o', 'u' };

for (int i = 0; i < 3; i++)
{
    // Output the vowel
    System.Console.Write(vowels[i]);
}

// => aei
```

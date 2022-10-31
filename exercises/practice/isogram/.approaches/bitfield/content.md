# Bit field

```csharp
public static class Isogram
{
    public static bool IsIsogram(string word) {
    int letter_flags = 0;
        foreach (char letter in word)
        {
            if (letter >= 'a' && letter <= 'z')
            {
                if ((letter_flags & (1 << (letter - 'a'))) != 0)
                    return false;
                else
                    letter_flags |= (1 << (letter - 'a'));
            }
            else if (letter >= 'A' && letter <= 'Z')
            {
                if ((letter_flags & (1 << (letter - 'A'))) != 0)
                    return false;
                else
                    letter_flags |= (1 << (letter - 'A'));
            }
        }
        return true;    
    }
}
```

This solution uses the [ASCII][ascii] value of the letter to set the corresponding bit position.

The `string` loops through its characters and looks for a character being `a` through `z` or `A` through `Z`.
The ASCII value for `a` is `97`, and for `z` is `122`.
The ASCII value for `A` is `65`, and for `Z` is `90`.

- If the lower-cased letter is subtracted by `a`, then `a` will result in `0`, because `97` minus `97`  equals `0`.
`z` would result in `25`, because `122` minus `97` equals `25`.
So `a` would have `1` [shifted left][shift-left] 0 places (so not shifted at all) and `z` would have `1` shifted left 25 places.
- If the upper-cased letter is subtracted by `A`, then `A` will result in `0`, because `65` minus `65`  equals `0`.
`Z` would result in `25`, because `90` minus `65` equals `25`.
So `A` would have `1` [shifted left][shift-left] 0 places (so not shifted at all) and `Z` would have `1` shifted left 25 places.

In that way, both a lower-cased `z` and an upper-cased `Z` can share the same position in the bit field.

So, for an unsigned thirty-two bit integer, if the values for `a` and `Z` were both set, the bits would look like

```
      zyxwvutsrqponmlkjihgfedcba
00000010000000000000000000000001
```

We can use the [bitwise AND operator][and] to check if a bit has already been set.
If it has been set, we know the letter is duplicated and we can immediately return `false`.
If it has not been set, we can use the [bitwise OR operator][or] to set the bit.
If the loop completes without finding a duplicate letter (and returning `false`), the function returns `true`.

This approach may be considered to be more idiomatic of the C language than C#.
It is fast, but it only works with the `ASCII` alphabet.

[ascii]: https://www.asciitable.com/
[shift-left]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#left-shift-operator-
[or]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-or-operator-
[and]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-and-operator-

```csharp
        int phrasemask = 0;
        foreach (char letter in input)
        {
            // a-z
            if (letter > 96 && letter < 123)
                phrasemask |= 1 << (letter - 97);
            // A - Z
            else if (letter > 64 && letter < 91)
                phrasemask |= 1 << (letter - 65);
        }
        //26 binary 1s
        return phrasemask == 67108863;
```

This solution uses the [ASCII][ascii] value of the letter to set the corresponding bit position.

If the lower-cased letter is subtracted by `a` (which is ASCII `97`), then `a` will result in `0`, and `z` would result in `25`. So `a` would have `1` [shifted left][shift-left] 0 places (so not shifted at all) and `z` would have `1` shifted left 25 places. So, for an unsigned thirty-two bit integer, if the values from `a` and `z` were set, the bits would look like

```
      zyxwvutsrqponmlkjihgfedcba
00000010000000000000000000000001
```

We can use the [bitwise OR operator][or] to set the bit.
After the loop completes, the function returns if the `phrasemask` value is the same value as when all `26` bits are set.

This approach may be considered to be more idiomatic of the C language than C#.
It is fast, but it only works with the `ASCII` alphabet.

[ascii]: https://www.asciitable.com/
[shift-left]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#left-shift-operator-
[or]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-or-operator-

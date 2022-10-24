```csharp
        int letter_flags = 0;
        foreach (char letter in word)
        {
            if (letter >= 'a' && letter <= 'z')
            {
                // shift 1 to the left for the letter's place in the alphabet
                if ((letter_flags & (1 << (letter - 'a'))) != 0)
                    return false;
                else
                    letter_flags |= (1 << (letter - 'a'));
            }
            else if (letter >= 'A' && letter <= 'Z')
            {
                // shift 1 to the left for the letter's place in the alphabet
                if ((letter_flags & (1 << (letter - 'A'))) != 0)
                    return false;
                else
                    letter_flags |= (1 << (letter - 'A'));
            }
        }
        return true;
```

This solution uses the [ASCII][ascii] value of the letter to set the corresponding bit position.

If the lower-cased letter is subtracted by `a`, then `a` will result in `0`, and `z` would result in `25`. So `a` would have `1`  shifted left 0 places (so not shifted at all) and `z` would have `1` shifted left 25 places. So, for an unsigned thirty-two bit integer, if the values from `a` and `z` were set, the bits would look like

```
      zyxwvutsrqponmlkjihgfedcba
00000010000000000000000000000001
```

We can use the [bitwise AND operator][and] to check if a bit has already been set.
If it has been set, we know the letter is duplicated and we can immediately return `false`.
If it has not been set, we can use the [bitwise OR operator][or] to set the bit.
If the loop completes without finding a duplicate letter and returning `false`, the function returns `true`.

This approach may be considered to be more idiomatic of the C language than C#.
It is fast, but it only works with the `ASCII` alphabet.

[ascii]: https://www.asciitable.com/
[or]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-or-operator-
[and]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-and-operator-

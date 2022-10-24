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
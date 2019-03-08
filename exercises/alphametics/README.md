# Alphametics

Write a function to solve alphametics puzzles.

[Alphametics](https://en.wikipedia.org/wiki/Alphametics) is a puzzle where
letters in words are replaced with numbers.

For example `SEND + MORE = MONEY`:

```text
  S E N D
  M O R E +
-----------
M O N E Y
```

Replacing these with valid numbers gives:

```text
  9 5 6 7
  1 0 8 5 +
-----------
1 0 6 5 2
```

This is correct because every letter is replaced by a different number and the
words, translated into numbers, then make a valid sum.

Each letter must represent a different digit, and the leading digit of
a multi-digit number must not be zero.

Write a function to solve alphametics puzzles.

## Hints
- To parse the text, you could try to use the [Sprache](https://github.com/sprache/Sprache/blob/develop/README.md) library. You can also find a good tutorial [here](https://www.thomaslevesque.com/2017/02/23/easy-text-parsing-in-c-with-sprache/).
- You can solve this exercise with a brute force algorithm, but this will possibly have a poor runtime performance.
Try to find a more sophisticated solution. 
- Hint: You could try the column-wise addition algorithm that is usually taught in school.


## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

Initially, only the first test will be enabled. This is to encourage you to solve the exercise one step at a time.
Once you get the first test passing, remove the `Skip` property from the next test and work on getting that test passing.
Once none of the tests are skipped and they are all passing, you can submit your solution 
using `exercism submit Alphametics.cs`

## Further information

For more detailed information about the C# track, including how to get help if
you're having trouble, please visit the exercism.io [C# language page](http://exercism.io/languages/csharp/resources).


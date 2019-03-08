# Minesweeper

Add the numbers to a minesweeper board.

Minesweeper is a popular game where the user has to find the mines using
numeric hints that indicate how many mines are directly adjacent
(horizontally, vertically, diagonally) to a square.

In this exercise you have to create some code that counts the number of
mines adjacent to a square and transforms boards like this (where `*`
indicates a mine):

    +-----+
    | * * |
    |  *  |
    |  *  |
    |     |
    +-----+

into this:

    +-----+
    |1*3*1|
    |13*31|
    | 2*2 |
    | 111 |
    +-----+

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

Initially, only the first test will be enabled. This is to encourage you to solve the exercise one step at a time.
Once you get the first test passing, remove the `Skip` property from the next test and work on getting that test passing.
Once none of the tests are skipped and they are all passing, you can submit your solution 
using `exercism submit Minesweeper.cs`

## Further information

For more detailed information about the C# track, including how to get help if
you're having trouble, please visit the exercism.io [C# language page](http://exercism.io/languages/csharp/resources).


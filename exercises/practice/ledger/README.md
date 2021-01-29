# Ledger

Refactor a ledger printer.

The ledger exercise is a refactoring exercise. There is code that prints a
nicely formatted ledger, given a locale (American or Dutch) and a currency (US
dollar or euro). The code however is rather badly written, though (somewhat
surprisingly) it consistently passes the test suite.

Rewrite this code. Remember that in refactoring the trick is to make small steps
that keep the tests passing. That way you can always quickly go back to a
working version.  Version control tools like git can help here as well.

Please keep a log of what changes you've made and make a comment on the exercise
containing that log, this will help reviewers.

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

Initially, only the first test will be enabled. This is to encourage you to solve the exercise one step at a time.
Once you get the first test passing, remove the `Skip` property from the next test and work on getting that test passing.
Once none of the tests are skipped and they are all passing, you can submit your solution 
using `exercism submit Ledger.cs`

## Further information

For more detailed information about the C# track, including how to get help if
you're having trouble, please visit the exercism.io [C# language page](http://exercism.io/languages/csharp/resources).


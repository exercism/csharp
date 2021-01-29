# Hangman

Implement the logic of the hangman game using functional reactive programming.

[Hangman][] is a simple word guessing game.

[Functional Reactive Programming][frp] is a way to write interactive
programs. It differs from the usual perspective in that instead of
saying "when the button is pressed increment the counter", you write
"the value of the counter is the sum of the number of times the button
is pressed."

Implement the basic logic behind hangman using functional reactive
programming.  You'll need to install an FRP library for this, this will
be described in the language/track specific files of the exercise.

[Hangman]: https://en.wikipedia.org/wiki/Hangman_%28game%29
[frp]: https://en.wikipedia.org/wiki/Functional_reactive_programming

## Hints
This exercise requires you to work with Reactive extension. For more information, see 
[this page](http://reactivex.io/intro.html) .

In reactive programming it's easier to communicate intentions in marble diagrams. Tests are augmented
with marble diagram information. Text format is parsable by
[this tool](https://bitbucket.org/achary/rx-marbles/src/master/docs/syntax.md?fileviewer=file-view-default)
.


## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

Initially, only the first test will be enabled. This is to encourage you to solve the exercise one step at a time.
Once you get the first test passing, remove the `Skip` property from the next test and work on getting that test passing.
Once none of the tests are skipped and they are all passing, you can submit your solution 
using `exercism submit Hangman.cs`

## Further information

For more detailed information about the C# track, including how to get help if
you're having trouble, please visit the exercism.io [C# language page](http://exercism.io/languages/csharp/resources).


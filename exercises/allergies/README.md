# Allergies

Given a person's allergy score, determine whether or not they're allergic to a given item, and their full list of allergies.

An allergy test produces a single numeric score which contains the
information about all the allergies the person has (that they were
tested for).

The list of items (and their value) that were tested are:

* eggs (1)
* peanuts (2)
* shellfish (4)
* strawberries (8)
* tomatoes (16)
* chocolate (32)
* pollen (64)
* cats (128)

So if Tom is allergic to peanuts and chocolate, he gets a score of 34.

Now, given just that score of 34, your program should be able to say:

- Whether Tom is allergic to any one of those allergens listed above.
- All the allergens Tom is allergic to.

Note: a given score may include allergens **not** listed above (i.e.
allergens that score 256, 512, 1024, etc.).  Your program should
ignore those components of the score.  For example, if the allergy
score is 257, your program should only report the eggs (1) allergy.

## Hints
This exercise requires you to use bitwise operations. For more information, see [this page](https://msdn.microsoft.com/en-us/library/6a71f45d.aspx). 

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

Initially, only the first test will be enabled. This is to encourage you to solve the exercise one step at a time.
Once you get the first test passing, remove the `Skip` property from the next test and work on getting that test passing.
Once none of the tests are skipped and they are all passing, you can submit your solution 
using `exercism submit Allergies.cs`

## Further information

For more detailed information about the C# track, including how to get help if
you're having trouble, please visit the exercism.io [C# language page](http://exercism.io/languages/csharp/resources).

## Source

Jumpstart Lab Warm-up [http://jumpstartlab.com](http://jumpstartlab.com)


# Pythagorean Triplet

A Pythagorean triplet is a set of three natural numbers, {a, b, c}, for
which,

```text
a**2 + b**2 = c**2
```

and such that,

```text
a < b < c
```

For example,

```text
3**2 + 4**2 = 9 + 16 = 25 = 5**2.
```

Given an input integer N, find all Pythagorean triplets for which `a + b + c = N`.

For example, with N = 1000, there is exactly one Pythagorean triplet for which `a + b + c = 1000`: `{200, 375, 425}`.

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

Initially, only the first test will be enabled. This is to encourage you to solve the exercise one step at a time.
Once you get the first test passing, remove the `Skip` property from the next test and work on getting that test passing.
Once none of the tests are skipped and they are all passing, you can submit your solution 
using `exercism submit PythagoreanTriplet.cs`

## Further information

For more detailed information about the C# track, including how to get help if
you're having trouble, please visit the exercism.io [C# language page](http://exercism.io/languages/csharp/resources).

## Source

Problem 9 at Project Euler [http://projecteuler.net/problem=9](http://projecteuler.net/problem=9)


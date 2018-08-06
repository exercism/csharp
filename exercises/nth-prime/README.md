# Nth Prime

Given a number n, determine what the nth prime is.

By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that
the 6th prime is 13.

If your language provides methods in the standard library to deal with prime
numbers, pretend they don't exist and implement them yourself.

## Hints

For this exercise the following C# feature comes in handy: 
Enumerables are evaluated lazily.    They allow you to work with an infinite sequence of values.
See [this article](https://blogs.msdn.microsoft.com/pedram/2007/06/02/lazy-evaluation-in-c/).

Note: to help speedup calculation, you should not check numbers which you know beforehand will never be prime. For more information, see the [Sieve of Eratosthenes](https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes).

## Running the tests

To run the tests, run the command `dotnet test` from within the exercise directory.

## Further information

For more detailed information about the C# track, including how to get help if
you're having trouble, please visit the exercism.io [C# language page](http://exercism.io/languages/csharp/resources).

## Source

A variation on Problem 7 at Project Euler [http://projecteuler.net/problem=7](http://projecteuler.net/problem=7)

## Submitting Incomplete Solutions
It's possible to submit an incomplete solution so you can see how others have completed the exercise.

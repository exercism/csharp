# Palindrome Products

Detect palindrome products in a given range.

A palindromic number is a number that remains the same when its digits are
reversed. For example, `121` is a palindromic number but `112` is not.

Given the definition of a palindromic number, we define a palindrome _product_
to be the product `c`, such that `a * b = c`, where `c` is a palindromic number and
 `a` and `b` are integers (possibly, but _not_ necessarily palindromic numbers).

For example, the palindromic number 9009 can be written as the palindrome
product: `91 * 99 = 9009`.

It's possible (and indeed common) for a palindrome product to be the product
of multiple combinations of numbers. For example, the palindrome product `9` has
the factors `(1, 9)`, `(3, 3)`, and `(9, 1)`.

Write a program that given a range of integers, returns the smallest and largest
palindromic product within that range, along with all of it's factors.

## Example 1

Given the range `[1, 9]` (both inclusive)...

The smallest product is `1`. It's factors are `(1, 1)`.
The largest product is `9`. It's factors are `(1, 9)`, `(3, 3)`, and `(9, 1)`.

## Example 2

Given the range `[10, 99]` (both inclusive)...

The smallest palindrome product is `121`. It's factors are `(11, 11)`.
The largest palindrome product is `9009`. It's factors are `(91, 99)` and `(99, 91)`.

## Hints

For this exercise, you will need to create a set of factors using tuples.
For more information on tuples, see [this link](https://msdn.microsoft.com/en-us/library/system.tuple(v=vs.110).aspx).

### Submitting Exercises

Note that, when trying to submit an exercise, make sure you're exercise file you're submitting is in the `exercism/csharp/<exerciseName>` directory.

For example, if you're submitting `bob.cs` for the Bob exercise, the submit command would be something like `exercism submit <path_to_exercism_dir>/csharp/bob/bob.cs`.
## Source

Problem 4 at Project Euler [http://projecteuler.net/problem=4](http://projecteuler.net/problem=4)

## Submitting Incomplete Solutions
It's possible to submit an incomplete solution so you can see how others have completed the exercise.

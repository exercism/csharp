# Concepts of high-scores

## Example implementations

- [Using Generic Collections and LINQ](https://exercism.io/tracks/csharp/exercises/high-scores/solutions/aa676c4a13344a5a9c7b7b944b5f3ad6)
- [Using Generic Collections, Sorted list, and Enumeration loops](https://exercism.io/tracks/csharp/exercises/high-scores/solutions/9f55365ea2bb4bf7b70e038002b54a9e)

## Object-oriented

- Classes: used on the template.
- Encapsulation: used on the template. There are public elements, some people create private elements (especially when non-LINQ approach is used).
- Methods: used on the template; all tested methods needs to be implemented
  - methods arguments: constructor receives collection as argument
  - return values: returning values from different methods

## Functional

- Pipelines (LINQ): some solutions use that to process the integer collections.
- Immutability: some people create readonly pre computed collections.
- Anonymous methods: necessary when using LINQ.
- Higher-order functions: when using LINQ - pass methods as arguments to other methods
- Lambda expressions: used when using LINQ
- Expression-bodied members: some solutions include methods written as expression-bodied members
- Enumerables: lists can can be iterated over as an enumerable (using LINQ approach)

## General

- Generics: use generic collections (lists).
- Enumeration: to process all chars on the string.
- Namespaces: used on the template.
- Exception handling: some people use that to detect errors. Even though it is not required by the tests.
- Nullability: some people need to check for nulls.
- Scoping: use `{` and `}` to denote scoping
- Visibility: making tested method and tested class `public`
- Assignment: assigning values
- Type inference: using `var` to define complex types
- Numbers: signed integers `int`
- Lists: strongly typed lists of `int` objects

## Approach: Using LINQ

- Enumerable methods for Mapping, Selecting, Ordering: using methods to manipulate enumerables (`LastOrDefault`, `OrderByDescending`, `Take`, `ToList`, `Min`, `Max`) when using LINQ

## Approach: Using sorted lists

- Enumeration loops (for, foreach): iterate over scores using `for`, `foreach` loops
- Ordering operators:`<`,`<=`
- Math operators: `+`, `+=` within enumeration loops
- Conditionals: Boolean logic operator `&&`
- Indexers: accessing single `int` elements (retrieving scores)

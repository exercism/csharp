# Design

## Goal

The goal of this exercise is to teach the student the basics of the Concept of Arrays in C#.

Of the many available C# collection types, we chose to use the `array` collection type as the first collection type students will be taught for the following reasons:

- Arrays don't require the student to know about generics.
- Arrays are a common data type in many languages.
- Arrays have a fixed length. No complexity in adding or removing elements.
- Arrays have a simple shorthand syntax. No need to understand how constructors work to define an array.

## Learning objectives

- The existence of the `Array` type.
- Defining an array.
- Accessing elements in an array by index.
- Updating an element in an array by index.
- Iterating over elements in an array.
- Basic array functions (like finding the index of an element in an array).

## Out of scope

- Multi-dimensional/jagged arrays.
- Memory and performance characteristics of arrays.
- Enumerables.
- Iterators.
- LINQ.

## Concepts

This Concepts Exercise's Concepts are:

- `arrays`: know of the existence of the `Array` type; know how to define an array; know how to access elements in an array by index; know how to update an element in an array by index; know how to iterate over elements in an array; know of some basic functions (like finding the index of an element in an array).
- `foreach-loops`: know how to iterate over a collection.

## Prequisites

This exercise's prerequisites Concepts are:

- `classes`: know how to work with fields.
- `for-loops`: know what a `for` loop is.
- `booleans`: know what a `bool` is.
- `basics`: know how to work with `integers` and how to assign and update variables.

## Representer

This exercise does not require any specific representation logic to be added to the [representer][representer].

## Analyzer

This exercise does not require any specific logic to be added to the [analyzer][analyzer].

[analyzer]: https://github.com/exercism/csharp-analyzer
[representer]: https://github.com/exercism/csharp-representer
[docs.microsoft.com-string]: https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netcore-3.1

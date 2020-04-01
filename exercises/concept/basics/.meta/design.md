# Design

## Goal

The goal of this exercise is to teach the student the basics of programming in C#.

## Learning objectives

- Know what a variable is.
- Know how to define a variable.
- Know how to update a variable.
- Know how to use type inference for variables.
- Know how to define a method.
- Know how to return a value from a method.
- Know how to call a method.
- Know that methods must be defined in classes.
- Know about the `public` access modifier.
- Know about the `static` modifier.
- Know how to define an integer.
- Know how to use mathematical operators on integers.
- Know how to define single- and multiline comments.

## Out of scope

- Naming rules for identifiers.
- Generic values.
- Memory and performance characteristics.
- Method overloads.
- Nested methods.
- Lambda's.
- Named parameters.
- Optional parameters.
- Classes.
- Organizing methods in namespaces.
- Visibility.

## Concepts

The Concepts this exercise unlocks are:

- `variables-basic`: know what a variable is; know how to define a variable; know how to update a variable; know how to use type inference for variables.
- `methods-basic`: know how to define a method; know how to return a value from a method; know how to call a method; know that methods must be defined in classes; know about the `public` access modifier; know about the `static` modifier.
- `integers-basic`: know how to define an integer; know how to use mathematical operators on integers.
- `comments-basic`: Know how to define single- and multiline comments.

## Prequisites

There are no prerequisites.

## Representer

This exercise does not require any specific representation logic to be added to the [representer][representer].

## Analyzer

This exercise could benefit from the following rules added to the the [analyzer][analyzer]:

- Verify that the `RemainingMinutesInOven` method calls the `ExpectedMinutesInOven` method.
- Verify that the `TotalTimeInMinutes` method calls the `PreparationTimeInMinutes` method.

[analyzer]: https://github.com/exercism/csharp-analyzer
[representer]: https://github.com/exercism/csharp-representer

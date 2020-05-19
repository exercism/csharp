# Design

## Goal

The goal of this exercise is to teach the student the Concept of Method Overloading in C#.

## Learning objectives

- Know what method overloading is
- Know how to define overloaded methods
- Know the limitations of method overloading
- Know how to define optional parameters
- Know how to pass named arguments

## Out of scope

- Overload resolution

## Concepts

This Concepts Exercise's Concepts are:

- `method-overloading`: know what method overloading is; know how to define overloaded methods; know the limitations of method overloading
- `optional-parameters`: know how to define optional parameters
- `named-arguments`: know how to use named arguments

## Prequisites

This Concept Exercise's prerequisites Concepts are:

- `classes`: know how to define methods on classes
- `constructors`: know how to define constructors on classes
- `properties`: know how to work with properties
- `enums`: know how to use enums
- `strings`: know how to format strings
- `basics`: know how to work with integers

## Representer

This exercise does not require any specific representation logic to be added to the [representer][representer].

## Analyzer

This exercise could benefit from the following rules added to the the [analyzer][analyzer]:

- Verify that the `Describe()` methods take take both a `Character` and `Destination` can be replaced with a single method that uses a default value for the `TravelMethod` parameter.

[analyzer]: https://github.com/exercism/csharp-analyzer
[representer]: https://github.com/exercism/csharp-representer

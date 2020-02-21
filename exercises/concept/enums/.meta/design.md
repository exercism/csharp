# Design

## Goal

The goal of this exercise is to teach the student the basics of the Concept of enums through [C#][docs.microsoft.com-enum].

## Learning objectives

After completing this exercise, the student should:

- Know of the existence of the `enum` keyword.
- Know how to define enum members.
- Know how to assign values to enum members.
- Know how to get an enum's numeric value.
- Know how to convert a `string` to an `enum` and vice versa.

## Out of scope

- Flag enums.
- That an enum's underlying type can be changed.
- Memory and performance characteristics.

## Concepts

The Concepts this exercise unlocks are:

- `enums-basic`: know of the existence of the `enum` keyword; know how to define enum members; know how to assign values to enum members; know how to get an enum's numeric value; know how to convert a `string` to an `enum` and vice versa.
- `conditionals-ternary`: know how to conditionally execute code using the ternary operator; know when to use the ternary operator.

## Prequisites

This exercise's prerequisites Concepts are:

- `strings-basic`: log lines are `string` values.
- `numbers-basic`: enum values are assigned a numeric value.
- `generics`: generics are used to specify the enum type being parsed.
- `conditionals-if`: used to handle the case when the enum could not be parsed.
- `type-conversion-numbers`: casting the enum to an `int`.

## Representer

This exercise does not require any specific representation logic to be added to the [representer][representer].

## Analyzer

This exercise does not require any specific logic to be added to the [analyzer][analyzer].

[analyzer]: https://github.com/exercism/csharp-analyzer
[representer]: https://github.com/exercism/csharp-representer
[docs.microsoft.com-enum]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum

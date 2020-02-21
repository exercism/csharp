# Design

## Goal

The goal of this exercise is to teach the student the basics of the Concept of Dates through [C#][docs.microsoft.com-datetime].

## Learning objectives

- Know of the existence of the `DateTime` type.
- Know how to get the current date.
- Know of the individual, date-related properties.
- Know how to access the current date.
- Know how to compare dates.
- Know how to convert a `string` to a `DateTime` and vice versa.

## Out of scope

- Using standard or custom format strings.
- Everything related to timezones.
- Exact parsing using format strings.
- The `DateTimeOffset` type.
- The `TimeSpan` type.

## Concepts

The Concepts this exercise unlocks are:

- `dates-basic`: know of the existence of the `DateTime` type; know of the individual, date-related properties; know how to access the current date; know how to compare dates; know how to convert a `string` to a `DateTime` and vice versa.
- `time-basic`: know of the existence of the `DateTime` type; know of the individual, time-related properties.

## Prequisites

This exercise's prerequisites Concepts are:

- `numbers-basic`: comparing the hour against specific number values.
- `strings-basic`: dates are parsed from and converted to strings.

## Representer

This exercise does not require any specific representation logic to be added to the [representer][representer].

## Analyzer

This exercise does not require any specific logic to be added to the [analyzer][analyzer].

[analyzer]: https://github.com/exercism/csharp-analyzer
[representer]: https://github.com/exercism/csharp-representer
[docs.microsoft.com-datetime]: https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netcore-3.1

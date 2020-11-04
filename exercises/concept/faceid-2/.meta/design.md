## Learning objectives

- Know how to check for equality and inequality.
- Know that equality works by default for value and reference types.
- Know how to customize equality checks using `Equals` and `GetHashCode()`.
- Know of the `IEquatable<T>` and `IEqualityComparer<T>` interfaces and how to implement them (discussion only).
- Know how to use `System.Collections.Generic.HashSet` and its relationship to `GetHashCode()`.

## Out of scope

- Collection equality.
- `struct` equality
- Equality of primitives

## Concepts

This Concepts Exercise's Concepts are:

- `equality`: know how to check for equality and inequality; know how reference equality differs from structural equality; know that equality works by default for value and reference types; know how to customize equality checks using `Equals` and `GetHashCode()`; know of the `IEquatable<T>` and `IEqualityComparer<T>` interfaces and how to implement them.
- `sets`: Know how to use hash sets `HashSet<T>` as provided by the .NET BCL. Understand the relationship with `Object.GetHashCode()` and the performance characteristics of hash sets.
- `marker-interfaces`: know what a marker interface is; know of some common marker interfaces

## Prerequisites

This Concept Exercise's prerequisites Concepts are:

- `generic-types`: needed for understanding the `IEquatable<T>` interface.
- `interfaces`: know how to implement interfaces
- `inheritance`: know that all types are derived from `object`.
- `classes`: know how to define and work with classes.
- `lists`: Know what a collection looks like and how it is generally used.
- `explicit-casts`: object -> T

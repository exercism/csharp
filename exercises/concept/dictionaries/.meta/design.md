## Goal

The goal of this exercise is to teach the student the basics of the Concept of Dictionaries in [C#][dictionaries-docs].

## Learning objectives

- Know of the existence of the `Dictionary<TKey, TElement>` type.
- Know how to define a dictionary.
- Know how to add and updated elements in a dictionary.
- Know how to access elements in a dictionary by key.
- Know how to iterate over elements in a dictionary.
- Know some basic dictionary functions (like checking if a key exists).

## Out of scope

- Generic functions.
- Generic constraints.
- Memory and performance characteristics.
- LINQ.
- Concurrency issues.
- Co-/contravariance.
- Equality.
- The `Lookup<TKey, TElement>` type.

## Concepts

This Concepts Exercise's Concepts are:

- `dictionaries`: know of the existence of the `Dictionary<TKey, TElement>` type; know how to define a dictionary; know how to add and updated elements in a dictionary; know how to access elements in a dictionary by key; know how to iterate over elements in a dictionary; know some basic dictionary functions.

## Prequisites

This Concept Exercise's prerequisites Concepts are:

- `foreach-loops`: know how to use a `foreach-loop` to iterate over a collection.
- `generic-types`: know how generic types work.
- `strings`: know how to discover string length
- `indexers`: usage and behavior of indexer properties

## Representer

This exercise does not require any specific representation logic to be added to the [representer][representer].

## Analyzer

This exercise does not require any specific analyzer logic to be added to the [analyzer][analyzer].

[how-to-implement-a-concept-exercise]: https://github.com/exercism/v3/blob/master/docs/maintainers/generic-how-to-implement-a-concept-exercise.md
[implemented-exercises]: https://github.com/exercism/v3/tree/master/languages/csharp/exercises/concept/README.md#implemented-exercises
[reference]: https://github.com/exercism/v3/blob/master/languages/csharp/reference/README.md#reference-docs
[reference-dictionary]: https://github.com/exercism/v3/blob/master/reference/types/dictionary.md
[reference-example]: https://github.com/exercism/v3/blob/master/reference/types/string.md#implementations
[analyzer]: https://github.com/exercism/csharp-analyzer
[representer]: https://github.com/exercism/csharp-representer
[exercise-example]: https://github.com/exercism/v3/tree/master/languages/csharp/exercises/concept/numbers-floating-point
[design-example]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/numbers/.meta/design.md
[config.json-example]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/numbers/.meta/config.json
[concept-exercises]: https://github.com/exercism/v3/blob/master/docs/concept-exercises.md
[dictionaries-docs]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netcore-3.1
[dictionaries-tutorial]: https://csharp.net-tutorials.com/collections/dictionaries/

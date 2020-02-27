# [C#] Add new Concept Exercise - arrays

This issue describes a new `arrays` exercise that should be added to the [v3 C# track][csharp-docs].

## Goal

The goal of this exercise is to teach the student how the concept of [collections][docs-v3-types-collection] is implemented in [C#][docs.microsoft.com-collections]. We'll teach the student about collections by having the student work with one specific type of collection, namely the [array][docs-v3-types-array]. The students will learn to define arrays, iterate over array items, access items by index, and more.

Of the many available C# collection types, we chose to use the `array` collection type as the first collection type students will be taught for the following reasons:

- Arrays don't require the student to know about generics.
- Arrays are a common data type in many language.
- Arrays have a fixed length. No complexity in adding or removing elements.
- Arrays have a simple shorthand syntax. No need to understand how constructors work to define an array.

## Learning objectives

- Know of the existence of the `Array` type.
- Know how to define an array.
- Know how to access elements in an array by index.
- Know how to iterate over elements in an array.
- Know some basic array functions (like finding the index of an element in an array).

## Out of scope

- Multi-dimensional/jagged arrays.
- Memory and performance characteristics of arrays.
- Enumerables.
- Iterators.
- LINQ.

## Concepts

This Concepts Exercise's Concepts are:

- `collections-basic`: know how to iterate over a collection.
- `arrays-basic`: know of the existence of the `Array` type; know how to define an array; know how to access elements in an array by index; know how to iterate over elements in an array; know of some basic functions (like finding the index of an element in an array).

## Prequisites

As an array is a collection type, it holds zero or more instances of another type. That means it _has_ to depend on one or more other types. In this exercise, we'll use the `int` data type for that, which is both interesting enough and easy to work with. The `int` data type is introduced in the `numbers-basic` concept.

This Concept Exercise's prerequisites Concepts are:

- `numbers-basic`: `int` values will be stored in the array and returned as output.

## Resources to refer to

### Hints

- [Arrays][docs.microsoft.com-arrays]
- [Single-dimensional arrays][docs.microsoft.com-single-dimensional-arrays]
- [Usings foreach with arrays][docs.microsoft.com-foreach-with-arrays]

### After

- [Collections][docs.microsoft.com-collections]
- [Implicitly typed arrays][docs.microsoft.com-implicitly-typed-arrays]

As this is an introductory exercise, we should take care not to link to very advanced resources, to prevent overwhelming the student.

## Representer

This exercise does not require any specific representation logic to be added to the [representer][csharp-representer].

## Analyzer

This exercise could benefit from having an [analyzer][csharp-analyzer] that can comment on:

- Difference between `for` vs `foreach` loops.

## Implementing

If you'd like to work on implementing this exercise, the first step is to let us know through a comment on this issue, to prevent multiple people from working on the same exercise. If you have any questions while implementing the exercise, please also post them as comments in this issue.

Implementing the exercise means creating the following files:

<pre>
languages
└── csharp
    └── exercises
        └── concept
            └── arrays
                ├── .docs
                |   ├── after.md
                |   ├── hints.md
                |   ├── instructions.md
                |   └── introduction.md
                ├── .meta
                |   ├── config.json
                |   ├── design.md
                |   └── Example.cs
                ├── Arrays.csproj
                ├── Arrays.cs
                └── ArraysTests.cs
</pre>

## Step 1: add .docs/introduction.md

This file contains an introduction to the concept. It should be explicit about what the student should learn from the exercise, and provide a short, concise introduction to the concept(s). The aim is to give the student just enough context to figure things out themselves and solve the exercise, as research has shown that self-discovery is the most effective learning experience. Mentioning technical terms that the student can Google if they so want, is preferable over including any code samples or an extensive description. For example we might describe a string as a "Sequence of Unicode characters" or a "series of bytes" or "an object". Unless the student needs to understand the details of what those mean to be able to solve the exercise we should not give more info in this introduction - instead allowing the student to Google, ignore, or map their existing knowledge.

## Step 2: add .docs/instructions.md

This file contains instructions for the exercise. It should explicitly explain what the student needs to do (define a method with the signature `X(...)` that takes an A and returns a Z), and provide at least one example usage of that function. If there are multiple tasks within the exercise, it should provide an example of each.

## Step 3: add .docs/hints.md

If the student gets stuck, we will allow them to click a button requesting a hint, which shows this file. This will not be a "recommended" path and we will (softly) discourage them using it unless they can't progress without it. As such, it's worth considering that the student reading it will be a little confused/overwhelmed and maybe frustrated.

The file should contain both general and task-specific "hints". These hints should be enough to unblock almost any student. They might link to the docs of the functions that need to be used.

The hints should not spell out the solution, but instead point to a resource describing the solution (e.g. linking to documentation for the function to use).

## Step 4: add .docs/after.md

Once the student completes the exercise they will be shown this file, which should provide them with a summary of what the exercise aimed to teach. This document can also link to any additional resources that might be interesting to the student in the context of the exercise.

The above four files are also all described in the [concept exercises document][docs-concept-exercises].

## Step 5: update languages/csharp/config.json

An entry should be added to the track's `config.json` file for the new concept exercise:

```json
{
  ...
  "exercises": {
    "concept": [
      ...
      {
        "slug": "arrays",
        "uuid": "b6c532c9-1e89-4fbf-8f08-27f5befb5bb8",
        "concepts": ["collections-basic", "arrays-basic"],
        "prerequisites": ["numbers-basic"]
      }
    ]
  }
}
```

## Step 6: adding track-specific files

These files are specific to the C# track:

- `Arrays.csproj`: the C# project file.
- `ArraysTests.cs`: the test suite.
- `Arrays.cs`. the stub implementation file, which is the starting point for students to work on the exercise.
- `.meta/Example.cs`: an example implementation that passes all the tests.

Check out the [`floating-point-numbers exercise`][csharp-docs-concept-exercises-floating-point-numbers] for an example on what these files should look like.

## Step 7: update the general concept document

Add the exercise to the [concept's shared document's][referrence-array] `## Implementations` section ([example](https://github.com/exercism/v3/blob/master/reference/types/string.md#implementations)).

## Step 8: updating list of implemented exercises

- Add the exercise to the [list of implemented exercises][csharp-docs-concept-exercises].

## Step 9: add .meta/design.md:

This file contains information on the exercise's design, which includes things like its goal, its teaching goals, what not to teach, and more ([example][meta-design]). This information can be extracted from this GitHub issue.

## Step 10: add .meta/config.json:

This file contains meta information on the exercise, which currently only includes the exercise's contributors ([example][meta-config.json]).

### Inspiration

When implementing this exericse, it can be very useful to look at already implemented C# exercises like the [strings][csharp-docs-concept-exercises-strings], [dates][csharp-docs-concept-exercises-dates] or [floating-point numbers][csharp-docs-concept-exercises-floating-point-numbers] exercises. You can also check the [general array concept documentation][docs-v3-types-array] to see if any other languages have already implemented an arrays exercise.

[docs.microsoft.com-arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
[docs.microsoft.com-collections]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections
[docs.microsoft.com-foreach-with-arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/using-foreach-with-arrays
[docs.microsoft.com-single-dimensional-arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays
[docs.microsoft.com-implicitly-typed-arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/implicitly-typed-arrays
[docs-v3]: https://github.com/exercism/v3/blob/master/docs/concept-exercises.md#exercise-structure
[docs-v3-types-array]: https://github.com/exercism/v3/blob/master/reference/types/array.md
[docs-v3-types-collection]: https://github.com/exercism/v3/blob/master/reference/types/collection.md
[csharp-docs]: https://github.com/exercism/v3/blob/master/languages/csharp/README.md
[csharp-docs-concept-exercises-strings]: https://github.com/exercism/v3/tree/master/languages/csharp/exercises/concept/strings
[csharp-docs-concept-exercises-dates]: https://github.com/exercism/v3/tree/master/languages/csharp/exercises/concept/dates
[csharp-docs-concept-exercises-floating-point-numbers]: https://github.com/exercism/v3/tree/master/languages/csharp/exercises/concept/numbers-floating-point
[csharp-analyzer]: https://github.com/exercism/csharp-analyzer
[csharp-representer]: https://github.com/exercism/csharp-representer
[csharp-docs-cli.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/.docs/cli.md
[csharp-docs-debug.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/.docs/debug.md
[csharp-docs-after.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/numbers-floating-point/.docs/after.md
[csharp-docs-hints.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/numbers-floating-point/.docs/hints.md
[csharp-docs-introduction.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/numbers-floating-point/.docs/introduction.md
[csharp-docs-instructions.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/numbers-floating-point/.docs/instructions.md
[csharp-docs-design.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/numbers-floating-point/.docs/design.md
[csharp-meta-config.json]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/numbers-floating-point/.meta/config.json
[csharp-docs-concept-exercises]: https://github.com/exercism/v3/tree/master/languages/csharp/exercises/concept/README.md
[referrence-array]: https://github.com/exercism/v3/blob/master/reference/types/array.md
[meta-config.json]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/enums-advanced/.meta/config.json

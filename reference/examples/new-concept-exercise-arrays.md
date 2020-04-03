This issue describes how to implement the `array` concept exercise for the C# track.

## Goal

The goal of this exercise is to teach the student the basics of the Concept of Arrays in [C#][arrays]. We'll use the array type to teach the student about some collection basics. The `array` collection type was chosen as the first collection type for the following reasons:

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

This Concept Exercise's prerequisites Concepts are:

- `numbers-basic`: `int` values will be stored in the array and returned as output.

## Resources to refer to

### Hints

- [Arrays][arrays]: basic information on strings.
- [Single-dimensional arrays][single-dimensional-arrays]: how to define a single-dimensional array.
- [Usings foreach with arrays][foreach]: how to iterate over an array using a `foreach` loop.

### After

- [Arrays][arrays]: basic information on strings.
- [Single-dimensional arrays][single-dimensional-arrays]: how to define a single-dimensional array.
- [Usings foreach with arrays][foreach]: how to iterate over an array using a `foreach` loop.
- [Implicitly typed arrays][implicitly-typed-arrays]: how to define implicitly-typed arrays.
- [Collections][collections]: how collections work.

As this is an introductory exercise, we should take care not to link to very advanced resources, to prevent overwhelming the student.

## Representer

This exercise does not require any specific representation logic to be added to the [representer][representer].

## Analyzer

This exercise could benefit from having an [analyzer][analyzer] that can comment on:

- Suggest using `foreach` if a `for` loop is used.

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

This file contains an introduction to the concept. It should make the exercise's learning goals explicit and provide a short introduction with enough detail for the student to complete the exercise. The aim is to give the student just enough context to figure out the solution themselves, as research has shown that self-discovery is the most effective learning experience. Using the proper technical terms in the descriptions will be helpful if the student wants to search for more information. If the exercise introduces new syntax, an example of the syntax should always be included; students should not need to search the web for examples of syntax.

As an example, the introduction to a "strings" exercise might describe a string as just a "Sequence of Unicode characters" or a "series of bytes". Unless the student needs to understand more nuanced details in order to solve the exercise, this type of brief explanation (along with an example of its syntax) should be sufficient information for the student to solve the exercise.

## Step 2: add .docs/instructions.md

This file contains instructions for the exercise. It should explicitly explain what the student needs to do (define a method with the signature `X(...)` that takes an A and returns a Z), and provide at least one example usage of that function. If there are multiple tasks within the exercise, it should provide an example of each.

## Step 3: add .docs/hints.md

If the student gets stuck, we will allow them to click a button requesting a hint, which shows this file. This will not be a "recommended" path and we will (softly) discourage them using it unless they can't progress without it. As such, it's worth considering that the student reading it will be a little confused/overwhelmed and maybe frustrated.

The file should contain both general and task-specific "hints". These hints should be enough to unblock almost any student. They might link to the docs of the functions that need to be used.

The hints should not spell out the solution, but instead point to a resource describing the solution (e.g. linking to documentation for the function to use).

## Step 4: add .docs/after.md

Once the student completes the exercise they will be shown this file, which should provide them with a summary of what the exercise aimed to teach. If the exercise introduced new syntax, syntax samples should be included. This document can also link to any additional resources that might be interesting to the student in the context of the exercise.

The above four files are also all described in the [concept exercises document][concept-exercises].

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

Check out [an existing exercise][exercise-example] to see what these files should look like.

## Step 7: update the general concept document

Add the exercise to the [concept's shared document's][reference-array] `## Implementations` section ([example][reference-example]).

## Step 8: updating list of implemented exercises

- Add the exercise to the [list of implemented exercises][implemented-exercises].

## Step 9: add .meta/design.md:

This file contains information on the exercise's design, which includes things like its goal, its teaching goals, what not to teach, and more ([example][design-example]). This information can be extracted from this GitHub issue.

## Step 10: add .meta/config.json:

This file contains meta information on the exercise, which currently only includes the exercise's contributors ([example][config.json-example]).

### Inspiration

When implementing this exericse, it can be very useful to look at [already implemented C# exercises][implemented-exercises]. You can also check the [general array concept documentation][reference-array] to see if any other languages have already implemented an arrays exercise.

[how-to-implement-a-concept-exercise]: https://github.com/exercism/v3/blob/master/docs/maintainers/generic-how-to-implement-a-concept-exercise.md
[implemented-exercises]: https://github.com/exercism/v3/tree/master/languages/csharp/exercises/concept/README.md#implemented-exercises
[reference]: https://github.com/exercism/v3/blob/master/languages/csharp/reference/README.md#reference-docs
[reference-array]: https://github.com/exercism/v3/blob/master/reference/types/array.md
[reference-example]: https://github.com/exercism/v3/blob/master/reference/types/string.md#implementations
[analyzer]: https://github.com/exercism/csharp-analyzer
[representer]: https://github.com/exercism/csharp-representer
[exercise-example]: https://github.com/exercism/v3/tree/master/languages/csharp/exercises/concept/numbers-floating-point
[design-example]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/numbers/.meta/design.md
[config.json-example]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/numbers/.meta/config.json
[concept-exercises]: https://github.com/exercism/v3/blob/master/docs/concept-exercises.md
[arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
[collections]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections
[foreach]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/using-foreach-with-arrays
[single-dimensional-arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays
[implicitly-typed-arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/implicitly-typed-arrays

Properties are covered early in the C# track as their purpose and power can be shown with few dependencies (classes, access modifiers and fields of simple types).

## Learning objectives

- Know what properties are and how they relate to fields and methods.
- Know what backing-field properties are.
- Know what auto-implemented properties are.
- Know what calculated properties are.
- Know how to use property accessors to customize visibility.
- Know how to define the different types of properties.

## Out of scope

- expression bodied properties, get accessors and set accessors (covered by expression-bodied members)
- properties on interfaces (covered by Interfaces)
- properties/abstract properties on abstract classes (covered by Inheritance)
- use of the `readonly` keyword with properties (covered by Immutability)
- static properties (covered by Statics)
- indexers (covered by Indexers)

Note that students may choose to implement expression-bodied members.

## Concepts

- `properties`: know what properties are and how they relate to fields and methods; know what backing-field properties are; know what auto-implemented properties are; know what calculated properties are; know how to use property accessors to customize visibility; know how to define the different types of properties.

## Prerequisites

- `numbers`: using the `int` type and using mathematical operators and number conversions.
- `floating-point-numbers`: using the `decimal` type.
- `classes`: defining classes and working with members.
- `enums`: working with enums.
- `exceptions`: throwing an exception.

Note that the values in the instructions' examples and tests
are selected specifically to avoid any question of rounding when converting
between float and int. Rounding and truncation will produce the
same result.

Prerequisite Exercises - TBA

## Resources to refer to

### Hints

- [Properties][docs.microsoft.com-properties]
- [Using Properties][docs.microsoft.com-using-properties]

### After

- [Properties][docs.microsoft.com-properties]
- [Using Properties][docs.microsoft.com-using-properties]

As this is an introductory exercise, we should take care not to link to very advanced resources, to prevent overwhelming the student.

## Representer

TBC

## Analyzer

It is difficult to get the student to exercise all different aspects of
properties through tests alone. We need comments to address the following
practices:

1. If `WeighingMachine.Units` is not auto-implemented
   then the following comment should be made: "The appropriate form
   for a property such as `WeighingMachine.Units` which has no validation or other processing required is
   that for an auto-implemented property". - Approved with comment.

2. If `WeighingMachine.DisplayWeight` has a non-private set accessor
   then the following comment should be made: "It is not approprirate
   for a property such as `WeighingMachine.DisplayWeight` which simply returns a value
   to have a set accessor. That should be removed.". - Approved with comment.

3. If `WeighingMachine.USDisplayWeight` has a non-private set accessor
   then the following comment should be made: "It is not approprirate
   for a property such as `USWeighingMachine.DisplayWeight` which simply returns a value
   to have a set accessor. That should be removed.". - Approved with comment.

4. If `USDisplayWeight.Pounds` has a non-private set accessor
   then the following comment should be made: "It is not approprirate
   for a property such as `USDisplayWeight.Pounds` which simply returns a value
   to have a set accessor. That should be removed.". - Approved with comment.

5. If `USDisplayWeight.Ounces` has a non-private set accessor
   then the following comment should be made: "It is not approprirate
   for a property such as `USDisplayWeight.Ounces` which simply returns a value
   to have a set accessor. That should be removed.". - Approved with comment.

6. If `WeighingMachine.TareAdjustement` is not an auto-implemented property
   then the following commen should be made: "A succinct way of implementing
   `WeighingMachine.TareAdjustment` is as an auto-implemented property with a
   `private` get accessor". - Approved with comment.

7. If `WeighingMachine.TareAdjustment` is an auto-implemented property
   but the get accessor is non-private then the following comment should be made:
   "A non-private set accessor is not appropriate for `WeighingMachine.TareAdjustment`
   as the instructions stipulate that the value must not be available outside the
   class". - Disapproved.

## Implementing

If you'd like to work on implementing this exercise, the first step is to let us know through a comment on this issue, to prevent multiple people from working on the same exercise. If you have any questions while implementing the exercise, please also post them as comments in this issue.

Implementing the exercise means creating the following files:

<pre>
languages
└── csharp
    └── exercises
        └── concept
            └── properties
                ├── .docs
                |   ├── after.md
                |   ├── hints.md
                |   ├── instructions.md
                |   └── introduction.md
                ├── .meta
                |   ├── design.md
                |   └── Example.cs
                ├── Properties.csproj
                ├── Properties.cs
                └── PropertiesTest.cs
</pre>

## Step 1: add .docs/introduction.md

This file contains an introduction to the concept. It should be explicit about what the exercise teaches and maybe provide a brief introduction to the concepts, but not give away so much that the user doesn't have to do any work to solve the exercise.

## Step 2: add .docs/instructions.md

This file contains instructions for the exercise. It should explicitly explain what the user needs to do (define a method with the signature `X(...)` that takes an A and returns a Z), and provide at least one example usage of that function. If there are multiple tasks within the exercise, it should provide an example of each.

## Step 3: add .docs/hints.md

If the user gets stuck, we will allow them to click a button requesting a hint, which shows this file. We will softly discourage them using it. The file should contain both general and task-specific "hints". These hints should be enough to unblock almost any student.

## Step 4: add .docs/after.md

Once the user completes the exercise they will be shown this file, which gives them any bonus information or further reading about the concept taught.

These files are also all described in the [concept exercises document][docs-concept-exercises].

## Step 5: update languages/csharp/config.json

An entry should be added to the track's `config.json` file for the new concept exercise:

```json
{
  ...
  "exercises": {
    "concept": [
      ...
      {
        "slug": "properties",
        "uuid": "978bcc16-0c49-4328-92e9-79f6204ce350",
        "concepts": ["properties"],
        "prerequisites": [
          "numbers",
          "floating-point-numbers",
          "classes",
          "enums",
          "exceptions"
        ]
      }
    ]
  }
}
```

## Step 6: adding track-specific files

These files are specific to the C# track:

- `Properties.csproj`: the C# project file.
- `PropertiesTest.cs`: the test suite.
- `Properties.cs`. the stub implementation file, which is the starting point for students to work on the exercise.
- `.meta/Example.cs`: an example implementation that passes all the tests.

Check out the [`floating-point-numbers exercise`][csharp-docs-concept-exercises-numbers-floating-point] for an example on what these files should look like.

## Step 7: update the general concept document

Not applicable for this concept

## Step 8: updating list of implemented exercises

- Add the exercise to the [list of implemented exercises][csharp-docs-concept-exercises].

## Step 9: add .meta/design.md:

This file contains information on the exercise's design, which includes things like its goal, its teaching goals, what not to teach, and more ([example][meta-design]). This information can be extracted from this GitHub issue.

### Inspiration

When implementing this exericse, it can be very useful to look at already implemented C# exercises like the [strings][csharp-docs-concept-exercises-strings], [dates][csharp-docs-concept-exercises-datetimes] or [floating-point numbers][csharp-docs-concept-exercises-numbers-floating-point] exercises.

[docs.microsoft.com-properties]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties
[docs.microsoft.com-using-properties]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties
[docs.microsoft.com-foreach-with-arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/using-foreach-with-arrays
[docs.microsoft.com-single-dimensional-arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/single-dimensional-arrays
[docs.microsoft.com-implicitly-typed-arrays]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/implicitly-typed-arrays
[docs-v3]: https://github.com/exercism/v3/blob/master/docs/concept-exercises.md#exercise-structure
[docs-v3-types-array]: https://github.com/exercism/v3/blob/master/reference/types/array.md
[docs-v3-types-collection]: https://github.com/exercism/v3/blob/master/reference/types/collection.md
[csharp-docs]: https://github.com/exercism/v3/blob/master/languages/csharp/README.md
[csharp-docs-concept-exercises-strings]: https://github.com/exercism/v3/tree/master/languages/csharp/exercises/concept/strings
[csharp-docs-concept-exercises-datetimes]: https://github.com/exercism/v3/tree/master/languages/csharp/exercises/concept/dates
[csharp-docs-concept-exercises-numbers-floating-point]: https://github.com/exercism/v3/tree/master/languages/csharp/exercises/concept/floating-point-numbers
[csharp-analyzer]: https://github.com/exercism/csharp-analyzer
[csharp-representer]: https://github.com/exercism/csharp-representer
[csharp-docs-cli.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/.docs/cli.md
[csharp-docs-debug.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/.docs/debug.md
[csharp-docs-after.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/floating-point-numbers/.docs/after.md
[csharp-docs-hints.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/floating-point-numbers/.docs/hints.md
[csharp-docs-introduction.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/floating-point-numbers/.docs/introduction.md
[csharp-docs-instructions.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/floating-point-numbers/.docs/instructions.md
[csharp-docs-design.md]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/floating-point-numbers/.docs/design.md
[csharp-meta-config.json]: https://github.com/exercism/v3/blob/master/languages/csharp/exercises/concept/floating-point-numbers/.meta/config.json
[csharp-docs-concept-exercises]: https://github.com/exercism/v3/tree/master/languages/csharp/exercises/concept/README.md
[referrence-array]: https://github.com/exercism/v3/blob/master/reference/types/array.md

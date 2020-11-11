# How to implement a C# concept exercise

This document describes how to implement a concept exercise for the C# track.

**Please please please read the docs before starting.** Posting PRs without reading these docs will be a lot more frustrating for you during the review cycle, and exhaust Exercism's maintainers' time. So, before diving into the implementation, please read the following documents:

- [The features of v3][docs-features-of-v3].
- [Rationale for v3][docs-rationale-for-v3].
- [What are concept exercises and how are they structured?][docs-concept-exercises]

Please also watch the following video:

- [The Anatomy of a Concept Exercise][anatomy-of-a-concept-exercise].

As this document is generic, the following placeholders are used:

- `<SLUG>`: the slug of the exercise in kebab-case (e.g. `calculator-conundrum`).
- `<NAME>`: the name of the exercise in PascalCase (e.g. `CalculatorConundrum`).
- `<CONCEPT_SLUG>`: the slug of one of the exercise's concepts in kebab-case (e.g. `anonymous-methods`).

Before implementing the exercise, please make sure you have a good understanding of what the exercise should be teaching (and what not). This information can be found in the exercise's GitHub issue. Having done this, please read the [C# concept exercises introduction][concept-exercises].

To implement a concept exercise, the following files must be added:

<pre>
languages
└── csharp
    ├── concepts
    |   └── &lt;CONCEPT_SLUG&gt;
    |       ├── about.md
    |       └── links.json
    └── exercises
        └── concept
            └── &lt;SLUG&gt;
                ├── .docs
                |   ├── instructions.md
                |   ├── introduction.md
                |   ├── hints.md
                |   └── source.md (required if there are third-party sources)
                ├── .meta
                |   |── config.json
                |   |── design.md
                |   └── Example.cs
                ├── &lt;NAME&gt;.cs
                ├── &lt;NAME&gt;.csproj
                └── &lt;NAME&gt;Tests.cs
</pre>

## Step 1: Add code files

The code files are track-specific and should be designed to help the student learn the exercise's concepts. The following C# code files must be added (not necessarily in this order):

### Add `<NAME>.cs` file

**Purpose:** Provide a stub implementation.

- The stub implementation's code should compile. The only exception is for exercises that introduce syntax we _want_ a student to define themselves, like how to define a class or property. In this case, insert a descriptive TODO comment instead of providing stub code (see [this example][todo]).
- Stub methods should throw a `NotImplementedException` which message contains the method to implement, see [this instance method example][not-implemented]. The message is subtly different for static stub methods, see [this static method example][not-implemented-static].

For more information, please read [this in-depth description][stub-file], [watch this video][video-stub-file] and check [this example stub file][example-stub-file].

### Add `<NAME>Tests.cs` file

**Purpose:** The test suite to verify a solution's correctness.

- [xUnit][xunit] is used as the test framework.
- Only use `Fact` tests; don't use `Theory` tests.
- All but the first test should be skipped by default (check [this example][skip-fact]).
- Test methods must be named using `snake_case`, with the first character uppercased (check [this example][test-name]).
- Test methods must have a single assertion.

For more information, please read [this in-depth description][tests-file], [watch this video][video-tests-file] and check [this example tests file][example-tests-file].

### Add `<NAME>.csproj` file

**Purpose:** The project file required to build the project and run the tests.

For more information, check [this example project file][example-project-file].

### Add `.meta/Example.cs` file

**Purpose:** The idiomatic example implementation that passes all the tests.

For more information, please read [this in-depth description][example-file], [watch this video][video-example-file] and check [this example file][example-example-file].

## Step 2: Add documentation files

How to create the files common to all tracks is described in the [how to implement a concept exercise document][how-to-implement-a-concept-exercise].

## Step 3: Update list of implemented exercises

- Add the exercise to the [list of implemented exercises][implemented-exercises].

## Step 4: format code

All C# code should be formatted using the [`dotnet format` tool][dotnet-format]. There are two ways to format your C# code:

#### 1. Using a GitHub comment

If you add a comment to a GitHub PR that contains the text `/dotnet-format`, a GitHub workflow will format all C# documents in the PR using `dotnet format`. Any formatting changes made by `dotnet format` will automatically be committed to the PR's branch. This also works for forks that have [enabled maintainers to edit the fork's PR][allowing-fork-pr-changes] (which is the default).

#### 2. Using a script

Open a command prompt in the `language/csharp` directory and then run:

- `./format.ps1 <SLUG>`, where `<SLUG>` is the exercise's directory name.

## Step 5: Add analyzer (optional)

Some exercises could benefit from having an exercise-specific [analyzer][analyzer]. If so, specify what analysis rules should be applied to this exercise and why.

_Skip this step if you're not sure what to do._

## Step 6: Add representation (optional)

Some exercises could benefit from having an custom representation as generated by the [C# representer][representer]. If so, specify what changes to the representation should be applied and why.

_Skip this step if you're not sure what to do._

## Inspiration

When implementing an exercise, it can be very useful to look at already implemented C# exercises like the [log-levels][concept-exercise-log-levels], [datetimes][concept-exercise-booking-up-for-beauty] or [floating-point numbers][concept-exercise-interest-is-interesting] exercises. You can also check the exercise's [general concepts documents][reference] to see if other languages have already implemented an exercise for that concept.

## Help

If you have any questions regarding implementing the exercise, please post them as comments in the exercise's GitHub issue.

[analyzer]: https://github.com/exercism/csharp-analyzer
[representer]: https://github.com/exercism/csharp-representer
[concept-exercises]: ../exercises/concept/README.md
[how-to-implement-a-concept-exercise]: ../../../docs/maintainers/generic-how-to-implement-a-concept-exercise.md
[docs-concept-exercises]: ../../../docs/concept-exercises.md
[docs-rationale-for-v3]: ../../../docs/rationale-for-v3.md
[docs-features-of-v3]: ../../../docs/features-of-v3.md
[anatomy-of-a-concept-exercise]: https://www.youtube.com/watch?v=gkbBqd7hPrA
[concept-exercise-log-levels]: ../exercises/concept/log-levels
[concept-exercise-booking-up-for-beauty]: ../exercises/concept/booking-up-for-beauty
[concept-exercise-interest-is-interesting]: ../exercises/concept/interest-is-interesting
[reference]: ../../../reference
[dotnet-format]: https://github.com/dotnet/format
[allowing-fork-pr-changes]: https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/allowing-changes-to-a-pull-request-branch-created-from-a-fork
[implemented-exercises]: ../exercises/concept/README.md#implemented-exercises
[video-stub-file]: https://www.youtube.com/watch?v=gkbBqd7hPrA&t=1171
[video-tests-file]: https://www.youtube.com/watch?v=gkbBqd7hPrA&t=1255
[video-example-file]: https://www.youtube.com/watch?v=gkbBqd7hPrA&t=781
[example-stub-file]: ../exercises/concept/log-levels/LogLevels.cs
[example-tests-file]: ../exercises/concept/log-levels/LogLevelsTests.cs
[example-example-file]: ../exercises/concept/log-levels/.meta/Example.cs
[example-project-file]: ../exercises/concept/log-levels/LogLevels.csproj
[skip-fact]: ../exercises/concept/log-levels/LogLevelsTests.cs#L11
[test-name]: ../exercises/concept/log-levels/LogLevelsTests.cs#L24
[xunit]: https://xunit.net/
[not-implemented-static]: ../exercises/concept/bird-watcher/BirdWatcher.cs#L12
[not-implemented]: ../exercises/concept/bird-watcher/BirdWatcher.cs#L17
[todo]: ../exercises/concept/lucians-luscious-lasagna/LuciansLusciousLasagna.cs
[stub-file]: ../../../docs/concept-exercises.md#stub-implementation-file
[tests-file]: ../../../docs/concept-exercises.md#tests-file
[example-file]: ../../../docs/concept-exercises.md#example-implementation-file
[video-stub-file]: https://www.youtube.com/watch?v=gkbBqd7hPrA&t=1171
[video-tests-file]: https://www.youtube.com/watch?v=gkbBqd7hPrA&t=1255
[video-example-file]: https://www.youtube.com/watch?v=gkbBqd7hPrA&t=781
[example-stub-file]: ../languages/csharp/exercises/concept/log-levels/LogLevels.cs
[example-tests-file]: ../languages/csharp/exercises/concept/log-levels/LogLevelsTests.cs
[example-example-file]: ../languages/csharp/exercises/concept/log-levels/.meta/Example.cs
[example-project-file]: ../exercises/concept/log-levels/LogLevels.csproj

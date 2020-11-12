# RNA transcription

## Example implementations

- [Using Linq and Dictionary](https://exercism.io/tracks/csharp/exercises/rna-transcription/solutions/9cd192112635494cbc16743f3877a9c6)
- [Using a StringBuilder, foreach and a Dictionary](https://exercism.io/tracks/csharp/exercises/rna-transcription/solutions/82fac18e0003494b8639bb80ac2ed0ce)
- [Using Linq and a switch](https://exercism.io/tracks/csharp/exercises/rna-transcription/solutions/15f7659e6f794051b337cbefa0c10259)

## Object-oriented

- classes: used on the template. Some people define a static dictionary to pre compute RNA pairs.
- encapsulation: used on the template. There are public elements, some people create private elements.
- methods: used on the template. One needs to implement a method.

## Functional

- pipelines (LINQ): some solutions use that to process the string chars.
- immutability: some people create readonly pre computed dictionaries.
- anonymous methods: necessary when using Linq.
- pattern matching: some solutions use switches.
- higher-order functions: Linq is basically that?
- local functions: is it a lambda?

## General

- generics: when people use Dictionaries they need that.
- conditionals: used to compute pairs.
- enumeration: to process all chars on the string.
- namespaces: used on the template.
- exception handling: some people use that to detect errors. Even though it is not required by the tests.
- nullability: some people need to check for nulls.
- comments

## Types

- strings: the basis of the exercise. I think things like Concat/Join/+/StringBuilder/ToString are probably concepts by themselves.
- lists: used as intermediate data structure.
- dictionaries: used to store pre computed RNA pairs.
- arrays: used as intermediate data structure.
- characters: we can either use only strings or only chars to solve the exercise.

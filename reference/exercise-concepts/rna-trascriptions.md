# RNA transcription

## Example implementations

- [Using Linq and Dictionary](https://exercism.io/tracks/csharp/exercises/rna-transcription/solutions/9cd192112635494cbc16743f3877a9c6)
- [Using a StringBuilder, foreach and a Dictionary](https://exercism.io/tracks/csharp/exercises/rna-transcription/solutions/82fac18e0003494b8639bb80ac2ed0ce)
- [Using Linq and a switch](https://exercism.io/tracks/csharp/exercises/rna-transcription/solutions/15f7659e6f794051b337cbefa0c10259)

## Object-oriented

- Classes: used on the template. Some people define a static dictionary to pre compute RNA pairs.
- Encapsulation: used on the template. There are public elements, some people create private elements.
- Methods: used on the template. One needs to implement a method.

## Functional

- Pipelines (LINQ): some solutions use that to process the string chars.
- Immutability: some people create readonly pre computed dictionaries.
- Anonymous methods: necessary when using Linq.
- Pattern matching: some solutions use switches.
- Higher-order functions: Linq is basically that? 
- Local functions: is it a lambda?

## General

- Generics: when people use Dictionaries they need that.
- Conditionals: used to compute pairs.
- Enumeration: to process all chars on the string.
- Namespaces: used on the template.
- Exception handling: some people use that to detect errors. Even though it is not required by the tests.
- Nullability: some people need to check for nulls.

## Types

- Strings: the basis of the exercice. I think things like Concat/Join/+/StringBuilder/ToString are problably concepts by themselves.
- Lists: used as intermediate data structure.
- Dictionaries: used to store pre computed RNA pairs.
- Arrays: used as intermediate data structure.
- Characters: we can either use only strings or only chars to solve the exercise.

## Missing

- Comments
- Naming conventions

# Concepts of protein-translation

[Example implementation](https://github.com/exercism/csharp/blob/master/exercises/protein-translation/Example.cs)

## General

- using keyword: for importing libraries
- access modifiers: in order to specify public vs private functions
- static keyword: in order to class/methods accessible without having to instantiate the class
- arrays: for the return value from the main function
- functions: used as the main entry point for the exercise
- function arguments: input strand is passed as an arguments
- var keyword: in order to prevent verbose declarations `List<string> results = new List<string>()`
- assignment: setting a variable to a specific value
- new keyword: used to instantiate a class
- lists: a `List<T>` temporarily holds the results before converting them to an array (Add and ToArray methods)
- for loop: iterate through the strands
- integers: `int` type used as a counter in the loop
- math operations: <, \*, and ++
- strings: substring and comparison
- exceptions: throw an exception in the event of invalid input

## Approach: switch

- switch cases: to convert the string to a protein name (including default case)

## Approach: dictionary

- dictionaries: `Dictionary<K, V>` is used to store a mapping
- immutable data structures: `ReadonlyDictionary<K, V>` should be used for the mapping which never changes

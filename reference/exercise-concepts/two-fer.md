# Concepts of Two Fer

[Example implementation](https://github.com/exercism/csharp/blob/master/exercises/two-fer/Example.cs)

## General

- function: used as the entry point to this exercise
- static function: the `static` keyword is the modifier that makes the method static, and enables it to be called without instantiation. The static method can access the variables passed in as arguments, global, and only other static members of the class.
- strings: used to format and return the result
- function arguments: need to add one optional argument - it would be avoided an unnecessary method overloading, keep the code simpler
- class: the tested method is defined in a class
- visibility: making tested method and tested class `public`
- imports: import types through `using` statements
- string interpolation: while `string` could be formatted in different ways, string interpolation provides a more effective and simpler way
- expression body method: it makes the code cleaner for a short (one-line) method

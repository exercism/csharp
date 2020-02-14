# Concepts of Space age

[Example implementation](https://github.com/exercism/csharp/blob/master/exercises/space-age/Example.cs)

## General
- methods: used as the entry points to this exercise
- class: the tested methods are defined in a class
- class constructor: SpaceAge class uses a constructor to assign the amount of seconds
- visibility: making tested method and tested class `public` while making class members which contain data `private`
- imports: import types through `using` statements
- expression-bodied members: it makes the code cleaner for On{Planet} methods 
- double: the return value of the On{Planet} methods and the argument of the class constructor is of type double, meaning the user must be exposed to working with floating point numbers
- division operator: user must know how to use binary arithmetic operators

## Approach using constants
- const: each orbital period for a planet can be stored into a constant field to prevent modification of the values

## Approach using Dictionary class
- using: import proper namespace for access to the Dictionary<TKey,TValue> Class (System.Collections.Generic)
- dictionaries : use the Dictionary class to store factors on each planet
- object initializers: create a dictionary with proper type for keys and values, assign proper combinations of key-value pairs
- indexers: used to retrieve values by their specified keys

## Approach using Enums
- enum: can be used as a Key for the Dictionary class instead of a string


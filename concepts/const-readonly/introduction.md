# Introduction

By default, values in C# are _mutable_, that is they can change over time. To make a value _immutable_, there are two options:

1. Add the `const` modifier
2. Add the `readonly` modifier

The `const` modifier has some restrictions:

1. It can only be applied to "constant" types: strings, booleans and numbers.
1. The `const` value must be initialized immediately.

If your value is a non-constant type or you need to initialize the value in a constructor, `readonly` can be used to enforce immutability.

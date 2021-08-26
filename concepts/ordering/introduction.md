# Introduction

To allow an object to be compared to another object, it must implement the `IComparable<T>` interface.
This interface has a single method that needs to be implemented: `int CompareTo(T other)`.

There are three possible return values for the `CompareTo` method:

- Value smaller than zero: the current object is smaller than the other object.
- Value greater than zero: the current object is greater than the other object.
- Value is zero: the current object is equal to the other object.

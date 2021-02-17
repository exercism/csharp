# Hints

The tests in this exercise are different from your usual tests. Normally, a test checks if for a given input, the output matches the expected value. This is called _value-based testing_. However, this exercise uses _property-based testing_, where the tests check if for a range of inputs, the output has a specific property. The two key differences that differentiate property-based testing from value-based testing are:

1. A property-based test works not with a single input value, but with many.
1. A property-based test verifies properties, not concrete values.

For this exercise, the tests all verify a property of the diamond shape your code should be producing. Furthermore, all tests check if the property they test holds for all valid input letters ('A' to 'Z').

In order to facilitate propery-based testing, the tests in this exercise leverage the [FsCheck](https://www.nuget.org/packages/FsCheck) and [FsCheck.Xunit](https://packages.nuget.org/packages/FsCheck.Xunit/2.2.0) packages. To learn more about FsCheck, the documentation on the framework can be found [here](https://fscheck.github.io/FsCheck/).

If you would like more information on property-based testing, see [this article](http://www.erikschierboom.com/2016/02/22/property-based-testing/).

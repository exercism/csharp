# Concepts of Leap

[Example implementation](https://github.com/exercism/csharp/blob/master/exercises/leap/Example.cs)

## General

- functions: used as the entry point to this exercise
- static functions: the `static` keyword is the modifier that makes the method static, and enables it to be called without instantiation. The static method can access the variables passed in as arguments, global, and only other static members of the class.
- classes: the tested method is defined in a class
- static class: a static class cannot be instantiated. Because there is no instance variable, members of a static class could be access by using the class name itself
- function argument: use input argument passed to parameter by value
- visibility: making tested method and tested class `public`
- imports: import types through `using` statements
- integers
- booleans: using comparison operator `==` as well as conditional operators
- artithmetic operator: use remainder operator `%`, checking if year is divisible with reference years (4, 100, 400)
- boolean operators: use conditional logical AND operator `&&` as well as conditional logical OR operator `||`. These greatly simplifies the code, avoiding if statements
- operator precedence: conditional AND operator has a higher precedence than conditional logical OR
- parentheses and operator precedence: Use parentheses `()` to change the order of evaluation imposed by operator precedence

## Approach: single boolean expression

- boolean expression: function could be written as a single combined boolean expression
- order of the validation: years divisible with 4 are more common, and adding this condition as first, removes the necessity to execute the other checks. Similar to 100 comparing to 400.
- expression body method: it makes the code cleaner for a short (one-line) method

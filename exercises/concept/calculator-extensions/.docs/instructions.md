# Instructions

In this exercise you will be adding extension-methods on the pre-existing `IEnumerable<int>` interface. The extension-methods express intent of the code, make code more readable, and add common functionality.

The goal is to add extension-methods that abstract away having to calculate statistical data such as the sum, product, mean, median and mode of a collection of numbers.

```csharp
var numbers = new int[] { 2, 4, 2, 1, 3 };

numbers.Sum(); // => returns 14

numbers.Product(); // => returns 48

numbers.Mean(); // => returns 2.8

numbers.Median(); // => returns 2

numbers.Mode(); // => returns 2
```

## 1. Implement the extension method Sum

Implement the `.Sum()` method to return the total of all numbers in the collection added.

## 2. Implement the extension method Product

Implement the `.Product()` method to return the total of all numbers in the collection multiplied.

## 3. Implement the extension method Mean

Implement the `.Mean()` method to return the average of the numbers in the collection.

## 4. Implement the extension method Median

Implement the `.Median()` method to return the middle value of the numbers in the collection.

## 5. Implement the extension method Mode

Implement the `.Mode()` method to return the most common number in the collection. If there is more than one, return the biggest.

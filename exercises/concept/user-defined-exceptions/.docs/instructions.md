While working at _Instruments of Texas_, you are tasked to work on an experimental calculator written in C#. You are building a test harness to verify a number of calculator functions starting with multiplication. You will see that there is particular concern when the two operands of the multiplication are negative.

The `Calculator` class has been provided for you and should not be modified.

## 1. Complete the definition of the user-defined exception `CalculationException`

Complete the definition of the constructor of `CalculationException` which will need to store (wrap) any exception thrown by the calculator as well as the operands that are being processed at the time the exception is thrown.

## 2. Handle overflow conditions in the calculator and provide enhanced information to the caller

Implement the `CalculatorTestHarness.Multiply()` method, which should call the `Calculator.Multiply()` method of the `Calculator` instance passed to the constructor.
passing in x and y integer values. If an overflow occurs in the `Calculator.Multiply()` method, it will throw an `OverflowException`. This exception should be caught in the `CalculatorTestHarness.Multiply()` method and wrapped in a `CalculationException` and the x and y values being passed around should be stored as the exception's operands. The newly created `CalculationException` object should be thrown. You can ignore the value returned by the `Calculator.Multiply()` method if it is successful.

```csharp
var cth = new CalculatorTestHarness(new Calculator());
cth.Multiply(Int32.MaxValue, Int32.MaxValue);
// => throws an instance of CalculationException

var cth2 = new CalculatorTestHarness(new Calculator());
cth2.Multiply(3, 2);
// => silently exits
```

## 3. Test the multiplication operation for valid inputs

Implement the `CalculatorTestHarness.TestMultiplication()` method which takes two integers and calls the `CalculatorTestHarness.Multiply()` method. `"Multiply succeeded"` is returned.

```csharp
var cth = new CalculatorTestHarness(new Calculator());
cth.Multiply(6, 7);
// => "Multiply succeeded"
```

## 4. Test the multiplication operation for negative inputs

Modify the `CalculatorTestHarness.TestMultiplication()` method so that `"Multiply failed for negative operands. <INNER_EXCEPTION_MESSAGE>"`is returned if both integer arguments are negative (less than zero).

The `<INNER_EXCEPTION_MESSAGE>` placeholder should be replaced with the `CalculationException`'s inner exception's message.

```csharp
var cth = new CalculatorTestHarness(new Calculator());
cth.TestMultiplication(-2, -Int32.MaxValue);
// => "Multiply failed for negative operands. " + innerException.Message
```

## 5. Test the multiplication operation for positive inputs

Modify the `CalculatorTestHarness.TestMultiplication()` method so that `"Multiply failed for mixed or positive operands. <INNER_EXCEPTION_MESSAGE>"` is returned if at least one of the integer arguments is not negative.

The `<INNER_EXCEPTION_MESSAGE>` placeholder should be replaced with the `CalculationException`'s inner exception's message.

```csharp
var cth = new CalculatorTestHarness(new Calculator());
cth.TestMultiplication(Int32.MaxValue, Int32.MaxValue);
// => "Multiply failed for mixed or positive operands. " + innerException.Message
```

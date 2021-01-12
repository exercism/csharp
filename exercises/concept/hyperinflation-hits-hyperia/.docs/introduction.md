Arithmetic overflow occurs when a computation such as an arithmetic operation or type conversion results in a value that is greater than the capacity of the receiving type.

Expressions of type `int` and `long` and their unsigned counterparts will quietly wrap around under these circumstances.

The behavior of integer computations can be modified by using the `checked` keyword. When an overflow occurs within a `checked` block an instance of `OverflowException` is thrown.

```csharp
int one = 1;
checked
{
    int expr = int.MaxValue + one;   // OverflowException is thrown
}

// or

int expr2 = checked(int.MaxValue + one);     // OverflowException is thrown
```

Expressions of type `float` and `double` will take a special value of infinity.

Expressions of type `decimal` will throw an instance of `OverflowException`.

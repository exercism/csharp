# Is number a palindrome? 

There are multiple approaches to solve the palindrome product exercise. 
Most of them require us to check if a given number is a palindrome. 

There are multiple ways to do it in C# and we will look at them in this article. 

## Approaches
### String reversal

### Math and stack

### Just math

## Performance considerations

OK, let's talk performance. We have tested the four methods above using [BenchmarkDotNet][benchmark-link].
The details of where we run it, on what hardware are not important.
We are interested in relative performance only here. 
Each test checked all numbers between 1 and 100,000 to see if they are a palindrome or not.
Here are the results:

|                          Method |      Mean |     Error |    StdDev |
|-------------------------------- |----------:|----------:|----------:|
|                  StringReversal | 15.152 ms | 0.0441 ms | 0.0412 ms |
| StringReversalWithInterpolation | 22.094 ms | 0.0365 ms | 0.0324 ms |
|        ArrayOfDigitsWalkThrough |  2.207 ms | 0.0047 ms | 0.0040 ms |
|              MathOnListOfDigits |  6.593 ms | 0.0302 ms | 0.0267 ms |
|                     MathInALoop |  1.096 ms | 0.0021 ms | 0.0017 ms |

There appears to be a big difference between 22 ms and 1 ms. 
It is also worth to observe that the `MathInALoop` is not only the fastest, but also the most predictable, the one with the smallest standard deviation. 

The `StringReversalWithInterpolation` is not only the slowest but also the least predictable. 

If you would like to test it yourself, check out [the source coude][benchmark-source-code] we used to test it. To run the benchmarks execute `dotnet run -c release`. 

## Which one to choose?

So which one to chose? The fastest always will be the fastest. 
But the difference is too small to perceive in human scales, even when comparing 100,000 numbers it is at most 22 ms. 

For 1,000,000 checks  the difference between the first string option and the math loop is 163 ms to 12 ms. 
Still almost impossible to spot with our human senses. 

And so, with performance so close, you can choose the one which is easiest to understand, one that reads the best. 

[benchmark-link]: https://benchmarkdotnet.org/
[extension-methods-link]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
[interpolation-link]: https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/string-interpolation
[linq-linl]: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
[modulo-division-link]: https://en.wikipedia.org/wiki/Modulo
[benchmark-source-code]: https://github.com/exercism/csharp/blob/main/exercises/practice/palindrome-products/.articles/is-palindrome-check/code
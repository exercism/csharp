# Checking if a number is a palindrome

There are multiple approaches to solve the palindrome product exercise. 
Most of them require us to check if a given number is a palindrome. 

There are multiple ways to do it in C# and we will look at them in this article. 

## The string reversal method

Possibly the most obvious solution is to treat a number as a string of characters.
We can then use string operations to see if the string is equal to its reversed version. 
We are checking if it "reads" the same left-to-right and right-to-left.  
Let's have a look:

```csharp
using System.Linq;

bool IsPalindrome(int number)
{
    var original = number.ToString();
    var reversed = new String(original.Reverse().ToArray());
    return original.Equals(reversed);
}
```

If you come from some other languages you might be surprised by the above code.
Unfortunately, C# doesn't come with a built in method to reverse a string. 
We have to use `.Reverse()` extension method provided by [Language-Integrated Query (LINQ)][linq-link].
However, it returns an iterator and so, it has to be collected with `.ToArray()` and converted into a `String` with `new String(char[])` constructor. 


## The string reversal with string interpolation method

Does the above, the [string reversal method](#the-string-reversal-method) look like a lot of code? 
It might be slightly shortened using [string interpolation][interpolation-link] to convert a number into a text like in the example below. 
However, before you use it read [the performance considerations](#performance-considerations) below.

```csharp
using System.Linq;

bool IsPalindrome(int number)
=>  $"{number}".Equals(new String($"{number}".Reverse().ToArray()));
```

## The array of digits method

But do we have to reverse the string? A string is an array of characters and so we can walk the array from both ends and compare the pairs of digits. As soon as we discover a pair that doesn't match we know the number is not a palindrome. 

```csharp
bool IsPalindrome(int number) 
{
    var digits = nubmer.ToString();
    for (int l = 0, r = digits.Length -1; l<r; ++l, --r)
    {
        if (digits[l] != digits[r]) { return false; }
    }
    return true;
}
```

## The list of digits method

Another approach is to use [modulo division][modulo-division-link] to extract individual digits from the least significant to the most significant. 
We can capture them in a list, and then read them again using maths to reconstruct the number in the reverse order. 
Before we look at the code, let's look at an example. The number is 754. 

| Step | number | n % 10 | n / 10 |    list |
|-----:|-------:|-------:|-------:|:--------|
|    1 |    754 |      4 |     75 | [4]     |
|    2 |     75 |      5 |      7 | [5,4]   |
|    3 |      7 |      7 |      0 | [7,5,4] |

So now we have digits, already in reversed order `[7,5,4]`. We have to combine them into a number.

| Step | number | digit | number * 10 + digit |
|-----:|-------:|------:|:--------------------|
|    1 |      0 |     7 | 7                   |
|    2 |      7 |     5 | 75                  |
|    3 |     75 |     4 | 754                 |

And now the same in code:

```csharp
using System.Collections.Generic;

bool IsPalindrome(int number)
{ 
    var original = number;
    var digits = new List<int>();
    
    while (number > 0) { 
        digits.Add(number % 10);
        number /= 10;
    }

    var reversed = 0;
    foreach(var digit in digits) {
        reversed = reversed * 10 + digit;
    }
    
    return original == reversed;
}
```

## The pure math method

The list in the above code helps us to see what is going on. 
The numbers are extracted, stored in the list and then collected. 
But, this can be done on the fly, using just math and loops without the storage. 

```csharp
bool IsPalindrome(int number)
{ 
    var original = number;
    var reversed = 0;
    
    while (number > 0) { 
        reversed = reversed * 10 + number % 10;
        number /= 10;
    }
    
    return original == reversed;
}
```

## Converting to an extension method
Talking about readability of code, we have another point to make. 
All of the above solutions can be implemented like they are above, or as an [extension methods][extension-methods-link].

What does it change? The code reads differently. Instead of: 

```csharp
if (IsPalindrome(number))
{ 
    /* do something */
}
```

you could have

```csharp
if (number.IsPalindrome()){
    /* do something */
}
```

You decide which one fits better with your code and your expectations. 


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
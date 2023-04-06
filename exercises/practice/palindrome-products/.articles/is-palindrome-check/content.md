# Checking if a number is a palindrome

There are multiple approaches to solve the palindrome product exercise. 
Most of them require us to check if a given number is a palindrome. 

There are multiple ways to do it in C# and we will look at them in this article. 

## The string reversal method

Possibly the most obvious solution is to treat a number as a string of characters
and reverse it. Let's have a look:

```csharp
using System.Linq;

private static bool IsPalindrome(int number)
{
    var original = number.ToString();
    var reversed = new String(original.Reverse().ToArray());
    return original.Equals(reversed);
}
```

If you come from some other languages you might be surprised by the above code.
Unfortunately, C# doesn't come with a built in method to reverse a string. 
We have to use `.Reverse()` extension method provided by 
[Language-Integrated Query (LINQ)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/). However, it returns an iterator and so it has to be collected with `.ToArray()` 
and converted into a `String` with `new String(char[])` constructor. 


If this looks like a lot of code to you, it might be slightly shortened using 
[string interpolation](https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/string-interpolation)
to convert a number into a text like in the example below. However, before you use it
read the performance considerations below.

```csharp
using System.Linq;

private static bool IsPalindrome(int number)
=>  $"{number}".Equals(new String($"{number}".Reverse().ToArray()));
```

## The list of digits method

Another approach is to use [modulo division](https://en.wikipedia.org/wiki/Modulo)
to extract individual digits from the least significant to the most significant. 
We can capture them in a list, and then read them again using maths again, 
to reconstruct the number in the reverse order. Before we look at the code, 
let's look at an example. The number is 123. 

| Step | number | n % 10 | n / 10 |    list |
|-----:|-------:|-------:|-------:|:--------|
|    1 |    123 |      3 |     12 | [3]     |
|    2 |     12 |      2 |      1 | [3,2]   |
|    3 |      1 |      1 |      0 | [3,2,1] |

So now we have digits, already in reversed order `[3,2,1]`. We have to combine them into a number.

| Step | number | digit | number * 10 + digit |
|-----:|-------:|------:|:--------------------|
|    1 |      0 |     3 | 3                   |
|    2 |      3 |     2 | 32                  |
|    3 |     32 |     1 | 321                 |

And now the same in code:

```csharp
using System.Collections.Generic;

private static bool IsPalindrome(int number)
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
private static bool IsPalindrome(int number)
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
All of the above solutions correctly check if a number is a palindrome. 
They differ in performance, something we will look at in a moment.
But they also differ in readability. You will have to decide which one makes
the most sense to you. 

Talking about readability of code, we have another decision to make. 
All of the above solutions can be implemented like they are above, or 
as an [[extension method](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods)]

What does it change? The code reads differently. Instead of 

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

You decide which one fits better with your code and expectations. 


## Performance considerations

OK, let's talk performance. I have tested the four methods above using
[BenchmarkDotNet](https://benchmarkdotnet.org/). I won't share the details
of where I run it, on what hardware as we are interested in relative performance only. 
What is important, that in an individual test I am checking all number between 1 and 100,000
to see if they are a palindrome or not. Here are the results:


|        Method |        Mean |     Error |    StdDev |
|-------------- |------------:|----------:|----------:|
|  String1Check | 13,131.6 μs | 100.98 μs |  94.45 μs |
|  String2Check | 19,578.5 μs | 324.35 μs | 303.40 μs |
|     ListCheck |  5,690.9 μs |  59.71 μs |  52.93 μs |
| MathLoopCheck |    935.2 μs |  12.60 μs |  11.79 μs |

There appears to be a big difference between almost 20ms and just under 1ms. 
It is also worth to observe that the MathLoop is not only the fastest, but also
the most predictable, the one with the smallest standard deviation. 

String interpolation `String2Check` is not only the slowest but also the least predictable. 

## Which one to choose?

So which one to chose? The fastest always will be the fastest. But the difference is too small
to perceive in human scales, even when comparing 100,000 numbers it is at most 20ms. 

For 1,000,000 checks  the difference between the first string option and the math loop is 163ms to 12ms. 
Still almost impossible to spot with our human senses. 

And so, with performance so close, you can choose the one which is easiest to understand,
one that reads the best. 
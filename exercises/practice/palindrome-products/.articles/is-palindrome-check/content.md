# Is number a palindrome? 

There are multiple approaches to solve the palindrome product exercise. 
Most of them require us to check if a given number is a palindrome. 

There are multiple ways to do it in C# and we will look at them in this article. 

## Approaches
### String reversal

```csharp
private static bool IsPalindrome(int number)
{
    var original = number.ToString();
    var reversed = new String(original.Reverse().ToArray());
    return original.Equals(reversed);
}
```

```csharp
private static bool IsPalindromeString(int number)
=>  $"{number}".Equals(new String($"{number}".Reverse().ToArray()));
```

### List of digits

```csharp
private static bool IsPalindrome(int number) { 
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

### Math 

```csharp
private static bool IsPalindrome(int number) { 
    var original = number;
    var reversed = 0;
    
    while (number > 0) { 
        reversed = reversed * 10 + number % 10;
        number /= 10;
    }
    
    return original == reversed;
}
```

## Performance considerations

## Which one to choose?



## The extension method options

```csharp
private static bool IsPalindrome(int number) { /*...*/ }

public static void Main() 
{
    if (IsPalindrome(123)) { /* do something */ };
}
```

```csharp
private static bool IsPalindrome(this int number) { /*...*/ }

public static void Main() 
{
    if (123.IsPalindrome()) { /* do something */ };
}
```
# Factors first

We are given a range of numbers between `min` and `max` and a task to generating all possible pairs. 

```csharp
IEnumerable<(int, int)> FactorPairsInRange(int min, int max) 
{
  for (var a = min; a <= max; ++a)
    for (var b = a; b <= max; ++b)
      yield return (a, b);
}
```

The above function does it. The algorithm has a very characteristic feature of nested `for` loops. 
It has quadratic complexity O(n^2). If the range is 1 to 10  it will generate 55 pairs. 
If the range is 10 to 100 it will generate 4095 pairs. 
We can calculate the exact number using the expression `(n(n+1))/2` where `n` is the count of possible numbers. 

## Finding the smallest palindrome and its factors
To find the smallest palindrome product and capture all its unique factor pairs we will need two variables:
```csharp
var smallestProduct = int.MaxValue;
var factors = new List<(int, int)>();  
```

We will then iterate over the factor pairs in range calculating the their product. 
If the `product` is a palindrome and it is smaller than the `smallestProduct` we will say it is the new `smallestProduct`, and we will remove the `factors` previously collected. 
Then, if the `product` is a palindrome and it is the same as the `smallestProduct` we will capture the `factors`. 
Otherwise, we will move to the next pair.

```csharp
foreach(var (a, b) in FactorPairsInRange(min, max)) {
    var product = a * b;
    
    if (IsPalindrome(product))
    {
        if (product < smallestProduct)
        {
            smallestProduct = product;
            factors.Clear();
        }
        if (produt == smallestProduct) 
        {
            factors.Add((a, b));
        }
    }
}
```

If at the end of the loop there are no factors then there are no palindrome numbers with factors in the given range. 
```csharp
if (results.Count == 0)
    throw new ArgumentException("No palindromes in the range");
```

But if there are any, we can return the smallest palindrome and its factors
```csharp
return (smallestProduct, factors.ToArray());
```

Additionally we can stop the loop as soon as we know that the small of the numbers in a given pair is greater than the `smallestProduct`. 
If we put it all together we get:

```csharp
(int, IEnumerable<(int,int)>) Smallest(int min, int max)
{
    var smallestProduct = int.MaxValue;
    var factors = new List<(int, int)>();

    foreach(var (a, b) in FactorPairsInRange(min, max)) {
        if (a > smallestProduct)
            break;
            
        var product = a * b;
        
        if (IsPalindrome(product))
        {
            if (product < smallestProduct)
            {
                smallestProduct = product;
                factors.Clear();
            }
            if (produt == smallestProduct) 
            {
                factors.Add((a, b));
            }
        }
    }

    if (results.Count == 0)
        throw new ArgumentException("No palindromes in the range");

    return (smallestProduct, factors.ToArray());
}
```

To get the largest palindrome we can follow a very similar algorithm. 


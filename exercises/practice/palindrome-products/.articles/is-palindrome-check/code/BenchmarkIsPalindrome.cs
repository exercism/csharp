using System;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


public class BenchmarkIsPalindrome {
    private static bool StringReversalSolution(int number)
    {
        var original = number.ToString();
        var reversed = new String(original.Reverse().ToArray());
        return original.Equals(reversed);
    }

    private static bool StringReversalWithInterpolationSolution(int number)
    =>  $"{number}".Equals(new String($"{number}".Reverse().ToArray()));

    private static bool ArrayOfDigitsWalkThroughSolution(int nubmer)
    {
        var digits = nubmer.ToString();
        for (int l = 0, r = digits.Length -1; l<r; ++l, --r)
        {
            if (digits[l] != digits[r]) { return false; }
        }
        return true;
    }

    private static bool MathOnListOfDigitsSolution(int number) { 
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

    private static bool MathInALoopSolution(int number) {         
        var original = number;
        var reversed = 0;
        
        while (number > 0) { 
            reversed = reversed * 10 + number % 10;
            number /= 10;
        }
        
        return original == reversed;
    }

    const int TOP_RANGE = 100_000;

    [Benchmark]
    public void StringReversal() { 
        Enumerable.Range(1,TOP_RANGE).Where(StringReversalSolution).ToList();
    }

    [Benchmark]
    public void StringReversalWithInterpolation() { 
        Enumerable.Range(1,TOP_RANGE).Where(StringReversalWithInterpolationSolution).ToList();
    }

    [Benchmark]
    public void CharByCharWalkThrough() { 
        Enumerable.Range(1,TOP_RANGE).Where(ArrayOfDigitsWalkThroughSolution).ToList();
    }

    [Benchmark]
    public void MathOnListOfDigits() { 
        Enumerable.Range(1,TOP_RANGE).Where(MathOnListOfDigitsSolution).ToList();
    }

    [Benchmark]
    public void MathInALoop() { 
        Enumerable.Range(1,TOP_RANGE).Where(MathInALoopSolution).ToList();
    }
}

public class BenchmarkPalindromes {
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<BenchmarkIsPalindrome>();
    }
}
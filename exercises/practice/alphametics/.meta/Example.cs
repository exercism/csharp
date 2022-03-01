using System;
using System.Collections.Generic;
using System.Linq;

public static class Alphametics
{
    public static IDictionary<char, int> Solve(string equation) => AlphameticsSolver.Solve(Parse(equation));

    private static AlphameticsEquation Parse(string equation)
    {
        var (left, right) = ParseOperands(equation);
        return new AlphameticsEquation(left, right);
    }

    private static (string[] left, string[] right) ParseOperands(string equation)
    {
        var leftAndRightOperands = equation.Split(" == ");
        var left = leftAndRightOperands[0].Split(" + ");
        var right = leftAndRightOperands[1].Split(" + ");

        return (left, right);
    }
}

public class AlphameticsEquation
{
    public AlphameticsEquation(string[] left, string[] right)
    {
        foreach (var leftSideOperand in left)
            ProcessOperand(leftSideOperand, 1);

        foreach (var rightSideOperand in right)
            ProcessOperand(rightSideOperand, -1);
    }

    public Dictionary<char, long> LettersWithCount { get; } = new Dictionary<char, long>();
    public HashSet<char> NonZeroLetters { get; } = new HashSet<char>();

    private void ProcessOperand(string operand, long multiplyCountBy)
    {
        var letterCount = multiplyCountBy;

        for (var i = operand.Length - 1; i >= 0; i--)
        {
            var letter = operand[i];
            if (LettersWithCount.TryGetValue(letter, out var existingCount))
                LettersWithCount[letter] = existingCount + letterCount;
            else
                LettersWithCount[letter] = letterCount;

            letterCount *= 10;
        }

        NonZeroLetters.Add(operand[0]);
    }
}

public static class AlphameticsSolver
{
    private static AlphameticsEquation _equation;
    
    public static IDictionary<char, int> Solve(AlphameticsEquation equation)
    {
        _equation = equation;
        
        var letterCount = LetterCountCombinations(equation).FirstOrDefault(IsSolution) ?? throw new ArgumentException();
        return SolutionForLetterCount(letterCount);
    }

    private static IEnumerable<int[]> LetterCountCombinations(AlphameticsEquation equation) 
        => Enumerable.Range(0, 10)
            .ToArray()
            .Permutations(equation.LettersWithCount.Count);

    private static bool IsSolution(int[] letterCountCombination)
    {
        if (LetterCountHasInvalidNonZeroLetter())
            return false;

        return _equation.LettersWithCount.Values
                .Zip(letterCountCombination, (count, solutionCount) => count * solutionCount).Sum() == 0;

        bool LetterCountHasInvalidNonZeroLetter()
        {
            var zeroLetterIndex = Array.IndexOf(letterCountCombination, 0);
            return zeroLetterIndex != -1 && _equation.NonZeroLetters.Contains(_equation.LettersWithCount.Keys.ElementAt(zeroLetterIndex));
        }
    }

    private static Dictionary<char, int> SolutionForLetterCount(IEnumerable<int> letterCount) 
        => letterCount
            .Zip(_equation.LettersWithCount.Keys, (x, y) => new KeyValuePair<char, int>(y, x))
            .ToDictionary(x => x.Key, x => x.Value);
}

public static class EnumerableExtensions
{
    public static IEnumerable<T[]> Permutations<T>(this T[] source, int length)
    {
        if (length == 1)
            return source.Select(t => new[] {t});

        return source.Permutations(length - 1)
            .SelectMany(t => source.Where(o => !t.Contains(o)),
                (t1, t2) => t1.Concat(new T[] {t2}).ToArray());
    }
}
using Sprache;
using System.Collections.Generic;
using System.Linq;
using System;

public static class Alphametics
{
    public static IDictionary<char, int> Solve(string equation)
    {
        var expression = ExpressionParser.Equation.Parse(equation);
        
        var maps = GetValidMaps(expression.Chars, expression.StartChars);
        var solution = maps.FirstOrDefault(map => expression.Solve(map) == 0);

        if (solution == null)
            throw new ArgumentException(nameof(equation));

        return solution;
    }
    
    private static IEnumerable<IDictionary<char, int>> GetValidMaps(HashSet<char> chars, HashSet<char> startChars)
        => GetMaps(chars, startChars).Where(map => IsValidMap(map, startChars));

    private static IEnumerable<IDictionary<char, int>> GetMaps(HashSet<char> chars, HashSet<char> startChars)
        => GetDigitPermutations(chars.Count).Select(digits => GetMap(digits, chars));

    private static IEnumerable<IEnumerable<int>> GetDigitPermutations(int length) 
        => Enumerable.Range(0, 10).Permutations(length);

    private static IDictionary<char, int> GetMap(IEnumerable<int> digits, IEnumerable<char> chars)
        => digits.Zip(chars, (i, c) => new KeyValuePair<char, int>(c, i)).ToDictionary(x => x.Key, x => x.Value);

    private static bool IsValidMap(IDictionary<char, int> map, IEnumerable<char> startChars) =>
        !startChars.Any(c => map[c] == 0);
}

public static class EnumerableExtensions
{
    public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> input, int length)
    {
        if (length == 1)
            return input.Select(t => new T[] { t });

        return Permutations(input, length - 1)
            .SelectMany(t => input.Where(o => !t.Contains(o)),
                (t1, t2) => t1.Concat(new T[] { t2 }));
    }
}

public enum ExpressionType
{
    Add,
    Equal
}

public abstract class Expression
{
    public abstract HashSet<char> Chars { get; }
    public abstract HashSet<char> StartChars { get; }
    public abstract int Solve(IDictionary<char, int> mapping);
}

public class PlaceholderExpression : Expression
{
    public PlaceholderExpression(string value)
    {
        Value = value;
        Chars = new HashSet<char>(value);
        StartChars = new HashSet<char> { value[0] };
    }

    public override HashSet<char> Chars { get; }
    public override HashSet<char> StartChars { get; }

    public string Value { get; }

    public static PlaceholderExpression Create(string value) => new PlaceholderExpression(value);

    public override int Solve(IDictionary<char, int> mapping) => Value.Aggregate(0, (acc, x) => acc * 10 + mapping[x]);
}

public abstract class BinaryExpression : Expression
{
    public BinaryExpression(Expression left, Expression right)
    {
        Left = left;
        Right = right;

        Chars = new HashSet<char>(Left.Chars);
        Chars.UnionWith(Right.Chars);

        StartChars = new HashSet<char>(Left.StartChars);
        StartChars.UnionWith(Right.StartChars);
    }

    public Expression Left { get; }
    public Expression Right { get; }

    public override HashSet<char> Chars { get; }
    public override HashSet<char> StartChars { get; }

    public static BinaryExpression Create(ExpressionType type, Expression left, Expression right)
    {
        switch (type)
        {
            case ExpressionType.Add:
                return new AddExpression(left, right);
            case ExpressionType.Equal:
                return new EqualExpression(left, right);
            default:
                throw new InvalidOperationException("Invalid expression");
        }
    }
}

public class AddExpression : BinaryExpression
{
    public AddExpression(Expression left, Expression right) : base(left, right)
    {
    }

    public override int Solve(IDictionary<char, int> mapping) => Left.Solve(mapping) + Right.Solve(mapping);
}

public class EqualExpression : BinaryExpression
{
    public EqualExpression(Expression left, Expression right) : base(left, right)
    {
    }

    public override int Solve(IDictionary<char, int> mapping) => Left.Solve(mapping) - Right.Solve(mapping);
}

public static class ExpressionParser
{
    public static Parser<ExpressionType> Operator(string op, ExpressionType operatorType)
        => Parse.String(op).Token().Return(operatorType);

    public static readonly Parser<ExpressionType> Add = Operator("+", ExpressionType.Add);
    public static readonly Parser<ExpressionType> Equality = Operator("==", ExpressionType.Equal);
    public static readonly Parser<Expression> Operand = Parse.Upper.AtLeastOnce().Text().Select(PlaceholderExpression.Create);
    public static readonly Parser<Expression> Expr = Parse.ChainOperator(Add, Operand, BinaryExpression.Create);
    public static readonly Parser<Expression> Equation = Parse.ChainOperator(Equality, Expr, BinaryExpression.Create);
}
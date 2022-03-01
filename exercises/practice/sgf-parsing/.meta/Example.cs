using System;
using System.Collections.Generic;
using System.Linq;
using Sprache;

public class SgfTree : IEquatable<SgfTree>
{
    public IDictionary<string, string[]> Data { get; }
    public SgfTree[] Children { get; }

    public SgfTree(IDictionary<string, string[]> data, params SgfTree[] children)
    {
        Data = data;
        Children = children;
    }

    public bool Equals(SgfTree other)
    {
        var otherData = other.Data;

        foreach (var d in Data)
            if (!d.Value.SequenceEqual(otherData.Where(od => od.Key == d.Key)?.FirstOrDefault().Value))
                return false;

        if (Children != null)
            if (!Children.SequenceEqual(other.Children))
                return false;

        return true;
    }
}

public static class SgfParser
{
    private static string ToString(IEnumerable<char> chars) => new string(chars.ToArray());
    private static string ToString(char c) => c.ToString();

    private static char Unescape(char c) => c == 'n' ? '\n' : c == 'r' || c == 't' ? ' ' : c == ']' ? ']'  : c;
    
    private static readonly Parser<char> NormalChar = Parse.Char(c => c != '\\' && c != ']', "Normal char");
    private static readonly Parser<char> EscapedChar = Parse.Char('\\').Then(_ => Parse.AnyChar.Select(Unescape));
    private static readonly Parser<string> CValueType = EscapedChar.Or(NormalChar).Many().Select(ToString);

    private static Parser<string> Value() =>
        CValueType.Contained(Parse.Char('['), Parse.Char(']'));

    private static Parser<KeyValuePair<string, string[]>> Property() =>
        from key in Parse.Upper.Select(ToString)
        from values in Value().AtLeastOnce().Select(values => values.ToArray())
        select new KeyValuePair<string, string[]>(key, values);

    private static Parser<Dictionary<string, string[]>> Properties() =>
        from properties in Property().Many().Select(properties => properties.ToArray())
        select new Dictionary<string, string[]>(properties);

    private static Parser<Dictionary<string, string[]>> Node() =>
        from _ in Parse.Char(';')
        from properties in Properties()
        select properties;
    
    private static Parser<SgfTree> Tree() =>
        from open in Parse.Char('(')
        from nodes in Node().Many()
        from children in Tree().Many()
        from close in Parse.Char(')')
        select NodesToTree(nodes, children);

    public static SgfTree ParseTree(string input)
    {
        try
        {
            return Tree().Parse(input);
        }
        catch (Exception e)
        {
            throw new ArgumentException(nameof(input), e);
        }
    }

    private static SgfTree NodesToTree(IEnumerable<IDictionary<string, string[]>> properties, IEnumerable<SgfTree> trees)
    {
        var numberOfProperties = properties.Count();

        if (numberOfProperties == 0)
        {
            throw new InvalidOperationException("Can only create tree from non-empty nodes list");
        }

        if (numberOfProperties == 1)
        {
            return new SgfTree(properties.First(), trees.ToArray());
        }

        return new SgfTree(properties.First(), NodesToTree(properties.Skip(1), trees));
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Sprache;

public class SgfTree
{
    public IDictionary<string, string[]> Data { get; }
    public SgfTree[] Children { get; }

    public SgfTree(IDictionary<string, string[]> data, params SgfTree[] children)
    {
        Data = data;
        Children = children;
    }
}

public static class SgfParser
{
    private static char Unescape(char c) => c == 'n' || c == 'r' || c == 't' ? ' ' : c;
    private static string ToString(IEnumerable<char> chars) => new string(chars.ToArray());

    private static readonly Parser<char> NormalChar = Parse.Char(c => c != '\\' && c != ']', "Normal char");
    private static readonly Parser<char> EscapedChar = Parse.Char('\\').Then(_ => Parse.AnyChar.Token().Select(Unescape));
    private static readonly Parser<string> CValueType = EscapedChar.Or(NormalChar).Many().Select(ToString);
    private static readonly Parser<string> PropValue = CValueType.Contained(Parse.Char('['), Parse.Char(']'));
    private static readonly Parser<string> PropIdent = Parse.Char(char.IsUpper, "Upper case character").Select(c => c.ToString());
    private static readonly Parser<IDictionary<string, string[]>> Property = PropIdent.Then(ident => PropValue.Many().Select(values => PropertyToData(ident, values)));
    private static readonly Parser<IDictionary<string, string[]>> Node = Parse.Char(';').Then(_ => Property.Optional().Select(o => o.GetOrDefault() ?? new Dictionary<string, string[]>()));

    private static Parser<SgfTree> GameTree() => 
        Parse.Char('(').Then(c => 
            Node.AtLeastOnce().Then(nodes => 
                GameTree().Many().Then(trees => Parse.Char(')')
                    .Select(___ => NodesToTree(nodes, trees)))));

    public static SgfTree ParseTree(string input) => GameTree().Parse(input);
    
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

    private static IDictionary<string, string[]> PropertyToData(string key, IEnumerable<string> values) =>
        new Dictionary<string, string[]>
        {
            [key] = values.ToArray()
        };
}
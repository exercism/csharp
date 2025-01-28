using System.Globalization;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;

namespace Generators;

internal static class Formatting
{
    private static readonly AdhocWorkspace AdhocWorkspace = new();

    internal static string FormatCode(string code) =>
        Formatter.Format(Parse(code).NormalizeWhitespace(), AdhocWorkspace)
            .ToFullString() + Environment.NewLine;

    private static SyntaxNode Parse(string code) =>
        CSharpSyntaxTree.ParseText(code).GetRoot();

    internal static string FormatLiteral(object obj) =>
        SymbolDisplay.FormatLiteral(Convert.ToString(obj, CultureInfo.InvariantCulture)!, obj is string);
}
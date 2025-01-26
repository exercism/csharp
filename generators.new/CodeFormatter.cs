using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;

namespace Generators;

internal static class CodeFormatter
{
    private static readonly AdhocWorkspace AdhocWorkspace = new();

    internal static string FormatCode(string code) =>
        Formatter.Format(Parse(code).NormalizeWhitespace(), AdhocWorkspace)
            .ToFullString() + Environment.NewLine;

    private static SyntaxNode Parse(string code) =>
        CSharpSyntaxTree.ParseText(code).GetRoot();
}
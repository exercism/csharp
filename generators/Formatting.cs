using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;

namespace Generators;

internal static class Formatting
{
    private static readonly AdhocWorkspace AdhocWorkspace = new();

    internal static string FormatCode(string code) =>
        CSharpSyntaxTree.ParseText(code).GetRoot().Format().ToFullString();

    private static SyntaxNode Format(this SyntaxNode node) => Formatter.Format(node, AdhocWorkspace);
}
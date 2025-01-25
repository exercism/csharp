using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Generators;

internal static class Formatter
{
    internal static string FormatCode(string code) =>
        CSharpSyntaxTree.ParseText(code)
            .GetRoot()
            .NormalizeWhitespace()
            .ToFullString() + Environment.NewLine;
}
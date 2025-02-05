using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Generators;

internal static class Formatting
{
    internal static string FormatCode(string code) => 
        Parse(code).NormalizeWhitespace().AddTrailingNewLine().ToFullString();

    private static SyntaxNode Parse(string code) =>
        CSharpSyntaxTree.ParseText(code).GetRoot();

    private static SyntaxNode AddTrailingNewLine(this SyntaxNode node) =>
        node.WithTrailingTrivia(SyntaxFactory.ElasticEndOfLine(Environment.NewLine));
}
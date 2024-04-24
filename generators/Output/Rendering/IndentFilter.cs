using System;
using System.Linq;

namespace Exercism.CSharp.Output.Rendering;

internal static class IndentFilter
{
    public static string Indent(string input)
        => string.Join(Environment.NewLine, input
            .NormalizeLineEndings()
            .Split("\n", StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Indent()));

    private static string NormalizeLineEndings(this string str) =>
        str.Replace("\r\n", "\n");
}
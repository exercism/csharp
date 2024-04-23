﻿using System;
using System.Linq;

namespace Exercism.CSharp.Output.Rendering;

internal static class IndentFilter
{
    public static string Indent(string input)
        => string.Join(Environment.NewLine, input.Trim()
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Indent()));
}
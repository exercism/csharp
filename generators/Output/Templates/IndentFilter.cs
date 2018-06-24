using System;
using System.Linq;

namespace Exercism.CSharp.Output.Templates
{
    public static class IndentFilter
    {
        public static string Indent(string input)
            => string.Join(Environment.NewLine, input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Indent()));
    }
}
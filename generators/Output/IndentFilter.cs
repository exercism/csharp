using System;
using System.Linq;

namespace Generators.Output
{
    public class IndentFilter
    {
        public static string Indent(string input) 
            => string.Join(Environment.NewLine, input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Indent()));
    }
}
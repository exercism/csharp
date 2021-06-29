using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Humanizer;

namespace Exercism.CSharp.Output.Rendering
{
    internal partial class Render
    {
        public UnescapedValue Enum(string enumType, string enumCase)
            => new($"{enumType}.{enumCase.ToLower().Dehumanize()}");

        public string Char(char c) => c.Quote();
       
        public string String(string s) => s.EscapeSpecialCharacters().Quote();
        
        public string StringMultiLine(MultiLineString multiLineString)
        {
            return multiLineString.Lines.Length switch
            {
                0 => String(string.Empty),
                1 => String(multiLineString.Lines[0]),
                _ => $"{Environment.NewLine}{string.Join(Environment.NewLine, RenderLines())}"
            };

            IEnumerable<string> RenderLines() =>
                multiLineString.Lines.Select((t, i) => i < multiLineString.Lines.Length - 1
                    ? $"{String($"{t}\n").Indent()} +"
                    : $"{String(t).Indent()}");
        }

        public string Regex(Regex regex) => String(regex.ToString());
    }
}
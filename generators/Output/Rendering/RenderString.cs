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
            => new UnescapedValue($"{enumType}.{enumCase.ToLower().Dehumanize()}");

        public string Char(char c) => c.Quote();
       
        public string String(string s) => s.EscapeSpecialCharacters().Quote();
        
        public string StringMultiLine(MultiLineString multiLineString)
        {
            switch (multiLineString.Lines.Length)
            {
                case 0:
                    return String(string.Empty);
                case 1:
                    return String(multiLineString.Lines[0]);
                default:
                    return $"{Environment.NewLine}{string.Join(Environment.NewLine, RenderLines())}";
            }
            
            IEnumerable<string> RenderLines() =>
                multiLineString.Lines.Select((t, i) => i < multiLineString.Lines.Length - 1
                    ? $"{String($"{t}\n").Indent()} +"
                    : $"{String(t).Indent()}");
        }

        public string Regex(Regex regex) => String(regex.ToString());
    }
}
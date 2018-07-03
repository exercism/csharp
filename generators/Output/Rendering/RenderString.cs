using System;
using System.Collections.Generic;
using System.Linq;
using Humanizer;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public UnescapedValue Enum(string enumType, string enumCase)
            => new UnescapedValue($"{enumType}.{enumCase.ToLower().Dehumanize()}");

        public string Char(char c) => $"'{c}'";
       
        public string String(string s) => s.EscapeSpecialCharacters().Quote();
        
        public string StringMultiLine(MultiLineString multiLineString)
        {
            if (multiLineString.Lines.Length == 0)
                return String(string.Empty);
            
            if (multiLineString.Lines.Length == 1)
                return String(multiLineString.Lines[0]);
            
            return $"{Environment.NewLine}{string.Join(Environment.NewLine, RenderLines())}";
            
            IEnumerable<string> RenderLines() =>
                multiLineString.Lines.Select((t, i) => i < multiLineString.Lines.Length - 1
                    ? $"{String($"{t}{Environment.NewLine}").Indent()} +"
                    : $"{String(t).Indent()}");
        }
    }
}
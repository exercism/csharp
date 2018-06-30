using System.Collections.Generic;
using System.Linq;
using Humanizer;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public UnescapedValue Enum(string enumType, string enumCase)
            => new UnescapedValue($"{enumType}.{enumCase.ToLower().Dehumanize()}");
       
        public string String(string s) => s.EscapeSpecialCharacters().Quote();

        public string Char(char c) => $"'{c}'";
        
        public IEnumerable<string> MultiLineString(string name, string str)
        {
            var strings = str.Split('\n');
            var renderedStrings = strings.Select((t, i) => i < strings.Length - 1
                ? $"{String(t + "\n")} +"
                : $"{String(t)}");

            return MultiLineVariable(renderedStrings, name);
        }
    }
}
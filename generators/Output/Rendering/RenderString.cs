using Humanizer;

namespace Exercism.CSharp.Output.Rendering
{
    public partial class Render
    {
        public UnescapedValue Enum(string enumType, string enumCase)
            => new UnescapedValue($"{enumType}.{enumCase.ToLower().Dehumanize()}");
       
        public string String(string s) => s.EscapeSpecialCharacters().Quote();

        public string Char(char c) => $"'{c}'";
    }
}
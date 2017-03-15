using System.Text.RegularExpressions;
using Humanizer;

namespace Generators
{
    public class TestedClassNameTransformer : IStringTransformer
    {
        public string Transform(string input) 
            => Regex.Replace(input, @"[^\w]+", "", RegexOptions.Compiled).Underscore().Transform(Humanizer.To.TitleCase);
    }
}
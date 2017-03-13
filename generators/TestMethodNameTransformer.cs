using System.Text.RegularExpressions;
using Humanizer;

namespace Generators
{
    public class TestMethodNameTransformer : IStringTransformer
    {
        public string Transform(string input) 
            => Regex.Replace(input, @"[^\w]+", "_", RegexOptions.Compiled).Underscore().Transform(Humanizer.To.TitleCase);
    }
}
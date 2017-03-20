using System.Text.RegularExpressions;
using Humanizer;

namespace Generators.Methods
{
    public class TestMethodNameTransformer : IStringTransformer
    {
        public string Transform(string input)
        {
            var methodName = Regex.Replace(input, @"[^\w]+", "_", RegexOptions.Compiled)
                .Underscore()
                .Transform(To.TitleCase);

            if (char.IsDigit(methodName[0]))
                return "Number_" + methodName;

            if (!char.IsLetter(methodName[0]))
                return "Test_";

            return methodName;
        }
    }
}
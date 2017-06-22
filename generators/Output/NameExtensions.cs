using System.Text.RegularExpressions;
using Humanizer;

namespace Generators.Output
{
    public static class NameExtensions
    {
        public static string ToTestClassName(this string input) => $"{input.Dehumanize()}Test";

        public static string ToTestedClassName(this string input) => input.Dehumanize();

        public static string ToTestMethodName(this string input)
        {
            var methodName = 
                Regex.Replace(input.Replace(":", " is"), @"[^\w]+", "_", RegexOptions.Compiled)
                    .Underscore()
                    .Transform(To.TitleCase);

            if (char.IsDigit(methodName[0]))
                return "Number_" + methodName;

            if (!char.IsLetter(methodName[0]))
                return "Test_";

            return methodName;
        }

        public static string ToTestedMethodName(this string input) => input.Dehumanize();
    }
}
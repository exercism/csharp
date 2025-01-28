using System.Dynamic;
using System.Globalization;

using HandlebarsDotNet;
using HandlebarsDotNet.Helpers;

using Humanizer;

using Microsoft.CodeAnalysis.CSharp;

using Newtonsoft.Json.Linq;

namespace Generators;

internal static class Templates
{
    private static readonly IHandlebars HandlebarsContext = Handlebars.Create();

    static Templates()
    {
        HandlebarsHelpers.Register(HandlebarsContext, options => { options.UseCategoryPrefix = false; });
        HandlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;
        HandlebarsContext.RegisterHelper("raw", (writer, context, parameters) =>
        {
            writer.WriteSafeString(parameters.First().ToString());
        });
        HandlebarsContext.RegisterHelper("literal", (writer, context, parameters) =>
        {
            var first = parameters.First();
            writer.WriteSafeString(SymbolDisplay.FormatLiteral(Convert.ToString(first, CultureInfo.InvariantCulture)!, first is string));
        });
    }

    public static string RenderTestsCode(CanonicalData canonicalData) =>
        CompileTemplate(canonicalData.Exercise)(TemplateData.ForCanonicalData(canonicalData));

    private static HandlebarsTemplate<object, object> CompileTemplate(Exercise exercise) =>
        HandlebarsContext.Compile(File.ReadAllText(Paths.TemplateFile(exercise)));

    private static class TemplateData
    {
        internal static Dictionary<string, object> ForCanonicalData(CanonicalData canonicalData)
        {
            var testCases = canonicalData.TestCases.Select(Create).ToArray();

            return new()
            {
                { "test_cases", testCases.ToArray() },
                { "test_cases_by_property", GroupTestCasesByProperty(testCases) }
            };
        }

        private static ExpandoObject Create(JToken testCase)
        {
            dynamic testData = testCase.ToObject<ExpandoObject>()!;
            testData.test_method_name = Naming.ToMethodName(testData.path.ToArray());
            testData.short_test_method_name = Naming.ToMethodName(testData.description);

            return testData;
        }

        private static Dictionary<string, dynamic[]> GroupTestCasesByProperty(IEnumerable<dynamic> testCases) =>
            testCases
                .GroupBy(testCase => (string)testCase.property)
                .ToDictionary(kv => kv.Key, kv => kv.ToArray());
    }
}

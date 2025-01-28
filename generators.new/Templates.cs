using System.Globalization;

using HandlebarsDotNet;
using HandlebarsDotNet.Helpers;

using Humanizer;

using Microsoft.CodeAnalysis.CSharp;

namespace Generators;

internal static class Templates
{
    private static readonly IHandlebars HandlebarsContext = Handlebars.Create();

    static Templates()
    {
        HandlebarsHelpers.Register(HandlebarsContext, options => { options.UseCategoryPrefix = false; });
        
        HandlebarsContext.Configuration.FormatProvider = CultureInfo.InvariantCulture;
        HandlebarsContext.RegisterHelper("method_name", (writer, context, parameters) =>
        {
            var path = parameters.SelectMany(parameter => parameter as IEnumerable<string> ?? [parameter.ToString()!]).ToArray();
            
            // Fix method names that start with a number
            if (char.IsNumber(path[0][0]))
            {
                var parts = path[0].Split(' ');
                path[0] = string.Join(" ", [Convert.ToInt32(parts[0]).ToWords(), ..parts[1..]]);
            }
            
            writer.WriteSafeString(string.Join(" ", path).Dehumanize());
        });
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
        CompileTemplate(canonicalData.Exercise)(ToTemplateData(canonicalData));

    private static HandlebarsTemplate<object, object> CompileTemplate(Exercise exercise) =>
        HandlebarsContext.Compile(File.ReadAllText(Paths.TemplateFile(exercise)));

    private static Dictionary<string, object> ToTemplateData(CanonicalData canonicalData) =>
        new()
        {
            { "exercise", canonicalData.Exercise },
            { "test_cases", canonicalData.TestCases },
            { "test_cases_by_property", GroupTestCasesByProperty(canonicalData.TestCases)}
        };

    private static Dictionary<string, TestCase[]> GroupTestCasesByProperty(TestCase[] testCases) =>
        testCases
            .GroupBy(testCase => testCase.Property)
            .ToDictionary(kv => kv.Key, kv => kv.ToArray());
}
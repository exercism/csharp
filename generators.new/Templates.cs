using System.Globalization;
using System.Text.Json;

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

    public static string RenderTests(Exercise exercise, TestCase[] testCases) =>
        CompileTemplate(exercise)(ToTemplateData(exercise, testCases));

    private static HandlebarsTemplate<object, object> CompileTemplate(Exercise exercise) =>
        HandlebarsContext.Compile(File.ReadAllText(Paths.TemplateFile(exercise)));

    private static Dictionary<string, object> ToTemplateData(Exercise exercise, TestCase[] testCases) =>
        new()
        {
            { "exercise", exercise },
            { "test_cases", testCases },
            { "test_cases_by_property", GroupTestCasesByProperty(testCases)}
        };

    private static Dictionary<string, TestCase[]> GroupTestCasesByProperty(TestCase[] testCases) =>
        testCases
            .GroupBy(testCase => testCase.Property)
            .ToDictionary(kv => kv.Key, kv => kv.ToArray());
}
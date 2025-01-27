using System.Text.Json;

using HandlebarsDotNet;
using HandlebarsDotNet.IO;

using Humanizer;

using Microsoft.CodeAnalysis.CSharp;

namespace Generators;

internal static class TemplateRenderer
{
    static TemplateRenderer()
    {
        Handlebars.RegisterHelper("method_name", (writer, context, parameters) =>
        {
            var path = parameters.SelectMany(parameter => parameter as IEnumerable<string> ?? [parameter.ToString()!]);
            writer.WriteSafeString(string.Join(" ", path).Dehumanize());
        });
        Handlebars.Configuration.FormatterProviders.Add(new JsonElementFormatter());
    }

    public static string RenderTests(Exercise exercise, TestCase[] testCases) =>
        CompileTemplate(exercise)(ToTemplateData(exercise, testCases));

    private static HandlebarsTemplate<object, object> CompileTemplate(Exercise exercise) =>
        Handlebars.Compile(File.ReadAllText(Paths.TemplateFile(exercise)));

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

    private sealed class JsonElementFormatter : IFormatter, IFormatterProvider
    {
        public void Format<T>(T value, in EncodedTextWriter writer)
        {
            if (value is not JsonElement element) 
                throw new ArgumentException("Invalid type");

            writer.Write(SymbolDisplay.FormatLiteral(element.ToString(), false));
        }

        public bool TryCreateFormatter(Type type, out IFormatter formatter)
        {
            if (type != typeof(JsonElement))
            {
                formatter = null;
                return false;
            }

            formatter = this;
            return true;
        }
    }
}
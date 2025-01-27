using HandlebarsDotNet;

using Humanizer;

namespace Generators;

internal static class TemplateRenderer
{
    static TemplateRenderer() =>
        Handlebars.RegisterHelper("method_name", (writer, context, parameters) =>
        {
            var path = parameters.SelectMany(parameter => parameter as IEnumerable<string> ?? [parameter.ToString()!]);
            writer.WriteSafeString(string.Join(" ", path).Dehumanize());
        });

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
}
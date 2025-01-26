using Humanizer;

using Scriban;
using Scriban.Runtime;

namespace Generators;

internal static class TemplateRenderer
{
    public static string RenderTests(Exercise exercise, TestCase[] testCases) =>
        Template.Parse(File.ReadAllText(Paths.TemplateFile(exercise)))
            .Render(CreateTemplateContext(exercise, testCases))!;

    private static TemplateContext CreateTemplateContext(Exercise exercise, TestCase[] testCases)
    {
        var customFunctions = new CustomFunctions
        {
            { "exercise", exercise },
            { "test_cases", testCases },
            { "test_cases_by_property", GroupTestCasesByProperty(testCases)}
        };

        var context = new TemplateContext();
        context.PushGlobal(customFunctions);

        return context;
    }

    private static Dictionary<string, TestCase[]> GroupTestCasesByProperty(TestCase[] testCases) =>
        testCases
            .GroupBy(testCase => testCase.Property)
            .ToDictionary(kv => kv.Key, kv => kv.ToArray());

    private class CustomFunctions : ScriptObject
    {
        public static string MethodName(params string[] path) => string.Join(" ", path).Dehumanize();
    }
}
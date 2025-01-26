using Humanizer;

using Scriban;
using Scriban.Runtime;

namespace Generators;

internal static class TemplateRenderer
{
    public static string RenderTests(Exercise exercise, TestCase[] testCases)
    {
        var template = Template.Parse(File.ReadAllText(Paths.TemplateFile(exercise)));

        var propertyTestCases = testCases
            .GroupBy(testCase => testCase.Property)
            .ToDictionary(k => k);

        var customFunctions = new CustomFunctions
        {
            { "exercise", exercise },
            { "test_cases", testCases },
            { "property_test_cases", propertyTestCases}
        };

        var context = new TemplateContext();
        context.PushGlobal(customFunctions);
        
        return template.Render(context)!;
    }

    private class CustomFunctions : ScriptObject
    {
        public static string MethodName(string[] path) => string.Join(" ", path).Dehumanize();
    }
}
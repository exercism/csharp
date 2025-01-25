using Humanizer;

using Scriban;
using Scriban.Runtime;

namespace Generators;

internal static class TemplateRenderer
{
    public static string RenderTests(Exercise exercise, TestCase[] testCases)
    {
        var template = Template.Parse(File.ReadAllText(Paths.TemplateFile(exercise)));
        
        var customFunctions = new CustomFunctions
        {
            { "exercise", exercise },
            { "test_cases", testCases }
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
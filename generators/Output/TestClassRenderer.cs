using System.Linq;

namespace Generators.Output
{
    public static class TestClassRenderer
    {
        private const string TestClassTemplate =
@"// This file was auto-generated based on version {CanonicalDataVersion} of the canonical data.

{UsingNamespaces}

public class {ClassName}
{
{Body}
}";

        public static string Render(TestClass testClass) =>
            TestClassTemplate
                .Replace("{CanonicalDataVersion}", testClass.CanonicalDataVersion)
                .Replace("{UsingNamespaces}", RenderUsingNamespaces(testClass))
                .Replace("{ClassName}", testClass.ClassName)
                .Replace("{Body}", RenderBody(testClass));

        private static string RenderUsingNamespaces(TestClass testClass) =>
           string.Join("\n", testClass.UsingNamespaces.Select(usingNamespace => $"using {usingNamespace};"));

        private static string RenderBody(TestClass testClass) =>
            string.Join("\n\n", testClass.TestMethods.Select(TestMethodRenderer.Render));
    }
}

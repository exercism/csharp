using System.Linq;

namespace Generators.Methods
{
    public static class TestMethodRenderer
    {
        private const string Tab = "    ";

        private const string TestMethodTemplate =
@"{Tab}[Fact{Skip}]
{Tab}public void {Name}()
{Tab}{
{Body}
{Tab}}";

        public static string Render(TestMethod testMethod) =>
            TestMethodTemplate
                .Replace("{Tab}", Tab)
                .Replace("{Name}", testMethod.MethodName)
                .Replace("{Body}", RenderBody(testMethod))
                .Replace("{Skip}", testMethod.Index == 0 ? "" : "(Skip = \"Remove to run test\")");

        private static string RenderBody(TestMethod testMethod) 
            => string.Join("\n", testMethod.Body.Split('\n').Select(line => $"{Tab}{Tab}{line}"));
    }
}

using System.Linq;

namespace Generators
{
    public static class TestClassRenderer
    {
        private const string testClassTemplate =
@"using Xunit;

public class {ClassName}Test
{
{TestMethods}
}
";

        public static string Render(TestClass testClass) =>
            testClassTemplate
                .Replace("{ClassName}", testClass.ClassName)
                .Replace("{TestMethods}", string.Join("\n\n", testClass.TestMethods.Select(TestMethodRenderer.Render)));
    }
}

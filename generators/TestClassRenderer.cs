using System.Linq;

namespace Generators
{
    public static class TestClassRenderer
    {
        public static string Render(TestClass testClass)
        {
            const string testClassTemplate =
@"
using Xunit;

public class {ClassName}Test
{
{TestMethods}
}
";

            const string testMethodTemplate =
@"
    [Fact{Skip}]
    public void {TestName}()
    {
        {TestBody}
    }
";


            var actualTestTemplate = testClassTemplate
                .Replace("{ClassName}", testClass.ClassName)
                .Replace("{TestMethods}", string.Join("", testClass.TestMethods.Select((testMethod, index) =>
                    testMethodTemplate
                        .Replace("{TestName}", testMethod.MethodName)
                        .Replace("{TestBody}", testMethod.Body)
                        .Replace("{Skip}", index == 0 ? "" : "(Skip = \"Remove to run test\")"))));

            return actualTestTemplate;

        }
    }
}

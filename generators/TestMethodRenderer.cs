namespace Generators
{
    public static class TestMethodRenderer
    {
        private const string testMethodTemplate =
@"    [Fact{Skip}]
    public void {Name}()
    {
        {Body}
    }";

        public static string Render(TestMethod testMethod) =>
            testMethodTemplate
                .Replace("{Name}", testMethod.MethodName)
                .Replace("{Body}", testMethod.Body)
                .Replace("{Skip}", testMethod.Index == 0 ? "" : "(Skip = \"Remove to run test\")");
    }
}

namespace Generators.Methods
{
    public static class TestMethodRenderer
    {
        private const string TestMethodTemplate =
@"    [Fact{Skip}]
    public void {Name}()
    {
        {Body}
    }";

        public static string Render(TestMethod testMethod) =>
            TestMethodTemplate
                .Replace("{Name}", testMethod.MethodName)
                .Replace("{Body}", testMethod.Body)
                .Replace("{Skip}", testMethod.Index == 0 ? "" : "(Skip = \"Remove to run test\")");
    }
}

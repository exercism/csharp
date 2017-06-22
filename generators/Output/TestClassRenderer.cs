using System.IO;
using System.Linq;
using DotLiquid;

namespace Generators.Output
{
    public static class TestClassRenderer
    {
        private static readonly string TemplateContents = File.ReadAllText(Path.Combine("Output", "TestClass.liquid"));

        private static readonly Template TestClassTemplate = Template.Parse(TemplateContents);

        public static string Render(TestClass testClass)
        {
            var templateData = new
            {
                CanonicalDataVersion = testClass.CanonicalDataVersion,
                UsingNamespaces = testClass.UsingNamespaces,
                ClassName = testClass.ClassName,
                TestMethods = testClass.TestMethods.Select(testMethod => new { Name = testMethod.MethodName, Body = testMethod.Body })
            };
            
            return TestClassTemplate.Render(Hash.FromAnonymousObject(templateData));
        }
    }
}

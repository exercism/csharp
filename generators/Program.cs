using Generators.Templates;
using System.Linq;

namespace Generators
{
    public static class Program
    {
        public static void Main()
        {
            foreach (var generator in new GeneratorCollection())
                generator.Generate();
        }
    }

    public abstract class Generator
    {
        private static readonly CanonicalDataParser CanonicalDataParser = new CanonicalDataParser();
        //private static readonly TemplateParser TemplateParser = new TemplateParser();

        public Generator(string exercise)
        {
            Exercise = exercise;
        }

        public string Exercise { get; }

        public void Generate()
        {
            Generate(CanonicalDataParser.Parse(Exercise));

            var testClass = new TestClass
            {
                ClassName = "Leap",
                TestMethods = new[]
                {
                    new TestMethod { MethodName = "Valid_leap_year", Body = "Assert.True(Year.IsLeap(1996));" },
                    new TestMethod { MethodName = "Invalid_leap_year", Body = "Assert.False(Year.IsLeap(1997));" }
                }
            };

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

            var x1 = new
            {
                ClassName = testClass.ClassName,
                TestMethods = 
                    from testMethod in testClass.TestMethods
                    select new { MethodName = testMethod.MethodName, testMethod.Body }
            };

            var y = TemplateRenderer.Render("TestClass", x1);

            System.Console.WriteLine(y);

            //var actualTestTemplate = testClassTemplate
            //    .Replace("{ClassName}", testClass.ClassName)
            //    .Replace("{TestMethods}", string.Join("", testClass.TestMethods.Select((testMethod, index) =>
            //        testMethodTemplate
            //            .Replace("{TestName}", testMethod.MethodName)
            //            .Replace("{TestBody}", testMethod.Body)
            //            .Replace("{Skip}", index == 0 ? "" : "(Skip = \"Remove to run test\")"))));


            //System.Console.WriteLine(actualTestTemplate);
        }

        protected abstract string Generate(CanonicalData canonicalData);
    }

    
    
    public class LeapExerciseGenerator : Generator
    {
        public LeapExerciseGenerator() : base("leap")
        {
        }

        protected override string Generate(CanonicalData canonicalData)
        {
            return null;
        }
    }
}
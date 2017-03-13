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

            var x1 = new
            {
                ClassName = testClass.ClassName,
                TestMethods = 
                    from testMethod in testClass.TestMethods
                    select new { MethodName = testMethod.MethodName, testMethod.Body }
            };

            var y = TestClassRenderer.Render(testClass);

            System.Console.WriteLine(y);
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

    public class PigLatinExerciseGenerator : Generator
    {
        public PigLatinExerciseGenerator() : base("pig-latin")
        {
        }

        protected override string Generate(CanonicalData canonicalData)
        {
            return null;
        }
    }
}
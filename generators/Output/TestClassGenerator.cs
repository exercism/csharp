using System.Linq;
using Generators.Exercises;
using Generators.Input;

namespace Generators.Output
{
    public static class TestClassGenerator
    {
        private static readonly BooleanTestMethodGenerator BooleanTestMethod = new BooleanTestMethodGenerator();
        private static readonly EqualityTestMethodGenerator EqualityTestMethod = new EqualityTestMethodGenerator();
        private static readonly ExceptionTestMethodGenerator ExceptionTestMethod = new ExceptionTestMethodGenerator();

        public static TestClass Create(Exercise exercise)
        {
            var testClass = new TestClass
            {
                ClassName = exercise.Name.ToTestClassName(),
                TestMethods = exercise.CanonicalData.Cases.Select(canonicalDataCase => CreateTestMethod(canonicalDataCase, exercise)).ToArray(),
                CanonicalDataVersion = exercise.CanonicalData.Version
            };

            AddTestMethodUsingNamespaces(testClass);

            return testClass;
        }

        private static void AddTestMethodUsingNamespaces(TestClass testClass)
        {
            foreach (var testMethod in testClass.TestMethods)
                testClass.UsingNamespaces.UnionWith(testMethod.UsingNamespaces);
        }

        private static TestMethod CreateTestMethod(TestMethodData testMethodData)
        {
            if (testMethodData.Configuration.ThrowExceptionWhenExpectedValueEquals(testMethodData.CanonicalDataCase.Expected))
                return ExceptionTestMethod.Create(testMethodData);

            if (testMethodData.Configuration.TestedMethodType == TestedMethodType.BooleanComparison)
                return BooleanTestMethod.Create(testMethodData);

            return EqualityTestMethod.Create(testMethodData);
        }

        private static TestMethod CreateTestMethod(CanonicalDataCase canonicalDataCase, Exercise exercise) => CreateTestMethod(CreateTestMethodData(canonicalDataCase, exercise));

        private static TestMethodData CreateTestMethodData(CanonicalDataCase canonicalDataCase, Exercise exercise) => new TestMethodData
        {
            CanonicalData = exercise.CanonicalData,
            CanonicalDataCase = canonicalDataCase,
            Configuration = exercise.Configuration
        };
    }
}

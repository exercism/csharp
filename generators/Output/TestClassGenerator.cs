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

        public static TestClass Create(Exercise exercise) => new TestClass
        {
            ClassName = exercise.Name.ToTestClassName(),
            TestMethods = exercise.CanonicalData.Cases.Select(canonicalDataCase => CreateTestMethod(canonicalDataCase, exercise)).ToArray(),
            CanonicalDataVersion = exercise.CanonicalData.Version
        };

        private static TestMethod CreateTestMethod(CanonicalDataCase canonicalDataCase, Exercise exercise)
        {
            if (exercise.Configuration.ThrowExceptionWhenExpectedValueEquals(canonicalDataCase.Expected))
                return ExceptionTestMethod.Create(canonicalDataCase, exercise);

            if (canonicalDataCase.Expected is bool)
                return BooleanTestMethod.Create(canonicalDataCase, exercise);

            return EqualityTestMethod.Create(canonicalDataCase, exercise);
        }
    }
}

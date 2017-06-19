using System.Linq;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public abstract class Exercise
    {
        protected static readonly BooleanTestMethodGenerator BooleanTestMethodGenerator = new BooleanTestMethodGenerator();
        protected static readonly EqualityTestMethodGenerator EqualityTestMethodGenerator = new EqualityTestMethodGenerator();
        protected static readonly ExceptionTestMethodGenerator ExceptionTestMethodGenerator = new ExceptionTestMethodGenerator();

        protected Exercise()
        {
            Name = GetType().Name.Kebaberize();
            Options = new TestMethodOptions();
        }

        public string Name { get; }

        protected TestMethodOptions Options { get; }

        public TestClass CreateTestClass(CanonicalData canonicalData)
        {
            var testClass = new TestClass
            {
                ClassName = Name.ToTestClassName(),
                TestMethods = canonicalData.Cases.Select((t, i) => CreateTestMethod(canonicalData, t)).ToArray(),
                CanonicalDataVersion = canonicalData.Version
            };

            AddTestMethodUsingNamespaces(testClass);

            return testClass;
        }

        private static void AddTestMethodUsingNamespaces(TestClass testClass)
        {
            foreach (var testMethod in testClass.TestMethods)
                testClass.UsingNamespaces.UnionWith(testMethod.UsingNamespaces);
        }

        protected abstract TestMethod CreateTestMethod(TestMethodData testMethodData);

        private TestMethod CreateTestMethod(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase) 
            => CreateTestMethod(CreateTestMethodData(canonicalData, canonicalDataCase));

        protected virtual TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase)
            => new TestMethodData
            {
                CanonicalData = canonicalData,
                CanonicalDataCase = canonicalDataCase,
                Options = Options
            };
    }
}
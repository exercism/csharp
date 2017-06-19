using System.Collections.Generic;
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
                TestMethods = CreateTestMethods(canonicalData).ToArray(),
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

        protected virtual IEnumerable<TestMethod> CreateTestMethods(CanonicalData canonicalData) 
            => canonicalData.Cases.Select((t, i) => CreateTestMethod(canonicalData, t, i));
        
        protected virtual TestMethod CreateTestMethod(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index) 
            => CreateTestMethod(CreateTestMethodData(canonicalData, canonicalDataCase, index));

        protected virtual TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
            => new TestMethodData
            {
                CanonicalData = canonicalData,
                CanonicalDataCase = canonicalDataCase,
                Index = index,
                Options = Options
            };
    }
}
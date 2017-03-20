using System.Collections.Generic;
using System.Linq;
using Generators.Classes;
using Generators.Data;
using Generators.Methods;
using Humanizer;
using Newtonsoft.Json.Linq;
using To = Generators.Helpers.To;

namespace Generators.Exercises
{
    public abstract class Exercise
    {
        private static readonly BooleanTestMethodGenerator BooleanTestMethodGenerator = new BooleanTestMethodGenerator();
        private static readonly EqualityTestMethodGenerator EqualityTestMethodGenerator = new EqualityTestMethodGenerator();
        private static readonly ExceptionTestMethodGenerator ExceptionTestMethodGenerator = new ExceptionTestMethodGenerator();

        protected Exercise(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public TestClass CreateTestClass(CanonicalData canonicalData)
        {
            var testClass = new TestClass
            {
                ClassName = Name.Transform(To.TestClassName),
                TestMethods = CreateTestMethods(canonicalData).ToArray()
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
        {
            var testMethodData = CreateTestMethodData(canonicalData, canonicalDataCase, index);
            
            if (testMethodData.CanonicalDataCase.Expected is JObject jObject)
                return CreateExceptionTestMethod(testMethodData);

            return CreateTestMethod(testMethodData);
        }

        protected virtual TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index) 
            => new TestMethodData
                {
                    CanonicalData = canonicalData,
                    CanonicalDataCase = canonicalDataCase,
                    Index = index,
                    Options = CreateTestMethodOptions(canonicalData, canonicalDataCase, index)
                };

        protected virtual TestMethodOptions CreateTestMethodOptions(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index) 
            => new TestMethodOptions();

        protected virtual TestMethod CreateBooleanTestMethod(TestMethodData testMethodData) 
            => BooleanTestMethodGenerator.Create(testMethodData);

        protected virtual TestMethod CreateEqualityTestMethod(TestMethodData testMethodData) 
            => EqualityTestMethodGenerator.Create(testMethodData);

        protected virtual TestMethod CreateExceptionTestMethod(TestMethodData testMethodData)
            => ExceptionTestMethodGenerator.Create(testMethodData);
    }
}
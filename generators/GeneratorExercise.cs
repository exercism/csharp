using System;
using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;

namespace Generators
{
    public abstract class GeneratorExercise : Exercise
    {
        private CanonicalData _canonicalData;

        public override string Name => GetType().ToExerciseName();

        public void Regenerate(CanonicalData canonicalData)
        {
            _canonicalData = canonicalData;

            var testClass = CreateTestClass();
            var testClassFile = new TestClassFile(testClass);
            testClassFile.Write();
        }

        private IList<string> RenderTestMethods(IEnumerable<TestData> testData)
        {
            var testMethods = testData
                .Select(CreateTestMethod)
                .ToArray();
            
            Array.ForEach(testMethods, UpdateTestMethod);

            return testMethods.Select(testMethod => testMethod.Render()).ToList();
        }

        private TestClass CreateTestClass()
        {
            var testData = CreateTestData();
            var testClass = new TestClass
            {
                Exercise = _canonicalData.Exercise,
                CanonicalDataVersion = _canonicalData.Version,
                ClassName = _canonicalData.Exercise.ToTestClassName(),
                Methods = RenderTestMethods(testData),
                Namespaces = GetNamespaces(testData)
            };

            UpdateTestClass(testClass);
            return testClass;
        }

        protected virtual void UpdateTestClass(TestClass @class)
        {
        }

        private ISet<string> GetNamespaces(IEnumerable<TestData> testData)
        {
            var exceptionNamespaces = testData
                .Where(x => x.ExceptionThrown != null)
                .Select(x => x.ExceptionThrown.Namespace);

            var defaultNamespaces = new[] { "Xunit" };

            var namespaces = new SortedSet<string>(defaultNamespaces.Concat(exceptionNamespaces));
            UpdateNamespaces(namespaces);
            
            return namespaces;
        }

        protected virtual void UpdateNamespaces(ISet<string> namespaces)
        {
        }

        private TestMethod CreateTestMethod(TestData data, int index) => new TestMethod
        {
            Skip = index > 0,
            Name = data.TestMethod,
            Body = CreateTestMethodBody(data)
        };

        protected virtual void UpdateTestMethod(TestMethod method)
        {
        }

        private TestMethodBody CreateTestMethodBody(TestData data)
        {
            var testMethodBody = CreateTestMethodBodyFromData(data);
            UpdateTestMethodBody(testMethodBody);

            return testMethodBody;
        }

        private static TestMethodBody CreateTestMethodBodyFromData(TestData data)
        {
            if (data.ExceptionThrown != null)
            {
                return new TestMethodBodyWithExceptionCheck(data);
            }

            switch (data.Expected)
            {
                case bool _:
                    return new TestMethodBodyWithBooleanCheck(data);
                case null:
                    return new TestMethodBodyWithNullCheck(data);
                default:
                    return new TestMethodBodyWithEqualityCheck(data);
            }
        }
        
        protected virtual void UpdateTestMethodBody(TestMethodBody body)
        {
        }

        private TestData[] CreateTestData()
        {
            var testData = _canonicalData.Cases
                .Select(canonicalDataCase => new TestData(_canonicalData, canonicalDataCase))
                .ToArray();
    
            Array.ForEach(testData, UpdateTestData);
            return testData;
        }

        protected virtual void UpdateTestData(TestData data)
        {
        }
    }
}

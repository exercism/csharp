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

            ExerciseWriter.WriteToFile(this);
        }

        public string Render() => CreateUpdatedTestClass().Render();

        protected virtual IEnumerable<string> AdditionalNamespaces => Enumerable.Empty<string>();

        protected virtual IEnumerable<string> RenderAdditionalMethods() => Array.Empty<string>();

        private IEnumerable<string> GetNamespaces(IEnumerable<TestData> testData)
        {
            var usingNamespaces = new SortedSet<string> { "Xunit" };

            foreach (var data in testData.Where(x => x.ExceptionThrown != null))
                usingNamespaces.Add(data.ExceptionThrown.Namespace);

            usingNamespaces.UnionWith(AdditionalNamespaces);

            return usingNamespaces;
        }

        private IEnumerable<string> RenderTestMethods(IEnumerable<TestData> testData) 
            => testData
                .Select(RenderTestMethod)
                .Concat(RenderAdditionalMethods())
                .ToArray();

        private TestClass CreateUpdatedTestClass()
        {
            var testClass = CreateTestClass();
            UpdateTestClass(testClass);

            return testClass;
        }

        private TestClass CreateTestClass()
        {
            var testData = CreateUpdatedTestData();

            return new TestClass
            {
                ClassName = Name.ToTestClassName(),
                Methods = RenderTestMethods(testData),
                CanonicalDataVersion = _canonicalData.Version,
                Namespaces = GetNamespaces(testData)
            };
        }
        
        protected virtual void UpdateTestClass(TestClass @class)
        {
        }

        private string RenderTestMethod(TestData data, int index) => CreateUpdatedTestMethod(data, index).Render();

        protected virtual TestMethod CreateUpdatedTestMethod(TestData data, int index)
        {
            var testMethod = CreateTestMethod(data, index);
            UpdateTestMethod(testMethod);

            return testMethod;
        }
        
        protected virtual TestMethod CreateTestMethod(TestData data, int index) => new TestMethod
        {
            Skip = index > 0,
            Name = ToTestMethodName(data),
            Body = CreateUpdatedTestMethodBody(data)
        };

        protected virtual void UpdateTestMethod(TestMethod method)
        {
        }

        private static string ToTestMethodName(TestData data)
            => data.UseFullDescriptionPath
                ? string.Join(" - ", data.DescriptionPath).ToTestMethodName()
                : data.Description.ToTestMethodName();

        private TestMethodBody CreateUpdatedTestMethodBody(TestData data)
        {
            var testMethodBody = CreateTestMethodBody(data);
            UpdateTestMethodBody(testMethodBody);

            return testMethodBody;
        }

        private static TestMethodBody CreateTestMethodBody(TestData data)
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

        private TestData[] CreateUpdatedTestData()
        {
            var testData = CreateTestData();
    
            foreach (var data in testData)
                UpdateTestData(data);

            return testData;
        }
        
        private TestData[] CreateTestData() => _canonicalData.Cases.Select(CreateTestData).ToArray();

        private TestData CreateTestData(CanonicalDataCase canonicalDataCase) => new TestData(_canonicalData, canonicalDataCase);

        protected virtual void UpdateTestData(TestData data)
        {
        }
    }
}

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

        public string Render() => CreateTestClass().Render();

        protected virtual IEnumerable<string> AdditionalNamespaces => Enumerable.Empty<string>();

        protected virtual IEnumerable<string> RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
            => new[] { TemplateRenderer.RenderPartial(testMethodBody.ArrangeTemplateName, testMethodBody.ArrangeTemplateParameters) };

        protected virtual IEnumerable<string> RenderTestMethodBodyAct(TestMethodBody testMethodBody)
            => new[] { TemplateRenderer.RenderPartial(testMethodBody.ActTemplateName, testMethodBody.ActTemplateParameters) };

        protected virtual IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
            => new[] { TemplateRenderer.RenderPartial(testMethodBody.AssertTemplateName, testMethodBody.AssertTemplateParameters) };

        protected virtual IEnumerable<string> RenderAdditionalMethods() => Array.Empty<string>();

        private IEnumerable<string> GetUsingNamespaces(IEnumerable<TestData> testData)
        {
            var usingNamespaces = new HashSet<string> { "Xunit" };

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

        protected virtual TestClass CreateTestClass()
        {
            var testData = _canonicalData.Cases
                .Select(canonicalDataCase => CreateTestData(_canonicalData, canonicalDataCase))
                .ToArray();

            foreach (var data in testData)
                UpdateTestData(data);
            
            return new TestClass
            {
                ClassName = Name.ToTestClassName(),
                Methods = RenderTestMethods(testData),
                CanonicalDataVersion = _canonicalData.Version,
                UsingNamespaces = GetUsingNamespaces(testData)
            };
        }

        private string RenderTestMethod(TestData data, int index) => CreateTestMethod(data, index).Render();

        protected virtual TestMethod CreateTestMethod(TestData data, int index) => new TestMethod
        {
            Skip = index > 0,
            Name = ToTestMethodName(data),
            Body = RenderTestMethodBody(data)
        };

        private static string ToTestMethodName(TestData data)
            => data.UseFullDescriptionPath
                ? string.Join(" - ", data.DescriptionPath).ToTestMethodName()
                : data.Description.ToTestMethodName();

        private string RenderTestMethodBody(TestData data)
        {
            var testMethodBody = CreateTestMethodBody(data);
            testMethodBody.Arrange = RenderTestMethodBodyArrange(testMethodBody);
            testMethodBody.Act = RenderTestMethodBodyAct(testMethodBody);
            testMethodBody.Assert = RenderTestMethodBodyAssert(testMethodBody);

            return testMethodBody.Render();
        }

        protected virtual TestData CreateTestData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase)
            => new TestData(canonicalData, canonicalDataCase);

        protected virtual void UpdateTestData(TestData data)
        {
        }

        protected virtual TestMethodBody CreateTestMethodBody(TestData data)
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
    }
}

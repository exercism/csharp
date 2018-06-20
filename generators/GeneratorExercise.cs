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

        private IEnumerable<string> GetUsingNamespaces(IEnumerable<TestMethodBodyData> testMethodBodyData)
        {
            var usingNamespaces = new HashSet<string> { "Xunit" };

            foreach (var data in testMethodBodyData.Where(x => x.ExceptionThrown != null))
                usingNamespaces.Add(data.ExceptionThrown.Namespace);

            usingNamespaces.UnionWith(AdditionalNamespaces);

            return usingNamespaces;
        }

        private IEnumerable<string> RenderTestMethods(IEnumerable<TestMethodBodyData> testMethodBodyData) 
            => testMethodBodyData
                    .Select(RenderTestMethod)
                    .Concat(RenderAdditionalMethods())
                    .ToArray();

        protected virtual TestClass CreateTestClass()
        {
            var testMethodBodyData = _canonicalData.Cases
                .Select(canonicalDataCase => CreateTestMethodBodyData(_canonicalData, canonicalDataCase))
                .ToArray();

            foreach (var data in testMethodBodyData)
                UpdateTestMethodBodyData(data);
            
            return new TestClass
            {
                ClassName = Name.ToTestClassName(),
                Methods = RenderTestMethods(testMethodBodyData),
                CanonicalDataVersion = _canonicalData.Version,
                UsingNamespaces = GetUsingNamespaces(testMethodBodyData)
            };
        }

        private string RenderTestMethod(TestMethodBodyData data, int index) => CreateTestMethod(data, index).Render();

        protected virtual TestMethod CreateTestMethod(TestMethodBodyData data, int index) => new TestMethod
        {
            Skip = index > 0,
            Name = ToTestMethodName(data),
            Body = RenderTestMethodBody(data)
        };

        private static string ToTestMethodName(TestMethodBodyData data)
            => data.UseFullDescriptionPath
                ? string.Join(" - ", data.DescriptionPath).ToTestMethodName()
                : data.Description.ToTestMethodName();

        private string RenderTestMethodBody(TestMethodBodyData data)
        {
            var testMethodBody = CreateTestMethodBody(data);
            testMethodBody.Arrange = RenderTestMethodBodyArrange(testMethodBody);
            testMethodBody.Act = RenderTestMethodBodyAct(testMethodBody);
            testMethodBody.Assert = RenderTestMethodBodyAssert(testMethodBody);

            return testMethodBody.Render();
        }

        protected virtual TestMethodBodyData CreateTestMethodBodyData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase)
            => new TestMethodBodyData(canonicalData, canonicalDataCase);

        protected virtual void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
        }

        protected virtual TestMethodBody CreateTestMethodBody(TestMethodBodyData data)
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

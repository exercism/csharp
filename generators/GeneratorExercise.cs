using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;

namespace Generators
{
    public abstract class GeneratorExercise : Exercise
    {
        private static readonly ExerciseWriter ExerciseWriter = new ExerciseWriter();
        private CanonicalData _canonicalData;

        public override string Name => GetType().ToExerciseName();

        public void Regenerate(CanonicalData canonicalData)
        {
            _canonicalData = canonicalData;
            UpdateCanonicalData(canonicalData);

            ExerciseWriter.WriteToFile(this);
        }

        public string Render() => CreateTestClass().Render();

        protected virtual void UpdateCanonicalData(CanonicalData canonicalData)
        {
        }

        protected virtual HashSet<string> AddAdditionalNamespaces()
        {
            return new HashSet<string>();
        }

        protected virtual string RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
            => TemplateRenderer.RenderPartial(testMethodBody.ArrangeTemplateName, testMethodBody.ArrangeTemplateParameters);

        protected virtual string RenderTestMethodBodyAct(TestMethodBody testMethodBody)
            => TemplateRenderer.RenderPartial(testMethodBody.ActTemplateName, testMethodBody.ActTemplateParameters);

        protected virtual string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
            => TemplateRenderer.RenderPartial(testMethodBody.AssertTemplateName, testMethodBody.AssertTemplateParameters);

        protected virtual string[] RenderAdditionalMethods()
        {
            return new string[] { };
        }

        private HashSet<string> GetUsingNamespaces()
        {
            var usingNamespaces = new HashSet<string> { "Xunit" };

            foreach (var canonicalDataCase in _canonicalData.Cases.Where(canonicalDataCase => canonicalDataCase.ExceptionThrown != null))
                usingNamespaces.Add(canonicalDataCase.ExceptionThrown.Namespace);

            usingNamespaces.UnionWith(AddAdditionalNamespaces());

            return usingNamespaces;
        }

        private string[] RenderTestMethods() => _canonicalData.Cases.Select(RenderTestMethod).Concat(RenderAdditionalMethods()).ToArray();

        protected virtual TestClass CreateTestClass() => new TestClass
        {
            ClassName = Name.ToTestClassName(),
            Methods = RenderTestMethods(),
            CanonicalDataVersion = _canonicalData.Version,
            UsingNamespaces = GetUsingNamespaces()
        };

        private string RenderTestMethod(CanonicalDataCase canonicalDataCase, int index) => CreateTestMethod(canonicalDataCase, index).Render();

        protected virtual TestMethod CreateTestMethod(CanonicalDataCase canonicalDataCase, int index) => new TestMethod
        {
            Skip = index > 0,
            Name = ToTestMethodName(canonicalDataCase),
            Body = RenderTestMethodBody(canonicalDataCase)
        };

        private static string ToTestMethodName(CanonicalDataCase canonicalDataCase)
            => canonicalDataCase.UseFullDescriptionPath
                ? string.Join(" - ", canonicalDataCase.DescriptionPath).ToTestMethodName()
                : canonicalDataCase.Description.ToTestMethodName();

        private string RenderTestMethodBody(CanonicalDataCase canonicalDataCase)
        {
            var testMethodBody = CreateTestMethodBody(canonicalDataCase);
            testMethodBody.Arrange = RenderTestMethodBodyArrange(testMethodBody);
            testMethodBody.Act = RenderTestMethodBodyAct(testMethodBody);
            testMethodBody.Assert = RenderTestMethodBodyAssert(testMethodBody);

            return testMethodBody.Render();
        }

        protected virtual TestMethodBody CreateTestMethodBody(CanonicalDataCase canonicalDataCase)
        {
            if (canonicalDataCase.ExceptionThrown != null)
            {
                return new TestMethodBodyWithExceptionCheck(canonicalDataCase, _canonicalData);
            }

            if (canonicalDataCase.Expected is bool)
            {
                return new TestMethodBodyWithBooleanCheck(canonicalDataCase, _canonicalData);
            }

            if (canonicalDataCase.Expected is null)
            {
                return new TestMethodBodyWithNullCheck(canonicalDataCase, _canonicalData);
            }

            return new TestMethodBodyWithEqualityCheck(canonicalDataCase, _canonicalData);
        }
    }
}

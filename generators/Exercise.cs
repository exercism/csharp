using System.Collections.Generic;
using System.Linq;
using Generators.Input;
using Generators.Output;

namespace Generators
{
    public abstract class Exercise
    {
        private static readonly ExerciseWriter ExerciseWriter = new ExerciseWriter();
        
        public string Name => GetType().ToExerciseName();

        protected CanonicalData CanonicalData { get; private set; }
        
        public void Regenerate(CanonicalData canonicalData)
        {
            CanonicalData = canonicalData;
            UpdateCanonicalData(CanonicalData);

            ExerciseWriter.WriteToFile(this);
        }

        protected virtual void UpdateCanonicalData(CanonicalData canonicalData)
        {
        }

        public virtual string Render() => CreateTestClass().Render();

        protected virtual TestClass CreateTestClass() => new TestClass
        {
            ClassName = Name.ToTestClassName(),
            Methods = RenderTestMethods(),
            CanonicalDataVersion = CanonicalData.Version,
            UsingNamespaces = GetUsingNamespaces()
        };

        protected virtual HashSet<string> GetUsingNamespaces()
        {
            var usingNamespaces = new HashSet<string> { "Xunit" };

            foreach (var canonicalDataCase in CanonicalData.Cases.Where(canonicalDataCase => canonicalDataCase.ExceptionThrown != null))
                usingNamespaces.Add(canonicalDataCase.ExceptionThrown.Namespace);

            return usingNamespaces;
        }

        protected virtual string[] RenderTestMethods() => CanonicalData.Cases.Select(RenderTestMethod).ToArray();

        protected virtual string RenderTestMethod(CanonicalDataCase canonicalDataCase, int index) => CreateTestMethod(canonicalDataCase, index).Render();

        protected virtual TestMethod CreateTestMethod(CanonicalDataCase canonicalDataCase, int index) => new TestMethod
        {
            Skip = index > 0,
            Name = canonicalDataCase.Description.ToTestMethodName(),
            Body = RenderTestMethodBody(canonicalDataCase)
        };

        protected virtual string RenderTestMethodBody(CanonicalDataCase canonicalDataCase)
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
                return new TestMethodBodyWithExceptionCheck(canonicalDataCase, CanonicalData);
            }

            if (canonicalDataCase.Expected is bool)
            {
                return new TestMethodBodyWithBooleanCheck(canonicalDataCase, CanonicalData);
            }

            if (canonicalDataCase.Expected is null)
            {
                return new TestMethodBodyWithNullCheck(canonicalDataCase, CanonicalData);
            }

            return new TestMethodBodyWithEqualityCheck(canonicalDataCase, CanonicalData);
        }

        protected virtual string RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
            => TemplateRenderer.RenderPartial(testMethodBody.ArrangeTemplateName, testMethodBody.ArrangeTemplateParameters);

        protected virtual string RenderTestMethodBodyAct(TestMethodBody testMethodBody)
            => TemplateRenderer.RenderPartial(testMethodBody.ActTemplateName, testMethodBody.ActTemplateParameters);

        protected virtual string RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
            => TemplateRenderer.RenderPartial(testMethodBody.AssertTemplateName, testMethodBody.AssertTemplateParameters);
    }
}

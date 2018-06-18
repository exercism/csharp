﻿using System;
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

            foreach (var canonicalDataCase in _canonicalData.Cases)
                UpdateCanonicalDataCase(canonicalDataCase);

            ExerciseWriter.WriteToFile(this);
        }

        public string Render() => CreateTestClass().Render();

        protected virtual void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
        }

        protected virtual IEnumerable<string> AdditionalNamespaces => Enumerable.Empty<string>();

        protected virtual IEnumerable<string> RenderTestMethodBodyArrange(TestMethodBody testMethodBody)
            => new[] { TemplateRenderer.RenderPartial(testMethodBody.ArrangeTemplateName, testMethodBody.ArrangeTemplateParameters) };

        protected virtual IEnumerable<string> RenderTestMethodBodyAct(TestMethodBody testMethodBody)
            => new[] { TemplateRenderer.RenderPartial(testMethodBody.ActTemplateName, testMethodBody.ActTemplateParameters) };

        protected virtual IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
            => new[] { TemplateRenderer.RenderPartial(testMethodBody.AssertTemplateName, testMethodBody.AssertTemplateParameters) };

        protected virtual IEnumerable<string> RenderAdditionalMethods() => Array.Empty<string>();

        private IEnumerable<string> GetUsingNamespaces()
        {
            var usingNamespaces = new HashSet<string> { "Xunit" };

            foreach (var canonicalDataCase in _canonicalData.Cases.Where(canonicalDataCase => canonicalDataCase.ExceptionThrown != null))
                usingNamespaces.Add(canonicalDataCase.ExceptionThrown.Namespace);

            usingNamespaces.UnionWith(AdditionalNamespaces);

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

            switch (canonicalDataCase.Expected)
            {
                case bool _:
                    return new TestMethodBodyWithBooleanCheck(canonicalDataCase, _canonicalData);
                case null:
                    return new TestMethodBodyWithNullCheck(canonicalDataCase, _canonicalData);
                default:
                    return new TestMethodBodyWithEqualityCheck(canonicalDataCase, _canonicalData);
            }
        }
    }
}

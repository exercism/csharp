using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Input;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises
{
    public abstract class ExerciseGenerator
    {
        public string Name => GetType().ToExerciseName();
        
        protected Render Render { get; } = new Render();

        public void Regenerate(CanonicalData canonicalData)
        {   
            var testClass = CreateTestClass(canonicalData);
            var testClassOutput = new TestClassOutput(testClass);
            testClassOutput.WriteToFile();
        }

        private TestClass CreateTestClass(CanonicalData canonicalData)
        {
            var testMethods = CreateTestMethods(canonicalData);
            var testClass = new TestClass(
                exercise: canonicalData.Exercise,
                version: canonicalData.Version,
                className: canonicalData.Exercise.ToTestClassName(),
                testMethods: testMethods
            );
            UpdateTestClass(testClass);
            UpdateNamespaces(testClass.Namespaces);

            return testClass;
        }

        protected virtual void UpdateTestClass(TestClass testClass)
        {
        }

        protected virtual void UpdateNamespaces(ISet<string> namespaces)
        {
        }
        
        private TestMethod[] CreateTestMethods(CanonicalData canonicalData) =>
            canonicalData.Cases
                .Select(canonicalDataCase => CreateTestMethod(canonicalData, canonicalDataCase))
                .ToArray();

        private TestMethod CreateTestMethod(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase)
        {
            var testMethod = new TestMethod(canonicalData, canonicalDataCase);
            UpdateTestMethod(testMethod);

            return testMethod;
        }

        protected virtual void UpdateTestMethod(TestMethod testMethod)
        {
        }
    }
}

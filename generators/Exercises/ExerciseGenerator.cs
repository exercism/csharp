using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Input;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises
{
    internal abstract class ExerciseGenerator
    {
        public string Name => GetType().ToExerciseName();
        
        protected Render Render { get; } = new();

        public void Regenerate(Exercise exercise, Options options)
        {   
            var testClass = CreateTestClass(exercise);
            var testClassOutput = new TestClassOutput(testClass, options);
            testClassOutput.WriteToFile();
        }

        private TestClass CreateTestClass(Exercise exercise)
        {
            var testMethods = CreateTestMethods(exercise);
            var testClass = new TestClass(
                exercise.Name,
                exercise.Name.ToTestClassName(),
                testMethods);
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
        
        private TestMethod[] CreateTestMethods(Exercise exercise) =>
            exercise.TestCases
                .Select(canonicalDataCase => CreateTestMethod(exercise, canonicalDataCase))
                .ToArray();

        private TestMethod CreateTestMethod(Exercise exercise, TestCase testCase)
        {
            var testMethod = new TestMethod(exercise, testCase);
            UpdateTestMethod(testMethod);

            return testMethod;
        }

        protected virtual void UpdateTestMethod(TestMethod testMethod)
        {
        }
    }
}

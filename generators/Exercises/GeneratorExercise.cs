using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Input;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises
{
    public abstract class GeneratorExercise : Exercise
    {
        public override string Name => GetType().ToExerciseName();
        
        protected Render Render { get; } = new Render();

        public void Regenerate(CanonicalData canonicalData)
        {   
            var testClass = CreateTestClass(canonicalData);
            TestClassFile.Write(testClass);
        }

        private TestClass CreateTestClass(CanonicalData canonicalData)
        {
            var testMethods = CreateTestMethods(canonicalData);
            var testClass = new TestClass
            {
                Exercise = canonicalData.Exercise,
                CanonicalDataVersion = canonicalData.Version,
                ClassName = canonicalData.Exercise.ToTestClassName(),
                Methods = testMethods.Select(testMethod => testMethod.Render()).ToList(),
                Namespaces = GetNamespaces(testMethods)
            };
            UpdateTestClass(testClass);

            return testClass;
        }

        protected virtual void UpdateTestClass(TestClass testClass)
        {
        }

        private ISet<string> GetNamespaces(IEnumerable<TestMethod> testMethods)
        {
            var exceptionNamespaces = testMethods
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

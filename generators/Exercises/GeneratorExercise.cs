﻿using System.Collections;
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
        private CanonicalData _canonicalData;
        private TestData[] _testData;

        protected Render Render { get; } = new Render(); 

        public override string Name => GetType().ToExerciseName();

        public void Regenerate(CanonicalData canonicalData)
        {   
            var testClass = CreateTestClass(canonicalData);
            TestClassFile.Write(testClass);
        }

        private TestClass CreateTestClass()
        {
            var testClass = new TestClass
            {
                Exercise = _canonicalData.Exercise,
                CanonicalDataVersion = _canonicalData.Version,
                ClassName = _canonicalData.Exercise.ToTestClassName(),
                Methods = GetMethods(),
                Namespaces = GetNamespaces()
            };

            UpdateTestClass(testClass);
            return testClass;
        }

        protected virtual void UpdateTestClass(TestClass @class)
        {
        }

        private ISet<string> GetNamespaces()
        {
            var exceptionNamespaces = _testData
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

        private IList<string> GetMethods()
        {
            var renderedMethods = new List<string>();

            foreach (var data in _testData)
            {
                UpdateTestData(data);

                var method = CreateTestMethod(data);
                UpdateTestMethod(method);
                
                renderedMethods.Add(method.Render());
            }

            return renderedMethods;
        }

        private static TestMethod CreateTestMethod(TestData data)
        {
            if (data.ExceptionThrown != null)
                return new TestMethodWithExceptionAssertion(data);

            switch (data.Expected)
            {
                case bool _:
                    return new TestMethodWithBooleanAssertion(data);
                case null:
                    return new TestMethodWithNullAssertion(data);
                default:
                    if (UseEmptyAssertion(data))
                        return new TestMethodWithEmptyAssertion(data);
                        
                    return new TestMethodWithEqualityAssertion(data);
            }
        }

        protected virtual void UpdateTestMethod(TestMethod method)
        {
        }

        private TestData[] CreateTestData() => 
            _canonicalData.Cases
                .Select(canonicalDataCase => new TestData(_canonicalData, canonicalDataCase))
                .ToArray();

        protected virtual void UpdateTestData(TestData data)
        {
        }

        private static bool UseEmptyAssertion(TestData data)
        {   
            if (data.Expected is string)
                return false;
            
            return data.Expected is IEnumerable enumerable && enumerable.GetEnumerator().MoveNext() == false;
        }
    }
}

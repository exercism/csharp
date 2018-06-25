﻿using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Helpers;
using Exercism.CSharp.Input;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises
{
    public abstract class GeneratorExercise : Exercise
    {
        private CanonicalData _canonicalData;
        private TestData[] _testData;

        public override string Name => GetType().ToExerciseName();

        public void Regenerate(CanonicalData canonicalData)
        {
            _canonicalData = canonicalData;
            _testData = CreateTestData();

            var testClass = CreateTestClass();
            var testClassFile = new TestClassFile(testClass);
            testClassFile.Write();
        }

        private TestClass CreateTestClass()
        {
            var testClass = new TestClass
            {
                Exercise = _canonicalData.Exercise,
                CanonicalDataVersion = _canonicalData.Version,
                ClassName = _canonicalData.Exercise.ToTestClassName(),
                Namespaces = GetNamespaces(),
                Methods = RenderTestMethods()
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

        private IList<string> RenderTestMethods() 
            => CreateTestMethods()
                .Select(testMethod => testMethod.Render())
                .ToList();

        private IEnumerable<TestMethod> CreateTestMethods()
        {
            var testMethods = _testData
                .Select(CreateTestMethod)
                .ToArray();
    
            Array.ForEach(testMethods, UpdateTestMethod);
            return testMethods;
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
                    if ((data.Expected as object).IsEmptyEnumerable())
                        return new TestMethodWithEmptyAssertion(data);
                        
                    return new TestMethodWithEqualityAssertion(data);
            }
        }

        protected virtual void UpdateTestMethod(TestMethod method)
        {
        }

        private TestData[] CreateTestData()
        {
            var testData = _canonicalData.Cases
                .Select(CreateTestData)
                .ToArray();
    
            Array.ForEach(testData, UpdateTestData);
            return testData;
        }

        private TestData CreateTestData(CanonicalDataCase canonicalDataCase) 
            => new TestData(_canonicalData, canonicalDataCase);

        protected virtual void UpdateTestData(TestData data)
        {
        }
    }
}

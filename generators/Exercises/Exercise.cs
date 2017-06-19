﻿using System.Linq;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public abstract class Exercise
    {
        protected static readonly BooleanTestMethodGenerator BooleanTestMethod = new BooleanTestMethodGenerator();
        protected static readonly EqualityTestMethodGenerator EqualityTestMethod = new EqualityTestMethodGenerator();
        protected static readonly ExceptionTestMethodGenerator ExceptionTestMethod = new ExceptionTestMethodGenerator();

        protected Exercise()
        {
            Name = GetType().Name.Kebaberize();
            CanonicalData = CanonicalDataParser.Parse(Name);
            Options = new TestMethodOptions();
        }

        public string Name { get; }
        public CanonicalData CanonicalData { get; }
        public TestMethodOptions Options { get; }

        public TestClass CreateTestClass()
        {
            var testClass = new TestClass
            {
                ClassName = Name.ToTestClassName(),
                TestMethods = CanonicalData.Cases.Select(CreateTestMethod).ToArray(),
                CanonicalDataVersion = CanonicalData.Version
            };

            AddTestMethodUsingNamespaces(testClass);

            return testClass;
        }

        private static void AddTestMethodUsingNamespaces(TestClass testClass)
        {
            foreach (var testMethod in testClass.TestMethods)
                testClass.UsingNamespaces.UnionWith(testMethod.UsingNamespaces);
        }

        protected abstract TestMethod CreateTestMethod(TestMethodData testMethodData);

        private TestMethod CreateTestMethod(CanonicalDataCase canonicalDataCase) => CreateTestMethod(CreateTestMethodData(canonicalDataCase));

        private TestMethodData CreateTestMethodData(CanonicalDataCase canonicalDataCase) => new TestMethodData
        {
            CanonicalData = CanonicalData,
            CanonicalDataCase = canonicalDataCase,
            Options = Options
        };
    }
}
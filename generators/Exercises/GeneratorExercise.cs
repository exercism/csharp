﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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

        public bool IsOutdated(CanonicalData canonicalData)
        {
            var filePath = FilePathHelper.TestClassFilePath(Name, Name.ToTestClassName());
            var firsLine = File.ReadLines(filePath).First();

            if (firsLine.StartsWith("//"))
            {
                var currentTestversion = Regex.Match(firsLine, @"[\d\.]{5}").Value;
                return currentTestversion != canonicalData.Version;
            }

            return false;
        }

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

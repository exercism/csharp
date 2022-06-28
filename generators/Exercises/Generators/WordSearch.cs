﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class WordSearch : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForTested = true;
            testMethod.UseVariableForExpected = true;
            testMethod.UseVariablesForConstructorParameters = true;
            
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.ConstructorInputParameters = new[] { "grid" };

            testMethod.Input["grid"] = new MultiLineString(testMethod.Input["grid"]);
            testMethod.Expected = ConvertExpected(testMethod);

            testMethod.Assert = RenderAssert(testMethod);
        }

        private static Dictionary<string, ((int, int), (int, int))?> ConvertExpected(TestMethod testMethod) 
            => ((IDictionary<string, dynamic>)testMethod.Expected!).ToDictionary(kv => kv.Key, kv => (((int, int), (int, int))?)ConvertToPosition(kv.Value));

        private string RenderAssert(TestMethod testMethod)
        {
            var assert = new StringBuilder();

            foreach (var kv in testMethod.Expected!)
                assert.AppendLine(RenderAssertForSearchWord(kv.Key));

            return assert.ToString();
        }

        private string RenderAssertForSearchWord(string word) 
            => Render.AssertEqual($"expected[\"{word}\"]", $"actual[\"{word}\"]");

        private static ((int, int), (int, int))? ConvertToPosition(dynamic position)
        {
            if (position == null)
                return null;

            return (ConvertToCoordinate(position["start"]), ConvertToCoordinate(position["end"]));
        }

        private static (int, int) ConvertToCoordinate(dynamic coordinate)
            => (Convert.ToInt32(coordinate["column"]), Convert.ToInt32(coordinate["row"]));

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(ValueTuple<int, int>).Namespace!);
            namespaces.Add(typeof(Dictionary<string, ValueTuple<int, int>>).Namespace!);
        }
    }
}
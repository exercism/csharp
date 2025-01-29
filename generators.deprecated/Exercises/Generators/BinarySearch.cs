﻿using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators;

internal class BinarySearch : ExerciseGenerator
{
    protected override void UpdateTestMethod(TestMethod testMethod)
    {
            if (testMethod.Input["array"] is JArray)
                testMethod.Input["array"] = Array.Empty<int>();

            testMethod.UseVariablesForInput = true;

            if (testMethod.ExpectedIsError)
            {
                testMethod.Expected = -1;
            }
        }

    protected override void UpdateNamespaces(ISet<string> namespaces) => namespaces.Add(typeof(Array).Namespace!);
}
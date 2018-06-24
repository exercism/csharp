﻿using System;
using System.Collections.Generic;
using Generators.Helpers;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class BinarySearch : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Input["array"] = ConvertHelper.ToArray<int>(data.Input["array"]);
            data.UseVariablesForConstructorParameters = true;
            data.SetConstructorInputParameters("array");
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(Array).Namespace);
        }
    }
}
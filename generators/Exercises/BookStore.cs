﻿using System;
using System.Collections.Generic;
using Generators.Input;

namespace Generators.Exercises
{
    public class BookStore : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Expected = canonicalDataCase.Expected / 100.0f;
            canonicalDataCase.Input["basket"] = ConvertHelper.ToArray<int>(canonicalDataCase.Input["basket"]);
            canonicalDataCase.SetInputParameters("basket");
            canonicalDataCase.UseVariablesForInput = true;
        }

        protected override IEnumerable<string> AdditionalNamespaces => new[] { typeof(Array).Namespace };
    }
}
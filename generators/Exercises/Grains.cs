﻿using System;
using Generators.Input;

namespace Generators.Exercises
{
    public class Grains : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            if (ShouldThrowException(canonicalDataCase.Expected))
                canonicalDataCase.ExceptionThrown = typeof(ArgumentOutOfRangeException);
            else
                canonicalDataCase.Expected = (ulong)canonicalDataCase.Expected;
        }

        private static bool ShouldThrowException(dynamic value) => value is int i && i == -1;
    }
}
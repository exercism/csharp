﻿using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators;

internal class MatchingBrackets : ExerciseGenerator
{
    protected override void UpdateTestMethod(TestMethod testMethod)
    {
            testMethod.Input["value"] = testMethod.Input["value"].Replace("\\", "\\\\");
            testMethod.UseVariablesForInput = true;
        }
}
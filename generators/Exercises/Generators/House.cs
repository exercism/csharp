﻿using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators;

internal class House : ExerciseGenerator
{
    protected override void UpdateTestMethod(TestMethod testMethod)
    {
            testMethod.UseVariableForExpected = true;
            testMethod.Expected = new MultiLineString(testMethod.Expected);

            if (testMethod.Input["startVerse"] == testMethod.Input["endVerse"])
            {
                testMethod.InputParameters = new[] { "startVerse" };
            }
        }
}
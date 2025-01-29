﻿using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators;

internal class SpiralMatrix : ExerciseGenerator
{
    protected override void UpdateTestMethod(TestMethod testMethod)
    {
            testMethod.TestedMethod = "GetMatrix";
            testMethod.UseVariableForExpected = true;
            testMethod.Expected = ConvertExpected(testMethod.Expected);
        }

    private static int[,] ConvertExpected(JToken jArray) => jArray.ToObject<int[,]>()!;
}
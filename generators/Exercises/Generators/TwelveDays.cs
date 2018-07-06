﻿using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class TwelveDays : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariableForExpected = true;
            testMethod.Expected = new MultiLineString(testMethod.Expected);

            if (testMethod.Input["startVerse"] == testMethod.Input["endVerse"])
            {
                testMethod.SetInputParameters("startVerse");
            }
        }
    }
}

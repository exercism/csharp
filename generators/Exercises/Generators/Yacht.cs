﻿using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Yacht : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedClass = "YachtGame";
            testMethod.Input["category"] = Render.Enum("YachtCategory", testMethod.Input["category"]);
        }
    }
}

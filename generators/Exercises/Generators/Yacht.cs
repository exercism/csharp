﻿using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Yacht : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedClass = "YachtGame";
            data.Input["category"] = Render.Enum("YachtCategory", data.Input["category"]);
        }
    }
}

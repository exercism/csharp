﻿using Generators.Output;

namespace Generators.Exercises
{
    public class Matrix : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Properties["string"] = data.Properties["input"]["string"];
            data.SetConstructorInputParameters("string");
            data.Properties["index"] = data.Properties["input"]["index"];
            data.SetInputParameters("index");
        }
    }
}

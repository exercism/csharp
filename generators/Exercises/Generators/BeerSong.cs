﻿using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    public class BeerSong : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariableForExpected = true;
            data.Expected = new MultiLineString(data.Expected);
        }
    }
}
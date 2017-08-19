﻿using Generators.Input;

namespace Generators.Exercises
{
    public class House : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.UseVariableForExpected = true;
                canonicalDataCase.Expected = canonicalDataCase.Expected.ConvertMultiLineString();
            }
        }
    }
}
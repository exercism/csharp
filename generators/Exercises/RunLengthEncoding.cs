﻿using System.Collections.Generic;
using Generators.Input;
using Generators.Output;

namespace Generators.Exercises
{
    public class RunLengthEncoding : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            canonicalDataCase.Description = $"{canonicalDataCase.Property} {canonicalDataCase.Description}";
        }

        protected override IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            return testMethodBody.Data.CanonicalDataCase.Property == "consistency" 
                ? RenderConsistencyToAssert(testMethodBody) 
                : base.RenderTestMethodBodyAssert(testMethodBody);
        }

        private static IEnumerable<string> RenderConsistencyToAssert(TestMethodBody testMethodBody)
        {
            const string template = @"Assert.Equal(""{{ExpectedOutput}}"", {{ExerciseName}}.Decode({{ExerciseName}}.Encode(""{{ExpectedOutput}}"")));";

            var templateParameters = new
            {
                ExpectedOutput = testMethodBody.Data.CanonicalDataCase.Expected,
                ExerciseName = testMethodBody.Data.CanonicalDataCase.Exercise.ToTestedClassName()
            };

            return new[] { TemplateRenderer.RenderInline(template, templateParameters) };
        }
    }
}
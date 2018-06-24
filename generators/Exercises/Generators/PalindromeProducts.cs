using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class PalindromeProducts : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            if (data.Expected.ContainsKey("error"))
            {
                data.ExceptionThrown = typeof(ArgumentException);
            }
            else
            {
                data.UseVariableForTested = true;
                data.UseVariableForExpected = true;
                data.Expected = (data.Expected["value"], FormatCoordinates(data.Expected["factors"]));
            }
        }
        
        protected override void UpdateTestMethodBody(TestMethodBody body)
        {
            body.Assert = RenderTestMethodBodyAssert(body);
        }

        private static IEnumerable<string> RenderTestMethodBodyAssert(TestMethodBody testMethodBody)
        {
            if (testMethodBody.Data.ExceptionThrown != null)
            {
                return testMethodBody.Assert;
            }

            return new[]
            {
                "Assert.Equal(expected.Item1, actual.Item1);",
                "Assert.Equal(expected.Item2, actual.Item2);"
            };
        }

        private static string FormatCoordinates(dynamic coordinates)
            => ValueFormatter.Format((coordinates as JArray).Select(coordinate => (coordinate[0].ToObject<int>(), coordinate[1].ToObject<int>())).ToArray());
    }
}
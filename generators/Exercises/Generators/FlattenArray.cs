using System.Linq;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class FlattenArray : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForExpected = true;

            var renderedArray = Render.ArrayMultiLine(ConvertToObjectArray(testMethod.Input["array"]));
            testMethod.Input["array"] = new UnescapedValue(renderedArray.Replace("new[]", "new object[]"));
        }

        private static dynamic ConvertToObjectArray(dynamic input)
        {   
            if (input is int[] ints)
                return ints;

            if (input is JArray jArray)
                return jArray.Cast<object>().Select(ConvertToObjectArray).ToArray();

            if (input is JToken jToken && jToken.Type == JTokenType.Null)
                return null;

            return input;
        }
    }
}
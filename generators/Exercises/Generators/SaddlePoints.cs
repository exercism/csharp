using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class SaddlePoints : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethodType = TestedMethodType.Instance;
            data.TestedMethod = "Calculate";
            data.SetConstructorInputParameters("matrix");
            data.UseVariablesForConstructorParameters = true;
            data.UseVariablesForInput = true;
            data.UseVariableForTested = true;
            data.UseVariableForExpected = true;

            data.Input["matrix"] = ToMultiDimensionalArray(data.Input["matrix"]);

            if (data.Expected is Array array)
            {
                data.Expected = ToTupleCollection(array);
            }
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(string).Namespace);
        }

        private static dynamic ToMultiDimensionalArray(dynamic array)
        {
            var jArray = (JArray)array;
            if (jArray.Count == 1 && ((JArray)jArray[0]).Count == 0)
                return new int[0, 0];

            return jArray.ToObject<int[,]>();
        }

        private static IEnumerable<Tuple<string, object>> ToTupleCollection(Array array)
        {
            for (var x = 0; x < array.GetLength(0); x++)
            {
                var current = array.GetValue(x) as Dictionary<string, object>;
                yield return new Tuple<string, object>(current["row"].ToString(), current["column"].ToString());
            }
        }
    }
}

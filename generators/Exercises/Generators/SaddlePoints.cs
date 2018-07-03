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

        private static dynamic ToMultiDimensionalArray(JArray jArray) => jArray.ToObject<int[,]>();

        private static ValueTuple<string, object>[] ToTupleCollection(Array array)
        {
            var tuples = new List<ValueTuple<string, object>>();
            
            for (var x = 0; x < array.GetLength(0); x++)
            {
                var current = (Dictionary<string, object>)array.GetValue(x);
                tuples.Add(new ValueTuple<string, object>(current["row"].ToString(), current["column"].ToString()));
            }

            return tuples.ToArray();
        }
    }
}

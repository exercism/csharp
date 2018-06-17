using System;
using System.Collections.Generic;
using Generators.Input;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class SaddlePoints : GeneratorExercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.TestedMethodType = TestedMethodType.Instance;
                canonicalDataCase.Property = "Calculate";
                canonicalDataCase.SetConstructorInputParameters("matrix");
                canonicalDataCase.UseVariablesForConstructorParameters = true;
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForTested = true;
                canonicalDataCase.UseVariableForExpected = true;

                canonicalDataCase.Input["matrix"] = ToMultiDimensionalArray(canonicalDataCase.Input["matrix"]);

                var array = canonicalDataCase.Expected as Array;

                if (array != null)
                {
                    canonicalDataCase.Expected = ToTupleCollection(array);
                }
            }
        }

        protected override IEnumerable<string> AdditionalNamespaces() => new[] { typeof(System.String).Namespace };

        private static dynamic ToMultiDimensionalArray(dynamic array)
        {
            var jArray = (JArray)array;
            if (jArray.Count == 1 && ((JArray)jArray[0]).Count == 0)
                return new int[0, 0];

            return jArray.ToObject<int[,]>();
        }

        private IEnumerable<Tuple<string, object>> ToTupleCollection(Array array)
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                var current = ((Array)array).GetValue(x) as Dictionary<string, object>;
                yield return new Tuple<string, object>(current["row"].ToString(), current["column"].ToString());
            }
        }
    }
}

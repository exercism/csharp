using System;
using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Newtonsoft.Json.Linq;

namespace Exercism.CSharp.Exercises.Generators
{
    public class SaddlePoints : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.TestedMethod = "Calculate";
            testMethod.ConstructorInputParameters = new[] { "matrix" };

            testMethod.UseVariablesForConstructorParameters = true;
            testMethod.UseVariablesForInput = true;
            testMethod.UseVariableForTested = true;
            testMethod.UseVariableForExpected = true;

            testMethod.Input["matrix"] = ToMultiDimensionalArray(testMethod.Input["matrix"]);

            if (testMethod.Expected is Array array)
            {
                testMethod.Expected = ToTupleCollection(array);
            }
        }

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(string).Namespace);
        }

        private static dynamic ToMultiDimensionalArray(JToken jArray) => jArray.ToObject<int[,]>();

        private static (string, object)[] ToTupleCollection(Array array)
        {
            var tuples = new List<(string, object)>();
            
            for (var x = 0; x < array.GetLength(0); x++)
            {
                var current = (Dictionary<string, object>)array.GetValue(x);
                tuples.Add((current["row"].ToString(), current["column"].ToString()));
            }

            return tuples.OrderBy(x => x).ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Sublist : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Input["listOne"] = ConvertToList(testMethod.Input["listOne"]);
            testMethod.Input["listTwo"] = ConvertToList(testMethod.Input["listTwo"]);

            testMethod.TestedMethod = "Classify";
            testMethod.Expected = Render.Enum("SublistType", testMethod.Expected);
        }

        private static List<int> ConvertToList(dynamic value) => new List<int>(value as int[] ?? Array.Empty<int>());

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(IList<int>).Namespace);
        }
    }
}


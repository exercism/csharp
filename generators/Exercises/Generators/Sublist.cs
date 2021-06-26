using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Sublist : ExerciseGenerator
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.Input["listOne"] = ConvertToList(testMethod.Input["listOne"]);
            testMethod.Input["listTwo"] = ConvertToList(testMethod.Input["listTwo"]);

            testMethod.TestedMethod = "Classify";
            testMethod.Expected = Render.Enum("SublistType", testMethod.Expected);
        }

        private static List<int> ConvertToList(dynamic value) => new(value as int[] ?? Array.Empty<int>());

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(IList<int>).Namespace);
        }
    }
}


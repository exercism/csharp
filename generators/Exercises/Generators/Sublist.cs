using System;
using System.Collections.Generic;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Sublist : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.Input["listOne"] = ConvertToList(data.Input["listOne"]);
            data.Input["listTwo"] = ConvertToList(data.Input["listTwo"]);

            data.TestedMethod = "Classify";
            data.Expected = Render.Enum("SublistType", data.Expected);
        }

        private static List<int> ConvertToList(dynamic value) => new List<int>(value as int[] ?? Array.Empty<int>());

        protected override void UpdateNamespaces(ISet<string> namespaces)
        {
            namespaces.Add(typeof(IList<int>).Namespace);
        }
    }
}


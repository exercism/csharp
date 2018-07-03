using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class KindergartenGarden : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.TestedMethodType = TestedMethodType.Instance;
            data.UseFullDescriptionPath = true;

            if (data.Input.ContainsKey("students"))
                data.SetConstructorInputParameters("diagram", "students");
            else
                data.SetConstructorInputParameters("diagram");

            data.Expected = ConvertExpected(data.Expected);
        }

        private UnescapedValue[] ConvertExpected(IEnumerable<string> plants) 
            => plants
                .Select(plant => Render.Enum("Plant", plant))
                .ToArray();
    }
}
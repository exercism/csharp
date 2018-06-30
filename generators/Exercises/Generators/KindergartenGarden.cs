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

            var plants = (IEnumerable<string>)data.Expected;
            data.Expected = plants
                .Select(plant => Render.Enum("Plant", plant))
                .ToArray();
        }
    }
}
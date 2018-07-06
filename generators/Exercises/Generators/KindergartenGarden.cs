using System.Collections.Generic;
using System.Linq;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class KindergartenGarden : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.TestMethodName = testMethod.TestMethodNameWithPath;

            if (testMethod.Input.ContainsKey("students"))
                testMethod.SetConstructorInputParameters("diagram", "students");
            else
                testMethod.SetConstructorInputParameters("diagram");

            testMethod.Expected = ConvertExpected(testMethod.Expected);
        }

        private UnescapedValue[] ConvertExpected(IEnumerable<string> plants) 
            => plants
                .Select(plant => Render.Enum("Plant", plant))
                .ToArray();
    }
}
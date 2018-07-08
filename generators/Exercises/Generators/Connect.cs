using DotLiquid.Exceptions;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Connect : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForConstructorParameters = true;
            testMethod.ConstructorInputParameters = new[] { "board" };
            testMethod.TestedMethodType = TestedMethodType.InstanceMethod;
            testMethod.TestedMethod = "Result";
            
            testMethod.Input["board"] = new UnescapedValue(Render.ArrayMultiLine(testMethod.Input["board"]));
            testMethod.Expected = ConvertExpected(testMethod);
        }

        private UnescapedValue ConvertExpected(TestMethod testMethod)
        {
            switch (testMethod.Expected)
            {
                case "X":
                    return Render.Enum("ConnectWinner", "Black");
                case "O":
                    return Render.Enum("ConnectWinner", "White");
                case "":
                    return Render.Enum("ConnectWinner", "None");
                default:
                    throw new ArgumentException("Unsupported expected value");
            }
        }
    }
}

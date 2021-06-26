using DotLiquid.Exceptions;
using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    internal class Connect : ExerciseGenerator
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

        private UnescapedValue ConvertExpected(TestMethod testMethod) =>
            testMethod.Expected switch
            {
                "X" => Render.Enum("ConnectWinner", "Black"),
                "O" => Render.Enum("ConnectWinner", "White"),
                "" => Render.Enum("ConnectWinner", "None"),
                _ => throw new ArgumentException("Unsupported expected value")
            };
    }
}

using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Connect : GeneratorExercise
    {
        protected override void UpdateTestMethod(TestMethod testMethod)
        {
            testMethod.UseVariablesForConstructorParameters = true;
            testMethod.SetConstructorInputParameters("board");
            testMethod.TestedMethod = "Result";
            
            testMethod.Input["board"] = new UnescapedValue(Render.ArrayMultiLine(testMethod.Input["board"]));

            switch (testMethod.Expected)
            {
                case "X":
                    testMethod.Expected = Render.Enum("ConnectWinner", "Black");
                    break;
                case "O":
                    testMethod.Expected = Render.Enum("ConnectWinner", "White");
                    break;
                case "":
                    testMethod.Expected = Render.Enum("ConnectWinner", "None");
                    break;
            }
        }
    }
}

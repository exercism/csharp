using Exercism.CSharp.Output;
using Exercism.CSharp.Output.Rendering;

namespace Exercism.CSharp.Exercises.Generators
{
    public class Connect : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            data.UseVariablesForConstructorParameters = true;
            data.SetConstructorInputParameters("board");
            data.TestedMethod = "Result";

            switch (data.Expected)
            {
                case "X":
                    data.Expected = new UnescapedValue("ConnectWinner.Black");
                    break;
                case "O":
                    data.Expected = new UnescapedValue("ConnectWinner.White");
                    break;
                case "":
                    data.Expected = new UnescapedValue("ConnectWinner.None");
                    break;
            }
        }
    }
}

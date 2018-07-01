using Exercism.CSharp.Output;

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
                    data.Expected = Render.Enum("ConnectWinner", "Black");
                    break;
                case "O":
                    data.Expected = Render.Enum("ConnectWinner", "White");
                    break;
                case "":
                    data.Expected = Render.Enum("ConnectWinner", "None");
                    break;
            }
        }
    }
}

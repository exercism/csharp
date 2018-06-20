using Generators.Output;

namespace Generators.Exercises
{
    public class DifferenceOfSquares : GeneratorExercise
    {
        protected override void UpdateTestMethodBodyData(TestMethodBodyData data)
        {
            switch (data.Property)
            {
                case "squareOfSum":
                    data.Property = "CalculateSquareOfSum";
                    break;
                case "sumOfSquares":
                    data.Property = "CalculateSumOfSquares";
                    break;
                case "differenceOfSquares":
                    data.Property = "CalculateDifferenceOfSquares";
                    break;
            }
        }
    }
}

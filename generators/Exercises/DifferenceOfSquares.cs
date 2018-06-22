using Generators.Output;

namespace Generators.Exercises
{
    public class DifferenceOfSquares : GeneratorExercise
    {
        protected override void UpdateTestData(TestData data)
        {
            switch (data.Property)
            {
                case "squareOfSum":
                    data.TestedMethod = "CalculateSquareOfSum";
                    break;
                case "sumOfSquares":
                    data.TestedMethod = "CalculateSumOfSquares";
                    break;
                case "differenceOfSquares":
                    data.TestedMethod = "CalculateDifferenceOfSquares";
                    break;
            }
        }
    }
}

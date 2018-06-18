using Generators.Input;

namespace Generators.Exercises
{
    public class DifferenceOfSquares : GeneratorExercise
    {
        protected override void UpdateCanonicalDataCase(CanonicalDataCase canonicalDataCase)
        {
            switch(canonicalDataCase.Property)
            {
                case "squareOfSum":
                    canonicalDataCase.Property = "CalculateSquareOfSum";
                    break;
                case "sumOfSquares":
                    canonicalDataCase.Property = "CalculateSumOfSquares";
                    break;
                case "differenceOfSquares":
                    canonicalDataCase.Property = "CalculateDifferenceOfSquares";
                    break;
            }
        }
    }
}

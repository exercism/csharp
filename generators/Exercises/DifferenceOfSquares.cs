using Generators.Input;

namespace Generators.Exercises
{
    public class DifferenceOfSquares : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
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

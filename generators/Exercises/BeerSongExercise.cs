using Generators.Data;
using Generators.Methods;

namespace Generators.Exercises
{
    public class BeerSongExercise : EqualityExercise
    {
        public BeerSongExercise() : base("beer-song")
        {
        }

        protected override TestMethodData CreateTestMethodData(CanonicalData canonicalData, CanonicalDataCase canonicalDataCase, int index)
        {
            var testMethodData = base.CreateTestMethodData(canonicalData, canonicalDataCase, index);

            testMethodData.Options.UseVariableForExpected = true;
            testMethodData.Options.FormatExpected = true;

            testMethodData.CanonicalDataCase.Expected = CanonicalDataValue.ExpectedToMultiLineString(testMethodData.CanonicalDataCase.Expected);

            if (testMethodData.CanonicalDataCase.Property == "verse")
                testMethodData.Options.InputProperty = "number";
            else
                testMethodData.CanonicalDataCase.Input = new[] 
                { 
                    testMethodData.CanonicalDataCase.Data["beginning"], 
                    testMethodData.CanonicalDataCase.Data["end"]
                };
                
            return testMethodData;
        }
    }
}
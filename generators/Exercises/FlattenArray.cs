using Generators.Input;
using Generators.Output;
using System.Collections;

namespace Generators.Exercises
{
    public class FlattenArray : Exercise
    {
    	protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var canonicalDataCase in canonicalData.Cases)
            {
                canonicalDataCase.UseVariablesForInput = true;
                canonicalDataCase.UseVariableForExpected = true;

                string stringInput = canonicalDataCase.Properties["input"].ToString();

                // We skip reformatting of pure int arrays.
                if(stringInput.Contains("System.Int32"))
                    continue;

                string properInput = ToProperObjArray(stringInput);

                canonicalDataCase.Properties["input"] = new UnescapedValue(properInput);
            }
        }

        private string ToProperObjArray(string input) 
        {
            string res = input.Replace("System.Int32", "");
            res = res.Replace("]", "}");
            res = res.Replace("[", "new object[] {");
            return res;
        }
    }
}
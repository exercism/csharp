using System;
using Generators.Input;
using Generators.Output;
using Humanizer;

namespace Generators.Exercises
{
    public class Yacht: GeneratorExercise
    {
	protected override void UpdateCanonicalData(CanonicalData canonicalData)
	{
            // TODO
	   //canonicalData.Exercise = "yacht-game";
	   foreach (var canonicalDataCase in canonicalData.Cases)
	   {				
              var input = canonicalDataCase.Properties["input"] as System.Collections.Generic.Dictionary<string,object>;
	            input["category"] = new UnescapedValue($"YachtCategory.{input["category"].ToString().Dehumanize()}");
	   }
	}
    }
}

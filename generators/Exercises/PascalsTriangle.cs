using System;
using Generators.Input;
using Generators.Output;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class PascalsTriangle : Exercise
    {
        protected override void UpdateCanonicalData(CanonicalData canonicalData)
        {
            foreach (var dataCases in canonicalData.Cases)
            {
                dataCases.UseVariableForExpected = true;
                dataCases.Property = "calculate";
                if (!(dataCases.Expected is JArray))
                    dataCases.ExceptionThrown = typeof(ArgumentOutOfRangeException);
                if (dataCases.Properties["count"] == null)
                    dataCases.Properties["count"] = -1;
            }
        }
    }
}
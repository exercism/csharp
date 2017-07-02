using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Generators.Exercises
{
    public class BookStore : Exercise
    {
        public BookStore()
        {
            foreach (var canonicalDataCase in CanonicalData.Cases)
            {
                canonicalDataCase.Input = new Dictionary<string, object>
                {
                    ["input"] = ((JArray)canonicalDataCase.Input["basket"]).Values<int>()
                };
                canonicalDataCase.UseInputParameters = true;
            }
        }
    }
}